using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFF_peche
{
    class Action_Attente : Action
    {
        public Action_Attente()
        {
            type = (int)ActionType.Attente;
        }

        public int delai { get; set; }

        public override string ToString()
        {
            return "Action Attente; Delai : " + delai;
        }
    }
}
