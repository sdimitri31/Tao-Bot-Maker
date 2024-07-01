using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace Tao_Bot_Maker.Helpers
{
    public class KeyboardSimulator
    {
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        private readonly Random random;

        public KeyboardSimulator()
        {
            random = new Random();
        }

        public async Task TypeText(string text, int typingSpeed)
        {
            text = PreventMultipleReturns(text);
            foreach (char c in text)
            {
                SendKeys.SendWait(PrepareForSendKeys(c.ToString()));

                int delay = GetRandomDelayFromSpeed(typingSpeed);
                await Task.Delay(delay);
            }
        }

        public async Task PressKey(Keys key)
        {
            string prepare = PrepareForSendKeys(key);

            SendKeys.SendWait(prepare);
            await Task.Delay(0);
        }

        public static bool IsValidKey(int keyValue)
        {
            // Vérifie si la touche principale est valide
            int keyCode = keyValue & (int)Keys.KeyCode;
            if (!Enum.IsDefined(typeof(Keys), keyCode))
            {
                return false;
            }

            // Vérifie les modificateurs
            int modifiers = keyValue & (int)Keys.Modifiers;
            int validModifiers = (int)(Keys.Shift | Keys.Control | Keys.Alt);

            // Si les modificateurs ne sont pas valides, retourner false
            if ((modifiers & ~validModifiers) != 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Transform a Keys to a more user friendly string 
        /// </summary>
        /// <param name="key">Keys to process</param>
        /// <returns>String in a format ": Ctrl + Alt + Shift + Key</returns>
        public static string GetFormatedKeysString(Keys key)
        {
            string formatedName = key.ToString();

            //Clean name when there is only a modifier
            formatedName = formatedName.ToString().Replace("ControlKey, Control", Resources.Strings.KeysCtrl);
            formatedName = formatedName.ToString().Replace("Menu, Alt", Resources.Strings.KeysAlt);
            formatedName = formatedName.ToString().Replace("ShiftKey, Shift", Resources.Strings.KeysShift);

            //Split key from modifiers
            string[] keys = formatedName.Split(',');
            string modifiers = "";

            //Skip the key
            for (int i = 1; i < keys.Length; i++)
            {
                modifiers += keys[i].Replace(" ", "") + " + ";
            }

            //Clean modifier names
            modifiers = modifiers.Replace("Control", Resources.Strings.KeysCtrl);
            modifiers = modifiers.Replace("Alt", Resources.Strings.KeysAlt);
            modifiers = modifiers.Replace("Shift", Resources.Strings.KeysShift);
            modifiers = modifiers.Replace(",", "");

            return modifiers + KeyStringTranslate(keys[0]);
        }
        public static string KeyStringTranslate(string key)
        {
            string keyboardLocale = InputLanguage.CurrentInputLanguage.Culture.Name;

            //Common accross locales
            switch (key)
            {
                case "Back":
                    return Resources.Strings.KeysBackspace;
                case "Separator":
                    return "{BREAK}";
                case "Capital":
                    return Resources.Strings.KeysCapsLock;
                case "Delete":
                    return Resources.Strings.KeysDelete;
                case "Down":
                    return Resources.Strings.KeysDown;
                case "End":
                    return Resources.Strings.KeysEnd;
                case "Return":
                    return Resources.Strings.KeysEnter;
                case "Escape":
                    return Resources.Strings.KeysEscape;
                case "Help":
                    return "HELP";
                case "Home":
                    return "HOME";
                case "Insert":
                    return "INSERT";
                case "Left":
                    return Resources.Strings.KeysLeft;
                case "NumLock":
                    return "NUMLOCK";
                case "PageDown":
                    return "PGDN";
                case "PageUp":
                    return "PGUP";
                case "PrintScreen":
                    return "PRTSC";
                case "Right":
                    return Resources.Strings.KeysRight;
                case "Scroll":
                    return "SCROLLLOCK";
                case "Tab":
                    return "TAB";
                case "Up":
                    return Resources.Strings.KeysUp;
                case "F1":
                    return "F1";
                case "F2":
                    return "F2";
                case "F3":
                    return "F3";
                case "F4":
                    return "F4";
                case "F5":
                    return "F5";
                case "F6":
                    return "F6";
                case "F7":
                    return "F7";
                case "F8":
                    return "F8";
                case "F9":
                    return "F9";
                case "F10":
                    return "F10";
                case "F11":
                    return "F11";
                case "F12":
                    return "F12";
                case "F13":
                    return "F13";
                case "F14":
                    return "F14";
                case "F15":
                    return "F15";
                case "F16":
                    return "F16";
                case "Add":
                    return "+";
                case "Subtract":
                    return "-";
                case "Multiply":
                    return "*";
                case "Divide":
                    return "/";
                case "ShiftKey":
                    return Resources.Strings.KeysShift;
                case "ControlKey":
                    return Resources.Strings.KeysCtrl;
                case "AltKey":
                    return Resources.Strings.KeysAlt;
                case "Space":
                    return Resources.Strings.KeysSpace;
            }

            if (keyboardLocale.Equals("fr-FR"))
            {
                switch (key)
                {
                    case "OemBackslash":
                        return "<";
                    case "OemOpenBrackets":
                        return ")";
                    case "Oemplus":
                        return "=";
                    case "Oem1":
                        return "$";
                    case "Oem5":
                        return "*";
                    case "Oem6":
                        return "^";
                    case "Oem7":
                        return "²";
                    case "Oem8":
                        return "!";
                    case "Oemtilde":
                        return "ù";
                    case "Oemcomma":
                        return ",";
                    case "OemPeriod":
                        return ";";
                    case "OemQuestion":
                        return ":";
                    case "D1":
                        return "&&";
                    case "D2":
                        return "é";
                    case "D3":
                        return "\"";
                    case "D4":
                        return "'";
                    case "D5":
                        return "(";
                    case "D6":
                        return "-";
                    case "D7":
                        return "è";
                    case "D8":
                        return "_";
                    case "D9":
                        return "ç";
                    case "D0":
                        return "à";
                }
            }

            else if (keyboardLocale.Equals("en-US") || keyboardLocale.Equals("en-GB"))
            {
                switch (key)
                {
                    case "OemOpenBrackets":
                        return "[";
                    case "Oemplus":
                        return "=";
                    case "Oem1":
                        return ";";
                    case "Oem5":
                        return "\\";
                    case "Oem6":
                        return "]";
                    case "Oem7":
                        return "'";
                    case "Oemtilde":
                        return "`";
                    case "Oemcomma":
                        return ",";
                    case "OemPeriod":
                        return ".";
                    case "OemQuestion":
                        return "/";
                    case "D1":
                        return "1";
                    case "D2":
                        return "2";
                    case "D3":
                        return "3";
                    case "D4":
                        return "4";
                    case "D5":
                        return "5";
                    case "D6":
                        return "6";
                    case "D7":
                        return "7";
                    case "D8":
                        return "8";
                    case "D9":
                        return "9";
                    case "D0":
                        return "0";
                }
            }

            return key.ToString();
        }

        private int GetRandomDelayFromSpeed(int speed)
        {
            switch (speed)
            {
                case 0:
                    return random.Next(100, 200);
                case 1:
                    return random.Next(40, 70);
                case 2:
                    return random.Next(10, 25);
                default:
                    return random.Next(75, 125);
            }
        }

        private string PreventMultipleReturns(string input)
        {
            return input.Replace("\r\n", "\r");
        }

        private string PrepareForSendKeys(string input)
        {
            var specialChars = "+^%~(){}";
            var c1 = "[BRACEOPEN]";
            var c2 = "[BRACECLOSE]";
            specialChars.ToList().ForEach(x =>
            {
                input = input.Replace(x.ToString(),
                    string.Format("{0}{1}{2}", c1, x.ToString(), c2));
            });
            input = input.Replace(c1, "{");
            input = input.Replace(c2, "}");
            input = PreventMultipleReturns(input);
            return input;
        }

        string PrepareForSendKeys(Keys input)
        {
            //Delete spaces
            string preparedString = input.ToString().Replace(" ", "");

            //Split key from modifiers
            string[] keysSplited = preparedString.Split(',');

            //Prepare modifiers
            string preparedModifiers = string.Empty;

            for (int i = 1; i < keysSplited.Length; i++)
            {
                keysSplited[i] = keysSplited[i].Replace("Control", "^");
                keysSplited[i] = keysSplited[i].Replace("Alt", "%");
                keysSplited[i] = keysSplited[i].Replace("Shift", "+");
                preparedModifiers += keysSplited[i];
            }

            //If no modifiers
            if (preparedModifiers == string.Empty)
            {
                preparedString = KeysToString(input);
            }
            else
            {
                Enum.TryParse(keysSplited[0], out Keys key);
                preparedString = KeysToString(key);

                preparedString = preparedModifiers + "(" + preparedString + ")";
            }


            return preparedString;
        }

        /// <summary>
        /// Convert a single Keys (no modifiers) to a string compatible with SendKey
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string KeysToString(Keys key)
        {
            string keyboardLocale = InputLanguage.CurrentInputLanguage.Culture.Name;

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

            if (keyboardLocale.Equals("fr-FR"))
            {
                switch (key)
                {
                    case Keys.OemBackslash:
                        return "<";
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
