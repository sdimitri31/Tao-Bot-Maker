
using System;
using System.Windows.Forms;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionKeyController
    {
        public ActionKeyController() { }

        public static Action GetActionFromControl(ActionKeyPanel panel)
        {
            String key = panel.Key;
            ActionKey actionKey = null;
            if (key != "")
            {
                actionKey = new ActionKey(key);
            }
            else
            {
                MessageBox.Show("Error : Key should be a entered");
            }

            return actionKey;
        }

    }
}
