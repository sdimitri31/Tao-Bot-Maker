using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.Properties;
using Tao_Bot_Maker.View;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.Controller
{
    public class SequenceController
    {
        private ISequenceRepository sequenceRepository;
        private Sequence sequence;
        private static bool isPaused;

        public SequenceController()
        {
            sequenceRepository = new SequenceRepository();
            sequence = new Sequence();
        }

        public List<string> GetAllSequenceNames()
        {
            return (List<string>)sequenceRepository.GetAllSequenceNames();
        }

        public bool RemoveSequence(string name)
        {
            return sequenceRepository.RemoveSequence(name);
        }

        public Sequence GetSequence()
        {
            return sequence;
        }

        public Sequence LoadSequence(string name)
        {
            try
            {
                sequence = sequenceRepository.LoadSequence(name);
                return sequence;
            }
            catch (Exception e)
            {
                sequence = null;
                throw new Exception(e.Message);
            }
        }

        public void AddAction()
        {
            using (var addActionForm = new ActionForm())
            {
                if (addActionForm.ShowDialog() == DialogResult.OK)
                {
                    sequence.AddAction(addActionForm.Action);
                }
            }
        }

        internal void UpdateAction(Action oldAction)
        {
            using (var addActionForm = new ActionForm(false, oldAction))
            {
                if (addActionForm.ShowDialog() == DialogResult.OK)
                {
                    sequence.UpdateAction(oldAction, addActionForm.Action);
                }
            }
        }

        public void RemoveAction(Action action)
        {
            sequence.RemoveAction(action);
        }

        public string SaveSequence(string name = null)
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

        public async Task ExecuteSequence(CancellationToken token)
        {
            try
            {
                Logger.Log("Execution started");
                isPaused = false;
                await Task.Run(async () =>
                {
                    foreach (var action in sequence.Actions)
                    {
                        token.ThrowIfCancellationRequested();

                        await PauseIfRequested();

                        try { 
                            await ExecuteAction(action, 0, 0, token); 
                        }
                        catch (OperationCanceledException e) { Console.WriteLine($"SequenceController OperationCanceledException  {e.Message}"); }
                        catch (Exception e) { Console.WriteLine($"SequenceController Error : {e.Message}"); }
                    }
                }, token);

                Logger.Log("Execution completed");
            }
            catch (OperationCanceledException e)
            {
                throw new OperationCanceledException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception($"SequenceController Error : {e.Message}", e);
            }
        }

        public static async Task ExecuteAction(Action action, int x, int y, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();

                await PauseIfRequested();

                await action.Execute(x, y, token);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"SequenceController ExecuteAction OperationCanceledException  {e.Message}");
                throw new OperationCanceledException(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"SequenceController ExecuteAction Error : {e.Message}");
                throw new Exception($"SequenceController Error : {e.Message}", e);
            }
        }

        public static bool GetIsPaused()
        {
            return isPaused;
        }

        public static async Task PauseIfRequested()
        {
            while (GetIsPaused())
            {
                await Task.Delay(100);
            }
        }

        public void PauseSequence()
        {
            isPaused = true;
        }

        public void ResumeSequence()
        {
            isPaused = false;
        }

        public void TogglePause()
        {
            isPaused = !isPaused;
            string message = isPaused ? "paused" : "resumed";
            Logger.Log($"Execution {message}");
        }

        public void StopSequence(CancellationTokenSource token)
        {
            token.Cancel();
            Logger.Log($"Execution stopped");
        }

    }
}
