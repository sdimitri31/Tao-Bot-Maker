using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class MainForm : Form
    {
        private readonly MainFormController mainFormController;

        // Used for the insertion line
        private int insertionIndex = -1;
        private int draggedItemIndex = -1;

        private int selectedActionIndex = -1;

        private int previousSequenceSelectedIndex = -1;

        public MainForm()
        {
            InitializeComponent();
            mainFormController = new MainFormController(this);

            Logger.LogMessageReceived += OnLogMessageReceived;
            CultureManager.CultureChanged += UpdateUICulture;
            SequenceController.RunningStateChanged += UpdateUIState;
            SequenceController.SavedStatusChanged += UpdateUICulture;
            actionFlowLayoutPanel.KeyDown += new KeyEventHandler(ActionFlowLayoutPanel_KeyDown);

            LoadSettings();
            LoadSequenceNames();
            UpdateUIState();

            Logger.Log(Resources.Strings.InfoMessageProgramReady, TraceEventType.Information);
        }

        private void New()
        {
            if (mainFormController.IsSequenceRunning)
                return;

            // If not on a new sequence change index
            // and combobox will handle messageBox for changes
            if (sequenceComboBox.SelectedIndex != -1)
                sequenceComboBox.SelectedIndex = -1;
            else
            {
                // Else we take care of it
                if (!mainFormController.IsSequenceSaved)
                {
                    string message = string.Format(Resources.Strings.WarningMessageUnsavedChanges);
                    message += Environment.NewLine;
                    message += Resources.Strings.QuestionMessageContinue;

                    DialogResult result = MessageBox.Show(message, Resources.Strings.CaptionMessageContinue, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }
            }

            mainFormController.NewSequence();
            LoadSequenceNames();
            LoadActions();
            UpdateUIState();
        }

        private void UpdateUICulture()
        {
            string unsaved = mainFormController.IsSequenceSaved ? "" : " - " + Resources.Strings.Unsaved;
            this.Text = Resources.Strings.FormTitleMain + unsaved;

            string startButtonText = Resources.Strings.MenuBotStart + " / " + Resources.Strings.MenuBotPause + " / " + Resources.Strings.MenuBotResume;

            // FILE
            fileToolStripMenuItem.Text = Resources.Strings.MenuFile;
            newToolStripMenuItem.Text = Resources.Strings.MenuFileNew;
            saveToolStripMenuItem.Text = Resources.Strings.MenuFileSave;
            saveAsToolStripMenuItem.Text = Resources.Strings.MenuFileSaveAs;
            exitToolStripMenuItem.Text = Resources.Strings.MenuFileExit;

            // EDIT
            editToolStripMenuItem.Text = Resources.Strings.MenuEdit;
            addActionToolStripMenuItem.Text = Resources.Strings.MenuEditAddAction;
            editActionToolStripMenuItem.Text = Resources.Strings.MenuEditEditAction;
            moveActionUpToolStripMenuItem.Text = Resources.Strings.MenuEditMoveUp;
            moveActionDownToolStripMenuItem.Text = Resources.Strings.MenuEditMoveDown;
            deleteActionToolStripMenuItem.Text = Resources.Strings.MenuEditDeleteAction;
            deleteSequenceToolStripMenuItem.Text = Resources.Strings.MenuEditDeleteSequence;

            // BOT
            botToolStripMenuItem.Text = Resources.Strings.MenuBot;
            startToolStripMenuItem.Text = startButtonText;
            stopToolStripMenuItem.Text = Resources.Strings.MenuBotStop;

            // SETTINGS
            settingsToolStripMenuItem.Text = Resources.Strings.MenuSettings;
            languageToolStripMenuItem.Text = Resources.Strings.MenuSettingsLanguage;
            hotkeysToolStripMenuItem.Text = Resources.Strings.MenuSettingsShortcuts;
            settingsToolStripMenuItem1.Text = Resources.Strings.MenuSettings;
            themeToolStripMenuItem.Text = Resources.Strings.MenuSettingsTheme;
            autoThemeToolStripMenuItem.Text = Resources.Strings.LabelThemeAuto;
            lightThemeToolStripMenuItem.Text = Resources.Strings.LabelThemeLight;
            darkThemeToolStripMenuItem.Text = Resources.Strings.LabelThemeDark;

            // ?
            aboutToolStripMenuItem.Text = Resources.Strings.MenuAbout;

            // ACTION BUTTON
            addActionToolStripButton.Text = Resources.Strings.MenuEditAddAction;
            editActionToolStripButton.Text = Resources.Strings.MenuEditEditAction;
            deleteActionToolStripButton.Text = Resources.Strings.MenuEditDeleteAction;

            // BOT BUTTON
            startBotToolStripButton.Text = mainFormController.IsSequencePaused ? Resources.Strings.MenuBotResume : Resources.Strings.MenuBotStart;
            pauseBotToolStripButton.Text = Resources.Strings.MenuBotPause;
            stopBotToolStripButton.Text = Resources.Strings.MenuBotStop;

            // SEQUENCE BUTTON
            saveSequenceToolStripButton.Text = Resources.Strings.MenuFileSave;
            deleteSequenceToolStripButton.Text = Resources.Strings.MenuEditDeleteSequence;

            // CONTEXT MENU
            moveActionUpContextMenuItem.Text = Resources.Strings.MenuEditMoveUp;
            moveActionDownContextMenuItem.Text = Resources.Strings.MenuEditMoveDown;
            editActionContextMenuItem.Text = Resources.Strings.MenuEditEditAction;
            deleteActionContextMenuItem.Text = Resources.Strings.MenuEditDeleteAction;
        }

        private void UpdateUIState()
        {
            bool isRunning = mainFormController.IsSequenceRunning;
            bool isPaused = mainFormController.IsSequencePaused;

            // FILE
            newToolStripMenuItem.Enabled = !isRunning;
            saveToolStripMenuItem.Enabled = !isRunning;
            saveAsToolStripMenuItem.Enabled = !isRunning;

            // EDIT
            addActionToolStripMenuItem.Enabled = !isRunning;
            editActionToolStripMenuItem.Enabled = !isRunning && (selectedActionIndex != -1);
            deleteActionToolStripMenuItem.Enabled = !isRunning && (selectedActionIndex != -1);
            moveActionUpToolStripMenuItem.Enabled = !isRunning && (selectedActionIndex > 0);
            moveActionDownToolStripMenuItem.Enabled = !isRunning && (selectedActionIndex != -1) && (selectedActionIndex < actionFlowLayoutPanel.Controls.Count - 1);
            deleteSequenceToolStripMenuItem.Enabled = !isRunning && (sequenceComboBox.SelectedIndex != -1);

            // BOT
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = isRunning;

            // ACTION BUTTON
            addActionToolStripButton.Enabled = !isRunning;
            editActionToolStripButton.Enabled = !isRunning && (selectedActionIndex != -1);
            deleteActionToolStripButton.Enabled = !isRunning && (selectedActionIndex != -1);

            // BOT BUTTON
            startBotToolStripButton.Visible = !isRunning || isPaused;
            startBotToolStripButton.Text = isPaused ? Resources.Strings.MenuBotResume : Resources.Strings.MenuBotStart;
            pauseBotToolStripButton.Visible = isRunning && !isPaused;
            stopBotToolStripButton.Enabled = isRunning;

            // SEQUENCE BUTTON
            sequenceComboBox.Enabled = !isRunning;
            saveSequenceToolStripButton.Enabled = !isRunning;
            deleteSequenceToolStripButton.Enabled = !isRunning && (sequenceComboBox.SelectedIndex != -1);

            //CONTEXT MENU
            moveActionDownContextMenuItem.Enabled = moveActionDownToolStripMenuItem.Enabled;
            moveActionUpContextMenuItem.Enabled = moveActionUpToolStripMenuItem.Enabled;
            deleteActionContextMenuItem.Enabled = deleteActionToolStripMenuItem.Enabled;
        }

        #region SETTINGS METHODS

        /// <summary>
        /// Calls all methods to load the settings
        /// </summary>
        private void LoadSettings()
        {
            LoadMenuStripShortcuts();
            LoadLanguageSettings();
            LoadThemeSettings();
        }

        private void LoadMenuStripShortcuts()
        {
            // New (Ctrl + N)
            newToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)131150);
            newToolStripMenuItem.ShortcutKeys = (Keys)131150;

            // Save (Ctrl + S)
            saveToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)131155);
            saveToolStripMenuItem.ShortcutKeys = (Keys)131155;

            // Save As (Ctrl + Shift + S)
            saveAsToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)196691);
            saveAsToolStripMenuItem.ShortcutKeys = (Keys)196691;

            // Exit (Alt + F4)
            exitToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)262259);
            exitToolStripMenuItem.ShortcutKeys = (Keys)262259;

            // Start Bot 
            startToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString(mainFormController.KeyStartSequence);

            // Stop Bot
            stopToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString(mainFormController.KeyStopSequence);
        }

        private void LoadLanguageSettings()
        {
            string language = mainFormController.GetLanguageSettings();
            englishToolStripMenuItem.Checked = false;
            francaisToolStripMenuItem.Checked = false;
            switch (language)
            {
                case "English":
                    englishToolStripMenuItem.Checked = true;
                    break;
                case "Français":
                    francaisToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void LoadThemeSettings()
        {
            string theme = mainFormController.GetThemeSettings();
            autoThemeToolStripMenuItem.Checked = false;
            darkThemeToolStripMenuItem.Checked = false;
            lightThemeToolStripMenuItem.Checked = false;
            switch (theme)
            {
                case "Dark":
                    darkThemeToolStripMenuItem.Checked = true;
                    break;
                case "Light":
                    lightThemeToolStripMenuItem.Checked = true;
                    break;
                default:
                    autoThemeToolStripMenuItem.Checked = true;
                    break;
            }
            AppThemeHelper.ApplyTheme(AppThemeHelper.GetAppThemeFromName(theme), this, 0);
        }

        #endregion

        #region ACTIONS METODS

        /// <summary>
        /// Calls the controller to add an action and update the UI
        /// </summary>
        private void AddAction()
        {
            if (mainFormController.IsSequenceRunning)
                return;

            mainFormController.AddAction();
            LoadActions();
            UpdateUIState();
        }

        /// <summary>
        /// Calls the controller to edit an action and update the UI
        /// </summary>
        private void EditAction()
        {
            if (selectedActionIndex < 0)
                return;

            mainFormController.UpdateAction(actionFlowLayoutPanel.Controls.OfType<ActionCustomListItem>().ElementAt(selectedActionIndex).Action);
            LoadActions();
            SetSelectedActionByIndex(selectedActionIndex);
        }

        /// <summary>
        /// Calls the controller to remove an action and update the UI
        /// </summary>
        private void DeleteAction()
        {
            if (selectedActionIndex < 0)
                return;

            mainFormController.RemoveAction(actionFlowLayoutPanel.Controls.OfType<ActionCustomListItem>().ElementAt(selectedActionIndex).Action);
            actionFlowLayoutPanel.Controls.RemoveAt(selectedActionIndex);
            AddBottomMarginToLastAction();
            SetSelectedAction(null);
        }

        /// <summary>
        /// Move an action up
        /// </summary>
        private void MoveActionUp()
        {
            if (selectedActionIndex > 0 && selectedActionIndex < actionFlowLayoutPanel.Controls.Count)
            {
                Action action = GetSelectedAction();
                mainFormController.MoveAction(selectedActionIndex - 1, action);
                actionFlowLayoutPanel.Controls.SetChildIndex(actionFlowLayoutPanel.Controls[selectedActionIndex], selectedActionIndex - 1);
                SetSelectedAction(action);
                AddBottomMarginToLastAction();
            }
        }

        /// <summary>
        /// Move an action down
        /// </summary>
        private void MoveActionDown()
        {
            if (selectedActionIndex < actionFlowLayoutPanel.Controls.Count - 1 && selectedActionIndex >= 0)
            {
                Action action = GetSelectedAction();
                mainFormController.MoveAction(selectedActionIndex + 1, action);
                actionFlowLayoutPanel.Controls.SetChildIndex(actionFlowLayoutPanel.Controls[selectedActionIndex], selectedActionIndex + 1);
                SetSelectedAction(action);
                AddBottomMarginToLastAction();
            }
        }

        /// <summary>
        /// Display all actions in current sequence
        /// </summary>
        private void LoadActions()
        {
            actionFlowLayoutPanel.Controls.Clear();
            SetSelectedActionByIndex(-1);

            if (mainFormController.GetSequence() == null)
                return;

            foreach (Action action in mainFormController.GetSequence().Actions)
            {
                actionFlowLayoutPanel.Controls.Add(GetActionItem(action));
            }

            string theme = mainFormController.GetThemeSettings();
            AppThemeHelper.ApplyThemeToControl(AppThemeHelper.GetAppThemeFromName(theme), actionFlowLayoutPanel, 3);

            AddBottomMarginToLastAction();
        }

        /// <summary>
        /// Fix missing marging bottom on last action to get space to draw the insertion line
        /// </summary>
        private void AddBottomMarginToLastAction()
        {
            foreach (Control c in actionFlowLayoutPanel.Controls)
            {
                if (c != actionFlowLayoutPanel.Controls[actionFlowLayoutPanel.Controls.Count - 1])
                {
                    c.Margin = new Padding(c.Margin.Left, c.Margin.Top, c.Margin.Right, 8);
                }
                else if (c == actionFlowLayoutPanel.Controls[actionFlowLayoutPanel.Controls.Count - 1])
                {
                    c.Margin = new Padding(c.Margin.Left, c.Margin.Top, c.Margin.Right, 16);
                }
            }
        }

        /// <summary>
        /// Get a new ActionCustomListItem
        /// </summary>
        /// <param name="action">Action to display</param>
        /// <returns>ActionCustomListItem ready to be displayed</returns>
        private ActionCustomListItem GetActionItem(Action action)
        {
            var customItem = new ActionCustomListItem();
            customItem.SetAction(action);

            customItem.Click += ActionItem_Click;
            customItem.MouseDown += ActionFlowLayoutPanel_MouseDown;
            customItem.KeyDown += ActionFlowLayoutPanel_KeyDown;
            customItem.DoubleClick += ActionFlowLayoutPanel_DoubleClick;

            customItem.Width = actionFlowLayoutPanel.ClientSize.Width - actionFlowLayoutPanel.Padding.Left - actionFlowLayoutPanel.Padding.Right - 2;

            return customItem;
        }

        /// <summary>
        /// Select an action
        /// </summary>
        /// <param name="action">Action to select</param>
        private void SetSelectedAction(Action action)
        {
            foreach (ActionCustomListItem item in actionFlowLayoutPanel.Controls.OfType<ActionCustomListItem>())
            {
                item.Selected = item.Action == action;
            }

            try
            {
                selectedActionIndex = actionFlowLayoutPanel.Controls.GetChildIndex(actionFlowLayoutPanel.Controls.OfType<ActionCustomListItem>().First(x => x.Action == action));
            }
            catch (Exception)
            {
                selectedActionIndex = -1;
            }
            UpdateUIState();
            Logger.Log("Selected action index: " + selectedActionIndex, TraceEventType.Verbose);
        }

        /// <summary>
        /// Select an action by index
        /// </summary>
        /// <param name="index">Index of the action</param>
        private void SetSelectedActionByIndex(int index)
        {
            Action action = (index < 0) || (index >= mainFormController.GetSequence().Actions.Count()) ? null : mainFormController.GetSequence().Actions.ElementAt(index);
            SetSelectedAction(action);
        }

        /// <summary>
        /// Get the selected action
        /// </summary>
        /// <returns></returns>
        private Action GetSelectedAction()
        {
            Action action = (selectedActionIndex < 0) || (selectedActionIndex >= mainFormController.GetSequence().Actions.Count()) ? null : mainFormController.GetSequence().Actions.ElementAt(selectedActionIndex);
            return action;
        }

        #endregion

        #region SEQUENCE METHODS

        /// <summary>
        /// Populate the combobox with all sequence names
        /// </summary>
        private void LoadSequenceNames()
        {
            sequenceComboBox.Items.Clear();
            foreach (var sequenceName in mainFormController.GetAllSequenceNames())
            {
                sequenceComboBox.Items.Add(sequenceName);
            }
        }

        /// <summary>
        /// Calls the controller to load the sequence and load actions
        /// </summary>
        /// <param name="sequenceName"></param>
        private async void LoadSequenceAsync(string sequenceName)
        {
            try
            {
                await mainFormController.LoadSequenceAsync(sequenceName);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Loading sequence was cancelled.");
                Logger.Log("Loading sequence was cancelled.", TraceEventType.Verbose);
            }
            catch (Exception ex)
            {
                string error = Resources.Strings.Error;
                string fullMessage = string.Format(Resources.Strings.ErrorMessageFormat, error, ex.Message);

                Logger.Log(fullMessage, TraceEventType.Error);
                MessageBox.Show(fullMessage, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadActions();
        }

        /// <summary>
        /// Calls the controller to save the sequence as a new file
        /// </summary>
        private void SaveAsSequence()
        {
            mainFormController.SaveAsSequence();
            if (mainFormController.GetCurrentSequenceName() != null)
            {
                LoadSequenceNames();
                sequenceComboBox.SelectedItem = mainFormController.GetCurrentSequenceName();
            }
        }

        /// <summary>
        /// Calls the controller to save the current sequence
        /// </summary>
        private void SaveSequence()
        {
            if (string.IsNullOrEmpty(mainFormController.GetCurrentSequenceName()))
            {
                SaveAsSequence();
            }
            else
            {
                mainFormController.SaveSequence();
            }
        }

        /// <summary>
        /// Calls the controller to delete the current sequence
        /// </summary>
        private void DeleteSequence()
        {
            string sequenceName = sequenceComboBox.SelectedItem.ToString();

            if (string.IsNullOrEmpty(sequenceName))
            {
                return;
            }

            string message = string.Format(Resources.Strings.WarningMessageDeleteSequence, sequenceName);
            message += Environment.NewLine;
            message += Resources.Strings.QuestionMessageDelete;

            DialogResult result = MessageBox.Show(message, Resources.Strings.CaptionMessageDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (mainFormController.RemoveSequence(sequenceName))
                    New();
            }
        }

        #endregion

        #region BOT METHODS

        /// <summary>
        /// Calls the controller to start the sequence
        /// </summary>
        private void StartSequence()
        {
            mainFormController.StartSequence();
        }

        /// <summary>
        /// Calls the controller to stop the sequence
        /// </summary>
        private void StopSequence()
        {
            mainFormController.StopSequence();
        }

        #endregion

        #region MENU STRIP EVENTS

        #region FILE MENU STRIP EVENTS

        // New
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        // Save
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        // Save As
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsSequence();
        }

        // Exit
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region EDIT MENU STRIP EVENTS

        // Add Action
        private void AddActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        // Edit Action
        private void EditActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAction();
        }

        // Delete Action
        private void DeleteActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        // Move Up
        private void MoveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveActionUp();
        }

        // Move Down
        private void MoveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveActionDown();
        }

        // Delete Sequence
        private void DeleteSequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSequence();
        }

        #endregion

        #region BOT MENU STRIP EVENTS

        // Start Bot
        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSequence();
        }

        // Stop Bot
        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopSequence();
        }

        #endregion

        #region SETTINGS MENU STRIP EVENTS

        // Language English
        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetLanguageSettings("English");
            LoadSettings();
        }

        // Language French
        private void FrenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetLanguageSettings("Français");
            LoadSettings();
        }

        // Hotkeys
        private void HotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.OpenSettingsForm(SettingsType.Hotkeys);
            LoadSettings();
        }

        // Theme Auto
        private void AutoThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetThemeSettings("Auto");
            LoadThemeSettings();
        }

        // Theme Light
        private void LightThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetThemeSettings("Light");
            LoadThemeSettings();
        }

        // Theme Dark
        private void DarkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetThemeSettings("Dark");
            LoadThemeSettings();
        }

        // Settings
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.OpenSettingsForm();
            LoadSettings();
        }

        #endregion

        #region ABOUT MENU STRIP EVENTS

        // About
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.About();
        }

        #endregion

        #endregion

        #region TOOLBAR EVENTS

        #region ACTION TOOLBAR EVENTS

        // Add Action
        private void AddActionToolStripButton_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        // Edit Action
        private void EditActionToolStripButton_Click(object sender, EventArgs e)
        {
            EditAction();
        }

        // Delete Action
        private void DeleteActionToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        #endregion

        #region BOT TOOLBAR EVENTS

        // Start Bot
        private void StartBotToolStripButton_Click(object sender, EventArgs e)
        {
            StartSequence();
        }

        // Pause Bot
        private void PauseBotToolStripButton_Click(object sender, EventArgs e)
        {
            mainFormController.TogglePause();
        }

        // Stop Bot
        private void StopBotToolStripButton_Click(object sender, EventArgs e)
        {
            StopSequence();
        }

        #endregion

        #region SEQUENCE TOOLBAR EVENTS

        // Combo Box Selection Change
        private void SequenceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSequenceName = sequenceComboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedSequenceName))
            {
                if (!mainFormController.IsSequenceSaved)
                {
                    string message = string.Format(Resources.Strings.WarningMessageUnsavedChanges);
                    message += Environment.NewLine;
                    message += Resources.Strings.QuestionMessageContinue;

                    DialogResult result = MessageBox.Show(message, Resources.Strings.CaptionMessageContinue, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result != DialogResult.Yes)
                    {
                        // Cancel selection change
                        sequenceComboBox.SelectedIndexChanged -= SequenceComboBox_SelectedIndexChanged;
                        sequenceComboBox.SelectedIndex = previousSequenceSelectedIndex;
                        sequenceComboBox.SelectedIndexChanged += SequenceComboBox_SelectedIndexChanged;
                        return;
                    }
                }

                LoadSequenceAsync(selectedSequenceName);
            }
            previousSequenceSelectedIndex = sequenceComboBox.SelectedIndex;
            UpdateUIState();
        }

        // Save Sequence
        private void SaveSequenceToolStripButton_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        // Delete Sequence
        private void DeleteSequenceToolStripButton_Click(object sender, EventArgs e)
        {
            if (sequenceComboBox.SelectedItem == null)
                return;

            DeleteSequence();
        }

        #endregion

        #endregion

        #region MAIN FORM EVENTS

        private void OnLogMessageReceived(string message, TraceEventType level)
        {
            if (eventLogTextBox.InvokeRequired)
            {
                eventLogTextBox.Invoke((MethodInvoker)delegate
                {
                    eventLogTextBox.AppendText(message + Environment.NewLine);
                });
            }
            else
            {
                eventLogTextBox.AppendText(message + Environment.NewLine);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mainFormController.IsSequenceSaved)
            {
                string message = string.Format(Resources.Strings.WarningMessageUnsavedChanges);
                message += Environment.NewLine;
                message += Resources.Strings.QuestionMessageExit;

                DialogResult result = MessageBox.Show(message, Resources.Strings.CaptionMessageExit, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Logger.Log("Closing application", TraceEventType.Verbose);
            mainFormController.StopSequence();
            mainFormController.UnregisterHotkeys();
            Logger.LogMessageReceived -= OnLogMessageReceived;
            CultureManager.CultureChanged -= UpdateUICulture;
            SequenceController.RunningStateChanged -= UpdateUIState;
            SequenceController.SavedStatusChanged -= UpdateUICulture;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                mainFormController.ExecuteHotkey(m.LParam);
                return;
            }
        }

        #endregion

        #region ACTION FLOW LAYOUT EVENTS

        private void ActionFlowLayoutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Logger.Log("MouseDown Right from: " + sender, TraceEventType.Verbose);
                if (sender is ActionCustomListItem item)
                {
                    SetSelectedAction(item.Action);
                }
                else
                {
                    SetSelectedAction(null);
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                Logger.Log("MouseDown Left from: " + sender, TraceEventType.Verbose);
                if (sender is FlowLayoutPanel)
                {
                    SetSelectedAction(null);
                }
                //else if (sender is ActionCustomListItem item)
                //{
                //    SetSelectedAction(item.Action);
                //}
            }
        }

        /// <summary>
        /// Start drag and drop
        /// </summary>
        private void ActionFlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionCustomListItem)))
            {
                draggedItemIndex = actionFlowLayoutPanel.Controls.GetChildIndex((Control)e.Data.GetData(typeof(ActionCustomListItem)));
                Logger.Log("Start dragging item at index: " + draggedItemIndex, TraceEventType.Verbose);
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Move the dragged item to the new position
        /// </summary>
        private void ActionFlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionCustomListItem)))
            {
                var droppedItem = (ActionCustomListItem)e.Data.GetData(typeof(ActionCustomListItem));
                Point clientPoint = actionFlowLayoutPanel.PointToClient(new Point(e.X, e.Y));
                Control targetControl = actionFlowLayoutPanel.GetChildAtPoint(clientPoint);
                int targetIndex = targetControl != null ? actionFlowLayoutPanel.Controls.GetChildIndex(targetControl) : actionFlowLayoutPanel.Controls.Count - 1;

                // Move the item to the new position
                Logger.Log($"Moving item from {draggedItemIndex} to {targetIndex}", TraceEventType.Verbose);
                actionFlowLayoutPanel.Controls.SetChildIndex(droppedItem, targetIndex);
                mainFormController.MoveAction(targetIndex, droppedItem.Action);
                AddBottomMarginToLastAction();
                // Remove the insertion line
                DrawInsertionLine(-1);
            }
        }

        /// <summary>
        /// Update the position of the insertion line when hovering over a control
        /// </summary>
        private void ActionFlowLayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionCustomListItem)))
            {
                Point clientPoint = actionFlowLayoutPanel.PointToClient(new Point(e.X, e.Y));
                Control targetControl = actionFlowLayoutPanel.GetChildAtPoint(clientPoint);
                int targetIndex = targetControl != null ? actionFlowLayoutPanel.Controls.GetChildIndex(targetControl) : insertionIndex;

                if (targetIndex >= actionFlowLayoutPanel.Controls.Count)
                {
                    targetIndex = actionFlowLayoutPanel.Controls.Count - 1;
                }

                if (targetIndex != insertionIndex)
                {
                    DrawInsertionLine(targetIndex);
                }

                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Triggers Paint event to draw the insertion line
        /// </summary>
        /// <param name="index"></param>
        private void DrawInsertionLine(int index)
        {
            insertionIndex = index;
            actionFlowLayoutPanel.Invalidate();
        }

        /// <summary>
        /// Draws the insertion line
        /// </summary>
        private void ActionFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            if (insertionIndex >= 0 && insertionIndex <= actionFlowLayoutPanel.Controls.Count)
            {
                Control control = (insertionIndex < actionFlowLayoutPanel.Controls.Count) ? actionFlowLayoutPanel.Controls[insertionIndex] : null;

                int y = insertionIndex < draggedItemIndex ? control.Top - 4 : control.Bottom + 4;

                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawLine(pen, new Point(0, y), new Point(actionFlowLayoutPanel.ClientSize.Width, y));
                }
            }
        }

        private void ActionFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            // Unselect any selected action
            SetSelectedAction(null);
        }

        private void ActionFlowLayoutPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void ActionFlowLayoutPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteAction();
            }
        }

        private void ActionFlowLayoutPanel_DoubleClick(object sender, EventArgs e)
        {
            EditAction();
        }

        private void ActionFlowLayoutPanel_ClientSizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in actionFlowLayoutPanel.Controls)
            {
                control.Width = actionFlowLayoutPanel.ClientSize.Width - actionFlowLayoutPanel.Padding.Left - actionFlowLayoutPanel.Padding.Right - 2;
            }
        }

        #endregion

        private void ActionItem_Click(object sender, EventArgs e)
        {
            Logger.Log("Click from: " + sender, TraceEventType.Verbose);
            SetSelectedAction((sender as ActionCustomListItem).Action);
        }

        private void ActionListBoxContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // Disable the context menu if no action is selected
            if(selectedActionIndex == -1)
                e.Cancel = true;
        }

    }
}