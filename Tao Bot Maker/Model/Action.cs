using System;

namespace Tao_Bot_Maker
{
    public class Action
    {
        //Type d'action : Touche; Attente; Recherche Image;
        public enum ActionType
        {
            Key = 0,
            Wait = 1,
            PictureWait = 2,
            IfPicture = 3,
            Sequence = 4,
            Click = 5,
            Loop = 6
        }

        public int Type { get; set; }

        public override string ToString()
        {
            return "Main Class Action";
        }

    }
}
