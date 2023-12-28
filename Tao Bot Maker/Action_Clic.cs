using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker
{
    class Action_Clic : Action
    {
        public Action_Clic()
        {
            type = (int)ActionType.Clic;
        }

        public String clic { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public override string ToString()
        {
            return "Action Clic; Clic : " + clic + "; X : " + x + "; Y : " + y;
        }
    }
}
