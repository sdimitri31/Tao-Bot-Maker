using System.Collections.Generic;

namespace Tao_Bot_Maker
{
    public class Sequence
    {
        public string Name { get; set; }

        public List<Action> Actions { get; set; }
        
        public bool IsSaved { get; set; }

        public Sequence(string name = "", List<Action> actions = null, bool isSaved = true)
        {
            this.Name = name;

            if (actions != null) this.Actions = actions;
            else this.Actions = new List<Action>();

            this.IsSaved = isSaved;
        }

    }
}
