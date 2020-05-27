using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFF_peche
{
    class Sequence
    {
        private List<Action> actions = new List<Action>();

        public Sequence()
        {

        }

        public void addAction(Action newAction)
        {
            actions.Add(newAction);
        }

        public void deleteAction(Action action)
        {
            actions.Remove(action);
        }

        public void deleteAction(int indexAction)
        {
            actions.RemoveAt(indexAction);
        }

        public List<Action> getActions() { return actions; }

        public void setActions(List<Action> actions)
        {
            this.actions = actions;
        }

    }
}
