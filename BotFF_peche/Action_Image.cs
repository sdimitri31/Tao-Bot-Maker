using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker
{
    class Action_Image : Action
    {
        public Action_Image()
        {
            type = (int)ActionType.Image_Attente;
        }

        public String chemin { get; set; }
        public int tolerance { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }
        public int waitTime { get; set; }
        public String sequenceIfExpired { get; set; }

        public override string ToString()
        {
            return "Action Attente d'image; Image : " + chemin + "; Tolérance : " + tolerance + "; X1 : " + x1 + "; Y1 : " + y1 + "; X2 : " + x2 + "; Y2 : " + y2 + "; Attente max : " + waitTime + "; Séquence si expiration : " + sequenceIfExpired;
        }
    }
}
