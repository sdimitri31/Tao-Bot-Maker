using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFF_peche
{
    class Action_Sequence : Action
    {
        public Action_Sequence()
        {
            type = (int)ActionType.Sequence;
        }

        public String chemin { get; set; }

        public override string ToString()
        {
            return "Action Sequence; Séquence : " + chemin;
        }
    }
}
