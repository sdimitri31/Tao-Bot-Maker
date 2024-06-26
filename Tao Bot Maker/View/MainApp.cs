﻿using BlueMystic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;
using Log = Tao_Bot_Maker.Controller.Log;

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
        private int lastIndexSequenceLoaded;

        //Needed to filter current loaded sequence
        public string LoadedSequenceName { get; set; }
        public string LastSuccessfullyLoadedSequenceName { get; set; }

        public MainApp()
        {
            SetProcessDPIAware();
            InitializeComponent();

            ApplyTheme();

            SetLanguageUI();

            Localization();

            bot = new Bot(this);

            hotkeyStartBot = new HotKeyController(SettingsController.GetHotkeyStartBot(), this);
            hotkeyStartBot.Register();

            hotkeyStopBot = new HotKeyController(SettingsController.GetHotkeyStopBot(), this);
            hotkeyStopBot.Register();

            NewSequence();

            Log.Write(Properties.strings.log_ApplicationInitialized, listBoxLog, Log.INFO);
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
                    break;
                case "FR":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;
            }
            Log.Write(message + language, Log.TRACE);
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

            Log.Write(Properties.strings.log_LocalizationUpdated, Log.TRACE);
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

            Log.Write(Properties.strings.log_UpdateButtonState_Edit + button_EditAction.Enabled, Log.TRACE);
        }
        private void UpdateButtonStateDeleteAction()
        {
            if (listBoxActions.SelectedIndex == -1)
                button_DeleteSelectedAction.Enabled = false;
            else
                button_DeleteSelectedAction.Enabled = true;

            Log.Write(Properties.strings.log_UpdateButtonState_DeleteAction + button_DeleteSelectedAction.Enabled, Log.TRACE);
        }
        private void UpdateButtonStateDeleteSequence()
        {
            if (flatComboBoxSequenceList.SelectedIndex == -1)
                button_DeleteSequence.Enabled = false;
            else
                button_DeleteSequence.Enabled = true;

            Log.Write(Properties.strings.log_UpdateButtonState_DeleteSequence + button_DeleteSequence.Enabled, Log.TRACE);
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
            Log.Write(Properties.strings.log_UpdateButtonState_Bot + bot.IsRunning, Log.TRACE);
        }
        private void UpdateButtonStateSaveLogs()
        {
            tsm_Settings_Logs.Checked = SettingsController.IsSaveLogs();
            Log.Write(Properties.strings.log_UpdateButtonState_SaveLogs + tsm_Settings_Logs.Checked, Log.TRACE);
        }
        private void UpdateButtonStateLanguage()
        {
            string language = SettingsController.GetLanguage();
            tsm_Settings_Language_Francais.Checked = false;
            tsm_Settings_Language_English.Checked = false;

            if (language == "EN")
                tsm_Settings_Language_English.Checked = true;
            else if (language == "FR")
                tsm_Settings_Language_Francais.Checked = true;
            else
                tsm_Settings_Language_English.Checked = true;
            Log.Write(Properties.strings.log_UpdateButtonState_Language + language, Log.TRACE);
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
            Log.Write(Properties.strings.log_UpdateButtonState_Theme + themeMode, Log.TRACE);
        }
        private void UpdateButtonStateHotkey()
        {
            tsm_Bot_Start.ShortcutKeyDisplayString = Utils.GetFormatedKeysString(hotkeyStartBot.GetKey());
            tsm_Bot_Stop.ShortcutKeyDisplayString = Utils.GetFormatedKeysString(hotkeyStopBot.GetKey());
            Log.Write(Properties.strings.log_UpdateButtonState_Hotkey, Log.TRACE);
        }
        private void ApplyTheme()
        {
            DM = new DarkModeCS(this, SettingsController.GetTheme(), false);
            this.Refresh();
            Log.Write(Properties.strings.log_AppliedTheme, Log.TRACE);
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
        /// Populate listBoxActions with actions in sequence
        /// </summary>
        private void LoadActions()
        {
            Log.Write(Properties.strings.log_Loading_Actions, Log.TRACE);
            this.listBoxActions.Items.Clear();

            foreach(Action action in sequenceController.GetActions())
            {
                string error = "";
                if (!string.IsNullOrEmpty(action.ErrorMessage))
                {
                    error = "# " + action.ErrorMessage + " #";
                }

                Log.Write(Properties.strings.log_Loading_Action + action, Log.TRACE);
                this.listBoxActions.Items.Add(error + action);
            }

            UpdateButtonStateEdit();
            UpdateButtonStateDeleteAction();
            UpdateButtonStateBot();

            Log.Write(Properties.strings.log_Loaded_Actions, Log.TRACE);
        }

        private bool LoadSequence(string sequenceName)
        {
            Log.Write(Properties.strings.log_Loading_Sequence + sequenceName, Log.TRACE);

            if(sequenceController.LoadSequence(sequenceName))
            {
                LastSuccessfullyLoadedSequenceName = sequenceController.SequenceName;
                flatComboBoxSequenceList.SelectedItem = sequenceController.SequenceName;
                Log.Write(Properties.strings.log_Loading_Sequence_Success, Log.TRACE);
                return true;
            }

            MessageBox.Show(Properties.strings.MessageBox_Error_LoadingSequence);

            if (!string.IsNullOrEmpty(LastSuccessfullyLoadedSequenceName))
                LoadSequence(LastSuccessfullyLoadedSequenceName);
            else
                flatComboBoxSequenceList.SelectedItem = null;

            Log.Write(Properties.strings.log_Loading_Sequence_Fail + sequenceName, Log.ERROR);
            return false;
        }

        private void SaveSequence(string sequenceName = "")
        {
            bool saveResult = sequenceController.Save(sequenceName);

            if (saveResult)
            {
                LoadSequencesList();
                flatComboBoxSequenceList.SelectedItem = sequenceController.SequenceName;
                Log.Write(Properties.strings.log_Sequence_Saved + sequenceController.SequenceName, GetListBoxLog());
            }
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

            lastIndexSequenceLoaded = -1;
            LoadedSequenceName = "";

            UpdateAllButtonState();
        }

        private void AddAction()
        {
            var actionView = new ActionView(this);
            actionView.StartPosition = FormStartPosition.CenterParent;
            var result = actionView.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                sequenceController.AddAction(actionView.ReturnValueAction);
                Log.Write(Properties.strings.log_ActionAdded + actionView.ReturnValueAction.ToString(), GetListBoxLog());
                LoadActions();
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
                }
            }
        }
        
        private void DeleteAction(Action selectedAction)
        {
            sequenceController.RemoveAction(selectedAction);
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
            bool result = SequenceController.DeleteSequence(sequenceController.SequenceName);
            if (result)
            {
                Log.Write(Properties.strings.log_Sequence_Deleted + sequenceController.SequenceName, GetListBoxLog());
                NewSequence();
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
            SaveSequence(sequenceController.SequenceName);
        }

        //Save As
        private void Tsm_File_SaveAs_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        //Close
        private void Tsm_File_Exit_Click(object sender, EventArgs e)
        {
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

            HotkeyView hotkeyView = new HotkeyView
            {
                StartPosition = FormStartPosition.CenterParent
            };

            hotkeyStartBot.Unregiser();
            hotkeyStopBot.Unregiser();

            var result = hotkeyView.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                hotkeyStartBot.SetHotkey(hotkeyView.HotkeyStartBot);
                hotkeyStartBot.Register();
                SettingsController.SetHotkeyStartBot(hotkeyView.HotkeyStartBot);

                hotkeyStopBot.SetHotkey(hotkeyView.HotkeyStopBot);
                hotkeyStopBot.Register();
                SettingsController.SetHotkeyStopBot(hotkeyView.HotkeyStopBot);

                SettingsController.SetHotkeyXY(hotkeyView.HotkeyXY);

                SettingsController.SetHotkeyXY2(hotkeyView.HotkeyXY2);

                UpdateButtonStateHotkey();
            }
            else
            {
                hotkeyStartBot.Register();
                hotkeyStopBot.Register();
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
            SaveSequence(sequenceController.SequenceName);
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

                    if (!sequenceController.IsSaved())
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
            if(!sequenceController.IsSaved())
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
                Log.Write("", listBoxLog, Log.INFO);
            }
        }

        //HotKey without focus
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                //m.LParam = 0xKKKKMMMM, K is Key, M is modifier
                Keys pressedKey = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                Keys pressedModifier = (Keys)Utils.Reverse3Bits(((int)m.LParam & 0xFFFF));

                //Converting to same format as regular Keys
                Keys pressedHotkey = (Keys)(((int)pressedModifier << 16 ) | (int)pressedKey);

                //Key = 0xMMMMKKKK, K is Key, M is modifier
                //Keys startbotKey = (Keys)((int)hotkeyStartBot.GetKey() & 0xFFFF);
                //Keys startbotModifier = (Keys)(((int)hotkeyStartBot.GetKey() >> 16) & 0xFFFF);

                if (pressedHotkey == hotkeyStartBot.GetKey())
                {
                    StartBot();
                }
                if (pressedHotkey == hotkeyStopBot.GetKey())
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
