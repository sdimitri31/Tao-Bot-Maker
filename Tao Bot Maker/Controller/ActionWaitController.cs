
using System.Windows.Forms;
using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionWaitController
    {
        //Default values
        private static readonly int _defaultWaitTime = 0;

        public static (ActionWait actionWait, string errorMessage) CreateAction(int waitTime)
        {
            string errorMessage = string.Empty;

            if (!ValidateWaitTime(waitTime, out string error))
            {
                errorMessage += error + "\r\n";
                waitTime = _defaultWaitTime;
            }

            ActionWait actionWait = new ActionWait(waitTime);

            return (actionWait, errorMessage);
        }

        private static bool ValidateWaitTime(int waitTime, out string errorMessage)
        {
            errorMessage = string.Empty;

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

        public static (ActionWait action, string errorMessage) GetActionFromXElement(XElement xmlAction)
        {
            //Version ajusting and crash prevention
            string errors = string.Empty;

            int waitTime = _defaultWaitTime;
            //If parsing error
            if (!int.TryParse(xmlAction.Value, out waitTime))
            {
                errors += Properties.strings.action_Member_WaitTime + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
            }

            var (actionWait, errorMessage) = CreateAction(waitTime);

            errors += errorMessage;

            return (actionWait, errors);
        }

    }
}
