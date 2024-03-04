using System;

namespace Tao_Bot_Maker
{
    public class ActionSequence : Action
    {
        public ActionSequence()
        {
            Type = (int)ActionType.Sequence;
        }

        public ActionSequence(string sequenceName)
        {
            Type = (int)ActionType.Sequence;
            SequenceName = sequenceName;
        }
        public string SequenceName { get; set; }

        public override string ToString()
        {
            string text = "";
            text += Properties.strings.action + " : " + Properties.strings.ActionName_Sequence;
            text += " | " + Properties.strings.action_Member_Sequence + " : " + SequenceName;
            
            return text;
        }
    }
}
