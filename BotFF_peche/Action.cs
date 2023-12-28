using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker
{
    public class Action
    {
        //Type d'action : Touche; Attente; Recherche Image;
        public enum ActionType
        {
            Touche = 0,
            Attente = 1,
            Image_Attente = 2,
            Si_Image = 3,
            Sequence = 4,
            Clic = 5,
            Boucle = 6
        }

        public int type { get; set; }
        public override string ToString()
        {
            return "Main Class Action";
        }


    }
}
