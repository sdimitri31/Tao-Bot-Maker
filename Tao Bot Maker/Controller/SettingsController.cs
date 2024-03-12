using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.Controller
{
    public class SettingsController
    {
        private static void WriteSetting(string key, string value, string section = null)
        {
            var MyIni = new IniFile(Constants.SETTINGS_INI_NAME);
            MyIni.Write(key, value, section);
        }

        private static string ReadSetting(string key, string section)
        {
            var MyIni = new IniFile(Constants.SETTINGS_INI_NAME);
            var value = MyIni.Read(key, section);
            return value.ToString();
        }

        private static void DeleteSetting(string Key, string Section = null)
        {
            var MyIni = new IniFile(Constants.SETTINGS_INI_NAME);
            MyIni.DeleteKey(Key, Section);
        }

        public static bool IsSaveLogs()
        {
            string value = ReadSetting(Constants.SETTINGS_KEY_SAVELOGS, Constants.SETTINGS_SECTION_GENERAL);
            if (value.ToLower() == "true")
                return true;

            return false;
        }

        public static void SetSaveLogs(bool isSaved)
        {
            WriteSetting(Constants.SETTINGS_KEY_SAVELOGS, isSaved.ToString(), Constants.SETTINGS_SECTION_GENERAL);
        }

        public static string GetLanguage()
        {
            string language = ReadSetting(Constants.SETTINGS_KEY_LANGUAGE, Constants.SETTINGS_SECTION_GENERAL);
            if (language == "")
                return "EN";
            return language.ToUpper();
        }

        public static void SetLanguage(string language)
        {
            WriteSetting(Constants.SETTINGS_KEY_LANGUAGE, language.ToUpper(), Constants.SETTINGS_SECTION_GENERAL);
        }

        public static int GetTheme()
        {
            //Default value '2' Auto dark mode
            int value = 2;
            try
            {
                value = Int32.Parse(ReadSetting(Constants.SETTINGS_KEY_THEME, Constants.SETTINGS_SECTION_GENERAL));
            }
            catch
            { }
            return value;
        }

        public static void SetTheme(int theme)
        {
            WriteSetting(Constants.SETTINGS_KEY_THEME, theme.ToString(), Constants.SETTINGS_SECTION_GENERAL);
        }

        //---------------------------------------------------------
        //HOTKEY
        
        public static Keys GetHotkey(string settingName)
        {
            bool result = Enum.TryParse(ReadSetting(settingName, Constants.SETTINGS_SECTION_HOTKEY), out Keys key);
            if (result)
                return key;
            else
            {
                if (settingName == Constants.SETTINGS_KEY_HOTKEY_STARTBOT_KEY)
                    return Keys.F6;
                if (settingName == Constants.SETTINGS_KEY_HOTKEY_STOPBOT_KEY)
                    return Keys.F7;
                if (settingName == Constants.SETTINGS_KEY_HOTKEY_XY_KEY)
                    return Keys.F1;
                if (settingName == Constants.SETTINGS_KEY_HOTKEY_XY2_KEY)
                    return Keys.F2;
            }
            return Keys.None;
        }

        public static void SetHotkey(string settingName, Keys key)
        {
            WriteSetting(settingName, ((int)key).ToString(), Constants.SETTINGS_SECTION_HOTKEY);
        }

        //HOTKEY : STARTBOT
        public static Keys GetHotkeyStartBot()
        {
            //If there is a modifier we need to update to new format
            if (ReadSetting(Constants.SETTINGS_KEY_HOTKEY_STARTBOT_MODIFIER, Constants.SETTINGS_SECTION_HOTKEY) != "")
            {
                DeleteSetting(Constants.SETTINGS_KEY_HOTKEY_STARTBOT_MODIFIER, Constants.SETTINGS_SECTION_HOTKEY);
                return Keys.F6;
            }
            else
            {
                Keys hotkey = GetHotkey(Constants.SETTINGS_KEY_HOTKEY_STARTBOT_KEY);
                return hotkey;
            }
        }

        public static void SetHotkeyStartBot(Keys key)
        {
            SetHotkey(Constants.SETTINGS_KEY_HOTKEY_STARTBOT_KEY, key);
        }

        //HOTKEY : STOPBOT

        public static Keys GetHotkeyStopBot()
        {
            //If there is a modifier we need to update to new format
            if (ReadSetting(Constants.SETTINGS_KEY_HOTKEY_STOPBOT_MODIFIER, Constants.SETTINGS_SECTION_HOTKEY) != "")
            {
                DeleteSetting(Constants.SETTINGS_KEY_HOTKEY_STOPBOT_MODIFIER, Constants.SETTINGS_SECTION_HOTKEY);
                return Keys.F7;
            }
            else
            {
                Keys hotkey = GetHotkey(Constants.SETTINGS_KEY_HOTKEY_STOPBOT_KEY);
                return hotkey;
            }
        }
        
        public static void SetHotkeyStopBot(Keys key)
        {
            SetHotkey(Constants.SETTINGS_KEY_HOTKEY_STOPBOT_KEY, key);
        }

        //HOTKEY : XY
        public static Keys GetHotkeyXY()
        {
            //If there is a modifier we need to update to new format
            if (ReadSetting(Constants.SETTINGS_KEY_HOTKEY_XY_MODIFIER, Constants.SETTINGS_SECTION_HOTKEY) != "")
            {
                DeleteSetting(Constants.SETTINGS_KEY_HOTKEY_XY_MODIFIER, Constants.SETTINGS_SECTION_HOTKEY);
                return Keys.F1;
            }
            else
            {
                Keys hotkey = GetHotkey(Constants.SETTINGS_KEY_HOTKEY_XY_KEY);
                return hotkey;
            }
        }

        public static void SetHotkeyXY(Keys key)
        {
            SetHotkey(Constants.SETTINGS_KEY_HOTKEY_XY_KEY, key);
        }

        //HOTKEY : XY2
        public static Keys GetHotkeyXY2()
        {
            //If there is a modifier we need to update to new format
            if (ReadSetting(Constants.SETTINGS_KEY_HOTKEY_XY2_MODIFIER, Constants.SETTINGS_SECTION_HOTKEY) != "")
            {
                DeleteSetting(Constants.SETTINGS_KEY_HOTKEY_XY2_MODIFIER, Constants.SETTINGS_SECTION_HOTKEY);
                return Keys.F2;
            }
            else
            {
                Keys hotkey = GetHotkey(Constants.SETTINGS_KEY_HOTKEY_XY2_KEY);
                return hotkey;
            }
        }

        public static void SetHotkeyXY2(Keys key)
        {
            SetHotkey(Constants.SETTINGS_KEY_HOTKEY_XY2_KEY, key);
        }

    }
}
