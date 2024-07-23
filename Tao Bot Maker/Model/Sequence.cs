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

        public void MoveAction(int newIndex, Action action)
        {
            int oldIndex = Actions.IndexOf(action);
            if (oldIndex == -1) 
                return;

            Actions.RemoveAt(oldIndex);
            if (newIndex > Actions.Count - 1)
                Actions.Add(action);
            else
                Actions.Insert(newIndex, action);
        }
    }
}
