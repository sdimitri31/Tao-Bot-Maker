using System;

namespace Tao_Bot_Maker
{
    class ActionSequence : Action
    {
        public ActionSequence()
        {
            Type = (int)ActionType.Sequence;
        }

        public ActionSequence(String sequencePath)
        {
            Type = (int)ActionType.Sequence;
            SequencePath = sequencePath;
        }
        public String SequencePath { get; set; }

        public override string ToString()
        {
            return "Action Sequence; Séquence : " + SequencePath;
        }
    }
}
