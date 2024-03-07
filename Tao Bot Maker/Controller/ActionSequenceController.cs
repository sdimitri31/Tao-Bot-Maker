using System.Windows.Forms;
using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionSequenceController
    {
        //Default values
        private static readonly string _defaultName = "";

        public static (ActionSequence actionSequence, string errorMessage) CreateAction(string name)
        {
            string errorMessage = string.Empty;

            if (!ValidateSequenceName(name, out string error))
            {
                errorMessage += error + "\r\n";
                name = _defaultName;
            }

            ActionSequence actionSequence = new ActionSequence(name);

            return (actionSequence, errorMessage);
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

        public static (ActionSequence actionSequence, string errorMessage) GetActionFromControl(ActionSequencePanel panel)
        {
            var (actionSequence, errorMessage) = CreateAction(panel.SequenceName);

            return (actionSequence, errorMessage);
        }

        public static (ActionSequence action, string errorMessage) GetActionFromXElement(XElement xmlAction)
        {
            string sequence = (string)xmlAction;

            var (actionSequence, errorMessage) = CreateAction(sequence);

            return (actionSequence, errorMessage);
        }
    }
}
