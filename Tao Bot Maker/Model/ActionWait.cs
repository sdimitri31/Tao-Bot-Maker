namespace Tao_Bot_Maker
{
    public class ActionWait : Action
    {
        public ActionWait()
        {
            Type = (int)ActionType.Wait;
        }

        public ActionWait(int waitTime)
        {
            Type = (int)ActionType.Wait;
            WaitTime = waitTime;
        }

        public int WaitTime { get; set; }

        public override string ToString()
        {
            string text = "";
            text += Properties.strings.action + " : " + Properties.strings.ActionName_Wait;
            text += " | " + Properties.strings.action_Member_WaitTime + " : " + WaitTime;

            return text;
        }
    }
}
