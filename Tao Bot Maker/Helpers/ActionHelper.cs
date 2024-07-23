using System.Drawing;

namespace Tao_Bot_Maker.Controller
{
    public class ActionHelper
    {
        public static string GetActionTypeDisplayName(ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.MouseAction:
                    return Resources.Strings.ActionTypeMouse;
                case ActionType.TextAction:
                    return Resources.Strings.ActionTypeText;
                case ActionType.WaitAction:
                    return Resources.Strings.ActionTypeWait;
                case ActionType.SequenceAction:
                    return Resources.Strings.ActionTypeSequence;
                case ActionType.KeyAction:
                    return Resources.Strings.ActionTypeKey;
                case ActionType.ImageAction:
                    return Resources.Strings.ActionTypeImage;
                case ActionType.CorruptAction:
                    return Resources.Strings.ActionTypeCorrupted;
                default:
                    return actionType.ToString();
            }
        }

        public static Image GetActionTypeIcon(ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.MouseAction:
                    return Resources.Images.ActionTypeMouse;
                case ActionType.TextAction:
                    return Resources.Images.ActionTypeText;
                case ActionType.WaitAction:
                    return Resources.Images.ActionTypeWait;
                case ActionType.SequenceAction:
                    return Resources.Images.ActionTypeSequence;
                case ActionType.KeyAction:
                    return Resources.Images.ActionTypeKey;
                case ActionType.ImageAction:
                    return Resources.Images.ActionTypeImage;
                case ActionType.CorruptAction:
                    return Resources.Images.ActionTypeCorrupted;
                default:
                    return Resources.Images.ActionTypeCorrupted;
            }
        }
    }
}
