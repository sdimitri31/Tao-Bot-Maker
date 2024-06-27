using System;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    public class TextAction : Action
    {
        public override ActionType Type { get; set; }
        public string TextToType { get; set; }
        public string TypingSpeed { get; set; }

        private readonly KeyboardSimulator keyboardSimulator;

        public TextAction(string textToType = "", string typingSpeed = "Medium")
        {
            Type = ActionType.TextAction;
            TextToType = textToType;
            TypingSpeed = typingSpeed;
            keyboardSimulator = new KeyboardSimulator();
        }

        public override async Task Execute()
        {
            Logger.Log($"Typing text: {TextToType}");
            await keyboardSimulator.TypeText(TextToType, TypingSpeed);
            Logger.Log("Typing text completed.");
        }

        public override async Task Execute(int x, int y)
        {
            await Execute();
        }

        public override string ToString()
        {
            return $"Text: {TextToType} TypingSpeed: {TypingSpeed}";
        }

        public override bool Validate(out string errorMessage)
        {
            if (string.IsNullOrEmpty(TextToType))
            {
                errorMessage = "Text to type cannot be empty.";
                return false;
            }

            if (string.IsNullOrEmpty(TypingSpeed))
            {
                errorMessage = "Typing speed cannot be empty.";
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
