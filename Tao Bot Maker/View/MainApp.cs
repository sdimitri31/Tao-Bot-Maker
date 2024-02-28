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

namespace Tao_Bot_Maker
{

    public partial class MainApp : Form
    {
        private DarkModeCS DM = null;
        //DLL Drawing
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        //Private Members
        private SequenceController sequenceController;
        private Bot bot;
        private HotKeyController hotkeyStartBot;
        private HotKeyController hotkeyStopBot;

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

            bot = new Bot(this);

            UpdateButtonState();
            UpdateUIHotkey();

            Log("Setting SaveLogs : " + SettingsController.IsSaveLogs(), LogFramework.Log.INFO);
            Log("Setting Language : " + SettingsController.GetLanguage(), LogFramework.Log.INFO);
            Log("Programme initialisé", LogFramework.Log.INFO);
        }

        //------------------------------------------------------------
        //    METHODS
        //------------------------------------------------------------
        private void SetLanguageUI()
        {
            switch (SettingsController.GetLanguage())
            {
                case "EN":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;
                case "FR":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;
            }
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

        }
        private void UpdateButtonState()
        {
            //Enable Edit Button
            if (listBoxActions.SelectedIndex == -1)
                button_EditAction.Enabled = false;
            else
                button_EditAction.Enabled = true;

            //Enable Bot Start or Stop
            UpdateButtonStateBot();

            //Check SaveLogs menu
            tsm_Settings_Logs.Checked = SettingsController.IsSaveLogs();

            //Language
            String language = SettingsController.GetLanguage();
            tsm_Settings_Language_Francais.Checked = false;
            tsm_Settings_Language_English.Checked = false;
            
            if (language == "EN")
                tsm_Settings_Language_English.Checked = true;
            else if (language == "FR")
                tsm_Settings_Language_Francais.Checked = true;

            //Theme
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
            else
            {
                button_StartBot.Enabled = true;
                tsm_Bot_Start.Enabled = true;
            }
        }

        private void UpdateUIHotkey()
        {
            int modifier = 0;

            //Reversing alt and shift modifier because of a bug in UI 
            modifier = Reverse3Bits((int)hotkeyStartBot.GetModifier()) << 16;
            tsm_Bot_Start.ShortcutKeys = (Keys)((int)hotkeyStartBot.GetKey() | modifier);

            modifier = Reverse3Bits((int)hotkeyStopBot.GetModifier()) << 16;
            tsm_Bot_Stop.ShortcutKeys = (Keys)((int)hotkeyStopBot.GetKey() | modifier);

        }
        private void ApplyTheme()
        {
            DM = new DarkModeCS(this, SettingsController.GetTheme(), false);
        }
        
        private void ChangeLanguage(string language)
        {
            SettingsController.SetLanguage(language.ToUpper());
            Log(LogFramework.Log.INFO, "Setting Language : " + SettingsController.GetLanguage());
            UpdateButtonState();
            SetLanguageUI();
            Localization();
        }
        public void Log(string message, int level)
        {
            Log(message, false, false, level);
        }
        public void Log(int level, string message)
        {
            Log(message, false, false, level);
        }
        public void Log(string logsentence, bool isthread = false, bool isTemporary = false, int logLevel = LogFramework.Log.INFO)
        {
            DateTime dateTime = DateTime.Now;
            String log = dateTime.ToString() + " : " + logsentence;
            if (isthread == false)
            {
                listBoxLog.Items.Add(log);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
            else
            {
                if (isTemporary)
                {
                    MethodInvoker mainthread = delegate
                    {
                        listBoxLog.Items.RemoveAt(listBoxLog.Items.Count - 1);
                        listBoxLog.Items.Add(log);
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    };
                    listBoxLog.BeginInvoke(mainthread);
                }
                else
                {
                    MethodInvoker mainthread = delegate
                    {
                        listBoxLog.Items.Add(log);
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    };
                    listBoxLog.BeginInvoke(mainthread);
                }
            }

            if (SettingsController.IsSaveLogs())
                LogFramework.Log.Write(logLevel, logsentence);
        }


        //------------------------------------------------------------
        //SAVING AND LOADING

        /// <summary>
        /// Populate listBoxActions with actions in this.sequence
        /// </summary>
        private void LoadActions()
        {
            //Log(LogFramework.Log.INFO, "Loading actions");
            this.listBoxActions.Items.Clear();
            foreach (Action action in sequenceController.GetActions())
            {
                //Log(LogFramework.Log.INFO, "Loading action : " + action.ToString());
                String currentItem = action.ToString();
                this.listBoxActions.Items.Add(currentItem);
            }

            //Log(LogFramework.Log.INFO, "Loading actions success");
        }

        /// <summary>
        /// Load an XML File into a Sequence Object 
        /// </summary>
        /// <param name="sequenceName">Name of Sequence XML to load</param>
        private bool LoadSequence(String sequenceName)
        {
            Log(LogFramework.Log.INFO, "Loading sequence : " + sequenceName);
            if((sequenceName != null) && (sequenceName != ""))
            {
                //Get Sequence from XML
                this.sequenceController.Sequence = SequenceXmlManager.LoadSequence(sequenceName);
                //Log(LogFramework.Log.INFO, "Loading success");
                return true;
            }
            Log(LogFramework.Log.ERROR, "Loading failed");
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

                Log(LogFramework.Log.INFO, "Sequence saved : " + saveSequenceView.ReturnValueSequenceName);
            }
        }

        /// <summary>
        /// Save the current sequence to the selected name in the sequenceDropBox
        /// </summary>
        private void SaveSequence()
        {
            if(flatComboBoxSequenceList.SelectedItem != null)
                SequenceXmlManager.SaveSequence(flatComboBoxSequenceList.SelectedItem.ToString(), this.sequenceController);
            else
                SaveAsSequence();
        }


        //------------------------------------------------------------
        //ADDING, EDITING, DELETING

        private void AddAction()
        {
            var formPopup = new ActionView(this);
            formPopup.StartPosition = FormStartPosition.CenterParent;
            var result = formPopup.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                //Log(LogFramework.Log.INFO, "Action View OK");
                sequenceController.AddAction(formPopup.ReturnValueAction);

                Log(LogFramework.Log.INFO, "Action Créé : " + formPopup.ReturnValueAction.ToString());
                LoadActions();
            }
            else
            {
                //Log(LogFramework.Log.INFO, "Action View CANCEL");
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
                    //Log(LogFramework.Log.INFO, "Action View Edit OK");
                    sequenceController.EditAction(selectedActionIndex, formPopup.ReturnValueAction);

                    Log("Action Modifiée : " + sequenceController.GetActions()[selectedActionIndex].ToString());
                    LoadActions();
                }
                else
                {
                    //Log(LogFramework.Log.INFO, "Action View Edit CANCEL");
                }
            }

        }
        
        private void RemoveAction(Action selectedAction)
        {
            sequenceController.RemoveAction(selectedAction);
        }

        private void ClearActions()
        {
            sequenceController.ClearActions();
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
            Log(LogFramework.Log.INFO, "Setting SaveLogs : " + SettingsController.IsSaveLogs());
            UpdateButtonState();
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

                UpdateUIHotkey();
            }
        }


        //Theme
        private void Tsm_Settings_Theme_Light_Click(object sender, EventArgs e)
        {
            SettingsController.SetTheme(1);
            ApplyTheme();
            UpdateButtonState();
            this.Refresh();
        }

        private void Tsm_Settings_Theme_Dark_Click(object sender, EventArgs e)
        {
            SettingsController.SetTheme(0);
            ApplyTheme();
            UpdateButtonState();
            this.Refresh();
        }

        private void Tsm_Settings_Theme_Auto_Click(object sender, EventArgs e)
        {
            SettingsController.SetTheme(2);
            ApplyTheme();
            UpdateButtonState();
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
            DialogResult dr = MessageBox.Show("Warning : This will delete the sequence entirely", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                bool result = SequenceController.DeleteSequence(sequenceController.SequenceName);
                if(result)
                    NewSequence();
            }
        }
        
        private void Button_StartBot_Click(object sender, EventArgs e)
        {
            StartBot();
        }

        private void Button_StopBot_Click(object sender, EventArgs e)
        {
            StopBot();
        }

        private void Button_SaveSequence_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        //------------------------------------------------------------
        //ListBoxAction EVENTS
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
                    RemoveAction(action);
                }

                LoadActions();
            }
            catch (Exception) { }
        }
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
                UpdateButtonState();
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
            UpdateButtonState();
        }
        
        //------------------------------------------------------------
        //Combobox SequenceList EVENTS
        
        private void FlatComboBoxSequenceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flatComboBoxSequenceList.SelectedIndex != -1)
            {
                //Load Sequence
                if (LoadSequence(flatComboBoxSequenceList.SelectedItem.ToString()))
                {
                    //Populate ActionListBox
                    LoadActions();
                }
            }
            else
            {

            }
            UpdateButtonState();
        }


        //------------------------------------------------------------
        //MainForm EVENTS

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopBot();
            hotkeyStartBot.Unregiser();
            hotkeyStopBot.Unregiser();
            Log("Closing App complete", LogFramework.Log.INFO);
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


        private void NewSequence()
        {
            //Populate Combobox with all sequences saved
            LoadSequencesList();

            //Initialize sequenceController
            sequenceController = new SequenceController();

            //Make sure ActionList is empty
            LoadActions();
        }

        public static int Reverse3Bits(int n)
        {
            return (0x73516240 >> (n << 2)) & 7;
        }

    }
}
