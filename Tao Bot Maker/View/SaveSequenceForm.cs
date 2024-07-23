using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class SaveSequenceForm : Form
    {
        private AppTheme appTheme;
        private readonly SequenceController sequenceController = new SequenceController();
        private readonly List<string> sequencesNames = new List<string>();

        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public SaveSequenceForm()
        {
            InitializeComponent();
            ResizeColumns();
            sequencesNames = sequenceController.GetAllSequenceNames();

            FillSequenceList();
            LoadThemeSettings();
            UpdateUI();
        }

        private void LoadThemeSettings()
        {
            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
            appTheme = AppThemeHelper.GetAppThemeFromName(theme);
            AppThemeHelper.ApplyTheme(appTheme, this);
        }
        private void UpdateUI()
        {
            Text = Resources.Strings.FormTitleSaveSequence;
            openSequencesFolderButton.Text = Resources.Strings.ButtonOpenSequencesFolder;
            sequenceNameLabel.Text = Resources.Strings.LabelSequenceName;
            savedSequencesLabel.Text = Resources.Strings.LabelSavedSequences;
            okButton.Text = Resources.Strings.ButtonSave;
            cancelButton.Text = Resources.Strings.ButtonCancel;
        }

        private void ResizeColumns()
        {
            sequenceNameColumnHeader.Width = savedSequencesListView.Width - 8;
        }

        private void FillSequenceList()
        {
            savedSequencesListView.Items.Clear();

            foreach (var sequenceName in sequencesNames)
            {
                var item = new ListViewItem(sequenceName);
                savedSequencesListView.Items.Add(item);
            }
        }

        private void SavedSequencesListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (savedSequencesListView.SelectedItems.Count > 0)
            {
                FileName = savedSequencesListView.SelectedItems[0].Text;
                sequenceNameTextBox.Text = FileName;
            }
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            FileName = sequenceNameTextBox.Text;

            if (FileName == "")
            {
                string message = Resources.Strings.ErrorMessageEmptySequenceName;
                string caption = Resources.Strings.Error;
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sequencesNames.Contains(FileName))
            {
                string messageFileExists = string.Format(Resources.Strings.InfoMessageFileExists, FileName);
                string questionReplace = Resources.Strings.QuestionMessageReplace;
                string message = messageFileExists + Environment.NewLine + questionReplace;

                string title = Resources.Strings.CaptionMessageFileExists;
                var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void OpenSequencesFolderButton_Click(object sender, System.EventArgs e)
        {
            Directory.CreateDirectory(sequenceController.GetSequenceFolder());
            Process.Start("explorer.exe", sequenceController.GetSequenceFolder());
        }

        private void SavedSequencesListView_Resize(object sender, System.EventArgs e)
        {
            ResizeColumns();
        }
    }
}
