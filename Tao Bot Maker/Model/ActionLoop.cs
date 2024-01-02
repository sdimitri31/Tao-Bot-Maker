using System;

namespace Tao_Bot_Maker
{
    class ActionLoop : Action
    {
        public ActionLoop()
        {
            Type = (int)ActionType.Loop;
        }
        public ActionLoop(String sequencePath, int numberOfRepetitions)
        {
            Type = (int)ActionType.Loop;
            SequencePath = sequencePath;
            NumberOfRepetitions = numberOfRepetitions;
        }

        public String SequencePath { get; set; }
        public int NumberOfRepetitions { get; set; }

        public override string ToString()
        {
            return "Action Boucle; Séquence : " + SequencePath + "; Répétition : " + NumberOfRepetitions;
        }
    }
}
