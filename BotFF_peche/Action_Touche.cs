using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFF_peche
{
    class Action_Touche : Action
    {
        public Action_Touche()
        {
            type = (int) ActionType.Touche;
        }

        public String key { get; set; }

        public override string ToString()
        {
            return "Action Touche; Touche : " + key;
        }
    }
}
