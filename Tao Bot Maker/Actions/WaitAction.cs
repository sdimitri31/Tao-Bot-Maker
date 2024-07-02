using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    [JsonConverter(typeof(ActionConverter))]
    public class WaitAction : Action
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public override ActionType Type { get; set; }
        public int MinimumWait { get; set; }
        public int MaximumWait { get; set; }
        public bool RandomizeWait { get; set; }

        public WaitAction(int minimumWait = 0, int maximumWait = 0, bool randomizeWait = false)
        {
            Type = ActionType.WaitAction;
            MinimumWait = minimumWait;
            MaximumWait = maximumWait;
            RandomizeWait = randomizeWait;
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

            int waitTime = RandomizeWait ? new Random().Next(MinimumWait, MaximumWait) : MinimumWait;

            string messageWaitingFor = string.Format(Resources.Strings.InfoMessageWaitActionWaitingTime, waitTime);
            Logger.Log(messageWaitingFor);
            
            await Task.Delay(waitTime);
        }

        public override string ToString()
        {
            if (RandomizeWait)
            {
                return string.Format(Resources.Strings.WaitActionWithIntervalToString, MinimumWait, MaximumWait);
            }
            else
            {
                return string.Format(Resources.Strings.WaitActionToString, MinimumWait);
            }
        }

        public override bool Validate(out string errorMessage)
        {
            if (MinimumWait < 0)
            {
                errorMessage = Resources.Strings.ErrorMessageWaitActionInvalidMinimumWait;
                return false;
            }

            if (RandomizeWait)
                if (MaximumWait < MinimumWait)
                {
                    errorMessage = Resources.Strings.ErrorMessageWaitActionInvalidMaximumWait;
                    return false;
                }

            errorMessage = string.Empty;
            return true;
        }

        public override void Update(Action newAction)
        {
            base.Update(newAction);
            var newWaitAction = newAction as WaitAction;
            if (newWaitAction != null)
            {
                this.MinimumWait = newWaitAction.MinimumWait;
                this.MaximumWait = newWaitAction.MaximumWait;
                this.RandomizeWait = newWaitAction.RandomizeWait;
            }
        }
    }
}
