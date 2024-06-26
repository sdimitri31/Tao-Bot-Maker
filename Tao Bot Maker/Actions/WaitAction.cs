using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class WaitAction : Action
    {
        public override string ActionType { get; set; }
        public int MinimumWait { get; set; }
        public int MaximumWait { get; set; }
        public bool RandomizeWait { get; set; }

        public WaitAction(int minimumWait = 0, int maximumWait = 0, bool randomizeWait = false)
        {
            ActionType = ActionTypes.WaitAction.ToString();
            MinimumWait = minimumWait;
            MaximumWait = maximumWait;
            RandomizeWait = randomizeWait;
        }

        public override async Task Execute()
        {
            int waitTime = MinimumWait;
            if (RandomizeWait)
            {
                waitTime = new Random().Next(waitTime, MaximumWait);
            }
            Console.WriteLine($"Wait action will be executed for {waitTime} ms.");
            await Task.Delay(waitTime);
            Console.WriteLine($"Wait action done.");
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
    }
}
