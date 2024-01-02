using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionController
    {
        public ActionController() { }
        public static String[] GetActionTypeNames()
        {
            String[] actionTypeList = new String[Enum.GetValues(typeof(Action.ActionType)).Length];
            foreach (int i in Enum.GetValues(typeof(Action.ActionType)))
            {
                actionTypeList[i] = GetTypeName(i);
            }
            return actionTypeList;
        }

        public static String GetTypeName(int type)
        {
            switch (type)
            {
                case (int)Action.ActionType.Key:
                    return "Touche";
                case (int)Action.ActionType.Wait:
                    return "Attente";
                case (int)Action.ActionType.PictureWait:
                    return "Attente image";
                case (int)Action.ActionType.IfPicture:
                    return "Si image";
                case (int)Action.ActionType.Sequence:
                    return "Séquence";
                case (int)Action.ActionType.Click:
                    return "Clic";
                case (int)Action.ActionType.Loop:
                    return "Boucle";
                default:
                    return "Unknown type";
            }
        }
        public static Control GetControlView(int type, ActionView actionView)
        {
            switch (type)
            {
                case (int)Action.ActionType.Key:
                    return new ActionKeyPanel();
                case (int)Action.ActionType.Wait:
                    return new ActionWaitPanel();
                case (int)Action.ActionType.PictureWait:
                    return new ActionPictureWaitPanel(actionView);
                case (int)Action.ActionType.IfPicture:
                    return new ActionIfPicturePanel(actionView);
                case (int)Action.ActionType.Sequence:
                    return new ActionSequencePanel();
                case (int)Action.ActionType.Click:
                    return new ActionClickPanel(actionView);
                case (int)Action.ActionType.Loop:
                    return new ActionLoopPanel();
                default:
                    return null;
            }
        }

        public static Action GetActionFromControl(int type, Control control)
        {
            switch (type)
            {
                case (int)Action.ActionType.Key:
                    return ActionKeyController.GetActionFromControl((ActionKeyPanel)control);
                case (int)Action.ActionType.Wait:
                    return ActionWaitController.GetActionFromControl((ActionWaitPanel)control);
                case (int)Action.ActionType.PictureWait:
                    return ActionPictureWaitController.GetActionFromControl((ActionPictureWaitPanel)control);
                case (int)Action.ActionType.IfPicture:
                    return ActionIfPictureController.GetActionFromControl((ActionIfPicturePanel)control);
                case (int)Action.ActionType.Sequence:
                    return ActionSequenceController.GetActionFromControl((ActionSequencePanel)control);
                case (int)Action.ActionType.Click:
                    return ActionClickController.GetActionFromControl((ActionClickPanel)control);
                case (int)Action.ActionType.Loop:
                    return ActionLoopController.GetActionFromControl((ActionLoopPanel)control);
                default:
                    return null;
            }
        }
    }
}
