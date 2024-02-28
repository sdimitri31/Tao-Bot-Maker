using System;

namespace Tao_Bot_Maker
{
    class ActionIfPicture : Action
    {
        public ActionIfPicture()
        {
            Type = (int)ActionType.IfPicture;
        }
        public ActionIfPicture(String pictureName, int threshold, int x1, int x2, int y1, int y2, int waitTime, String ifTrueSequence, String ifFalseSequence)
        {
            Type = (int)ActionType.IfPicture;
            PictureName = pictureName;
            Threshold = threshold;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            WaitTime = waitTime;
            SequenceIfFound = ifTrueSequence;
            SequenceIfNotFound = ifFalseSequence;
        }
        public String PictureName { get; set; }
        public int Threshold { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int WaitTime { get; set; }
        public String SequenceIfFound { get; set; }
        public String SequenceIfNotFound { get; set; }

        public override string ToString()
        {
            return "Action Si Image; Image : " + PictureName + "; Tolérance : " + Threshold + "; X1 : " + X1 + "; Y1 : " + Y1 + "; X2 : " + X2 + "; Y2 : " + Y2 + "; Si : " + SequenceIfFound + "; Sinon : " + SequenceIfNotFound;
        }
    }
}
