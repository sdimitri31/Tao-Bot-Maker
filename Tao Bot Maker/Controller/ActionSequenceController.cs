using System.Windows.Forms;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionSequenceController
    {
        public ActionSequenceController() { }

        public static Action GetActionFromControl(ActionSequencePanel panel)
        {
            string sequencePath = panel.SequencePath;
            ActionSequence actionSequence = null;

            if (sequencePath != "")
            {
                actionSequence = new ActionSequence(sequencePath);
            }
            else
            {
                MessageBox.Show("Error : A sequence must be selected");
            }

            return actionSequence;
        }

    }
}
