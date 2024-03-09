using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Tao_Bot_Maker.Action;

namespace Tao_Bot_Maker
{
    public class SequenceController
    {

        private Sequence sequence;

        public SequenceController()
        {
            this.sequence = new Sequence();
        }

        public Sequence Sequence
        {
            get => this.sequence;
            set => this.sequence = value;
        }

        public string SequenceName
        {
            get => sequence.Name;
            set => sequence.Name = value;
        }

        public List<Action> GetActions() => sequence.Actions;

        public void AddAction(Action newAction)
        {
            sequence.Actions.Add(newAction);
        }

        public void RemoveAction(Action action)
        {
            sequence.Actions.Remove(action);
        }

        public void RemoveAction(int indexAction)
        {
            sequence.Actions.RemoveAt(indexAction);
        }

        public void EditAction(int selectedActionIndex, Action returnValueAction)
        {
            sequence.Actions.RemoveAt(selectedActionIndex);
            sequence.Actions.Insert(selectedActionIndex, returnValueAction);
        }

        public void InsertAction(int indexAction, Action action)
        {
            sequence.Actions.Insert(indexAction, action);
        }

        public static bool DeleteSequence(string sequenceName)
        {
            return SequenceXmlManager.DeleteSequence(sequenceName);
        }

        public void ClearActions()
        {
            sequence.Actions.Clear();
        }
    }
}
