using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View.Setting
{
    public partial class OtherSettingsPropertiesPanel : UserControl, ISettingsPropertiesPanel
    {
        public OtherSettingsPropertiesPanel()
        {
            InitializeComponent();
        }

        public void LoadSettings(Settings settings)
        {
            saveLogCheckBox.Checked = settings.GetSettingValue<bool>(Settings.SETTING_SAVELOG);
        }

        public void SaveSettings(Settings settings)
        {
            settings.SetSettingValue(Settings.SETTING_SAVELOG, saveLogCheckBox.Checked, SettingsType.Other);
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.Other;
        }
    }
}
