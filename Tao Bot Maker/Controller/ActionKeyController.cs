
using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionKeyController
    {
        public static (ActionKey actionKey, string errorMessage) CreateAction(string key)
        {
            int errorCount = 0;
            string errorMessage = "";

            if (!ValidateKey(key, out string error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            ActionKey actionKey = null;

            if (errorCount == 0)
            {
                actionKey = new ActionKey(key);
            }

            //Return Error message if there is an error
            if (actionKey == null)
            {
                Log.Write(errorMessage, LogFramework.Log.ERROR);
                return (null, errorMessage);
            }
            //Or ActionClick if no error
            else
                return (actionKey, "");
        }

        private static bool ValidateKey(string key, out string errorMessage)
        {
            errorMessage = "";

            if (!string.IsNullOrEmpty(key))
            {
                Log.Write("ValidateKey(" + key + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_Key;
                Log.Write("ValidateKey(" + key + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        public static (ActionKey action, string errorMessage) GetActionFromControl(ActionKeyPanel panel)
        {
            var (actionClick, errorMessage) = CreateAction(panel.Key);

            return (actionClick, errorMessage);
        }

    }
}
