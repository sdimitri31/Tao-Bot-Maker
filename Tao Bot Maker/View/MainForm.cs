using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;
using Settings = Tao_Bot_Maker.Model.Settings;

namespace Tao_Bot_Maker.View
{
    public partial class MainForm : Form
    {
        private readonly MainFormController mainFormController;

        private Point dragStartPoint;
        private int draggedIndex = -1;
        private int insertIndex = -2;

        private int previousActionSelectedIndex = -1;
        private int previousSequenceSelectedIndex = -1;

        public MainForm()
        {
            InitializeComponent();

            Logger.LogMessageReceived += OnLogMessageReceived;
            CultureManager.CultureChanged += UpdateUI;
            SequenceController.RunningStateChanged += UpdateUIState;
            SequenceController.SavedStatusChanged += UpdateUI;

            mainFormController = new MainFormController(this);

            LoadSettings();
            LoadSequenceNames();

            // Configurer les événements pour le drag and drop
            actionsListBox.AllowDrop = true;
            actionsListBox.MouseDown += ActionsListBox_MouseDown;
            actionsListBox.DragOver += ActionsListBox_DragOver;
            actionsListBox.DragDrop += ActionsListBox_DragDrop;
            actionsListBox.DragLeave += ActionsListBox_DragLeave;
            actionsListBox.MouseMove += ActionsListBox_MouseMove;
            actionsListBox.DrawItem += ActionsListBox_DrawItem;
            actionsListBox.DrawMode = DrawMode.OwnerDrawFixed;
            SetDoubleBuffered(actionsListBox);

            Logger.Log(Resources.Strings.InfoMessageProgramReady, TraceEventType.Information);
        }

        private void SetDoubleBuffered(Control control)
        {
            if (SystemInformation.TerminalServerSession)
                return;

            PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            aProp.SetValue(control, true, null);
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

        private void UpdateUI()
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
            themeToolStripMenuItem.Text = Resources.Strings.MenuSettingsTheme;
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
            editActionToolStripMenuItem.Enabled = !isRunning && (actionsListBox.SelectedIndex != -1);
            deleteActionToolStripMenuItem.Enabled = !isRunning && (actionsListBox.SelectedIndex != -1);
            moveActionUpToolStripMenuItem.Enabled = !isRunning && (actionsListBox.SelectedIndex > 0);
            moveActionDownToolStripMenuItem.Enabled = !isRunning && (actionsListBox.SelectedIndex != -1) && (actionsListBox.SelectedIndex < actionsListBox.Items.Count - 1);
            deleteSequenceToolStripMenuItem.Enabled = !isRunning && (sequenceComboBox.SelectedIndex != -1);

            // BOT
            startToolStripMenuItem.Enabled = !isRunning;
            pauseToolStripMenuItem.Enabled = isRunning;
            pauseToolStripMenuItem.Text = isPaused ? Resources.Strings.MenuBotResume : Resources.Strings.MenuBotPause;
            stopToolStripMenuItem.Enabled = isRunning;

            // ACTION BUTTON
            addActionToolStripButton.Enabled = !isRunning;
            editActionToolStripButton.Enabled = !isRunning && (actionsListBox.SelectedIndex != -1);
            deleteActionToolStripButton.Enabled = !isRunning && (actionsListBox.SelectedIndex != -1);

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

        private void ActionsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = actionsListBox.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    actionsListBox.SelectedIndex = index;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                dragStartPoint = e.Location;
                draggedIndex = actionsListBox.IndexFromPoint(e.Location);
                Logger.Log("Drag started at index " + draggedIndex + "", TraceEventType.Verbose);
            }
        }

        private void ActionsListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // Si la distance de drag est suffisante, démarrer le drag and drop
                if (Math.Abs(e.X - dragStartPoint.X) >= SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - dragStartPoint.Y) >= SystemInformation.DragSize.Height)
                {
                    if (draggedIndex >= 0 && draggedIndex < actionsListBox.Items.Count)
                    {
                        actionsListBox.DoDragDrop(actionsListBox.Items[draggedIndex], DragDropEffects.Move);
                    }
                }
            }
        }

        private void ActionsListBox_DragOver(object sender, DragEventArgs e)
        {
            // Permettre le drop si le format de données est correct
            if (e.Data.GetDataPresent(typeof(CustomDisplayItem<Action>)))
            {
                e.Effect = DragDropEffects.Move;

                Point point = actionsListBox.PointToClient(new Point(e.X, e.Y));
                int newIndex = actionsListBox.IndexFromPoint(point);

                if (newIndex != insertIndex)
                {
                    insertIndex = newIndex;
                    actionsListBox.Invalidate(); // Redessiner seulement si l'index de l'insertion a changé
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ActionsListBox_DragDrop(object sender, DragEventArgs e)
        {
            // Obtenir l'élément draggué et l'index de drop
            if (e.Data.GetDataPresent(typeof(CustomDisplayItem<Action>)))
            {
                CustomDisplayItem<Action> draggedAction = (CustomDisplayItem<Action>)e.Data.GetData(typeof(CustomDisplayItem<Action>));
                Action action = draggedAction.Value;
                Point point = actionsListBox.PointToClient(new Point(e.X, e.Y));
                int newIndex = actionsListBox.IndexFromPoint(point);

                Logger.Log("Drag ended at index " + newIndex + "", TraceEventType.Verbose);

                if (newIndex == -1)
                {
                    newIndex = actionsListBox.Items.Count;
                }

                if (newIndex != draggedIndex)
                {
                    mainFormController.MoveAction(newIndex, action);
                    LoadActions();
                }
            }

            // Réinitialiser l'indicateur de position
            insertIndex = -2;
            actionsListBox.Invalidate();
        }

        private void ActionsListBox_DragLeave(object sender, EventArgs e)
        {
            // Réinitialiser l'indicateur de position
            insertIndex = -2;
            actionsListBox.Invalidate();
        }

        private void ActionsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();
            e.Graphics.DrawString(actionsListBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds);

            // Dessiner l'indicateur de position si nécessaire
            if (e.Index == insertIndex)
            {
                e.Graphics.DrawLine(Pens.Red, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);
            }

            // Si nous dessinons le dernier élément et que insertIndex est à -1, dessiner le trait sous l'élément
            if (e.Index == actionsListBox.Items.Count - 1 && insertIndex == -1)
            {
                e.Graphics.DrawLine(Pens.Red, e.Bounds.Left, e.Bounds.Bottom, e.Bounds.Right, e.Bounds.Bottom);
            }

            e.DrawFocusRectangle();
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

            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
            autoToolStripMenuItem.Checked = false;
            lightToolStripMenuItem.Checked = false;
            darkToolStripMenuItem.Checked = false;
            switch (theme)
            {
                case "Auto":
                    //ThemeManager.ApplyTheme(this, Themes.LightTheme);
                    autoToolStripMenuItem.Checked = true;
                    break;
                case "Light":
                    //ThemeManager.ApplyTheme(this, Themes.LightTheme);
                    lightToolStripMenuItem.Checked = true;
                    break;
                case "Dark":
                    //ThemeManager.ApplyTheme(this, Themes.DarkTheme);
                    darkToolStripMenuItem.Checked = true;
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
            actionsListBox.SelectedIndex = -1;
            actionsListBox.Items.Clear();

            if (mainFormController.GetSequence() == null)
                return;

            foreach (Action action in mainFormController.GetSequence().Actions)
            {
                actionsListBox.Items.Add(new CustomDisplayItem<Action>(action, action.ToString()));
            }
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

        private void AutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetSettingValue(Settings.SETTING_THEME, "Auto", SettingsType.General);
            LoadSettings();
        }

        private void DarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetSettingValue(Settings.SETTING_THEME, "Dark", SettingsType.General);
            LoadSettings();
        }

        private void LightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFormController.SetSettingValue(Settings.SETTING_THEME, "Light", SettingsType.General);
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
            if (actionsListBox.SelectedItem == null)
                return;

            mainFormController.RemoveAction((actionsListBox.SelectedItem as CustomDisplayItem<Action>).Value);
            LoadActions();
            UpdateUIState();
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
            CultureManager.CultureChanged -= UpdateUI;
            SequenceController.RunningStateChanged -= UpdateUIState;
            SequenceController.SavedStatusChanged -= UpdateUI;
        }

        private void EditActionToolStripButton_Click(object sender, EventArgs e)
        {
            EditAction();
        }

        private void EditAction()
        {
            if (actionsListBox.SelectedItem == null)
                return;

            mainFormController.UpdateAction((actionsListBox.SelectedItem as CustomDisplayItem<Action>).Value);
            LoadActions();
            UpdateUIState();
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

        private void ActionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIState();
        }

        private void MoveActionUp()
        {
            if (actionsListBox.SelectedIndex > 0)
            {
                previousActionSelectedIndex = actionsListBox.SelectedIndex;
                mainFormController.MoveAction(actionsListBox.SelectedIndex - 1, (actionsListBox.SelectedItem as CustomDisplayItem<Action>).Value);
                LoadActions();
                actionsListBox.SelectedIndex = previousActionSelectedIndex - 1;
            }
        }

        private void MoveActionDown()
        {
            if (actionsListBox.SelectedIndex < actionsListBox.Items.Count - 1)
            {
                previousActionSelectedIndex = actionsListBox.SelectedIndex;
                mainFormController.MoveAction(actionsListBox.SelectedIndex + 1, (actionsListBox.SelectedItem as CustomDisplayItem<Action>).Value);
                LoadActions();
                actionsListBox.SelectedIndex = previousActionSelectedIndex + 1;
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

        private void ActionsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                DeleteAction();
            }
        }
    }
}