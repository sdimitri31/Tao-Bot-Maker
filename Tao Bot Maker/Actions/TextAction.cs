using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    public class TextAction : Action
    {
        public override ActionType Type { get; set; }
        public string TextToType { get; set; }
        public int TypingSpeed { get; set; }

        private readonly KeyboardSimulator keyboardSimulator;

        public TextAction(string textToType = "", int typingSpeed = 2)
        {
            Type = ActionType.TextAction;
            TextToType = textToType;
            TypingSpeed = typingSpeed;
            keyboardSimulator = new KeyboardSimulator();
        }

        public override async Task Execute(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            string executeAction = string.Format(Resources.Strings.InfoMessageExecuteAction, this.ToString());
            Logger.Log(executeAction);

            await keyboardSimulator.TypeText(TextToType, TypingSpeed);
        }

        public override async Task Execute(int x, int y, CancellationToken token)
        {
            await Execute(token);
        }

        public override string ToString()
        {
            return string.Format(Resources.Strings.TextActionToString, TextToType, TypingSpeed);
        }

        public override bool Validate(out string errorMessage)
        {
            if (string.IsNullOrEmpty(TextToType))
            {
                errorMessage = Resources.Strings.ErrorMessageEmptyFieldTextToType;
                return false;
            }

            if ((TypingSpeed < 0) || (TypingSpeed > 2))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidTypingSpeed, 0, 2);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public override void Update(Action newAction)
        {
            base.Update(newAction);
            var newTextAction = newAction as TextAction;
            if (newTextAction != null)
            {
                this.TextToType = newTextAction.TextToType;
                this.TypingSpeed = newTextAction.TypingSpeed;
            }
        }
    }
}
