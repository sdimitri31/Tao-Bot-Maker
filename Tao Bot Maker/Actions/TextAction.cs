using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    [JsonConverter(typeof(ActionConverter))]
    public class TextAction : Action
    {
        [JsonConverter(typeof(StringEnumConverter))]
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

        public override async Task Execute(CancellationToken token, int x, int y)
        {
            token.ThrowIfCancellationRequested();

            string executeAction = string.Format(Resources.Strings.InfoMessageExecuteAction, this.ToString());
            Logger.Log(executeAction);

            if (!Validate(out string errorMessage))
            {
                throw new Exception(errorMessage);
            }

            await keyboardSimulator.TypeText(TextToType, TypingSpeed);
        }

        public override string ToString()
        {
            return string.Format(Resources.Strings.TextActionToString, TextToType, TypingSpeed);
        }

        public override bool Validate(out string errorMessage)
        {
            Logger.Log($"Validating TextAction", TraceEventType.Verbose);
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

            Logger.Log($"Validated TextAction", TraceEventType.Verbose);
            errorMessage = string.Empty;
            return true;
        }
    }
}
