using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using static System.Windows.Forms.AxHost;

namespace Tao_Bot_Maker.Model
{
    public class KeyAction : Action
    {
        public override ActionType Type { get; set; }
        public Keys Key { get; set; }

        private readonly KeyboardSimulator keyboardSimulator;

        public KeyAction(Keys key = Keys.None)
        {
            Type = ActionType.KeyAction;
            Key = key;
            keyboardSimulator = new KeyboardSimulator();
        }

        public override async Task Execute()
        {
            string keyName = KeyboardSimulator.GetFormatedKeysString(Key);
            Logger.Log($"Pressing key: {keyName}");
            await keyboardSimulator.PressKey(Key);
        }

        public override async Task Execute(int x, int y)
        {
            await Execute();
        }

        public override string ToString()
        {
            return $"Action key: {KeyboardSimulator.GetFormatedKeysString(Key)}";
        }

        public override bool Validate(out string errorMessage)
        {
            errorMessage = string.Empty;
            return true;
        }
        public override void Update(Action newAction)
        {
            base.Update(newAction);
            var newKeyAction = newAction as KeyAction;
            if (newKeyAction != null)
            {
                this.Key = newKeyAction.Key;
            }
        }
    }
}
