using System;
using System.Windows.Forms;

namespace Tao_Bot_Maker
{
    public class Hotkey
    {
        [Flags]
        public enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public int Modifier {  get; set; }
        public Keys Key { get; set; }

        public Hotkey(int modifier, Keys key) 
        { 
            Modifier = modifier;
            Key = key;
        }

        public override string ToString()
        {
            return Modifier.ToString() + "+" + Key.ToString();
        }

    }
}
