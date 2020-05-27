using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFF_peche
{
    class Action_Si_Image : Action
    {
        public Action_Si_Image()
        {
            type = (int)ActionType.Si_Image;
        }

        public String chemin { get; set; }
        public int tolerance { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }

        public String ifTrueSequence { get; set; }
        public String ifFalseSequence { get; set; }

        public override string ToString()
        {
            return "Action Si Image; Image : " + chemin + "; Tolérance : " + tolerance + "; X1 : " + x1 + "; Y1 : " + y1 + "; X2 : " + x2 + "; Y2 : " + y2 + "; Si : " + ifTrueSequence + "; Sinon : " + ifFalseSequence;
        }
    }
}
