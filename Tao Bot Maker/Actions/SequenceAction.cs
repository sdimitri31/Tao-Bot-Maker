using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao_Bot_Maker.Controller;

namespace Tao_Bot_Maker.Model
{
    public class SequenceAction : Action
    {
        public override string ActionType { get; set; }
        public string SequenceName { get; set; }
        public int RepeatCount { get; set; }
        private Sequence sequence;

        public SequenceAction(string sequenceName = "", int repeatCount = 1)
        {
            ActionType = ActionTypes.SequenceAction.ToString();
            SequenceName = sequenceName;
            RepeatCount = repeatCount;

            SequenceController sequenceController = new SequenceController();
            sequence = sequenceController.GetSequence(sequenceName);
        }

        public override async Task Execute()
        {
            // Exécute chaque action dans la séquence le nombre de fois spécifié
            for (int i = 0; i < RepeatCount; i++)
            {
                foreach (var action in sequence.Actions)
                {
                    await action.Execute();
                }
            }
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
    }
}
