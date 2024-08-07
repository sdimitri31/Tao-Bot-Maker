﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View.Setting
{
    public partial class OtherSettingsPropertiesPanel : UserControl, ISettingsPropertiesPanel
    {
        private List<CheckBox> showLogCheckBoxes;
        private List<CheckBox> saveLogCheckBoxes;

        public OtherSettingsPropertiesPanel()
        {
            InitializeComponent();
            InitializeCheckBoxes();
            UpdateSaveLogLevelPanelState();
            UpdateUI();
        }

        private void UpdateUI()
        {
            showLogLevelLabel.Text = Resources.Strings.LabelShowLogLevel;
            saveLogLevelLabel.Text = Resources.Strings.LabelSaveLogLevel;
            saveLogLevelWarningCheckBox.Text = Resources.Strings.LabelWarning;
            saveLogLevelErrorCheckBox.Text = Resources.Strings.LabelError;
            saveLogLevelDebugCheckBox.Text = Resources.Strings.LabelDebug;
            saveLogLevelInformationCheckBox.Text = Resources.Strings.LabelInformation;
            showLogLevelWarningCheckBox.Text = Resources.Strings.LabelWarning;
            showLogLevelErrorCheckBox.Text = Resources.Strings.LabelError;
            showLogLevelDebugCheckBox.Text = Resources.Strings.LabelDebug;
            showLogLevelInformationCheckBox.Text = Resources.Strings.LabelInformation;
            saveLogCheckBox.Text = Resources.Strings.LabelSaveLogs;
            openLogFolderButton.Text = Resources.Strings.ButtonOpenLogsFolder;
        }

        private void InitializeCheckBoxes()
        {
            showLogCheckBoxes = new List<CheckBox>
            {
                showLogLevelInformationCheckBox,
                showLogLevelWarningCheckBox,
                showLogLevelErrorCheckBox,
                showLogLevelDebugCheckBox
            };

            saveLogCheckBoxes = new List<CheckBox>
            {
                saveLogLevelInformationCheckBox,
                saveLogLevelWarningCheckBox,
                saveLogLevelErrorCheckBox,
                saveLogLevelDebugCheckBox
            };
        }

        private void SetCheckboxesFromFlag(List<CheckBox> checkBoxes, int flag)
        {
            checkBoxes[0].Checked = (flag & 1) != 0;
            checkBoxes[1].Checked = (flag & 2) != 0;
            checkBoxes[2].Checked = (flag & 4) != 0;
            checkBoxes[3].Checked = (flag & 8) != 0;
        }

        private int GetFlagFromCheckboxes(List<CheckBox> checkBoxes)
        {
            int flag = 0;
            if (checkBoxes[0].Checked) flag |= 1;
            if (checkBoxes[1].Checked) flag |= 2;
            if (checkBoxes[2].Checked) flag |= 4;
            if (checkBoxes[3].Checked) flag |= 8;
            return flag;
        }

        private void UpdateSaveLogLevelPanelState()
        {
            saveLogLevelPanel.Enabled = saveLogCheckBox.Checked;
        }

        public void LoadSettings()
        {
            saveLogCheckBox.Checked = SettingsController.GetSettingValue<bool>(Settings.SETTING_SAVELOG);

            SetCheckboxesFromFlag(showLogCheckBoxes, SettingsController.GetSettingValue<int>(Settings.SETTING_SHOWLOGLEVEL));
            SetCheckboxesFromFlag(saveLogCheckBoxes, SettingsController.GetSettingValue<int>(Settings.SETTING_SAVELOGLEVEL));
        }

        public void SaveSettings()
        {
            SettingsController.SetSettingValue(Settings.SETTING_SAVELOG, saveLogCheckBox.Checked, SettingsType.Other);

            SettingsController.SetSettingValue(Settings.SETTING_SHOWLOGLEVEL, GetFlagFromCheckboxes(showLogCheckBoxes), SettingsType.Other);
            SettingsController.SetSettingValue(Settings.SETTING_SAVELOGLEVEL, GetFlagFromCheckboxes(saveLogCheckBoxes), SettingsType.Other);
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.Other;
        }

        private void OpenLogFolderButton_Click(object sender, System.EventArgs e)
        {
            Directory.CreateDirectory(Logger.FOLDER_NAME);
            Process.Start("explorer.exe", Logger.FOLDER_NAME);
        }

        private void SaveLogCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateSaveLogLevelPanelState();
        }
    }
}
