using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Tao_Bot_Maker.Action;

namespace Tao_Bot_Maker
{
    public class Sequence
    {
        public String SequenceName { get; set; }

        public List<Action> Actions { get; set; }

        public Sequence() 
        { 
            this.SequenceName = "";
            this.Actions = new List<Action>();
        }

    }
}
