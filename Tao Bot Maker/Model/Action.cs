using System;

namespace Tao_Bot_Maker
{
    public class Action
    {
        /// <summary>
        /// Enum containing all action type
        /// </summary>
        public enum ActionType
        {
            Text = 0,
            Wait = 1,
            Click = 5,
            Loop = 6,
            ImageSearch = 7,
            Key = 8
        }

        /// <summary>
        /// Enum containing all action type no longer supported
        /// </summary>
        public enum DeprecatedActionType
        {
            PictureWait = 2,
            IfPicture = 3,
            Sequence = 4,
        }

        public int Type { get; set; }

        /// <summary>
        /// Store a message containing details about errors when creating an action
        /// </summary>
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return "Main Class Action";
        }

        public Action(string errorMessage = "")
        {
            ErrorMessage = errorMessage;
        }

    }
}
