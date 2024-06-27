using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker.Controller
{
    public class SettingsController
    {
        private Settings settings;

        public SettingsController()
        {
            settings = Settings.Load();
        }

        public void OpenSettingsForm(SettingsType settingsType = SettingsType.General)
        {
            var settingsForm = new SettingsForm(settings, settingsType);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                settings = settingsForm.Settings;
                settings.Save();
            }
        }

        public void SetSettingValue(string name, string value, SettingsType type)
        {
            settings.SetSettingValue(name, value, type);
            settings.Save();
        }

        public T GetSettingValue<T>(string name)
        {
            return settings.GetSettingValue<T>(name);
        }
    }
}
