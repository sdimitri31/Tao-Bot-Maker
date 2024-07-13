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
                Resources.Strings.LabelThemeAuto,
                Resources.Strings.LabelThemeLight,
                Resources.Strings.LabelThemeDark
            });
        }

        public void LoadSettings()
        {
            languageComboBox.SelectedItem = SettingsController.GetSettingValue<string>(Settings.SETTING_LANGUAGE);
            themeComboBox.SelectedItem = SettingsController.GetSelectedThemeResourceFromValue(SettingsController.GetSettingValue<string>(Settings.SETTING_THEME));
        }

        public void SaveSettings()
        {
            SettingsController.SetSettingValue(Settings.SETTING_LANGUAGE, languageComboBox.SelectedItem.ToString(), SettingsType.General);
            SettingsController.SetSettingValue(Settings.SETTING_THEME, SettingsController.GetSelectedThemeValueFromResource(themeComboBox.SelectedText), SettingsType.General);
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.General;
        }
    }
}
