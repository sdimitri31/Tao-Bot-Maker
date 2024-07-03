﻿using System;
using System.Diagnostics;
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

        private int previousSelectedIndex = -1;

        public MainForm()
        {
            InitializeComponent();
            //_ = new DarkModeCS(this, false, true);

            Logger.LogMessageReceived += OnLogMessageReceived;
            CultureManager.CultureChanged += UpdateUI;
            SequenceController.RunningStateChanged += UpdateUIState;
            SequenceController.SavedStatusChanged += UpdateUI;

            mainFormController = new MainFormController(this);

            LoadSettings();
            LoadSequenceNames();

            Logger.Log(Resources.Strings.InfoMessageProgramReady, TraceEventType.Information);
        }


        private void New()
        {
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

            sequenceComboBox.SelectedIndex = -1;
            mainFormController.NewSequence();
            LoadActions();
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
            string unsaved = SequenceController.GetIsSaved() ? "" : " - Unsaved changes";
            this.Text = Resources.Strings.FormTitleMain + unsaved;

            fileToolStripMenuItem.Text = Resources.Strings.MenuFile;
            newToolStripMenuItem.Text = Resources.Strings.MenuFileNew;
            saveToolStripMenuItem.Text = Resources.Strings.MenuFileSave;
            saveAsToolStripMenuItem.Text = Resources.Strings.MenuFileSaveAs;
            exitToolStripMenuItem.Text = Resources.Strings.MenuFileExit;

            botToolStripMenuItem.Text = Resources.Strings.MenuBot;
            startToolStripMenuItem.Text = Resources.Strings.MenuBotStart;
            pauseToolStripMenuItem.Text = SequenceController.GetIsPaused() ? Resources.Strings.MenuBotResume : Resources.Strings.MenuBotPause;
            stopToolStripMenuItem.Text = Resources.Strings.MenuBotStop;

            settingsToolStripMenuItem.Text = Resources.Strings.MenuSettings;
            languageToolStripMenuItem.Text = Resources.Strings.MenuSettingsLanguage;
            shortcutsToolStripMenuItem.Text = Resources.Strings.MenuSettingsShortcuts;
            themeToolStripMenuItem.Text = Resources.Strings.MenuSettingsTheme;
            settingsToolStripMenuItem1.Text = Resources.Strings.MenuSettings;
            aboutToolStripMenuItem.Text = Resources.Strings.MenuAbout;

            startBotToolStripButton.Text = Resources.Strings.MenuBotStart;
            pauseBotToolStripButton.Text = Resources.Strings.MenuBotPause;
            stopBotToolStripButton.Text = Resources.Strings.MenuBotStop;
        }

        private void UpdateUIState()
        {
            bool isRunning = SequenceController.GetIsRunning();
            bool isPaused = SequenceController.GetIsPaused();

            newToolStripMenuItem.Enabled = !isRunning;
            saveToolStripMenuItem.Enabled = !isRunning;
            saveAsToolStripMenuItem.Enabled = !isRunning;

            startToolStripMenuItem.Enabled = !isRunning;
            pauseToolStripMenuItem.Enabled = isRunning;
            pauseToolStripMenuItem.Text = isPaused ? Resources.Strings.MenuBotResume : Resources.Strings.MenuBotPause;
            stopToolStripMenuItem.Enabled = isRunning;

            addActionToolStripButton.Enabled = !isRunning;
            editActionToolStripButton.Enabled = !isRunning;
            deleteActionToolStripButton.Enabled = !isRunning;

            startBotToolStripButton.Visible = !isRunning || isPaused;
            startBotToolStripButton.Text = isPaused ? Resources.Strings.MenuBotResume : Resources.Strings.MenuBotStart;
            pauseBotToolStripButton.Visible = isRunning && !isPaused;
            stopBotToolStripButton.Enabled = isRunning;

            sequenceComboBox.Enabled = !isRunning;
            saveSequenceToolStripButton.Enabled = !isRunning;
            deleteSequenceToolStripButton.Enabled = !isRunning;
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
            actionsListBox.Items.Clear();

            if (mainFormController.GetSequence() == null)
                return;

            foreach (var action in mainFormController.GetSequence().Actions)
            {
                actionsListBox.Items.Add(action);
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
                        sequenceComboBox.SelectedIndex = previousSelectedIndex;
                        sequenceComboBox.SelectedIndexChanged += SequenceComboBox_SelectedIndexChanged;
                        return;
                    }
                }

                previousSelectedIndex = sequenceComboBox.SelectedIndex;
                LoadSequenceAsync(selectedSequenceName);
            }
        }

        private void AddActionToolStripButton_Click(object sender, EventArgs e)
        {
            mainFormController.AddAction();
            LoadActions();
        }

        private void StartBotToolStripButton_Click(object sender, EventArgs e)
        {
            StartSequence();
        }

        private void DeleteActionToolStripButton_Click(object sender, EventArgs e)
        {
            mainFormController.RemoveAction((Action)actionsListBox.SelectedItem);
            LoadActions();
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
            mainFormController.StopSequence();
            mainFormController.UnregisterHotkeys();
            Logger.LogMessageReceived -= OnLogMessageReceived;
            CultureManager.CultureChanged -= UpdateUI;
            SequenceController.RunningStateChanged -= UpdateUIState;
            SequenceController.SavedStatusChanged -= UpdateUI;
        }

        private void EditActionToolStripButton_Click(object sender, EventArgs e)
        {
            mainFormController.UpdateAction((Action)actionsListBox.SelectedItem);
            LoadActions();
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

            string sequenceName = sequenceComboBox.SelectedItem.ToString();
            DeleteSequence(sequenceName);
        }

        private void StartSequence()
        {
            mainFormController.StartSequence();
        }

        private void StopSequence()
        {
            mainFormController.StopSequence();
        }

        private void DeleteSequence(string sequenceName)
        {
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
            const int WM_SETTINGCHANGE = 0x001A;

            if (m.Msg == WM_SETTINGCHANGE)
            {
                //_ = new DarkModeCS(this, false);
            }

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
    }
}