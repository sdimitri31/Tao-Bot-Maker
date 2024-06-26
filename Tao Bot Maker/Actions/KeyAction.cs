using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    public class KeyAction : Action
    {
        public override string ActionType { get; set; }
        public Keys Key { get; set; }

        private readonly KeyboardSimulator keyboardSimulator;

        public KeyAction(Keys keyToPress)
        {
            ActionType = ActionTypes.KeyAction.ToString();
            Key = keyToPress;
            keyboardSimulator = new KeyboardSimulator();
        }

        public override async Task Execute()
        {
            Console.WriteLine($"Pressing key: {Key}");
            await keyboardSimulator.PressKey(Key);
        }

        public override string ToString()
        {
            return $"Pressing key: {Key}";
        }

        public override bool Validate(out string errorMessage)
        {
            errorMessage = string.Empty;
            return true;
        }

    }
}
