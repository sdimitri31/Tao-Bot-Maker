using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionLoopController
    {
        public static (ActionLoop actionLoop, string errorMessage) CreateAction(string sequenceName, int repeatNumber)
        {
            int errorCount = 0;
            string errorMessage = "";

            if (!ValidateSequenceName(sequenceName, out string error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            if (!ValidateRepeatNumber(repeatNumber, out error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            ActionLoop actionLoop = null;

            if (errorCount == 0)
            {
                actionLoop = new ActionLoop(sequenceName, repeatNumber);
            }

            //Return Error message if there is an error
            if (actionLoop == null)
            {
                Log.Write(errorMessage, LogFramework.Log.ERROR);
                return (null, errorMessage);
            }
            //Or ActionClick if no error
            else
                return (actionLoop, "");
        }

        private static bool ValidateSequenceName(string sequenceName, out string errorMessage)
        {
            errorMessage = "";

            if (!string.IsNullOrEmpty(sequenceName))
            {
                Log.Write("ValidateSequenceName(" + sequenceName + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_SequenceName;
                Log.Write("ValidateSequenceName(" + sequenceName + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        private static bool ValidateRepeatNumber(int repeatNumber, out string errorMessage)
        {
            errorMessage = "";

            if ((repeatNumber >= -1) && (repeatNumber <= 999999))
            {
                Log.Write("ValidateRepeatNumber(" + repeatNumber + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_RepeatNumber;
                Log.Write("ValidateRepeatNumber(" + repeatNumber + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        public static (ActionLoop actionLoop, string errorMessage) GetActionFromControl(ActionLoopPanel panel)
        {
            var (actionClick, errorMessage) = CreateAction(panel.SequenceName, panel.RepeatNumber);

            return (actionClick, errorMessage);
        }

    }
}
