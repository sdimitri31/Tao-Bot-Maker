using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View.Setting
{
    public partial class GeneralSettingsPropertiesPanel : UserControl, ISettingsPropertiesPanel
    {
        public GeneralSettingsPropertiesPanel()
        {
            InitializeComponent();
            InitializeLanguage();
            InitializeTheme();
            UpdateUI();
        }

        private void UpdateUI()
        {
            languageLabel.Text = Resources.Strings.LabelLanguage;
            themeLabel.Text = Resources.Strings.LabelTheme;
        }

        public void InitializeLanguage()
        {
            this.languageComboBox.Items.AddRange(new object[] {
                "English",
                "Français"
            });
        }

        public void InitializeTheme()
        {
            this.themeComboBox.Items.AddRange(new object[] {
                new DisplayItem<string>("Auto", Resources.Strings.LabelThemeAuto),
                new DisplayItem<string>("Light", Resources.Strings.LabelThemeLight),
                new DisplayItem<string>("Dark", Resources.Strings.LabelThemeDark)
            });
        }

        public void LoadSettings()
        {
            languageComboBox.SelectedItem = SettingsController.GetSettingValue<string>(Settings.SETTING_LANGUAGE);

            themeComboBox.SelectedItem = themeComboBox.Items.Cast<DisplayItem<string>>().First(item => item.Value == SettingsController.GetSettingValue<string>(Settings.SETTING_THEME));
        }

        public void SaveSettings()
        {
            SettingsController.SetSettingValue(Settings.SETTING_LANGUAGE, languageComboBox.SelectedItem.ToString(), SettingsType.General);

            if (themeComboBox.SelectedItem is DisplayItem<string> selectedItem)
            {
                SettingsController.SetSettingValue(Settings.SETTING_THEME, selectedItem.Value, SettingsType.General);
            }
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.General;
        }
    }
}
