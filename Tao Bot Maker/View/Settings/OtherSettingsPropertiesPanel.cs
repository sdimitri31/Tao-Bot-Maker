using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View.Setting
{
    public partial class OtherSettingsPropertiesPanel : UserControl, ISettingsPropertiesPanel
    {
        public OtherSettingsPropertiesPanel()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            saveLogCheckBox.Checked = SettingsController.GetSettingValue<bool>(Settings.SETTING_SAVELOG);
        }

        public void SaveSettings()
        {
            SettingsController.SetSettingValue(Settings.SETTING_SAVELOG, saveLogCheckBox.Checked, SettingsType.Other);
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.Other;
        }
    }
}
