using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionLoopController
    {
        //Default values
        private static readonly string  _defaultName = "";
        private static readonly int     _defaultRepeatNumber = 1;

        public static ActionLoop CreateAction(string name, int repeatNumber)
        {
            string errorMessage = string.Empty;

            if (!ValidateSequenceName(name, out string error))
            {
                errorMessage += error + "\r\n";
                name = _defaultName;
            }

            if (!ValidateRepeatNumber(repeatNumber, out error))
            {
                errorMessage += error + "\r\n";
                repeatNumber = _defaultRepeatNumber;
            }

            ActionLoop action = new ActionLoop(name, repeatNumber, errorMessage);

            return action;
        }

        private static bool ValidateSequenceName(string sequenceName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!string.IsNullOrEmpty(sequenceName))
            {
                Log.Write("ValidateSequenceName(" + sequenceName + ") Result : true", Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_SequenceName;
                Log.Write("ValidateSequenceName(" + sequenceName + ") Result : false", Log.ERROR);
                return false;
            }
        }

        private static bool ValidateRepeatNumber(int repeatNumber, out string errorMessage)
        {
            errorMessage = string.Empty;

            if ((repeatNumber >= -1) && (repeatNumber <= 999999))
            {
                Log.Write("ValidateRepeatNumber(" + repeatNumber + ") Result : true", Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_RepeatNumber;
                Log.Write("ValidateRepeatNumber(" + repeatNumber + ") Result : false", Log.ERROR);
                return false;
            }
        }

        public static ActionLoop GetActionFromControl(ActionLoopPanel panel)
        {
            ActionLoop action = CreateAction(panel.SequenceName, panel.RepeatNumber);

            return action;
        }

        public static ActionLoop GetActionFromXElement(XElement xmlAction)
        {
            string name = (string)xmlAction;

            //Version ajusting and crash prevention
            string errors = string.Empty;

            int repeatNumber = _defaultRepeatNumber;
            if (xmlAction.Attribute("nbRepetition") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("nbRepetition").Value, out repeatNumber))
                {
                    errors += Properties.strings.action_Member_RepeatNumber + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_RepeatNumber + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            ActionLoop action = CreateAction(name, repeatNumber);

            action.ErrorMessage = errors + action.ErrorMessage;

            return action;
        }
    }
}
