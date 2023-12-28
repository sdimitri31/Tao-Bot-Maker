using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker
{
    class Action_Boucle : Action
    {
        public Action_Boucle()
        {
            type = (int)ActionType.Boucle;
        }

        public String chemin { get; set; }
        public int nbRepetition { get; set; }

        public override string ToString()
        {
            return "Action Boucle; Séquence : " + chemin + "; Répétition : " + nbRepetition ;
        }
    }
}
