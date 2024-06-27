using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tao_Bot_Maker.Model
{
    public class Settings
    {
        private const string settingsFileName = "settings.json";
        private readonly string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileName);

        public const string SETTING_SAVELOG = "SaveLog";
        public const string SETTING_LANGUAGE = "Language";
        public const string SETTING_THEME = "Theme";
        public const string SETTING_HOTKEYSTARTSEQUENCE = "HotkeyStartSequence";
        public const string SETTING_HOTKEYSTOPSEQUENCE = "HotkeyStopSequence";
        public const string SETTING_HOTKEYSTARTCOORDS = "HotkeyStartCoords";
        public const string SETTING_HOTKEYENDCOORDS = "HotkeyEndCoords";

        public List<Setting> SettingsList { get; set; }

        public Settings()
        {
            SettingsList = new List<Setting>
            {
                new Setting(SETTING_SAVELOG, "false", SettingsType.General),
                new Setting(SETTING_LANGUAGE, "English", SettingsType.General),
                new Setting(SETTING_THEME, "Light", SettingsType.General),
                new Setting(SETTING_HOTKEYSTARTSEQUENCE, ((int)Keys.F6).ToString(), SettingsType.Hotkeys),
                new Setting(SETTING_HOTKEYSTOPSEQUENCE, ((int)Keys.F7).ToString(), SettingsType.Hotkeys),
                new Setting(SETTING_HOTKEYSTARTCOORDS, ((int)Keys.F1).ToString(), SettingsType.Hotkeys),
                new Setting(SETTING_HOTKEYENDCOORDS, ((int)Keys.F2).ToString(), SettingsType.Hotkeys)
            };
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(SettingsList, Formatting.Indented);
            File.WriteAllText(settingsFilePath, json);
        }

        public static Settings Load()
        {
            string settingsPath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileName);
            if (File.Exists(settingsPath))
            {
                var json = File.ReadAllText(settingsPath);
                var settingsList = JsonConvert.DeserializeObject<List<Setting>>(json);
                return new Settings { SettingsList = settingsList };
            }

            return new Settings();
        }

        public T GetSettingValue<T>(string name)
        {
            var setting = SettingsList.FirstOrDefault(s => s.Name == name);
            if (setting != null)
            {
                return (T)Convert.ChangeType(setting.Value, typeof(T));
            }

            return default(T);
        }

        public void SetSettingValue<T>(string name, T value, SettingsType type)
        {
            var setting = SettingsList.FirstOrDefault(s => s.Name == name);
            if (setting != null)
            {
                setting.Value = value.ToString();
                setting.Type = type;
            }
            else
            {
                SettingsList.Add(new Setting(name, value.ToString(), type));
            }
        }
    }
}
