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
            Key = 0,
            Wait = 1,
            Sequence = 4,
            Click = 5,
            Loop = 6,
            ImageSearch = 7
        }

        /// <summary>
        /// Enum containing all action type no longer supported
        /// </summary>
        public enum DeprecatedActionType
        {
            PictureWait = 2,
            IfPicture = 3,
        }

        public int Type { get; set; }

        public override string ToString()
        {
            return "Main Class Action";
        }

    }
}
