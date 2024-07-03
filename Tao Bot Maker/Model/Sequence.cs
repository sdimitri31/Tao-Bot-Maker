using System;
using System.Collections.Generic;

namespace Tao_Bot_Maker.Model
{
    public class Sequence
    {
        public List<Action> Actions { get; set; }

        public Sequence()
        {
            Actions = new List<Action>();
        }

        public void AddAction(Action action)
        {
            Actions.Add(action);
        }

        public void RemoveAction(Action action)
        {
            Actions.Remove(action);
        }

        public void ClearActions()
        {
            Actions.Clear();
        }

        internal void UpdateAction(Action oldAction, Action newAction)
        {
            int index = Actions.IndexOf(oldAction);
            Actions[index] = newAction;
        }
    }
}
