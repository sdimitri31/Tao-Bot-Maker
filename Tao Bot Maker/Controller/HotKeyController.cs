using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.View;

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

        public HotKeyController(int modifier, Keys key, Form form)
        {
            hotkey = new Hotkey(modifier, key);

            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public void SetHotkey(Hotkey hotkey)
        {
            this.hotkey = hotkey;
        }

        public int GetModifier()
        {
            return hotkey.Modifier;
        }

        public Keys GetKey()
        {
            return hotkey.Key;
        }

        public override int GetHashCode()
        {
            return (int)hotkey.Modifier ^ (int)hotkey.Key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, (int)hotkey.Modifier, (int)hotkey.Key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
