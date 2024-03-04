using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionSequenceController
    {
        public static (ActionSequence actionSequence, string errorMessage) CreateAction(string sequenceName)
        {
            int errorCount = 0;
            string errorMessage = "";

            if (!ValidateSequenceName(sequenceName, out string error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            ActionSequence actionSequence = null;

            if (errorCount == 0)
            {
                actionSequence = new ActionSequence(sequenceName);
            }

            //Return Error message if there is an error
            if (actionSequence == null)
            {
                Log.Write(errorMessage, LogFramework.Log.ERROR);
                return (null, errorMessage);
            }
            //Or ActionClick if no error
            else
                return (actionSequence, "");
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

        public static (ActionSequence actionSequence, string errorMessage) GetActionFromControl(ActionSequencePanel panel)
        {
            var (actionSequence, errorMessage) = CreateAction(panel.SequenceName);

            return (actionSequence, errorMessage);
        }

    }
}
