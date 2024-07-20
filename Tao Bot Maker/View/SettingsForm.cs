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
            ApplyTheme();
            panels = new List<UserControl>();
            SelectedSettingsType = selectedSettingsType;
            LoadAllSettingsType();
            LoadSettings();
            SetSelectedSettingsTypeFlowLayout(SelectedSettingsType);
            SetPropertiesPanel(SelectedSettingsType);
        }

        private void ApplyTheme()
        {
            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
            appTheme = AppThemeHelper.GetAppThemeFromName(theme);
            AppThemeHelper.ApplyTheme(appTheme, this);
        }

        private void UpdateUI()
        {
            this.Text = Resources.Strings.FormTitleSettings;

            okButton.Text = Resources.Strings.ButtonOk;
            cancelButton.Text = Resources.Strings.ButtonCancel;
        }

        private void AddCustomItem(SettingsType settingsType)
        {
            CustomItemControl<SettingsType> customItem = new CustomItemControl<SettingsType>
            {
                Item = new CustomItem<SettingsType>(settingsType, GetSettingsTypeDisplayName(settingsType), GetSettingsTypeIcon(settingsType)),
                Selected = false
            };
            customItem.Width = settingsTypeFlowLayoutPanel.Width - 16;
            customItem.Click += SettingsTypeCustomListItem_Click;

            customItem.Margin = new Padding(customItem.Margin.Left, customItem.Margin.Top, customItem.Margin.Right, 8);

            settingsTypeFlowLayoutPanel.Controls.Add(customItem);
            AppThemeHelper.ApplyThemeToControl(appTheme, customItem, 2);
        }

        private void SettingsTypeCustomListItem_Click(object sender, EventArgs e)
        {
            CustomItemControl<SettingsType> item = sender as CustomItemControl<SettingsType>;
            if (item != null)
            {
                SelectedSettingsType = item.Data;
                SetPropertiesPanel(SelectedSettingsType);
                SetSelectedSettingsTypeFlowLayout(SelectedSettingsType);
            }
        }

        private void SetSelectedSettingsTypeFlowLayout(SettingsType settingsType)
        {
            foreach (CustomItemControl<SettingsType> item in settingsTypeFlowLayoutPanel.Controls.OfType<CustomItemControl<SettingsType>>())
            {
                item.Selected = item.Data == settingsType;
            }
        }

        private void SetPropertiesPanel(SettingsType settingsType)
        {
            foreach (UserControl panel in panels)
            {
                panel.Visible = (panel as ISettingsPropertiesPanel).GetType() == settingsType;
            }
        }

        private void LoadAllSettingsType()
        {
            foreach (SettingsType settingsType in Enum.GetValues(typeof(SettingsType)))
            {
                AddPropertiesPanel(settingsType);
                AddCustomItem(settingsType);
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

        private Image GetSettingsTypeIcon(SettingsType setttingsType)
        {
            switch (setttingsType)
            {
                case SettingsType.Other:
                    return Resources.Images.SettingTypeOther;
                case SettingsType.Hotkeys:
                    return Resources.Images.SettingTypeHotkey;
                case SettingsType.General:
                    return Resources.Images.SettingTypeGeneral;
                default:
                    return Resources.Images.SettingTypeGeneral;
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
                panel.Width = settingsPropertiesPanel.Width;
                panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                settingsPropertiesPanel.Controls.Add(panel);
                panels.Add(panel);
                AppThemeHelper.ApplyThemeToControl(appTheme, settingsPropertiesPanel, 3);
            }
        }

        private void ShowPanel(SettingsType settingsType)
        {
            foreach (UserControl panel in panels)
            {
                panel.Visible = (panel as ISettingsPropertiesPanel).GetType() == settingsType;
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
