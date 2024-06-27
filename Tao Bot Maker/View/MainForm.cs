﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private MainFormController mainFormController;

        public MainForm()
        {
            InitializeComponent();
            Logger.LogMessageReceived += OnLogMessageReceived;

            mainFormController = new MainFormController();
            LoadSettings();
            LoadSequenceNames();

            Logger.Log("Initialized");
        }

        private void New()
        {
            mainFormController = new MainFormController();
            LoadSequenceNames();
            LoadActions();
        }

        private void OnLogMessageReceived(string message, TraceEventType level)
        {
            // Mettre à jour la TextBox eventLogTextBox avec les messages de log
            if (eventLogTextBox.InvokeRequired)
            {
                eventLogTextBox.Invoke((MethodInvoker)delegate {
                    eventLogTextBox.AppendText(message + Environment.NewLine);
                });
            }
            else
            {
                eventLogTextBox.AppendText(message + Environment.NewLine);
            }
        }

        private void LoadSettings()
        {
            string language = mainFormController.GetSettingValue<string>(Settings.SETTING_LANGUAGE);
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

            string theme = mainFormController.GetSettingValue<string>(Settings.SETTING_THEME);
            autoToolStripMenuItem.Checked = false;
            lightToolStripMenuItem.Checked = false;
            darkToolStripMenuItem.Checked = false;
            switch (theme) {
                case "Auto":
                    autoToolStripMenuItem.Checked = true;
                    break;
                case "Light":
                    lightToolStripMenuItem.Checked = true;
                    break;
                case "Dark":
                    darkToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private async void LoadSequence(string sequenceName)
        {
            // Annuler toute opération en cours
            cancellationTokenSource.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            try
            {
                await mainFormController.LoadSequenceAsync(sequenceName, token);
                var loadedSequence = mainFormController.GetCurrentSequence();
                if (loadedSequence != null)
                {
                    LoadActions();
                }
            }
            catch (OperationCanceledException)
            {
                // Chargement annulé, on peut ignorer cette exception
            }
            catch (Exception ex)
            {
                // Gérer d'autres exceptions si nécessaire
                MessageBox.Show($"Erreur lors du chargement de la séquence : {ex.Message}");
            }
        }

        private void LoadActions()
        {
            actionsListBox.Items.Clear();
            foreach (var action in mainFormController.GetCurrentSequence().Actions)
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
            mainFormController.SaveAsCurrentSequence();
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
                mainFormController.SaveCurrentSequence();
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
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                LoadSequence(selectedSequenceName);
            }
        }

        private void AddActionToolStripButton_Click(object sender, EventArgs e)
        {
            mainFormController.AddAction();
            LoadActions();
        }

        private async void StartBotToolStripButton_Click(object sender, EventArgs e)
        {
            var sequence = mainFormController.GetCurrentSequence();
            if (sequence != null)
            {
                await mainFormController.ExecuteSequence(sequence);
            }
        }

        private void DeleteActionToolStripButton_Click(object sender, EventArgs e)
        {
            mainFormController.RemoveActionFromCurrentSequence((Action)actionsListBox.SelectedItem);
            LoadActions();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.LogMessageReceived -= OnLogMessageReceived;
        }

        private void EditActionToolStripButton_Click(object sender, EventArgs e)
        {
            mainFormController.UpdateAction((Action)actionsListBox.SelectedItem);
            LoadActions();
        }

        private void StopBotToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveSequenceToolStripButton_Click(object sender, EventArgs e)
        {
            SaveSequence();
        }

        private void DeleteSequenceToolStripButton_Click(object sender, EventArgs e)
        {
            if(mainFormController.RemoveSequence())
                New();
        }
    }
}