using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;
using System.Windows.Forms;

namespace Tao_Bot_Maker
{
    public class ActionKeyController
    {
        //Default values
        private static readonly Keys _defaultKey = Keys.None;

        /// <summary>
        /// Create an action with given parameters
        /// </summary>
        /// <param name="text">String to type</param>
        /// <returns>ActionKey : with given parameters or default value if error. ErrorMessage : empty if no error or details about it</returns>
        public static ActionKey CreateAction(Keys key)
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

        private static bool ValidateKey(Keys key, out string errorMessage)
        {
            errorMessage = string.Empty;

            //If key not entered
            if (key == Keys.None)
            {
                errorMessage = Properties.strings.action_ErrorMessage_Key_NotEntered;
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
            //Version ajusting and crash prevention
            string errors = string.Empty;

            //If parsing error
            if (!int.TryParse((string)xmlAction, out int intKey))
            {
                errors = Properties.strings.action_Member_Key + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
            }

            Keys key = (Keys)intKey;

            ActionKey action = CreateAction(key);

            return action;
        }
    }
}
