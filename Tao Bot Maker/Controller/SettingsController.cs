using System;
using System.Diagnostics;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker.Controller
{
    public class SettingsController
    {
        public static void OpenSettingsForm(SettingsType settingsType = SettingsType.General)
        {
            var settingsForm = new SettingsForm(settingsType);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                Logger.Log($"Settings saved", TraceEventType.Verbose);
                Console.WriteLine("Settings saved.");
            }
        }

        public static void SetSettingValue<T>(string name, T value, SettingsType type)
        {
            Logger.Log($"Setting '{name}' to '{value}'", TraceEventType.Verbose);
            Settings settings = Settings.Load();
            settings.SetSettingValue(name, value, type);
            settings.Save();
        }

        public static T GetSettingValue<T>(string name)
        {
            Settings settings = Settings.Load();
            return settings.GetSettingValue<T>(name);
        }

        public static string GetSelectedThemeValueFromResource(string selectedItem)
        {
            if (selectedItem == Resources.Strings.LabelThemeAuto)
                return "Auto";
            else if (selectedItem == Resources.Strings.LabelThemeLight)
                return "Light";
            else if (selectedItem == Resources.Strings.LabelThemeDark)
                return "Dark";
            else
                return "Auto";
        }

        public static string GetSelectedThemeResourceFromValue(string themeName)
        {
            string selectedItem;
            switch (themeName)
            {
                case "Auto":
                    selectedItem = Resources.Strings.LabelThemeAuto;
                    break;
                case "Light":
                    selectedItem = Resources.Strings.LabelThemeLight;
                    break;
                case "Dark":
                    selectedItem = Resources.Strings.LabelThemeDark;
                    break;
                default:
                    selectedItem = Resources.Strings.LabelThemeAuto;
                    break;
            }
            return selectedItem;
        }
    }
}
