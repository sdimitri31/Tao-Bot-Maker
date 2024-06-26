using System;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    public class TextAction : Action
    {
        public override string ActionType { get; set; }
        public string TextToType { get; set; }
        public string TypingSpeed { get; set; }

        private readonly KeyboardSimulator keyboardSimulator;

        public TextAction(string textToType = "", string typingSpeed = "Medium")
        {
            ActionType = ActionTypes.TextAction.ToString();
            TextToType = textToType;
            TypingSpeed = typingSpeed;
            keyboardSimulator = new KeyboardSimulator();
        }

        public override async Task Execute()
        {
            Console.WriteLine($"Typing text: {TextToType}");
            await keyboardSimulator.TypeText(TextToType, TypingSpeed);
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
    }
}
