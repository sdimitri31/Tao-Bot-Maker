using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tao_Bot_Maker
{
    public class HotKeyController
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private Hotkey hotkey;

        private IntPtr hWnd;
        private int id;

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
            int modifiersConverted = Controller.Utils.Reverse3Bits((int)modifiers >> 16);

            return RegisterHotKey(hWnd, id, modifiersConverted, (int)key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
