using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    public class WaitAction : Action
    {
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

        public override async Task Execute(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            int waitTime = RandomizeWait ? new Random().Next(MinimumWait, MaximumWait) : MinimumWait;

            Logger.Log($"Executing wait action. Waiting for {waitTime} ms.");

            await Task.Delay(waitTime);

            Logger.Log("Wait action completed.");
        }

        public override async Task Execute(int x, int y, CancellationToken token)
        {
            await Execute(token);
        }

        public override string ToString()
        {
            if (RandomizeWait)
            {
                return $"Wait between {MinimumWait} and {MaximumWait} ms";
            }
            return $"Wait {MinimumWait} ms";
        }

        public override bool Validate(out string errorMessage)
        {
            if (MinimumWait < 0)
            {
                errorMessage = "Minimum wait time cannot be less than 0.";
                return false;
            }

            if (RandomizeWait)
                if (MaximumWait < MinimumWait)
                {
                    errorMessage = "Maximum wait time cannot be less than minimum wait time.";
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
