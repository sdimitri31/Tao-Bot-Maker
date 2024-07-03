using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tao_Bot_Maker.Model
{
    public class Settings
    {
        private const string settingsFileName = "settings.json";
        private readonly string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileName);

        public const string SETTING_SHOWLOGLEVEL = "ShowLogLevel";
        public const string SETTING_SAVELOGLEVEL = "SaveLogLevel";
        public const string SETTING_SAVELOG = "SaveLog";
        public const string SETTING_LANGUAGE = "Language";
        public const string SETTING_THEME = "Theme";
        public const string SETTING_HOTKEYSTARTSEQUENCE = "HotkeyStartSequence";
        public const string SETTING_HOTKEYPAUSESEQUENCE = "HotkeyPauseSequence";
        public const string SETTING_HOTKEYSTOPSEQUENCE = "HotkeyStopSequence";
        public const string SETTING_HOTKEYSTARTCOORDS = "HotkeyStartCoords";
        public const string SETTING_HOTKEYENDCOORDS = "HotkeyEndCoords";

        private static readonly Dictionary<string, string> DefaultValues = new Dictionary<string, string>
        {
            { SETTING_SHOWLOGLEVEL, 0b0111.ToString() },
            { SETTING_SAVELOGLEVEL, 0b0111.ToString() },
            { SETTING_SAVELOG, "true" },
            { SETTING_LANGUAGE, "English" },
            { SETTING_THEME, "Light" },
            { SETTING_HOTKEYSTARTSEQUENCE, ((int)Keys.F5).ToString() },
            { SETTING_HOTKEYPAUSESEQUENCE, ((int)Keys.F6).ToString() },
            { SETTING_HOTKEYSTOPSEQUENCE, ((int)Keys.F7).ToString() },
            { SETTING_HOTKEYSTARTCOORDS, ((int)Keys.F1).ToString() },
            { SETTING_HOTKEYENDCOORDS, ((int)Keys.F2).ToString() }
        };

        public List<Setting> SettingsList { get; set; }

        public Settings()
        {
            SettingsList = InitializeDefaultSettings();
        }

        private List<Setting> InitializeDefaultSettings()
        {
            return new List<Setting>
            {
                new Setting(SETTING_SHOWLOGLEVEL, GetDefaultValue(SETTING_SHOWLOGLEVEL), SettingsType.General),
                new Setting(SETTING_SAVELOGLEVEL, GetDefaultValue(SETTING_SAVELOGLEVEL), SettingsType.General),
                new Setting(SETTING_SAVELOG, GetDefaultValue(SETTING_SAVELOG), SettingsType.General),
                new Setting(SETTING_LANGUAGE, GetDefaultValue(SETTING_LANGUAGE), SettingsType.General),
                new Setting(SETTING_THEME, GetDefaultValue(SETTING_THEME), SettingsType.General),
                new Setting(SETTING_HOTKEYSTARTSEQUENCE, GetDefaultValue(SETTING_HOTKEYSTARTSEQUENCE), SettingsType.Hotkeys),
                new Setting(SETTING_HOTKEYPAUSESEQUENCE, GetDefaultValue(SETTING_HOTKEYPAUSESEQUENCE), SettingsType.Hotkeys),
                new Setting(SETTING_HOTKEYSTOPSEQUENCE, GetDefaultValue(SETTING_HOTKEYSTOPSEQUENCE), SettingsType.Hotkeys),
                new Setting(SETTING_HOTKEYSTARTCOORDS, GetDefaultValue(SETTING_HOTKEYSTARTCOORDS), SettingsType.Hotkeys),
                new Setting(SETTING_HOTKEYENDCOORDS, GetDefaultValue(SETTING_HOTKEYENDCOORDS), SettingsType.Hotkeys)
            };
        }

        private static string GetDefaultValue(string key)
        {
            if (DefaultValues.ContainsKey(key))
            {
                return DefaultValues[key];
            }
            return null;
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(SettingsList, Formatting.Indented);
            File.WriteAllText(settingsFilePath, json);
        }

        public static Settings Load()
        {
            string settingsPath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileName);
            try
            {
                if (File.Exists(settingsPath))
                {
                    var json = File.ReadAllText(settingsPath);
                    var settingsList = JsonConvert.DeserializeObject<List<Setting>>(json);
                    foreach (var setting in settingsList)
                    {
                        setting.Value = ValidateSetting(setting.Name, setting.Value);
                    }
                    return new Settings { SettingsList = settingsList };
                }
            }
            catch
            {
                Console.WriteLine("Error loading settings");
            }

            return new Settings();
        }

        public T GetSettingValue<T>(string name)
        {
            var setting = SettingsList.FirstOrDefault(s => s.Name == name);
            if (setting != null)
            {
                try
                {
                    var validatedValue = ValidateSetting(name, setting.Value);
                    if (validatedValue != null)
                        return (T)Convert.ChangeType(validatedValue, typeof(T));
                }
                catch { Console.WriteLine($"Error converting setting {name} to type {typeof(T)}"); }
            }
            else if (GetDefaultValue(name) != null)
            {
                return (T)Convert.ChangeType(GetDefaultValue(name), typeof(T));
            }

            return default;
        }

        private static readonly Dictionary<string, List<string>> ValidValues = new Dictionary<string, List<string>>
        {
            { SETTING_LANGUAGE, new List<string> { "English", "Français" } },
            { SETTING_THEME, new List<string> { "Light", "Dark", "Auto" } },
            // Add more settings and their valid values as needed
        };

        private static string ValidateSetting(string key, string value)
        {
            if (ValidValues.ContainsKey(key) && ValidValues[key].Contains(value))
            {
                return value;
            }

            switch (key)
            {
                case SETTING_SHOWLOGLEVEL:
                case SETTING_SAVELOGLEVEL:
                    if (!int.TryParse(value, out int levelInt))
                    {
                        return GetDefaultValue(key);
                    }
                    if (levelInt < 0x0000 || levelInt > 0x1111)
                    {
                        return GetDefaultValue(key);
                    }
                    return value;
                case SETTING_SAVELOG:
                    if (bool.TryParse(value, out _)) return value;
                    break;
                case SETTING_HOTKEYSTARTSEQUENCE:
                case SETTING_HOTKEYPAUSESEQUENCE:
                case SETTING_HOTKEYSTOPSEQUENCE:
                case SETTING_HOTKEYSTARTCOORDS:
                case SETTING_HOTKEYENDCOORDS:
                    if (!int.TryParse(value, out int keyInt))
                    {
                        return GetDefaultValue(key);
                    }

                    if (!Helpers.KeyboardSimulator.IsValidKey(keyInt))
                    {
                        return GetDefaultValue(key);
                    }
                    return value;
            }

            return GetDefaultValue(key);
        }

        public void SetSettingValue<T>(string name, T value, SettingsType type)
        {
            var setting = SettingsList.FirstOrDefault(s => s.Name == name);
            if (setting != null)
            {
                setting.Value = (string)Convert.ChangeType(value, typeof(string));
                setting.Type = type;
            }
            else
            {
                SettingsList.Add(new Setting(name, value.ToString(), type));
            }
        }
    }
}
