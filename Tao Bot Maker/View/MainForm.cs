using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Action = Tao_Bot_Maker.Model.Action;
using Settings = Tao_Bot_Maker.Model.Settings;

namespace Tao_Bot_Maker.View
{
    public partial class MainForm : Form
    {
        private readonly MainFormController mainFormController;
        private AppTheme appTheme;
        // Used for the insertion line
        private int insertionIndex = -1;
        private int draggedItemIndex = -1;

        private int selectedActionIndex = -1;

        private int previousSequenceSelectedIndex = -1;

        public MainForm()
        {
            InitializeComponent();
            Logger.LogMessageReceived += OnLogMessageReceived;
            CultureManager.CultureChanged += UpdateUICulture;
            SequenceController.RunningStateChanged += UpdateUIState;
            SequenceController.SavedStatusChanged += UpdateUICulture;
            actionPanel.KeyDown += new KeyEventHandler(ActionFlowLayoutPanel_KeyDown);

            mainFormController = new MainFormController(this);

            LoadSettings();
            LoadSequenceNames();

            Logger.Log(Resources.Strings.InfoMessageProgramReady, TraceEventType.Information);
        }

        private void New()
        {
            if (SequenceController.GetIsRunning())
                return;

            // If not on a new sequence change index
            // and combobox will handle messageBox for changes
            if (sequenceComboBox.SelectedIndex != -1)
                sequenceComboBox.SelectedIndex = -1;
            else
            {
                // Else we take care of it
                if (!SequenceController.GetIsSaved())
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


        private void UpdateUICulture()
        {
            string unsaved = SequenceController.GetIsSaved() ? "" : " - " + Resources.Strings.Unsaved;
            this.Text = Resources.Strings.FormTitleMain + unsaved;

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
            startToolStripMenuItem.Text = Resources.Strings.MenuBotStart;
            pauseToolStripMenuItem.Text = SequenceController.GetIsPaused() ? Resources.Strings.MenuBotResume : Resources.Strings.MenuBotPause;
            stopToolStripMenuItem.Text = Resources.Strings.MenuBotStop;

            // SETTINGS
            settingsToolStripMenuItem.Text = Resources.Strings.MenuSettings;
            languageToolStripMenuItem.Text = Resources.Strings.MenuSettingsLanguage;
            shortcutsToolStripMenuItem.Text = Resources.Strings.MenuSettingsShortcuts;
            settingsToolStripMenuItem1.Text = Resources.Strings.MenuSettings;

            // ?
            aboutToolStripMenuItem.Text = Resources.Strings.MenuAbout;

            // ACTION BUTTON
            addActionToolStripButton.Text = Resources.Strings.MenuEditAddAction;
            editActionToolStripButton.Text = Resources.Strings.MenuEditEditAction;
            deleteActionToolStripButton.Text = Resources.Strings.MenuEditDeleteAction;

            // BOT BUTTON
            startBotToolStripButton.Text = Resources.Strings.MenuBotStart;
            pauseBotToolStripButton.Text = Resources.Strings.MenuBotPause;
            stopBotToolStripButton.Text = Resources.Strings.MenuBotStop;

            // SEQUENCE BUTTON
            saveSequenceToolStripButton.Text = Resources.Strings.MenuFileSave;
            deleteSequenceToolStripButton.Text = Resources.Strings.MenuEditDeleteSequence;
        }

        private void UpdateUIState()
        {
            bool isRunning = SequenceController.GetIsRunning();
            bool isPaused = SequenceController.GetIsPaused();

            // FILE
            newToolStripMenuItem.Enabled = !isRunning;
            saveToolStripMenuItem.Enabled = !isRunning;
            saveAsToolStripMenuItem.Enabled = !isRunning;

            // EDIT
            addActionToolStripMenuItem.Enabled = !isRunning;
            editActionToolStripMenuItem.Enabled = !isRunning && (selectedActionIndex != -1);
            deleteActionToolStripMenuItem.Enabled = !isRunning && (selectedActionIndex != -1);
            moveActionUpToolStripMenuItem.Enabled = !isRunning && (selectedActionIndex > 0);
            moveActionDownToolStripMenuItem.Enabled = !isRunning && (selectedActionIndex != -1) && (selectedActionIndex < actionPanel.Controls.Count - 1);
            deleteSequenceToolStripMenuItem.Enabled = !isRunning && (sequenceComboBox.SelectedIndex != -1);

            // BOT
            startToolStripMenuItem.Enabled = !isRunning;
            pauseToolStripMenuItem.Enabled = isRunning;
            pauseToolStripMenuItem.Text = isPaused ? Resources.Strings.MenuBotResume : Resources.Strings.MenuBotPause;
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

        private void LoadSettings()
        {
            string language = SettingsController.GetSettingValue<string>(Settings.SETTING_LANGUAGE);
            englishToolStripMenuItem.Checked = false;
            francaisToolStripMenuItem.Checked = false;
            switch (language)
            {
                case "English":
                    englishToolStripMenuItem.Checked = true;
                    CultureManager.ChangeCulture("en");
                    break;
                case "Français":
                    francaisToolStripMenuItem.Checked = true;
                    CultureManager.ChangeCulture("fr");
                    break;
            }

            newToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)131150);
            newToolStripMenuItem.ShortcutKeys = (Keys)131150;
            saveToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)131155);
            saveToolStripMenuItem.ShortcutKeys = (Keys)131155;
            saveAsToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)196691);
            saveAsToolStripMenuItem.ShortcutKeys = (Keys)196691;
            exitToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)262259);
            exitToolStripMenuItem.ShortcutKeys = (Keys)262259;
            startToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYSTARTSEQUENCE));
            stopToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYSTOPSEQUENCE));
            pauseToolStripMenuItem.ShortcutKeyDisplayString = KeyboardSimulator.GetFormatedKeysString((Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYPAUSESEQUENCE));

            LoadThemeSettings();
        }

        private void LoadThemeSettings()
        {
            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
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
            appTheme = AppThemeHelper.GetAppThemeFromName(theme);
            AppThemeHelper.ApplyTheme(appTheme, this, 1);
        }

        private async void LoadSequenceAsync(string sequenceName)
        {
            try
            {
                await mainFormController.LoadSequenceAsync(sequenceName);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Loading sequence was cancelled.");
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

        private void LoadActions()
        {
            actionPanel.Controls.Clear();
            SetSelectedActionIndex(-1);

            if (mainFormController.GetSequence() == null)
                return;

            foreach (Action action in mainFormController.GetSequence().Actions)
            {
                AddCustomItem(action);
            }
            AddBottomSpacer();
        }

        /// <summary>
        /// Fix missing marging bottom on last action
        /// </summary>
        private void AddBottomSpacer()
        {
            var spacer = new Panel();
            spacer.Height = 8;
            spacer.Dock = DockStyle.Bottom;
            spacer.BackColor = Color.Transparent;
            actionPanel.Controls.Add(spacer);
        }

        private void AddCustomItem(Action action)
        {
            var customItem = new ActionCustomListItem();
            customItem.SetAction(action);

            customItem.Click += ActionCustomListItem_Click;
            customItem.MouseDown += ActionCustomListView_MouseDown;
            customItem.KeyDown += ActionFlowLayoutPanel_KeyDown;

            customItem.Width = actionPanel.ClientSize.Width - actionPanel.Padding.Left - actionPanel.Padding.Right - 2;

            actionPanel.Controls.Add(customItem);
            AppThemeHelper.ApplyThemeToControl(appTheme, customItem, 3);
        }

        private void ActionCustomListItem_Click(object sender, EventArgs e)
        {
            Logger.Log("Click from: " + sender, TraceEventType.Verbose);
            SetSelectedAction((sender as ActionCustomListItem).Action);
        }

        private void SetSelectedAction(Action action)
        {
            foreach (ActionCustomListItem item in actionPanel.Controls.OfType<ActionCustomListItem>())
            {
                item.Selected = item.Action == action;
            }

            try
            {
                selectedActionIndex = actionPanel.Controls.GetChildIndex(actionPanel.Controls.OfType<ActionCustomListItem>().First(x => x.Action == action));
            }
            catch (Exception)
            {
                selectedActionIndex = -1;
            }
            UpdateUIState();
            Logger.Log("Selected action index: " + selectedActionIndex, TraceEventType.Verbose);
        }

        private void SetSelectedActionIndex(int index)
        {
            Action action = (index < 0) || (index >= mainFormController.GetSequence().Actions.Count()) ? null : mainFormController.GetSequence().Actions.ElementAt(index);
            SetSelectedAction(action);
        }

        private Action GetSelectedAction()
        {
            Action action = (selectedActionIndex < 0) || (selectedActionIndex >= mainFormController.GetSequence().Actions.Count()) ? null : mainFormController.GetSequence().Actions.ElementAt(selectedActionIndex);
            return action;
        }

        private void LoadSequenceNames()
        {
            sequenceComboBox.Items.Clear();
            foreach (var sequenceName in mainFormController.GetAllSequenceNames())
            {
                sequenceComboBox.Items.Add(sequenceName);
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void SaveAsSequence()
        {
            mainFormController.SaveAsSequence();
            if (mainFormController.GetCurrentSequenceName() != null)
            {
                LoadSequenceNames();
                sequenceComboBox.SelectedItem = mainFormController.GetCurrentSequenceName();
            }
        }

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

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsSequence();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSequence();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopSequence();
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetSettingValue(Settings.SETTING_LANGUAGE, "English", SettingsType.General);
            LoadSettings();
        }

        private void FrenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetSettingValue(Settings.SETTING_LANGUAGE, "Français", SettingsType.General);
            LoadSettings();
        }

        private void ShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.OpenSettingsForm(SettingsType.Hotkeys);
            LoadSettings();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.OpenSettingsForm();
            LoadSettings();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void SequenceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSequenceName = sequenceComboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedSequenceName))
            {
                if (!SequenceController.GetIsSaved())
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

        private void AddActionToolStripButton_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        private void AddAction()
        {
            if (SequenceController.GetIsRunning())
                return;

            mainFormController.AddAction();
            LoadActions();
            UpdateUIState();
        }

        private void StartBotToolStripButton_Click(object sender, EventArgs e)
        {
            StartSequence();
        }

        private void DeleteActionToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        private void DeleteAction()
        {
            if (selectedActionIndex < 0)
                return;

            mainFormController.RemoveAction(actionPanel.Controls.OfType<ActionCustomListItem>().ElementAt(selectedActionIndex).Action);
            actionPanel.Controls.RemoveAt(selectedActionIndex);
            SetSelectedAction(null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SequenceController.GetIsSaved())
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

        private void EditActionToolStripButton_Click(object sender, EventArgs e)
        {
            EditAction();
        }

        private void EditAction()
        {
            if (selectedActionIndex < 0)
                return;

            mainFormController.UpdateAction(actionPanel.Controls.OfType<ActionCustomListItem>().ElementAt(selectedActionIndex).Action);
            LoadActions();
            SetSelectedActionIndex(selectedActionIndex);
        }

        private void StopBotToolStripButton_Click(object sender, EventArgs e)
        {
            StopSequence();
        }

        private void SaveSequenceToolStripButton_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        private void PauseBotToolStripButton_Click(object sender, EventArgs e)
        {
            mainFormController.TogglePause();
        }

        private void DeleteSequenceToolStripButton_Click(object sender, EventArgs e)
        {
            if (sequenceComboBox.SelectedItem == null)
                return;

            DeleteSequence();
        }

        private void StartSequence()
        {
            mainFormController.StartSequence();
        }

        private void StopSequence()
        {
            mainFormController.StopSequence();
        }

        private void DeleteSequence()
        {
            string sequenceName = sequenceComboBox.SelectedItem.ToString();

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

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                mainFormController.ExecuteHotkey(m.LParam);
                return;
            }
        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.TogglePause();
        }

        private void AddActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        private void EditActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAction();
        }

        private void DeleteActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        private void DeleteSequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSequence();
        }

        private void MoveActionUp()
        {
            if (selectedActionIndex > 0 && selectedActionIndex < actionPanel.Controls.Count)
            {
                Action action = GetSelectedAction();
                mainFormController.MoveAction(selectedActionIndex - 1, action);
                actionPanel.Controls.SetChildIndex(actionPanel.Controls[selectedActionIndex], selectedActionIndex - 1);
                SetSelectedAction(action);
            }
        }

        private void MoveActionDown()
        {
            if (selectedActionIndex < actionPanel.Controls.Count - 1 && selectedActionIndex >= 0)
            {
                Action action = GetSelectedAction();
                mainFormController.MoveAction(selectedActionIndex + 1, action);
                actionPanel.Controls.SetChildIndex(actionPanel.Controls[selectedActionIndex], selectedActionIndex + 1);
                SetSelectedAction(action);
            }
        }

        private void MoveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveActionUp();
        }

        private void MoveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveActionDown();
        }

        private void ActionCustomListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Logger.Log("MouseDown Right from: " + sender, TraceEventType.Verbose);
                if (sender is ActionCustomListItem)
                {
                    ActionCustomListItem item = (ActionCustomListItem)sender;
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
            }
        }

        /// <summary>
        /// Start drag and drop
        /// </summary>
        private void ActionFlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionCustomListItem)))
            {
                draggedItemIndex = actionPanel.Controls.GetChildIndex((Control)e.Data.GetData(typeof(ActionCustomListItem)));
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
                Point clientPoint = actionPanel.PointToClient(new Point(e.X, e.Y));
                Control targetControl = actionPanel.GetChildAtPoint(clientPoint);
                int targetIndex = targetControl != null ? actionPanel.Controls.GetChildIndex(targetControl) : actionPanel.Controls.Count - 1;

                // Move the item to the new position
                Logger.Log($"Moving item from {draggedItemIndex} to {targetIndex}", TraceEventType.Verbose);
                actionPanel.Controls.SetChildIndex(droppedItem, targetIndex);
                mainFormController.MoveAction(targetIndex, droppedItem.Action);

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
                Point clientPoint = actionPanel.PointToClient(new Point(e.X, e.Y));
                Control targetControl = actionPanel.GetChildAtPoint(clientPoint);
                int targetIndex = targetControl != null ? actionPanel.Controls.GetChildIndex(targetControl) : insertionIndex;

                if (targetIndex >= actionPanel.Controls.Count)
                {
                    targetIndex = actionPanel.Controls.Count - 1;
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
            actionPanel.Invalidate();
        }

        /// <summary>
        /// Draws the insertion line
        /// </summary>
        private void ActionFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            if (insertionIndex >= 0 && insertionIndex <= actionPanel.Controls.Count)
            {
                Control control = (insertionIndex < actionPanel.Controls.Count) ? actionPanel.Controls[insertionIndex] : null;

                int y = insertionIndex < draggedItemIndex ? control.Top - 4 : control.Bottom + 4;

                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawLine(pen, new Point(0, y), new Point(actionPanel.ClientSize.Width, y));
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

        void ActionFlowLayoutPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteAction();
            }
        }

        private void ActionPanel_ClientSizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in actionPanel.Controls)
            {
                control.Width = actionPanel.ClientSize.Width - actionPanel.Padding.Left - actionPanel.Padding.Right - 2;
            }
        }

        private void ActionListBoxContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // Disable the context menu if no action is selected
            if (!moveActionDownContextMenuItem.Enabled && 
                !moveActionUpContextMenuItem.Enabled && 
                !deleteActionContextMenuItem.Enabled)
                e.Cancel = true;
        }

        private void DarkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsController.SetSettingValue(Settings.SETTING_THEME, SettingsController.GetSelectedThemeValueFromResource(Resources.Strings.LabelThemeDark), SettingsType.General);
            LoadThemeSettings();
        }

        private void LightThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsController.SetSettingValue(Settings.SETTING_THEME, SettingsController.GetSelectedThemeValueFromResource(Resources.Strings.LabelThemeLight), SettingsType.General);
            LoadThemeSettings();
        }

        private void AutoThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsController.SetSettingValue(Settings.SETTING_THEME, SettingsController.GetSelectedThemeValueFromResource(Resources.Strings.LabelThemeAuto), SettingsType.General);
            LoadThemeSettings();
        }
    }
}