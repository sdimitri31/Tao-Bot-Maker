using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View.Setting;

namespace Tao_Bot_Maker.View
{
    public partial class SettingsForm : Form
    {
        private AppTheme appTheme;
        private SettingsType SelectedSettingsType { get; set; }

        private readonly List<UserControl> panels;

        public SettingsForm(SettingsType selectedSettingsType = SettingsType.General)
        {
            InitializeComponent();
            UpdateUI();
            panels = new List<UserControl>();
            FillSettingsForm();
            LoadSettings();

            LoadThemeSettings();
            settingsTypelistBox.SelectedItem = settingsTypelistBox.Items.Cast<CustomDisplayItem<SettingsType>>().First(item => item.Value == selectedSettingsType);
        }

        private void LoadThemeSettings()
        {
            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
            appTheme = AppThemeHelper.GetAppThemeFromName(theme);
            AppThemeHelper.ApplyTheme(appTheme, this, 1);
        }

        private void UpdateUI()
        {
            this.Text = Resources.Strings.FormTitleSettings;

            okButton.Text = Resources.Strings.ButtonOk;
            cancelButton.Text = Resources.Strings.ButtonCancel;
        }

        private void FillSettingsForm()
        {
            foreach (SettingsType settingsType in Enum.GetValues(typeof(SettingsType)))
            {
                string displayName = GetSettingsTypeDisplayName(settingsType);
                settingsTypelistBox.Items.Add(new CustomDisplayItem<SettingsType>(settingsType, displayName));
                AddPropertiesPanel(settingsType);
            }
        }

        private string GetSettingsTypeDisplayName(SettingsType setttingsType)
        {
            switch (setttingsType)
            {
                case SettingsType.Other:
                    return Resources.Strings.SettingsTypeOther;
                case SettingsType.Hotkeys:
                    return Resources.Strings.SettingsTypeHotkeys;
                case SettingsType.General:
                    return Resources.Strings.SettingsTypeGeneral;
                default:
                    return setttingsType.ToString();
            }
        }

        private void AddPropertiesPanel(SettingsType settingsType)
        {
            UserControl panel = null;

            switch (settingsType)
            {
                case SettingsType.General:
                    panel = new GeneralSettingsPropertiesPanel();
                    break;
                case SettingsType.Hotkeys:
                    panel = new HotkeySettingsPropertiesPanel();
                    break;
                case SettingsType.Other:
                    panel = new OtherSettingsPropertiesPanel();
                    break;
                default:
                    break;
            }

            if (panel != null)
            {
                panel.Location = new Point(0, 0);
                panel.Visible = false;
                settingsPropertiesPanel.Controls.Add(panel);
                panels.Add(panel);
            }
        }

        private void ShowPanel(SettingsType settingsType)
        {
            foreach (UserControl panel in panels)
            {
                panel.Visible = (panel as ISettingsPropertiesPanel).GetType() == settingsType;
            }
        }

        private void SettingsTypelistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (settingsTypelistBox.SelectedItem is CustomDisplayItem<SettingsType> selectedItem)
            {
                SelectedSettingsType = selectedItem.Value;
                ShowPanel(SelectedSettingsType);
            }
        }

        private void LoadSettings()
        {
            foreach (UserControl panel in panels)
            {
                (panel as ISettingsPropertiesPanel).LoadSettings();
            }
        }

        private void SaveSettings()
        {
            foreach (UserControl panel in panels)
            {
                (panel as ISettingsPropertiesPanel).SaveSettings();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
