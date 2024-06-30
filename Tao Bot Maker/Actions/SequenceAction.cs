﻿using Newtonsoft.Json.Linq;
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

        private readonly Sequence sequence;

        public SequenceAction(string sequenceName = "", int repeatCount = 1)
        {
            Type = ActionType.SequenceAction;
            SequenceName = sequenceName;
            RepeatCount = repeatCount;

            try { sequence = SequenceController.GetSequence(sequenceName); }
            catch (Exception ex) 
            { 
                sequence = null; 
                string errorMessage = string.Format(Resources.Strings.ErrorMessageFailToLoadSequence, sequenceName);
                Logger.Log($"{errorMessage} {ex.Message}", System.Diagnostics.TraceEventType.Error);
            }
        }

        public override async Task Execute(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            string executeAction = string.Format(Resources.Strings.InfoMessageExecuteAction, this.ToString());
            Logger.Log(executeAction);

            try { SequenceController.GetSequence(SequenceName); }
            catch (Exception ex)
            {
                string errorMessage = string.Format(Resources.Strings.ErrorMessageFailToLoadSequence, SequenceName);
                throw new Exception($"{errorMessage} {ex.Message}");
            }

            for (int i = 0; i < RepeatCount; i++)
            {
                string logLoop = string.Format(Resources.Strings.SequenceActionLoopNumber, i + 1, RepeatCount);
                Logger.Log(logLoop);
                foreach (var action in sequence.Actions)
                {
                    await action.Execute(token);
                }
            }
        }
        public override async Task Execute(int x, int y, CancellationToken token)
        {
            await Execute(token);
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
