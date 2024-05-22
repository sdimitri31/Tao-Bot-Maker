using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class SequenceController
    {
        private Sequence sequence;

        public SequenceController(string name = "", List<Action> actions = null, bool isSaved = true)
        {
            sequence = new Sequence(name, actions, isSaved);
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

        public bool IsSaved()
        {
            return sequence.IsSaved;
        }

        public List<Action> GetActions() => sequence.Actions;

        public bool AddAction(Action actionToAdd)
        {
            if (actionToAdd == null)
                return false;

            sequence.Actions.Add(actionToAdd);
            sequence.IsSaved = false;
            return true;
        }

        public bool RemoveAction(Action actionToRemove)
        {
            if (actionToRemove == null)
                return false;

            sequence.Actions.Remove(actionToRemove);
            sequence.IsSaved = false;
            return true;
        }

        public bool RemoveAction(int indexActionToRemove)
        {
            if (indexActionToRemove < 0)
                return false;

            if (indexActionToRemove > sequence.Actions.Count - 1)
                return false;

            sequence.Actions.RemoveAt(indexActionToRemove);
            sequence.IsSaved = false;
            return true;
        }

        public bool EditAction(int selectedActionIndex, Action action)
        {
            if (!RemoveAction(selectedActionIndex))
                return false;

            if (!InsertAction(selectedActionIndex, action))
                return false;

            return true;
        }


        public bool InsertAction(int indexAction, Action action)
        {
            if (indexAction < 0)
                return false;

            if (indexAction > sequence.Actions.Count - 1)
                return AddAction(action);

            if (action == null)
                return false;

            sequence.Actions.Insert(indexAction, action);
            sequence.IsSaved = false;
            return true;
        }

        public bool ClearActions()
        {
            sequence.Actions.Clear();
            sequence.IsSaved = false;
            return true;
        }

        public bool Save(string sequenceName = "")
        {
            bool saveResult;
            if (string.IsNullOrEmpty(sequenceName))
                saveResult = SaveAs();
            else
                saveResult = SequenceXmlManager.SaveSequence(sequenceName, this);

            sequence.IsSaved = saveResult;
            return saveResult;
        }

        private bool SaveAs()
        {
            SaveSequenceView saveSequenceView = new SaveSequenceView(this);
            saveSequenceView.StartPosition = FormStartPosition.CenterParent;

            var result = saveSequenceView.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.SequenceName = saveSequenceView.ReturnValueSequenceName;
                return true;
            }
            return false;
        }

        public bool LoadSequence(string sequenceName = "")
        {
            if (string.IsNullOrEmpty(sequenceName))
                return false;

            Sequence sequenceResult = SequenceXmlManager.LoadSequence(sequenceName);

            if (sequenceResult == null)
                return false;

            this.sequence = sequenceResult;

            return true;
        }

        public static bool DeleteSequence(string sequenceName)
        {
            if (string.IsNullOrEmpty(sequenceName))
                return false;

            DialogResult dr = MessageBox.Show(Properties.strings.MessageBox_WarningDeleteSequence, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                return SequenceXmlManager.DeleteSequence(sequenceName);
            }

            return false;
        }
    }
}
