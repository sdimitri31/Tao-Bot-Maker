using System;

namespace Tao_Bot_Maker
{
    class ActionIfPicture : Action
    {
        /// <summary>
        /// DEPRECATED DO NOT USE
        /// </summary>
        public ActionIfPicture()
        {
            Type = (int)DeprecatedActionType.IfPicture;
        }

        /// <summary>
        /// DEPRECATED DO NOT USE
        /// </summary>
        public ActionIfPicture(String pictureName, int threshold, int x1, int x2, int y1, int y2, String ifFound, String ifNotFound)
        {
            Type = (int)DeprecatedActionType.IfPicture;
            PictureName = pictureName;
            Threshold = threshold;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            IfFound = ifFound;
            IfNotFound = ifNotFound;
        }
        public String PictureName { get; set; }
        public int Threshold { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public String IfFound { get; set; }
        public String IfNotFound { get; set; }

        public override string ToString()
        {
            return "DEPRECATED ! NEEDS TO BE CHANGED ;Action Si Image; Image : " + PictureName + "; Tolérance : " + Threshold + "; X1 : " + X1 + "; Y1 : " + Y1 + "; X2 : " + X2 + "; Y2 : " + Y2 + "; Si : " + IfFound + "; Sinon : " + IfNotFound;
        }
    }
}
