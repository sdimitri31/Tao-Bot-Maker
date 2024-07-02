using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    [JsonConverter(typeof(ActionConverter))]
    public class SequenceAction : Action
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public override ActionType Type { get; set; }
        public string SequenceName { get; set; }
        public int RepeatCount { get; set; }

        public SequenceAction(string sequenceName = "", int repeatCount = 1)
        {
            Type = ActionType.SequenceAction;
            SequenceName = sequenceName;
            RepeatCount = repeatCount;
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

            Sequence sequence = SequenceController.GetSequence(SequenceName);
            for (int i = 0; i < RepeatCount; i++)
            {
                token.ThrowIfCancellationRequested();

                await SequenceController.PauseIfRequested();

                string logLoop = string.Format(Resources.Strings.SequenceActionLoopNumber, i + 1, RepeatCount);
                Logger.Log(logLoop);
                foreach (var action in sequence.Actions)
                {
                    await SequenceController.ExecuteAction(action, token);
                }
            }
        }

        public override string ToString()
        {
            return string.Format(Resources.Strings.SequenceActionToString, SequenceName, RepeatCount);
        }

        public override bool Validate(out string errorMessage)
        {
            if (string.IsNullOrEmpty(SequenceName))
            {
                errorMessage = Resources.Strings.ErrorMessageEmptyFieldSequence;
                return false;
            }

            try { SequenceController.GetSequence(SequenceName); }
            catch (Exception ex)
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageFailToLoadSequence, SequenceName);
                errorMessage = $"{errorMessage} {ex.Message}";
                return false;
            }

            if ((RepeatCount < -1 || RepeatCount > 999999) && RepeatCount != 0)
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidRepeatCount, 0, -1, 999999);
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
