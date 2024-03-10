using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionTextController
    {
        //Default values
        private static readonly string _defaultKey = "A";

        /// <summary>
        /// Create an action with given parameters
        /// </summary>
        /// <param name="text">String to type</param>
        /// <returns>ActionKey : with given parameters or default value if error. ErrorMessage : empty if no error or details about it</returns>
        public static ActionText CreateAction(string text)
        {
            string errorMessage = string.Empty;

            if (!ValidateText(text, out string error))
            {
                errorMessage += error + "\r\n";
                text = _defaultKey;
            }

            ActionText action = new ActionText(text, errorMessage);

            return action;
        }

        private static bool ValidateText(string text, out string errorMessage)
        {
            errorMessage = string.Empty;

            //If key not entered
            if (string.IsNullOrEmpty(text))
            {
                errorMessage = Properties.strings.action_ErrorMessage_Text_NotEntered;
                Log.Write("ValidateText(" + text + ") Result : false", Log.ERROR);
                return false;
            }
            else
            {
                Log.Write("ValidateText(" + text + ") Result : true", Log.TRACE);
                return true;
            }
        }

        public static ActionText GetActionFromControl(ActionTextPanel panel)
        {
            ActionText action = CreateAction(panel.Text);

            return action;
        }

        public static ActionText GetActionFromXElement(XElement xmlAction)
        {
            string key = (string)xmlAction;

            ActionText action = CreateAction(key);

            return action;
        }
    }
}
