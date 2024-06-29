using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    public class SequenceAction : Action
    {
        public override ActionType Type { get; set; }
        public string SequenceName { get; set; }
        public int RepeatCount { get; set; }
        private Sequence sequence;

        public SequenceAction(string sequenceName = "", int repeatCount = 1)
        {
            Type = ActionType.SequenceAction;
            SequenceName = sequenceName;
            RepeatCount = repeatCount;

            SequenceController sequenceController = new SequenceController();
            sequence = sequenceController.LoadSequence(sequenceName);
        }

        public override async Task Execute(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            Logger.Log($"Executing sequence action. {SequenceName} {RepeatCount} times");

            for (int i = 0; i < RepeatCount; i++)
            {
                Logger.Log($"Loop {i + 1} of {RepeatCount}");
                foreach (var action in sequence.Actions)
                {
                    await action.Execute(token);
                }
            }
            Logger.Log($"Repeating sequence completed.");
        }
        public override async Task Execute(int x, int y, CancellationToken token)
        {
            await Execute(token);
        }

        public override string ToString()
        {
            // Affiche les actions de la séquence
            return $"SequenceAction: Name: {SequenceName}, Actions: {string.Join(", ", sequence.Actions.Select(a => a.ToString()))} x {RepeatCount}";
        }

        public override bool Validate(out string errorMessage)
        {
            if (string.IsNullOrEmpty(SequenceName))
            {
                errorMessage = "Sequence name cannot be empty.";
                return false;
            }

            if((RepeatCount < -1 || RepeatCount > 999999) && RepeatCount != 0)
            {
                errorMessage = "Repeat count must be between -1 and 999999, and cannot be 0.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public override void Update(Action newAction)
        {
            base.Update(newAction);
            var newSequenceAction = newAction as SequenceAction;
            if (newSequenceAction != null)
            {
                this.SequenceName = newSequenceAction.SequenceName;
                this.RepeatCount = newSequenceAction.RepeatCount;
            }
        }
    }
}
