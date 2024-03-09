using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionKeyController
    {
        //Default values
        private static readonly string _defaultKey = "A";

        /// <summary>
        /// Create an action with given parameters
        /// </summary>
        /// <param name="key">Key to press</param>
        /// <returns>ActionKey : with given parameters or default value if error. ErrorMessage : empty if no error or details about it</returns>
        public static ActionKey CreateAction(string key)
        {
            string errorMessage = string.Empty;

            if (!ValidateKey(key, out string error))
            {
                errorMessage += error + "\r\n";
                key = _defaultKey;
            }

            ActionKey action = new ActionKey(key, errorMessage);

            return action;
        }

        private static bool ValidateKey(string key, out string errorMessage)
        {
            errorMessage = string.Empty;

            //If key not entered
            if (string.IsNullOrEmpty(key))
            {
                errorMessage = Properties.strings.action_ErrorMessage_Key_NotEntered;
                Log.Write("ValidateKey(" + key + ") Result : false", Log.ERROR);
                return false;
            }
            //If too many chars
            else if (key.Length > 1) 
            {
                errorMessage = Properties.strings.action_ErrorMessage_Key_Lenght;
                Log.Write("ValidateKey(" + key + ") Result : false", Log.ERROR);
                return false;
            }
            else
            {
                Log.Write("ValidateKey(" + key + ") Result : true", Log.TRACE);
                return true;
            }
        }

        public static ActionKey GetActionFromControl(ActionKeyPanel panel)
        {
            ActionKey action = CreateAction(panel.Key);

            return action;
        }

        public static ActionKey GetActionFromXElement(XElement xmlAction)
        {
            string key = (string)xmlAction;

            ActionKey action = CreateAction(key);

            return action;
        }
    }
}
