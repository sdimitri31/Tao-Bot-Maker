using System;
using System.Windows.Forms;
using System.Xml.Linq;
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
        public static string[] GetActionTypeNames()
        {
            int typeCount = Enum.GetValues(typeof(Action.ActionType)).Length;
            string[] actionTypeList = new string[typeCount];

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
                ComboboxItemActionType actionType = new ComboboxItemActionType
                {
                    ActionTypeId = typeId,
                    DisplayText = GetTypeName(typeId)
                };
                actionTypeList[i] = actionType;
                i++;
            }
            return actionTypeList;
        }

        public static string GetTypeName(int type)
        {
            switch (type)
            {
                case (int)Action.ActionType.Text:
                    return Properties.strings.ActionName_Text;
                case (int)Action.ActionType.Wait:
                    return Properties.strings.ActionName_Wait;
                case (int)Action.DeprecatedActionType.PictureWait:
                    return Properties.strings.ActionName_PictureWait;
                case (int)Action.DeprecatedActionType.IfPicture:
                    return Properties.strings.ActionName_IfPicture;
                case (int)Action.DeprecatedActionType.Sequence:
                    return Properties.strings.ActionName_Sequence;
                case (int)Action.ActionType.Click:
                    return Properties.strings.ActionName_Click;
                case (int)Action.ActionType.Loop:
                    return Properties.strings.ActionName_Loop;
                case (int)Action.ActionType.ImageSearch:
                    return Properties.strings.ActionName_ImageSearch;
                case (int)Action.ActionType.Key:
                    return Properties.strings.ActionName_Key;
                default:
                    return Properties.strings.ActionName_Unknown;

            }
        }

        public static int GetTypeFromName(string typeName)
        {
            if (typeName == Properties.strings.ActionName_Text) return (int)Action.ActionType.Text;
            else if (typeName == Properties.strings.ActionName_Wait) return (int)Action.ActionType.Wait;
            else if (typeName == Properties.strings.ActionName_PictureWait) return (int)Action.DeprecatedActionType.PictureWait;
            else if (typeName == Properties.strings.ActionName_IfPicture) return (int)Action.DeprecatedActionType.IfPicture;
            else if (typeName == Properties.strings.ActionName_Sequence) return (int)Action.DeprecatedActionType.Sequence;
            else if (typeName == Properties.strings.ActionName_Click) return (int)Action.ActionType.Click;
            else if (typeName == Properties.strings.ActionName_Loop) return (int)Action.ActionType.Loop;
            else if (typeName == Properties.strings.ActionName_ImageSearch) return (int)Action.ActionType.ImageSearch;
            else if (typeName == Properties.strings.ActionName_Key) return (int)Action.ActionType.Key;
            else return -1;
        }

        public static Action GetActionFromControl(int type, Control control)
        {
            switch (type)
            {
                case (int)Action.ActionType.Text:
                    return ActionTextController.GetActionFromControl((ActionTextPanel)control);
                case (int)Action.ActionType.Wait:
                    return ActionWaitController.GetActionFromControl((ActionWaitPanel)control);
                case (int)Action.DeprecatedActionType.Sequence:
                    return ActionSequenceController.GetActionFromControl((ActionSequencePanel)control);
                case (int)Action.ActionType.Click:
                    return ActionClickController.GetActionFromControl((ActionClickPanel)control);
                case (int)Action.ActionType.Loop:
                    return ActionLoopController.GetActionFromControl((ActionLoopPanel)control);
                case (int)Action.ActionType.ImageSearch:
                    return ActionImageSearchController.GetActionFromControl((ActionImageSearchPanel)control);
                case (int)Action.ActionType.Key:
                    return ActionKeyController.GetActionFromControl((ActionKeyPanel)control);
                default:
                    return new Action("INVALID ACTION TYPE");
            }
        }

        public static Action GetActionFromXElement(int type, XElement xmlAction)
        {
            switch (type)
            {
                case (int)Action.ActionType.Text:
                    return ActionTextController.GetActionFromXElement(xmlAction);
                case (int)Action.ActionType.Wait:
                    return ActionWaitController.GetActionFromXElement(xmlAction);
                case (int)Action.DeprecatedActionType.Sequence:
                    return ActionSequenceController.GetActionFromXElement(xmlAction);
                case (int)Action.ActionType.Click:
                    return ActionClickController.GetActionFromXElement(xmlAction);
                case (int)Action.ActionType.Loop:
                    return ActionLoopController.GetActionFromXElement(xmlAction);
                case (int)Action.ActionType.ImageSearch:
                    return ActionImageSearchController.GetActionFromXElement(xmlAction);
                case (int)Action.ActionType.Key:
                    return ActionKeyController.GetActionFromXElement(xmlAction);
                default:
                    return new Action("INVALID ACTION TYPE");
            }
        }

        public static Control CreatePanel(int type, ActionView actionView, Action action = null)
        {
            switch (type)
            {
                case (int)Action.ActionType.Text:
                    return new ActionTextPanel(actionView, action);
                case (int)Action.ActionType.Wait:
                    return new ActionWaitPanel(action);
                case (int)Action.DeprecatedActionType.Sequence:
                    return new ActionSequencePanel(actionView, action);
                case (int)Action.ActionType.Click:
                    return new ActionClickPanel(actionView, action);
                case (int)Action.ActionType.Loop:
                    return new ActionLoopPanel(actionView, action);
                case (int)Action.ActionType.ImageSearch:
                    return new ActionImageSearchPanel(actionView, action);
                case (int)Action.ActionType.Key:
                    return new ActionKeyPanel(action);
                default:
                    return null;
            }
        }
    }
}
