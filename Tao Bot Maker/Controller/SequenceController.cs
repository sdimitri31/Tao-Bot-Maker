using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.Controller
{
    public class SequenceController
    {
        private ISequenceRepository sequenceRepository;

        public SequenceController()
        {
            sequenceRepository = new SequenceRepository();
        }

        public List<string> GetAllSequenceNames()
        {
            return (List<string>)sequenceRepository.GetAllSequenceNames();
        }

        public void RemoveSequence(string name)
        {
            sequenceRepository.RemoveSequence(name);
        }

        public Sequence GetSequence(string name)
        {
            return sequenceRepository.GetSequence(name);
        }

        public void AddActionToSequence(Sequence sequence, Action action)
        {
            sequence.AddAction(action);
        }

        public void SaveSequence(Sequence sequence, string name)
        {
            sequenceRepository.SaveSequence(sequence, name);
        }

        public async Task ExecuteSequence(Sequence sequence)
        {
            Console.WriteLine($"ExecuteSequence.");
            foreach (var action in sequence.Actions)
            {
                await action.Execute();
            }
        }

    }
}
