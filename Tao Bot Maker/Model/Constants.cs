using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class Constants
    {
        public const string VERSION = "0.4.15";

        public const string PICTURE_FOLDER_NAME     = "Pictures";
        public const string SEQUENCES_FOLDER_NAME   = "Sequences";
        public const string SETTINGS_INI_NAME       = "Settings.ini";

        public const string SETTINGS_SECTION_GENERAL    = "General";
        public const string SETTINGS_KEY_SAVELOGS       = "SaveLogs";
        public const string SETTINGS_KEY_LANGUAGE       = "Language";
        public const string SETTINGS_KEY_THEME          = "Theme";

        public const string SETTINGS_SECTION_HOTKEY                 = "Hotkey";
        public const string SETTINGS_KEY_HOTKEY_STARTBOT_KEY        = "StartBotKey";
        public const string SETTINGS_KEY_HOTKEY_STOPBOT_KEY         = "StopBotKey";
        public const string SETTINGS_KEY_HOTKEY_XY_KEY              = "XYKey";
        public const string SETTINGS_KEY_HOTKEY_XY2_KEY             = "XY2Key";
        public const string SETTINGS_KEY_HOTKEY_STARTBOT_MODIFIER   = "StartBotModifier";
        public const string SETTINGS_KEY_HOTKEY_STOPBOT_MODIFIER    = "StopBotModifier";
        public const string SETTINGS_KEY_HOTKEY_XY_MODIFIER         = "XYModifier";
        public const string SETTINGS_KEY_HOTKEY_XY2_MODIFIER        = "XY2Modifier";

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        public const KnownColor COLOR_LABEL_XY = KnownColor.BlueViolet;
        public const KnownColor COLOR_LABEL_XY2 = KnownColor.Aqua;
    }
}
