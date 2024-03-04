
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionWaitController
    {
        public static (ActionWait actionWait, string errorMessage) CreateAction(int waitTime)
        {
            int errorCount = 0;
            string errorMessage = "";

            if (!ValidateWaitTime(waitTime, out string error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            ActionWait actionWait = null;

            if (errorCount == 0)
            {
                actionWait = new ActionWait(waitTime);
            }

            //Return Error message if there is an error
            if (actionWait == null)
            {
                Log.Write(errorMessage, LogFramework.Log.ERROR);
                return (null, errorMessage);
            }
            //Or ActionClick if no error
            else
                return (actionWait, "");
        }

        private static bool ValidateWaitTime(int waitTime, out string errorMessage)
        {
            errorMessage = "";

            if ((waitTime >= 0) && (waitTime <= 999999))
            {
                Log.Write("ValidateWaitTime(" + waitTime + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_RepeatNumber;
                Log.Write("ValidatValidateWaitTimeeRepeatNumber(" + waitTime + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        public static (ActionWait actionWait, string errorMessage) GetActionFromControl(ActionWaitPanel panel)
        {
            var (actionWait, errorMessage) = CreateAction(panel.WaitTime);

            return (actionWait, errorMessage);
        }

    }
}
