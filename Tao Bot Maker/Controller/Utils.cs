using System;
using System.Windows.Forms;

namespace Tao_Bot_Maker.Controller
{
    internal class Utils
    {
        public static int[] GetTopLeftCoords(int x1, int y1, int x2, int y2)
        {
            int x, y;

            if (x1 > x2) 
            { 
                x = x2; 
            }
            else 
            { 
                x = x1; 
            }

            if (y1 > y2) 
            { 
                y = y2; 
            }
            else 
            { 
                y = y1; 
            }

            return new int[] { x, y };
        }
        
        public static int[] GetBottomRightCoords(int x1, int y1, int x2, int y2)
        {
            int x, y;

            if (x1 < x2)
            {
                x = x2;
            }
            else
            {
                x = x1;
            }

            if (y1 < y2)
            {
                y = y2;
            }
            else
            {
                y = y1;
            }

            return new int[] { x, y };
        }
        
        public static int[] GetCoordsHeightWidth(int x1, int y1, int x2, int y2)
        {
            int height, width;

            int[] xy = Utils.GetTopLeftCoords(x1, y1, x2, y2);
            int[] xy2 = Utils.GetBottomRightCoords(x1, y1, x2, y2);

            width = xy2[0] - xy[0];
            height = xy2[1] - xy[1];

            return new int[] { xy[0], xy[1], width, height };
        }

        public static int GetMaxIntValueFromTimeUnitInMS(string unit)
        {
            switch (unit)
            {
                case "ms":
                    return 2147483646;
                case "s":
                    return (int)Math.Floor((decimal)(2147483646 / 1000));
                case "min":
                    return (int)Math.Floor((decimal)(2147483646 / 1000 / 60));
                case "h":
                    return (int)Math.Floor((decimal)(2147483646 / 1000 / 60 / 60));
                default: return 2147483646;
            }
        }

        /// <summary>
        /// Transform a Keys to a more user friendly string 
        /// </summary>
        /// <param name="key">Keys to process</param>
        /// <returns>String in a format : Ctrl + Alt + Shift + Key</returns>
        public static string GetFormatedKeysString(Keys key)
        {
            string formatedName = key.ToString();

            //Clean name when there is only a modifier
            formatedName = formatedName.ToString().Replace("ControlKey, Control", Properties.strings.label_Ctrl);
            formatedName = formatedName.ToString().Replace("AltKey, Alt", Properties.strings.label_Alt);
            formatedName = formatedName.ToString().Replace("ShiftKey, Shift", Properties.strings.label_Shift);

            //Split key from modifiers
            string[] keys = formatedName.Split(',');
            string modifiers = "";

            //Skip the key
            for (int i = 1; i < keys.Length; i++)
            {
                modifiers += keys[i].Replace(" ", "") + " + ";
            }

            //Clean modifier names
            modifiers = modifiers.Replace("Control", Properties.strings.label_Ctrl);
            modifiers = modifiers.Replace("Alt", Properties.strings.label_Alt);
            modifiers = modifiers.Replace("Shift", Properties.strings.label_Shift);
            modifiers = modifiers.Replace(",", "");

            return modifiers + keys[0];
        }

        /// <summary>
        /// Convert a single Keys (no modifiers) to a string compatible with SendKey
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string KeysToString(Keys key)
        {
            string keyboardLocale = InputLanguage.CurrentInputLanguage.Culture.Name;

            Log.Write("keyboardLocale : " + keyboardLocale, Log.TRACE);

            //Common accross locales
            switch (key)
            {
                case Keys.Back:
                    return "{BACKSPACE}";
                case Keys.Separator:
                    return "{BREAK}";
                case Keys.CapsLock:
                    return "{CAPSLOCK}";
                case Keys.Delete:
                    return "{DELETE}";
                case Keys.Down:
                    return "{DOWN}";
                case Keys.End:
                    return "{END}";
                case Keys.Enter:
                    return "{ENTER}";
                case Keys.Escape:
                    return "{ESC}";
                case Keys.Help:
                    return "{HELP}";
                case Keys.Home:
                    return "{HOME}";
                case Keys.Insert:
                    return "{INSERT}";
                case Keys.Left:
                    return "{LEFT}";
                case Keys.NumLock:
                    return "{NUMLOCK}";
                case Keys.PageDown:
                    return "{PGDN}";
                case Keys.PageUp:
                    return "{PGUP}";
                case Keys.PrintScreen:
                    return "{PRTSC}";
                case Keys.Right:
                    return "{RIGHT}";
                case Keys.Scroll:
                    return "{SCROLLLOCK}";
                case Keys.Tab:
                    return "{TAB}";
                case Keys.Up:
                    return "{UP}";
                case Keys.F1:
                    return "{F1}";
                case Keys.F2:
                    return "{F2}";
                case Keys.F3:
                    return "{F3}";
                case Keys.F4:
                    return "{F4}";
                case Keys.F5:
                    return "{F5}";
                case Keys.F6:
                    return "{F6}";
                case Keys.F7:
                    return "{F7}";
                case Keys.F8:
                    return "{F8}";
                case Keys.F9:
                    return "{F9}";
                case Keys.F10:
                    return "{F10}";
                case Keys.F11:
                    return "{F11}";
                case Keys.F12:
                    return "{F12}";
                case Keys.F13:
                    return "{F13}";
                case Keys.F14:
                    return "{F14}";
                case Keys.F15:
                    return "{F15}";
                case Keys.F16:
                    return "{F16}";
                case Keys.Add:
                    return "{ADD}";
                case Keys.Subtract:
                    return "{SUBTRACT}";
                case Keys.Multiply:
                    return "{MULTIPLY}";
                case Keys.Divide:
                    return "{DIVIDE}";
                case Keys.ShiftKey:
                    return "+";
                case Keys.ControlKey:
                    return "^";
                case Keys.Alt:
                    return "%";
                case Keys.Space:
                    return " ";
            }

            if(keyboardLocale.Equals("fr-FR"))
            {
                switch (key)
                {
                    case Keys.OemOpenBrackets:
                        return ")";
                    case Keys.Oemplus:
                        return "=";
                    case Keys.Oem1:
                        return "$";
                    case Keys.Oem5:
                        return "*";
                    case Keys.Oem6:
                        return "^";
                    case Keys.Oem7:
                        return "&";
                    case Keys.Oem8:
                        return "!";
                    case Keys.Oemtilde:
                        return "ù";
                    case Keys.Oemcomma:
                        return ",";
                    case Keys.OemPeriod:
                        return ";";
                    case Keys.OemQuestion:
                        return ":";
                    case Keys.D1:
                        return "&";
                    case Keys.D2:
                        return "é";
                    case Keys.D3:
                        return "\"";
                    case Keys.D4:
                        return "'";
                    case Keys.D5:
                        return "(";
                    case Keys.D6:
                        return "-";
                    case Keys.D7:
                        return "è";
                    case Keys.D8:
                        return "_";
                    case Keys.D9:
                        return "ç";
                    case Keys.D0:
                        return "à";
                }
            }

            else if (keyboardLocale.Equals("en-US") || keyboardLocale.Equals("en-GB"))
            {
                switch (key)
                {
                    case Keys.OemOpenBrackets:
                        return "[";
                    case Keys.Oemplus:
                        return "=";
                    case Keys.Oem1:
                        return ";";
                    case Keys.Oem5:
                        return "\\";
                    case Keys.Oem6:
                        return "]";
                    case Keys.Oem7:
                        return "'";
                    case Keys.Oemtilde:
                        return "`";
                    case Keys.Oemcomma:
                        return ",";
                    case Keys.OemPeriod:
                        return ".";
                    case Keys.OemQuestion:
                        return "/";
                    case Keys.D1:
                        return "1";
                    case Keys.D2:
                        return "2";
                    case Keys.D3:
                        return "3";
                    case Keys.D4:
                        return "4";
                    case Keys.D5:
                        return "5";
                    case Keys.D6:
                        return "6";
                    case Keys.D7:
                        return "7";
                    case Keys.D8:
                        return "8";
                    case Keys.D9:
                        return "9";
                    case Keys.D0:
                        return "0";
                }
            }

            return key.ToString();
        }
    }
}
