using System.Windows.Forms;
using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    /// <summary>
    /// DEPRECATED DO NOT USE
    /// </summary>
    public class ActionSequenceController
    {
        //Default values
        private static readonly string _defaultName = "";

        public static ActionSequence CreateAction(string name)
        {
            string errorMessage = string.Empty;

            if (!ValidateSequenceName(name, out string error))
            {
                errorMessage += error + "\r\n";
                name = _defaultName;
            }

            ActionSequence actionSequence = new ActionSequence(name, errorMessage);

            return actionSequence;
        }

        private static bool ValidateSequenceName(string sequenceName, out string errorMessage)
        {
            errorMessage = string.Empty;

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

        public static ActionSequence GetActionFromControl(ActionSequencePanel panel)
        {
            ActionSequence action = CreateAction(panel.SequenceName);

            return action;
        }

        public static ActionSequence GetActionFromXElement(XElement xmlAction)
        {
            string sequence = (string)xmlAction;

            ActionSequence action = CreateAction(sequence);

            return action;
        }
    }
}
