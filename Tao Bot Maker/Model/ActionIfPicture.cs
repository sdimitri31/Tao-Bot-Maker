namespace Tao_Bot_Maker
{
    /// <summary>
    /// DEPRECATED DO NOT USE
    /// </summary>
    class ActionIfPicture : Action
    {
        public ActionIfPicture()
        {
            Type = (int)DeprecatedActionType.IfPicture;
        }

        public ActionIfPicture(string pictureName, int threshold, int x1, int x2, int y1, int y2, string ifFound, string ifNotFound)
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
        public string PictureName { get; set; }
        public int Threshold { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public string IfFound { get; set; }
        public string IfNotFound { get; set; }

        public override string ToString()
        {
            string text = Properties.strings.action_ErrorMessage_DeprecatedType;
            text += " | Action Si Image; Image: " + PictureName + "; Tolérance: " + Threshold + "; X1: " + X1 + "; Y1: " + Y1 + "; X2: " + X2 + "; Y2: " + Y2 + "; Si: " + IfFound + "; Sinon: " + IfNotFound;
            return text;
        }
    }
}
