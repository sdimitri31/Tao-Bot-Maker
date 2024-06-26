using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.Controller
{
    public class MainFormController
    {
        private SequenceController sequenceController;
        private Sequence currentSequence;
        private string currentSequenceName;

        public MainFormController()
        {
            sequenceController = new SequenceController();
            currentSequence = new Sequence();
            currentSequenceName = null;
        }

        public List<string> GetAllSequenceNames()
        {
            return sequenceController.GetAllSequenceNames();
        }

        public void RemoveSequence(string name)
        {
            sequenceController.RemoveSequence(name);
        }

        public void LoadSequence(string sequenceName)
        {
            currentSequence = sequenceController.GetSequence(sequenceName);
            if (currentSequence != null)
            {
                currentSequenceName = sequenceName;
            }
        }

        public Sequence GetCurrentSequence()
        {
            return currentSequence;
        }

        public string GetCurrentSequenceName()
        {
            return currentSequenceName;
        }

        public void AddActionToCurrentSequence(Action action)
        {
            if (currentSequence != null)
            {
                sequenceController.AddActionToSequence(currentSequence, action);
            }
        }

        public void SaveCurrentSequence()
        {
            if (currentSequence != null)
            {
                sequenceController.SaveSequence(currentSequence, currentSequenceName);
            }
        }

        public void SaveAsCurrentSequence(string name)
        {
            sequenceController.SaveSequence(currentSequence, name);
        }

        public async Task ExecuteSequence(Sequence sequence)
        {
            await sequenceController.ExecuteSequence(sequence);
        }
    }
}
