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
        public string Name { get; set; }

        /// <summary>
        /// Contains all actions in this sequence
        /// </summary>
        public List<Action> Actions { get; set; }
        
        /// <summary>
        /// Contains error messages when action is not added with valid values
        /// </summary>
        public List<string> Errors { get; set; }

        public Sequence() 
        { 
            this.Name = "";
            this.Actions = new List<Action>();
            this.Errors = new List<string>();
        }

    }
}
