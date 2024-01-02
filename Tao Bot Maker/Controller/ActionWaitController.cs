
using System.Windows.Forms;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionWaitController
    {
        public ActionWaitController() { }

        public static Action GetActionFromControl(ActionWaitPanel panel)
        {
            int waitTime = panel.WaitTime;
            ActionWait actionWait = null;
            if (waitTime > 0)
            {
                actionWait = new ActionWait(waitTime);
            }
            else
            {
                MessageBox.Show("Error : Wait time should be a number greater than 0");
            }

            return actionWait;
        }

    }
}
