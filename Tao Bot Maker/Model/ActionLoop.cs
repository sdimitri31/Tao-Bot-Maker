namespace Tao_Bot_Maker
{
    public class ActionLoop : Action
    {
        public ActionLoop(string errorMessage = "")
        {
            Type = (int)ActionType.Loop;
            ErrorMessage = errorMessage;
        }

        public ActionLoop(string sequenceName, int repeatNumber, string errorMessage = "")
        {
            Type = (int)ActionType.Loop;
            ErrorMessage= errorMessage;
            SequenceName = sequenceName;
            RepeatNumber = repeatNumber;
        }

        public string SequenceName { get; set; }
        
        public int RepeatNumber { get; set; }

        public override string ToString()
        {
            string text = "";
            text += Properties.strings.action + " : " + Properties.strings.ActionName_Loop;
            text += " | " + Properties.strings.action_Member_Sequence + " : " + SequenceName;
            text += " | " + Properties.strings.action_Member_RepeatNumber + " : " + RepeatNumber;

            return text;
        }
    }
}
