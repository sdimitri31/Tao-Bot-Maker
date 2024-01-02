namespace Tao_Bot_Maker
{
    class ActionWait : Action
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
            return "Action Wait; Wait time : " + WaitTime + "ms";
        }
    }
}
