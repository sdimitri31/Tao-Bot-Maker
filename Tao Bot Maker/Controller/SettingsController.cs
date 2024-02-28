using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.Controller
{
    public class SettingsController
    {
        private static void WriteSetting(String key, String value, String section)
        {
            var MyIni = new IniFile(Constants.SETTINGS_INI_NAME);
            MyIni.Write(key, value, section);
        }

        private static void WriteSetting(String key, String value)
        {
            var MyIni = new IniFile(Constants.SETTINGS_INI_NAME);
            MyIni.Write(key, value);
        }

        private static String ReadSetting(String key, String section)
        {
            var MyIni = new IniFile(Constants.SETTINGS_INI_NAME);
            var value = MyIni.Read(key, section);
            return value.ToString();
        }

        public static bool IsSaveLogs()
        {
            String value = ReadSetting(Constants.SETTINGS_KEY_SAVELOGS, Constants.SETTINGS_SECTION_GENERAL);
            if (value.ToLower() == "true")
                return true;

            return false;
        }

        public static void SetSaveLogs(bool isSaved)
        {
            WriteSetting(Constants.SETTINGS_KEY_SAVELOGS, isSaved.ToString(), Constants.SETTINGS_SECTION_GENERAL);
        }

        public static String GetLanguage()
        {
            string language = ReadSetting(Constants.SETTINGS_KEY_LANGUAGE, Constants.SETTINGS_SECTION_GENERAL);
            if (language == "")
                return "EN";
            return language.ToUpper();
        }

        public static void SetLanguage(String language)
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
        public static int GetHotkeyModifier(string settingName)
        {
            int value = 0;
            try
            {
                value = Int32.Parse(ReadSetting(settingName, Constants.SETTINGS_SECTION_HOTKEY));
            }
            catch
            { }
            return value;
        }
        
        public static Keys GetHotkeyKey(string settingName)
        {
            Keys key;
            bool result = Enum.TryParse(ReadSetting(settingName, Constants.SETTINGS_SECTION_HOTKEY), out key);
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

        public static void SetHotkey(string hotkeyKeyName, string hotkeyModifierName, Hotkey hotkey)
        {
            WriteSetting(hotkeyKeyName, hotkey.Key.ToString(), Constants.SETTINGS_SECTION_HOTKEY);
            WriteSetting(hotkeyModifierName, hotkey.Modifier.ToString(), Constants.SETTINGS_SECTION_HOTKEY);
        }

        //HOTKEY : STARTBOT
        public static int GetHotkeyModifierStartBot()
        {
            return GetHotkeyModifier(Constants.SETTINGS_KEY_HOTKEY_STARTBOT_MODIFIER);
        }

        public static Keys GetHotkeyKeyStartBot()
        {
            return GetHotkeyKey(Constants.SETTINGS_KEY_HOTKEY_STARTBOT_KEY);
        }

        public static void SetHotkeyStartBot(Hotkey hotkey)
        {
            SetHotkey(Constants.SETTINGS_KEY_HOTKEY_STARTBOT_KEY, Constants.SETTINGS_KEY_HOTKEY_STARTBOT_MODIFIER, hotkey);
        }

        //HOTKEY : STOPBOT
        public static int GetHotkeyModifierStopBot()
        {
            return GetHotkeyModifier(Constants.SETTINGS_KEY_HOTKEY_STOPBOT_MODIFIER);
        }

        public static Keys GetHotkeyKeyStopBot()
        {
            return GetHotkeyKey(Constants.SETTINGS_KEY_HOTKEY_STOPBOT_KEY);
        }
        
        public static void SetHotkeyStopBot(Hotkey hotkey)
        {
            SetHotkey(Constants.SETTINGS_KEY_HOTKEY_STOPBOT_KEY, Constants.SETTINGS_KEY_HOTKEY_STOPBOT_MODIFIER, hotkey);
        }

        //HOTKEY : XY
        public static int GetHotkeyModifierXY()
        {
            return GetHotkeyModifier(Constants.SETTINGS_KEY_HOTKEY_XY_MODIFIER);
        }

        public static Keys GetHotkeyKeyXY()
        {
            return GetHotkeyKey(Constants.SETTINGS_KEY_HOTKEY_XY_KEY);
        }

        public static void SetHotkeyXY(Hotkey hotkey)
        {
            SetHotkey(Constants.SETTINGS_KEY_HOTKEY_XY_KEY, Constants.SETTINGS_KEY_HOTKEY_XY_MODIFIER, hotkey);
        }

        //HOTKEY : XY2
        public static int GetHotkeyModifierXY2()
        {
            return GetHotkeyModifier(Constants.SETTINGS_KEY_HOTKEY_XY2_MODIFIER);
        }

        public static Keys GetHotkeyKeyXY2()
        {
            return GetHotkeyKey(Constants.SETTINGS_KEY_HOTKEY_XY2_KEY);
        }

        public static void SetHotkeyXY2(Hotkey hotkey)
        {
            SetHotkey(Constants.SETTINGS_KEY_HOTKEY_XY2_KEY, Constants.SETTINGS_KEY_HOTKEY_XY2_MODIFIER, hotkey);
        }

    }
}
