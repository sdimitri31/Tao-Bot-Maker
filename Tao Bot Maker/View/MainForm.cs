using System;
using System.IO;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class MainForm : Form
    {
        private MainFormController mainFormController;

        public MainForm()
        {
            InitializeComponent();
            mainFormController = new MainFormController();
            LoadSequenceNames();
        }

        private void LoadSequence(string sequenceName)
        {
            mainFormController.LoadSequence(sequenceName);
            var loadedSequence = mainFormController.GetCurrentSequence();
            if (loadedSequence != null)
            {
                LoadActions();
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

        }

        private void SaveAsSequence()
        {
            if (mainFormController.GetCurrentSequence() != null)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string name = Path.GetFileNameWithoutExtension(dialog.FileName);
                        mainFormController.SaveAsCurrentSequence(name);
                        LoadSequenceNames();
                    }
                }
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

        }

        private void FrenchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DarkToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LightToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

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
            using (var addActionForm = new AddActionForm())
            {
                if (addActionForm.ShowDialog() == DialogResult.OK)
                {
                    mainFormController.AddActionToCurrentSequence(addActionForm.Action);
                    Console.WriteLine("Action : " + addActionForm.Action);
                    actionsListBox.Items.Add(addActionForm.Action);
                }
            }
        }

        private async void StartBotToolStripButton_Click(object sender, EventArgs e)
        {
            var sequence = mainFormController.GetCurrentSequence();
            if (sequence != null)
            {
                await mainFormController.ExecuteSequence(sequence);
            }
        }
    }
}