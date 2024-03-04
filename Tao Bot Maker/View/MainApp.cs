using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using LogFramework;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using BlueMystic;
using Tao_Bot_Maker.Model;
using Log = Tao_Bot_Maker.Controller.Log;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Tao_Bot_Maker
{

    public partial class MainApp : Form
    {
        //DLL Drawing
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        //Private Members
        private DarkModeCS DM = null;
        private SequenceController sequenceController;
        private Bot bot;
        private HotKeyController hotkeyStartBot;
        private HotKeyController hotkeyStopBot;
        private bool isSequenceSaved;
        private int lastIndexSequenceLoaded;
        private string loadedSequenceName;

        public string LoadedSequenceName
        {
            get { return loadedSequenceName; }
            set { loadedSequenceName = value.ToString(); } 
        }

        public MainApp()
        {
            SetProcessDPIAware();
            InitializeComponent();

            //Apply theme
            ApplyTheme();

            //Set application language
            SetLanguageUI();

            //Apply language to controls
            Localization();

            bot = new Bot(this);

            hotkeyStartBot = new HotKeyController(
                SettingsController.GetHotkeyModifierStartBot(),
                SettingsController.GetHotkeyKeyStartBot(), 
                this);
            hotkeyStartBot.Register();

            hotkeyStopBot = new HotKeyController(
                SettingsController.GetHotkeyModifierStopBot(),
                SettingsController.GetHotkeyKeyStopBot(),
                this);
            hotkeyStopBot.Register();

            NewSequence();


            Log.Write(Properties.strings.log_ApplicationInitialized, listBoxLog, LogFramework.Log.INFO);
        }

        //------------------------------------------------------------
        //    METHODS
        //------------------------------------------------------------
        private void SetLanguageUI()
        {
            string message = Properties.strings.log_SettingLanguage;
            string language = SettingsController.GetLanguage();
            switch (language)
            {
                case "EN":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    language = "EN";
                    break;
                case "FR":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
                    language = "FR";
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;
            }
            Log.Write(message + language, LogFramework.Log.TRACE);
        }
        private void Localization()
        {            
            tsm_File.Text = Properties.strings.tsm_File;
            tsm_File_New.Text = Properties.strings.tsm_File_New;
            tsm_File_Save.Text = Properties.strings.tsm_File_Save;
            tsm_File_SaveAs.Text = Properties.strings.tsm_File_SaveAs;
            tsm_File_Exit.Text = Properties.strings.tsm_File_Exit;

            tsm_Bot.Text = Properties.strings.tsm_Bot;
            tsm_Bot_Start.Text = Properties.strings.tsm_Bot_Start;
            tsm_Bot_Stop.Text = Properties.strings.tsm_Bot_Stop;

            tsm_Settings.Text = Properties.strings.tsm_Settings;
            tsm_Settings_Language.Text = Properties.strings.tsm_Settings_Language;
            tsm_Settings_Hotkeys.Text = Properties.strings.tsm_Settings_Shortcuts;
            tsm_Settings_Theme.Text = Properties.strings.tsm_Settings_Theme;
            tsm_Settings_Logs.Text = Properties.strings.tsm_Settings_SaveLogs;

            tsm_About.Text = Properties.strings.tsm_About;

            toolTip.SetToolTip(this.button_AddAction, Properties.strings.toolTip_Button_AddAction);
            toolTip.SetToolTip(this.button_EditAction, Properties.strings.toolTip_Button_EditAction);
            toolTip.SetToolTip(this.button_DeleteSelectedAction, Properties.strings.toolTip_Button_DeleteAction);
            toolTip.SetToolTip(this.button_StartBot, Properties.strings.toolTip_Button_StartBot);
            toolTip.SetToolTip(this.button_StopBot, Properties.strings.toolTip_Button_StopBot);
            toolTip.SetToolTip(this.button_SaveSequence, Properties.strings.toolTip_Button_SaveSequence);
            toolTip.SetToolTip(this.button_DeleteSequence, Properties.strings.toolTip_Button_DeleteSequence);

            Log.Write(Properties.strings.log_LocalizationUpdated, LogFramework.Log.TRACE);
        }
        private void UpdateAllButtonState()
        {
            //Edit Button
            UpdateButtonStateEdit();

            //Delete Button
            UpdateButtonStateDeleteAction();

            //Enable Bot Start or Stop
            UpdateButtonStateBot();

            //Delete sequence button
            UpdateButtonStateDeleteSequence();

            //Check SaveLogs menu
            UpdateButtonStateSaveLogs();

            //Language
            UpdateButtonStateLanguage();

            //Theme
            UpdateButtonStateTheme();

            //Hotkey displayed in TSM
            UpdateButtonStateHotkey();
        }
        private void UpdateButtonStateEdit()
        {
            if (listBoxActions.SelectedIndex == -1)
                button_EditAction.Enabled = false;
            else
                button_EditAction.Enabled = true;

            Log.Write(Properties.strings.log_UpdateButtonState_Edit + button_EditAction.Enabled, LogFramework.Log.TRACE);
        }
        private void UpdateButtonStateDeleteAction()
        {
            if (listBoxActions.SelectedIndex == -1)
                button_DeleteSelectedAction.Enabled = false;
            else
                button_DeleteSelectedAction.Enabled = true;

            Log.Write(Properties.strings.log_UpdateButtonState_DeleteAction + button_DeleteSelectedAction.Enabled, LogFramework.Log.TRACE);
        }
        private void UpdateButtonStateDeleteSequence()
        {
            if (flatComboBoxSequenceList.SelectedIndex == -1)
                button_DeleteSequence.Enabled = false;
            else
                button_DeleteSequence.Enabled = true;

            Log.Write(Properties.strings.log_UpdateButtonState_DeleteSequence + button_DeleteSequence.Enabled, LogFramework.Log.TRACE);
        }
        public void UpdateButtonStateBot()
        {
            //Enable Bot Start or Stop
            button_StartBot.Enabled = false;
            tsm_Bot_Start.Enabled = false;
            button_StopBot.Enabled = false;
            tsm_Bot_Stop.Enabled = false;

            if (bot.IsRunning)
            {
                button_StopBot.Enabled = true;
                tsm_Bot_Stop.Enabled = true;
            }
            //Enable START If bot is running or there is actions in the list
            else if (bot.IsRunning || (listBoxActions.Items.Count > 0))
            {
                button_StartBot.Enabled = true;
                tsm_Bot_Start.Enabled = true;
            }
            Log.Write(Properties.strings.log_UpdateButtonState_Bot + bot.IsRunning, LogFramework.Log.TRACE);
        }
        private void UpdateButtonStateSaveLogs()
        {
            tsm_Settings_Logs.Checked = SettingsController.IsSaveLogs();
            Log.Write(Properties.strings.log_UpdateButtonState_SaveLogs + tsm_Settings_Logs.Checked, LogFramework.Log.TRACE);
        }
        private void UpdateButtonStateLanguage()
        {
            String language = SettingsController.GetLanguage();
            tsm_Settings_Language_Francais.Checked = false;
            tsm_Settings_Language_English.Checked = false;

            if (language == "EN")
                tsm_Settings_Language_English.Checked = true;
            else if (language == "FR")
                tsm_Settings_Language_Francais.Checked = true;
            else
                tsm_Settings_Language_English.Checked = true;
            Log.Write(Properties.strings.log_UpdateButtonState_Language + language, LogFramework.Log.TRACE);
        }
        private void UpdateButtonStateTheme()
        {
            int themeMode = SettingsController.GetTheme();
            tsm_Settings_Theme_Dark.Checked = false;
            tsm_Settings_Theme_Light.Checked = false;
            tsm_Settings_Theme_Auto.Checked = false;

            if (themeMode == 0)
                tsm_Settings_Theme_Dark.Checked = true;
            else if (themeMode == 1)
                tsm_Settings_Theme_Light.Checked = true;
            else
                tsm_Settings_Theme_Auto.Checked = true; 
            Log.Write(Properties.strings.log_UpdateButtonState_Theme + themeMode, LogFramework.Log.TRACE);
        }
        private void UpdateButtonStateHotkey()
        {
            int modifier = 0;
            //Reversing alt and shift modifier because of a bug in UI 
            modifier = Reverse3Bits((int)hotkeyStartBot.GetModifier()) << 16;
            tsm_Bot_Start.ShortcutKeys = (Keys)((int)hotkeyStartBot.GetKey() | modifier);

            modifier = Reverse3Bits((int)hotkeyStopBot.GetModifier()) << 16;
            tsm_Bot_Stop.ShortcutKeys = (Keys)((int)hotkeyStopBot.GetKey() | modifier);
            Log.Write(Properties.strings.log_UpdateButtonState_Hotkey, LogFramework.Log.TRACE);
        }
        private void ApplyTheme()
        {
            DM = new DarkModeCS(this, SettingsController.GetTheme(), false);
            this.Refresh();
            Log.Write(Properties.strings.log_AppliedTheme, LogFramework.Log.TRACE);
        }
        private void ChangeLanguage(string language)
        {
            SettingsController.SetLanguage(language.ToUpper());
            SetLanguageUI();
            UpdateButtonStateLanguage();
            Localization();
        }

        //Used to write logs from other objects on the main window
        public ListBox GetListBoxLog()
        {
            return listBoxLog;
        }

        //------------------------------------------------------------
        //SAVING AND LOADING

        /// <summary>
        /// Populate listBoxActions with actions in this.sequence
        /// </summary>
        private void LoadActions()
        {
            Log.Write(Properties.strings.log_Loading_Actions, LogFramework.Log.TRACE);
            this.listBoxActions.Items.Clear();
            foreach (Action action in sequenceController.GetActions())
            {
                Log.Write(Properties.strings.log_Loading_Action + action.ToString(), LogFramework.Log.TRACE);
                String currentItem = action.ToString();
                this.listBoxActions.Items.Add(currentItem);
            }

            UpdateButtonStateEdit();
            UpdateButtonStateDeleteAction();
            UpdateButtonStateBot();

            Log.Write(Properties.strings.log_Loaded_Actions, LogFramework.Log.TRACE);
        }

        /// <summary>
        /// Load an XML File into a Sequence Object 
        /// </summary>
        /// <param name="sequenceName">Name of Sequence XML to load</param>
        private bool LoadSequence(String sequenceName)
        {
            Log.Write(Properties.strings.log_Loading_Sequence + sequenceName, LogFramework.Log.TRACE);

            if(!string.IsNullOrEmpty(sequenceName))
            {
                //Get Sequence from XML
                this.sequenceController.Sequence = SequenceXmlManager.LoadSequence(sequenceName);
                LoadedSequenceName = sequenceName;
                isSequenceSaved = true;
                Log.Write(Properties.strings.log_Loading_Sequence_Success, LogFramework.Log.TRACE);
                return true;
            }

            LoadedSequenceName = "";
            Log.Write(Properties.strings.log_Loading_Sequence_Fail + sequenceName, LogFramework.Log.ERROR);
            return false;
        }

        /// <summary>
        /// Open a form and save the sequence
        /// </summary>
        private void SaveAsSequence()
        {
            SaveSequenceView saveSequenceView = new SaveSequenceView(this.sequenceController);
            saveSequenceView.StartPosition = FormStartPosition.CenterParent;
            var result = saveSequenceView.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                //MessageBox.Show(saveSequenceView.ReturnValueSequenceName);
                LoadSequencesList();
                flatComboBoxSequenceList.SelectedItem = saveSequenceView.ReturnValueSequenceName;
                isSequenceSaved = true;

                Log.Write(Properties.strings.log_Sequence_Saved + saveSequenceView.ReturnValueSequenceName, GetListBoxLog());
            }
        }

        /// <summary>
        /// Save the current sequence to the selected name in the sequenceDropBox
        /// </summary>
        private void SaveSequence()
        {
            if(flatComboBoxSequenceList.SelectedItem != null)
            {
                SequenceXmlManager.SaveSequence(flatComboBoxSequenceList.SelectedItem.ToString(), this.sequenceController);
                isSequenceSaved = true;
                Log.Write(Properties.strings.log_Sequence_Saved + flatComboBoxSequenceList.SelectedItem.ToString(), GetListBoxLog());
            }
            else
                SaveAsSequence();
        }


        //------------------------------------------------------------
        //ADDING, EDITING, DELETING
        private void NewSequence()
        {
            //Populate Combobox with all sequences saved
            LoadSequencesList();

            //Initialize sequenceController
            sequenceController = new SequenceController();

            //Make sure ActionList is empty
            LoadActions();

            isSequenceSaved = true;
            lastIndexSequenceLoaded = -1;
            LoadedSequenceName = "";

            UpdateAllButtonState();
        }

        private void AddAction()
        {
            var formPopup = new ActionView(this);
            formPopup.StartPosition = FormStartPosition.CenterParent;
            var result = formPopup.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                sequenceController.AddAction(formPopup.ReturnValueAction);
                Log.Write(Properties.strings.log_ActionAdded + formPopup.ReturnValueAction.ToString(), GetListBoxLog());
                LoadActions();
                isSequenceSaved = false;
            }
        }

        private void EditAction(int selectedActionIndex)
        {
            if (selectedActionIndex != -1)
            {
                var formPopup = new ActionView(this, sequenceController.GetActions()[selectedActionIndex]);
                formPopup.StartPosition = FormStartPosition.CenterParent;
                var result = formPopup.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    sequenceController.EditAction(selectedActionIndex, formPopup.ReturnValueAction);
                    Log.Write(Properties.strings.log_ActionEdited + formPopup.ReturnValueAction.ToString(), GetListBoxLog());
                    LoadActions();
                    listBoxActions.SelectedIndex = selectedActionIndex;
                    isSequenceSaved = false;
                }
            }
        }
        
        private void DeleteAction(Action selectedAction)
        {
            sequenceController.RemoveAction(selectedAction);
            isSequenceSaved = false;
            Log.Write(Properties.strings.log_ActionDeleted + selectedAction.ToString(), GetListBoxLog());
        }
        
        private void DeleteSelectedActions()
        {
            try
            {
                List<Action> actionsToRemove = new List<Action>();
                //Get all selected actions
                for (int i = 0; i < listBoxActions.SelectedItems.Count; i++)
                {
                    actionsToRemove.Add(sequenceController.GetActions()[listBoxActions.SelectedIndices[i]]);
                }

                //Remove all selected actions
                foreach (Action action in actionsToRemove)
                {
                    DeleteAction(action);
                }

                LoadActions();

                listBoxActions.SelectedIndex = -1;

                UpdateAllButtonState();
            }
            catch (Exception) { }
        }
        
        private void DeleteSequence()
        {
            DialogResult dr = MessageBox.Show(Properties.strings.MessageBox_WarningDeleteSequence, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                bool result = SequenceController.DeleteSequence(sequenceController.SequenceName);
                if (result)
                {
                    Log.Write(Properties.strings.log_Sequence_Deleted + sequenceController.SequenceName, GetListBoxLog());
                    NewSequence();
                }
            }
        }

        //------------------------------------------------------------
        //BOT 

        private void StartBot()
        {
            bot.Start(sequenceController);
        }

        private void StopBot()
        {
            bot.Stop();
        }

        //------------------------------------------------------------
        //Combobox sequence list 

        private void LoadSequencesList()
        {
            flatComboBoxSequenceList.Items.Clear();
            flatComboBoxSequenceList.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            try
            {
                flatComboBoxSequenceList.SelectedIndex = -1;
            }
            catch { }
        }

        //------------------------------------------------------------
        //    EVENT HANDLING
        //------------------------------------------------------------

        //------------------------------------------------------------
        // ToolStripMenu EVENTS

        //------------------------------------------------------------
        //FILE

        //New
        private void Tsm_File_New_Click(object sender, EventArgs e)
        {
            NewSequence();
        }
        
        //Save
        private void Tsm_File_Save_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        //Save As
        private void Tsm_File_SaveAs_Click(object sender, EventArgs e)
        {
            SaveAsSequence();
        }

        //Close
        private void Tsm_File_Exit_Click(object sender, EventArgs e)
        {
            // TO DO : 
            // Check if Sequence is saved before closing

            this.Close();
        }

        //------------------------------------------------------------
        //BOT

        //Start
        private void Tsm_Bot_Start_Click(object sender, EventArgs e)
        {
            StartBot();
        }
        
        //Stop
        private void Tsm_Bot_Stop_Click(object sender, EventArgs e)
        {
            StopBot();
        }

        //------------------------------------------------------------
        //SETTINGS

        //Save logs
        private void Tsm_Settings_Logs_Click(object sender, EventArgs e)
        {
            //Toggle the settings
            SettingsController.SetSaveLogs(!SettingsController.IsSaveLogs());
            Log.Write(Properties.strings.log_SettingSavelogs + SettingsController.IsSaveLogs());
            UpdateButtonStateSaveLogs();
        }
        
        //English selected
        private void Tsm_Settings_Language_English_Click(object sender, EventArgs e)
        {
            ChangeLanguage("EN");
        }
        
        //French selected
        private void Tsm_Settings_Language_Francais_Click(object sender, EventArgs e)
        {
            ChangeLanguage("FR");
        }
        
        //Hotkey Dialog
        private void Tsm_Settings_Hotkeys_Click(object sender, EventArgs e)
        {
            HotkeyView shortcutsView = new HotkeyView();
            shortcutsView.StartPosition = FormStartPosition.CenterParent;
            var result = shortcutsView.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                hotkeyStartBot.Unregiser();
                hotkeyStartBot.SetHotkey(shortcutsView.ReturnHotkeyStartBot);
                hotkeyStartBot.Register();
                SettingsController.SetHotkeyStartBot(hotkeyStartBot.GetHotkey());

                hotkeyStopBot.Unregiser();
                hotkeyStopBot.SetHotkey(shortcutsView.ReturnHotkeyStopBot);
                hotkeyStopBot.Register();
                SettingsController.SetHotkeyStopBot(hotkeyStopBot.GetHotkey());

                SettingsController.SetHotkeyXY(shortcutsView.ReturnHotkeyXY);

                SettingsController.SetHotkeyXY2(shortcutsView.ReturnHotkeyXY2);

                UpdateButtonStateHotkey();
            }
        }

        //Theme
        private void Tsm_Settings_Theme_Light_Click(object sender, EventArgs e)
        {
            SettingsController.SetTheme(1);
            ApplyTheme();
            UpdateButtonStateTheme();
            this.Refresh();
        }

        private void Tsm_Settings_Theme_Dark_Click(object sender, EventArgs e)
        {
            SettingsController.SetTheme(0);
            ApplyTheme();
            UpdateButtonStateTheme();
            this.Refresh();
        }

        private void Tsm_Settings_Theme_Auto_Click(object sender, EventArgs e)
        {
            SettingsController.SetTheme(2);
            ApplyTheme();
            UpdateButtonStateTheme();
            this.Refresh();
        }
       
        //About
        private void Tsm_About_Click(object sender, EventArgs e)
        {
            var aboutPopup = new About();
            aboutPopup.StartPosition = FormStartPosition.CenterParent;
            aboutPopup.ShowDialog(this);
        }

        //------------------------------------------------------------
        // Buttons EVENTS 

        private void Button_Add_Action_Click(object sender, EventArgs e)
        {
            AddAction();
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            EditAction(listBoxActions.SelectedIndex);
        }
        private void Button_DeleteSelectedAction_Click(object sender, EventArgs e)
        {
            DeleteSelectedActions();
        }
        private void Button_DeleteSequence_Click(object sender, EventArgs e)
        {
            DeleteSequence();
        }
        private void Button_SaveSequence_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        private void Button_StartBot_Click(object sender, EventArgs e)
        {
            StartBot();
        }
        private void Button_StopBot_Click(object sender, EventArgs e)
        {
            StopBot();
        }

        //------------------------------------------------------------
        //ListBoxAction EVENTS
        private void ListBoxActions_KeyDown(object sender, KeyEventArgs e)
        {            
            //Del Key Pressed
            if (Keys.Delete == e.KeyCode)
            {
                DeleteSelectedActions();
            }

            //CTRL + A Pressed
            if (e.KeyData == (Keys.A | Keys.Control))
            {
                for (int i = 0; i < listBoxActions.Items.Count; i++)
                {
                    listBoxActions.SetSelected(i, true);
                }
                e.SuppressKeyPress = true;
            }

        }

        private void ListBoxActions_DoubleClick(object sender, EventArgs e)
        {
            EditAction(listBoxActions.SelectedIndex);
        }

        private void ListBoxActions_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listBoxActions.SelectedItem == null) return;
            if (e.Clicks == 1)
            {
                UpdateAllButtonState();
                this.listBoxActions.DoDragDrop(this.listBoxActions.SelectedItem, DragDropEffects.Move);
            }
        }

        private void ListBoxActions_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListBoxActions_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBoxActions.PointToClient(new Point(e.X, e.Y));
            //Get release click position
            int index = this.listBoxActions.IndexFromPoint(point); 

            //Backup selected action
            Action actionTPM = this.sequenceController.GetActions()[this.listBoxActions.SelectedIndex];

            //Delete selected item
            this.sequenceController.RemoveAction(this.listBoxActions.SelectedIndex);

            //If release mouse where there is no item, move item to last position
            if(index == -1)
                this.sequenceController.AddAction(actionTPM);
            else
                this.sequenceController.InsertAction(index, actionTPM);

            LoadActions();
        }
       
        private void ListBoxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAllButtonState();
        }
        
        //------------------------------------------------------------
        //Combobox SequenceList EVENTS
        
        private void FlatComboBoxSequenceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If selected index equals the last successfully loaded sequence
            //User probably clicked on No in the dialogbox
            //No need to reload
            if(!(flatComboBoxSequenceList.SelectedIndex == lastIndexSequenceLoaded))
                if (flatComboBoxSequenceList.SelectedIndex != -1)
                {
                    bool loadSequence = true;

                    if (!isSequenceSaved)
                    {
                        DialogResult dr = MessageBox.Show(Properties.strings.MessageBox_WarningSequenceNotSaved_ChangeSequence, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //Prevent closing
                        if (dr == DialogResult.No)
                        {
                            loadSequence = false;
                            flatComboBoxSequenceList.SelectedIndex = lastIndexSequenceLoaded;
                        }

                    }

                    if (loadSequence)
                    {
                        //Load Sequence
                        if (LoadSequence(flatComboBoxSequenceList.SelectedItem.ToString()))
                        {
                            //Populate ActionListBox
                            LoadActions();
                            lastIndexSequenceLoaded = flatComboBoxSequenceList.SelectedIndex;
                        }
                    }
                }
            UpdateAllButtonState();
        }


        //------------------------------------------------------------
        //MainForm EVENTS

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool close = true;

            StopBot();

            //If the sequence has not been saved
            if(!isSequenceSaved)
            {
                DialogResult dr = MessageBox.Show(Properties.strings.MessageBox_WarningSequenceNotSaved_Exit, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //Prevent closing
                if (dr == DialogResult.No)
                {
                    close = false;
                    e.Cancel = true;
                }
            }

            if(close)
            {
                hotkeyStartBot.Unregiser();
                hotkeyStopBot.Unregiser();

                Log.Write(Properties.strings.log_ApplicationClosed);
                //Blank line to separate logs between starts
                Log.Write("", listBoxLog, LogFramework.Log.INFO);
            }
        }

        //HotKey without focus
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                int modifier = ((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if ((modifier == hotkeyStartBot.GetModifier()) && (key == hotkeyStartBot.GetKey()))
                {
                    StartBot();
                }
                if ((modifier == hotkeyStopBot.GetModifier()) && (key == hotkeyStopBot.GetKey()))
                {
                    StopBot();
                }
            }
        }

        //Might be usefull to implement later
        private Bitmap takeScreenShot(int x, int y, int width, int height)
        {
            //Create a new bitmap.
            var bmpScreenshot = new Bitmap(width,
                                           height,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(x,
                                        y,
                                        0,
                                        0,
                                        new Size(width, height),
                                        CopyPixelOperation.SourceCopy);

            return bmpScreenshot;
        }


        public static int Reverse3Bits(int n)
        {
            return (0x73516240 >> (n << 2)) & 7;
        }

    }
}
