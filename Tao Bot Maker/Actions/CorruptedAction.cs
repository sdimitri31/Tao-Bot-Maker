using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    [JsonConverter(typeof(ActionConverter))]
    public class CorruptedAction : Action
    {
        public override ActionType Type { get; set; }

        public CorruptedAction()
        {
            Type = ActionType.CorruptAction;
        }

        public override async Task Execute(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            string executeAction = string.Format(Resources.Strings.InfoMessageExecuteAction, this.ToString());
            Logger.Log(executeAction);

            if (!Validate(out string errorMessage))
            {
                throw new Exception(errorMessage);
            }
            await Task.Delay(10, token);
        }

        public override async Task Execute(int x, int y, CancellationToken token)
        {
            await Execute(token);
        }

        public override string ToString()
        {
            return string.Format(Resources.Strings.ErrorMessageCorruptedAction);
        }

        public override bool Validate(out string errorMessage)
        {
            errorMessage = string.Format(Resources.Strings.ErrorMessageCorruptedAction);
            return false;
        }

    }
}
