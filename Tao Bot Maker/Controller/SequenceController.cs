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

        public static bool DeleteSequence(String sequenceName)
        {
            return SequenceXmlManager.DeleteSequence(sequenceName);
        }

        public Sequence Sequence { 
            get { return this.sequence; }
            set { this.sequence = value; }
        }

        public String SequenceName 
        { 
            set 
            {
                sequence.SequenceName = value;
            } 
            get
            {
                return sequence.SequenceName;
            }
        }

        public List<Action> GetActions() { return sequence.Actions; }

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

        public void ClearActions()
        {
            sequence.Actions.Clear();
        }
    }
}
