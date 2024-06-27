using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.Properties;
using Tao_Bot_Maker.View;
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

        public bool RemoveSequence(string name)
        {
            return sequenceRepository.RemoveSequence(name);
        }

        public Sequence GetSequence(string name)
        {
            try
            {
                return sequenceRepository.GetSequence(name);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void AddActionToSequence(Sequence sequence)
        {
            using (var addActionForm = new ActionForm())
            {
                if (addActionForm.ShowDialog() == DialogResult.OK)
                {
                    sequence.AddAction(addActionForm.Action);
                }
            }
        }

        public void RemoveActionFromSequence(Sequence sequence, Action action)
        {
            sequence.RemoveAction(action);
        }

        public string SaveSequence(Sequence sequence, string name = null)
        {
            if (sequence == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(name))
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        name = Path.GetFileNameWithoutExtension(dialog.FileName);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            sequenceRepository.SaveSequence(sequence, name);
            return name;
        }

        public async Task ExecuteSequence(Sequence sequence)
        {
            foreach (var action in sequence.Actions)
            {
                await action.Execute();
            }
        }

        internal void UpdateActionInSequence(Sequence sequence, Action oldAction)
        {
            using (var addActionForm = new ActionForm(false, oldAction))
            {
                if (addActionForm.ShowDialog() == DialogResult.OK)
                {
                    sequence.UpdateAction(oldAction, addActionForm.Action);
                }
            }
        }
    }
}
