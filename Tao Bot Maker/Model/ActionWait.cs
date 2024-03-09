namespace Tao_Bot_Maker
{
    public class ActionWait : Action
    {
        public ActionWait(string errorMessage = "")
        {
            Type = (int)ActionType.Wait;
            ErrorMessage = errorMessage;
        }

        public ActionWait(int waitTime, int waitTimeMax, bool isRandomInterval, string errorMessage = "")
        {
            Type = (int)ActionType.Wait;
            ErrorMessage = errorMessage;
            WaitTime = waitTime;
            WaitTimeMax = waitTimeMax;
            IsRandomInterval = isRandomInterval;
        }

        public int WaitTime { get; set; }

        public int WaitTimeMax { get; set; }

        public bool IsRandomInterval { get; set; }

        public override string ToString()
        {
            string text = "";
            text += Properties.strings.action + " : " + Properties.strings.ActionName_Wait;
            text += " | " + Properties.strings.action_Member_WaitTime + " : " + WaitTime;
            text += " | " + Properties.strings.action_Member_WaitTimeMax + " : " + WaitTimeMax;
            text += " | " + Properties.strings.action_Member_IsRandomInterval + " : " + IsRandomInterval;

            return text;
        }
    }
}
