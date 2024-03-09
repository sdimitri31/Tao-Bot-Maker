using System;

namespace Tao_Bot_Maker
{
    public class ActionImageSearch : Action
    {
        public ActionImageSearch(string errorMessage = "")
        {
            Type = (int)ActionType.ImageSearch;
            ErrorMessage = errorMessage;
        }
        public ActionImageSearch(string pictureName, int threshold, int x1, int x2, int y1, int y2, int expiration, string ifFound, string ifNotFound, string errorMessage = "")
        {
            Type = (int)ActionType.ImageSearch;
            ErrorMessage = errorMessage;
            PictureName = pictureName;
            Threshold = threshold;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            Expiration = expiration;
            IfFound = ifFound;
            IfNotFound = ifNotFound;
        }
        public string PictureName { get; set; }
        public int Threshold { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Expiration { get; set; }
        public string IfFound { get; set; }
        public string IfNotFound { get; set; }

        public override string ToString()
        {
            string text = "";
            text +=         Properties.strings.action + " : " + Properties.strings.ActionName_ImageSearch;
            text += " | " + Properties.strings.action_Member_PictureName + " : " + PictureName;
            text += " | " + Properties.strings.action_Member_Threshold + " : " + Threshold;
            text += " | " + Properties.strings.action_Member_X1 + " : " + X1;
            text += " | " + Properties.strings.action_Member_Y1 + " : " + Y1;
            text += " | " + Properties.strings.action_Member_X2 + " : " + X2;
            text += " | " + Properties.strings.action_Member_Y2 + " : " + Y2;
            text += " | " + Properties.strings.action_Member_Expiration + " : " + Expiration;
            text += " | " + Properties.strings.action_Member_IfFound + " : " + IfFound;
            text += " | " + Properties.strings.action_Member_IfNotFound + " : " + IfNotFound;

            return text;
        }
    }
}
