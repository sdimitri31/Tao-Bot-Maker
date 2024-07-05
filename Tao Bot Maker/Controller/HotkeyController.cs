using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.Controller
{
    public class HotKeyController
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly Hotkey hotkey;

        private readonly IntPtr hWnd;
        private readonly int id;

        public HotKeyController(Keys key, Form form)
        {
            hotkey = new Hotkey(key);

            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public void SetHotkey(Keys hotkey)
        {
            this.hotkey.Key = hotkey;
        }

        public Hotkey GetHotkey()
        {
            return hotkey;
        }

        public Keys GetKey()
        {
            return hotkey.Key;
        }

        public override int GetHashCode()
        {
            return (int)hotkey.Key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            Keys key = hotkey.Key & Keys.KeyCode;
            Keys modifiers = hotkey.Key & Keys.Modifiers;

            //Flag for hotkey modifier are reversed compared to Keys modifier
            int modifiersConverted = Reverse3Bits((int)modifiers >> 16);

            return RegisterHotKey(hWnd, id, modifiersConverted, (int)key);
        }

        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }

        /// <summary>
        /// Reverse modifiers flag to detect Shift and Alt properly
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Reverse3Bits(int n)
        {
            return (0x73516240 >> (n << 2)) & 7;
        }
    }
}
