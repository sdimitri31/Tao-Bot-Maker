using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionController
    {
        public ActionController() { }

        /// <summary>
        /// Get an array with all actions types names
        /// </summary>
        /// <returns></returns>
        public static String[] GetActionTypeNames()
        {
            int typeCount = Enum.GetValues(typeof(Action.ActionType)).Length;
            String[] actionTypeList = new String[typeCount];

            int i = 0;
            foreach (int typeId in Enum.GetValues(typeof(Action.ActionType)))
            {
                actionTypeList[i] = GetTypeName(typeId);
                i++;
            }
            return actionTypeList;
        }

        public static ComboboxItemActionType[] GetActionItems()
        {
            int typeCount = Enum.GetValues(typeof(Action.ActionType)).Length;
            ComboboxItemActionType[] actionTypeList = new ComboboxItemActionType[typeCount];

            int i = 0;
            foreach (int typeId in Enum.GetValues(typeof(Action.ActionType)))
            {
                ComboboxItemActionType actionType = new ComboboxItemActionType();
                actionType.ActionTypeId = typeId;
                actionType.DisplayText = GetTypeName(typeId);
                actionTypeList[i] = actionType;
                i++;
            }
            return actionTypeList;
        }

        public static String GetTypeName(int type)
        {
            switch (type)
            {
                case (int)Action.ActionType.Key:
                    return Properties.strings.ActionName_Key;
                case (int)Action.ActionType.Wait:
                    return Properties.strings.ActionName_Wait;
                case (int)Action.DeprecatedActionType.PictureWait:
                    return Properties.strings.ActionName_PictureWait;
                case (int)Action.DeprecatedActionType.IfPicture:
                    return Properties.strings.ActionName_IfPicture;
                case (int)Action.ActionType.Sequence:
                    return Properties.strings.ActionName_Sequence;
                case (int)Action.ActionType.Click:
                    return Properties.strings.ActionName_Click;
                case (int)Action.ActionType.Loop:
                    return Properties.strings.ActionName_Loop;
                case (int)Action.ActionType.ImageSearch:
                    return Properties.strings.ActionName_ImageSearch;
                default:
                    return Properties.strings.ActionName_Unknown;

            }
        }

        public static int GetTypeFromName(string typeName)
        {
            if (typeName == Properties.strings.ActionName_Key) return (int)Action.ActionType.Key;
            else if (typeName == Properties.strings.ActionName_Wait) return (int)Action.ActionType.Wait;
            else if (typeName == Properties.strings.ActionName_PictureWait) return (int)Action.DeprecatedActionType.PictureWait;
            else if (typeName == Properties.strings.ActionName_IfPicture) return (int)Action.DeprecatedActionType.IfPicture;
            else if (typeName == Properties.strings.ActionName_Sequence) return (int)Action.ActionType.Sequence;
            else if (typeName == Properties.strings.ActionName_Click) return (int)Action.ActionType.Click;
            else if (typeName == Properties.strings.ActionName_Loop) return (int)Action.ActionType.Loop;
            else if (typeName == Properties.strings.ActionName_ImageSearch) return (int)Action.ActionType.ImageSearch;
            else return -1;
        }

        public static Action GetActionFromControl(int type, Control control)
        {
            switch (type)
            {
                case (int)Action.ActionType.Key:
                    return ActionKeyController.GetActionFromControl((ActionKeyPanel)control);
                case (int)Action.ActionType.Wait:
                    return ActionWaitController.GetActionFromControl((ActionWaitPanel)control);
                case (int)Action.ActionType.Sequence:
                    return ActionSequenceController.GetActionFromControl((ActionSequencePanel)control);
                case (int)Action.ActionType.Click:
                    return ActionClickController.GetActionFromControl((ActionClickPanel)control);
                case (int)Action.ActionType.Loop:
                    return ActionLoopController.GetActionFromControl((ActionLoopPanel)control);
                case (int)Action.ActionType.ImageSearch:
                    return ActionImageSearchController.GetActionFromControl((ActionImageSearchPanel)control);
                default:
                    return null;
            }
        }

        public static Control CreatePanel(int type, ActionView actionView, Action action = null)
        {
            switch (type)
            {
                case (int)Action.ActionType.Key:
                    return new ActionKeyPanel(action);
                case (int)Action.ActionType.Wait:
                    return new ActionWaitPanel(action);
                case (int)Action.ActionType.Sequence:
                    return new ActionSequencePanel(actionView, action);
                case (int)Action.ActionType.Click:
                    return new ActionClickPanel(actionView, action);
                case (int)Action.ActionType.Loop:
                    return new ActionLoopPanel(action);
                case (int)Action.ActionType.ImageSearch:
                    return new ActionImageSearchPanel(actionView, action);
                default:
                    return null;
            }
        }
    }
}
