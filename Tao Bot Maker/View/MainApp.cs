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

namespace Tao_Bot_Maker
{
    public partial class MainApp : Form
    {
        //DLL Hotkey
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //DLL Drawing
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        //Public Members
        public static String PICTURE_FOLDER_NAME = "Pictures";
        public static String SETTINGS_INI_NAME = "Settings.ini";
        public static String SETTINGS_SECTION_GENERAL = "General";
        public static String SETTINGS_KEY_SAVELOGS = "SaveLogs";

        //Private Members
        private SequenceController sequenceController;
        private DrawingRectangle zoneRecherche;
        private Bot bot;

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        private void UpdateLanguageUI(string language)
        {
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

            tsm_File.Text = Properties.strings.tsm_File;
            tsm_File_Save.Text = Properties.strings.tsm_File_Save;
            tsm_File_SaveAs.Text = Properties.strings.tsm_File_SaveAs;
            tsm_File_Exit.Text = Properties.strings.tsm_File_Exit;

            tsm_Bot.Text = Properties.strings.tsm_Bot;
            tsm_Bot_Start.Text = Properties.strings.tsm_Bot_Start;
            tsm_Bot_Stop.Text = Properties.strings.tsm_Bot_Stop;

            tsm_Settings.Text = Properties.strings.tsm_Settings;
            tsm_Settings_Language.Text = Properties.strings.tsm_Settings_Language;
            tsm_Settings_Shortcuts.Text = Properties.strings.tsm_Settings_Shortcuts;
            tsm_Settings_Theme.Text = Properties.strings.tsm_Settings_Theme;
            tsm_Settings_Logs.Text = Properties.strings.tsm_Settings_SaveLogs;
            
        }

        public MainApp()
        {
            SetProcessDPIAware();
            InitializeComponent();
            RegisterHotKey(this.Handle, 0, (int)KeyModifier.None, Keys.F5.GetHashCode());
            RegisterHotKey(this.Handle, 1, (int)KeyModifier.None, Keys.F6.GetHashCode()); 

            LoadSequencesList();

            sequenceController = new SequenceController();

            zoneRecherche = new DrawingRectangle();
            zoneRecherche.Show();

            bot = new Bot(this, zoneRecherche);

            //labelNotice.Text = "F1 : Angle haut gauche ou clic \r\n" +
            //               "F2 : Angle bas droite \r\n" +
            //               "F6 : Start Bot \r\n" +
            //               "F7 : Stop Bot  \r\n" +
            //               "Tolérance : 0-255; 0 = pixel perfect; (Recommandé 100-150)";

            UpdateButtons();
            UpdateLanguageUI("EN");
            Log("Setting SaveLogs : " + IsSaveLogs(), LogFramework.Log.INFO);
            Log("Programme initialisé", LogFramework.Log.INFO);
        }

        //------------------------------------------------------------
        //    METHODS
        //------------------------------------------------------------
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

            if (IsSaveLogs())
                LogFramework.Log.Write(logLevel, logsentence);
        }
        private void UpdateButtons()
        {
            //Enable Edit Button
            if (listBoxActions.SelectedIndex == -1)
                button_EditAction.Enabled = false;
            else
                button_EditAction.Enabled = true;

            //Enable Bot Start or Stop
            if (bot.isRunning)
            {
                button_StartBot.Enabled = false;
                tsm_Bot_Start.Enabled = false;

                button_StopBot.Enabled = true;
                tsm_Bot_Stop.Enabled = true;
            }
            else
            {
                button_StartBot.Enabled = true;
                tsm_Bot_Start.Enabled = true;

                button_StopBot.Enabled = false;
                tsm_Bot_Stop.Enabled = false;
            }

            //Check SaveLogs menu
            if (IsSaveLogs())
            {
                tsm_Settings_Logs.Checked = true;
            }
            else
            {
                tsm_Settings_Logs.Checked = false;
            }

        }

        //------------------------------------------------------------
        //SAVING AND LOADING

        /// <summary>
        /// Populate listBoxActions with actions in this.sequence
        /// </summary>
        private void LoadActions()
        {
            Log(LogFramework.Log.INFO, "Loading actions");
            this.listBoxActions.Items.Clear();
            foreach (Action action in sequenceController.GetActions())
            {
                Log(LogFramework.Log.INFO, "Loading action : " + action.ToString());
                String currentItem = action.ToString();
                this.listBoxActions.Items.Add(currentItem);
            }

            Log(LogFramework.Log.INFO, "Loading actions success");
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
                Log(LogFramework.Log.INFO, "Loading success");
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
                MessageBox.Show(saveSequenceView.ReturnValueSequenceName);
                LoadSequencesList();
                comboBoxListSequences.SelectedItem = saveSequenceView.ReturnValueSequenceName;

                Log(LogFramework.Log.INFO, "Sequence saved : " + saveSequenceView.ReturnValueSequenceName);
            }
        }

        /// <summary>
        /// Save the current sequence to the selected name in the sequenceDropBox
        /// </summary>
        private void SaveSequence()
        {
            if(comboBoxListSequences.SelectedItem != null)
                SequenceXmlManager.SaveSequence(comboBoxListSequences.SelectedItem.ToString(), this.sequenceController);
            else
                SaveAsSequence();
        }

        //------------------------------------------------------------
        //SETTINGS
        public void WriteSetting(String key, String value, String section)
        {
            var MyIni = new IniFile(SETTINGS_INI_NAME);
            MyIni.Write(key, value, section);
        }
        public void WriteSetting(String key, String value)
        {
            var MyIni = new IniFile(SETTINGS_INI_NAME);
            MyIni.Write(key, value);
        }
        public String ReadSetting(String key, String section)
        {
            var MyIni = new IniFile(SETTINGS_INI_NAME);
            var value = MyIni.Read(key, section);
            return value.ToString();
        }

        //LOGS
        private bool IsSaveLogs()
        {
            String value = ReadSetting(SETTINGS_KEY_SAVELOGS, SETTINGS_SECTION_GENERAL);
            if (value.ToLower() == "true")
                return true;

            return false;
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
                Log(LogFramework.Log.INFO, "Action View OK");
                sequenceController.AddAction(formPopup.ReturnValueAction);

                Log(LogFramework.Log.INFO, "Action Créé : " + formPopup.ReturnValueAction.ToString());
                LoadActions();
            }
            else
            {
                Log(LogFramework.Log.INFO, "Action View CANCEL");
            }
        }

        private void EditAction(int selectedActionIndex)
        {
            if (selectedActionIndex != -1)
            {
                var formPopup = new ActionView(sequenceController.GetActions()[selectedActionIndex], this);
                formPopup.StartPosition = FormStartPosition.CenterParent;
                var result = formPopup.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    Log(LogFramework.Log.INFO, "Action View Edit OK");
                    sequenceController.EditAction(selectedActionIndex, formPopup.ReturnValueAction);

                    Log("Action Modifiée : " + sequenceController.GetActions()[selectedActionIndex].ToString());
                    LoadActions();
                }
                else
                {
                    Log(LogFramework.Log.INFO, "Action View Edit CANCEL");
                }
            }

        }
        
        private void RemoveAction(int selectedActionIndex)
        {
            sequenceController.RemoveAction(selectedActionIndex);
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
            bot.botStart(sequenceController);
            UpdateButtons();
        }

        private void StopBot()
        {
            zoneRecherche.ClearRectangles();
            zoneRecherche.Refresh();
            bot.stopBot();
            UpdateButtons();
        }
        
        //TODO : See if better to implement in bot
        public void clearZones()
        {
            zoneRecherche.ClearRectangles();
            zoneRecherche.Refresh();
        }

        //------------------------------------------------------------
        //Combobox sequence list 

        private void LoadSequencesList()
        {
            comboBoxListSequences.Items.Clear();
            comboBoxListSequences.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            try
            {
                comboBoxListSequences.SelectedIndex = -1;
            }
            catch { }
        }

        //------------------------------------------------------------
        //    EVENT HANDLING
        //------------------------------------------------------------

        //------------------------------------------------------------
        // ToolStripMenu EVENTS

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

        private void Tsm_Settings_Logs_Click(object sender, EventArgs e)
        {
            //Toggle the settings
            if (IsSaveLogs())
            {
                WriteSetting(SETTINGS_KEY_SAVELOGS, "false", SETTINGS_SECTION_GENERAL);
            }
            else
            {
                WriteSetting(SETTINGS_KEY_SAVELOGS, "true", SETTINGS_SECTION_GENERAL);
            }
            Log(LogFramework.Log.INFO, "Setting SaveLogs : " + IsSaveLogs());
            UpdateButtons();
        }

        //------------------------------------------------------------
        // Buttons EVENTS 

        private void ComboBoxListSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListSequences.SelectedIndex != -1)
            {
                //Load Sequence
                if (LoadSequence(comboBoxListSequences.SelectedItem.ToString()))
                {
                    //Populate ActionListBox
                    LoadActions();
                }
            }
            UpdateButtons();
        }

        private void Button_Add_Action_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            EditAction(listBoxActions.SelectedIndex);
        }
        
        private void Button_ClearSequence_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Warning : This will delete all actions in the list", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                ClearActions();
                LoadActions();
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

        private void ListBoxActions_KeyDown(object sender, KeyEventArgs e)
        {            
            //Del Key Pressed
            if (Keys.Delete == e.KeyCode)
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
                UpdateButtons();
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
            UpdateButtons();
        }
        
        //------------------------------------------------------------
        //MainForm EVENTS

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            bot.stopBot();
            UnregisterHotKey(this.Handle, 0); //Start hotkey
            UnregisterHotKey(this.Handle, 1); //Stop hotkey
            Log("Closing App complete", LogFramework.Log.INFO);
        }

        //HotKey without focus
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if (key.ToString() == "F6")
                    Button_StartBot_Click(null, null);

                if (key.ToString() == "F7")
                    bot.stopBot();
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

    }
}
