namespace Tao_Bot_Maker
{
    /// <summary>
    /// DEPRECATED DO NOT USE
    /// </summary>
    class ActionPictureWait : Action
    {
        public ActionPictureWait()
        {
            Type = (int)DeprecatedActionType.PictureWait;
        }

        public ActionPictureWait(string picturePath, int threshold, int x1, int x2, int y1, int y2, int waitTime, string sequenceIfExpired)
        {
            Type = (int)DeprecatedActionType.PictureWait;
            PictureName = picturePath;
            Threshold = threshold;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            WaitTime = waitTime;
            SequenceIfExpired = sequenceIfExpired;
        }

        public string PictureName { get; set; }
        public int Threshold { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int WaitTime { get; set; }
        public string SequenceIfExpired { get; set; }

        public override string ToString()
        {
            string text = Properties.strings.action_ErrorMessage_DeprecatedType;
            text += " | Action Attente d'image; Image : " + PictureName + "; Tolérance : " + Threshold + "; X1 : " + X1 + "; Y1 : " + Y1 + "; X2 : " + X2 + "; Y2 : " + Y2 + "; Attente max : " + WaitTime + "; Séquence si expiration : " + SequenceIfExpired;
            return text;
        }
    }
}
