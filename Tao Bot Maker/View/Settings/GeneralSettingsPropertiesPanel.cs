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
            UpdateUI();
        }

        private void UpdateUI()
        {
            languageLabel.Text = Resources.Strings.LabelLanguage;
        }

        public void InitializeLanguage()
        {
            this.languageComboBox.Items.AddRange(new object[] {
                "English",
                "Français"
            });
        }

        public void LoadSettings()
        {
            languageComboBox.SelectedItem = SettingsController.GetSettingValue<string>(Settings.SETTING_LANGUAGE);
        }

        public void SaveSettings()
        {
            SettingsController.SetSettingValue(Settings.SETTING_LANGUAGE, languageComboBox.SelectedItem.ToString(), SettingsType.General);
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.General;
        }
    }
}
