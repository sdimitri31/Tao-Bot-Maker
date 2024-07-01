using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private CancellationTokenSource sequenceLoadingToken = new CancellationTokenSource();
        private readonly ISequenceRepository sequenceRepository;
        private Sequence sequence;

        private CancellationTokenSource sequenceExecutionToken = new CancellationTokenSource();
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

        public static Sequence GetSequence(string name)
        {
            try
            {
                return new SequenceRepository().GetSequence(name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Sequence> LoadSequenceAsync(string name)
        {
            // Cancel any ongoing task
            sequenceLoadingToken.Cancel();
            sequenceLoadingToken = new CancellationTokenSource();
            var token = sequenceLoadingToken.Token;

            try
            {
                sequence = await sequenceRepository.LoadSequenceAsync(name, token);
                return sequence;
            }
            catch (OperationCanceledException ex)
            {
                sequence = new Sequence();
                throw new OperationCanceledException(ex.Message);
            }
            catch (Exception ex)
            {
                sequence = new Sequence();
                throw new Exception(ex.Message, ex);
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

        public async Task StartSequence()
        {
            sequenceExecutionToken.Cancel();
            sequenceExecutionToken = new CancellationTokenSource();
            var token = sequenceExecutionToken.Token;
            isPaused = false;

            try
            {
                Logger.Log(Resources.Strings.InfoMessageStartingExecution);

                Exception executionException = null;

                await Task.Run(async () =>
                {
                    try
                    {
                        foreach (var action in sequence.Actions)
                        {
                            await ExecuteAction(action, 0, 0, token);
                        }
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine($"Operation cancelled : {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        executionException = ex;
                    }
                }, token);

                if (executionException != null) {
                    throw executionException;
                }

                Logger.Log(Resources.Strings.InfoMessageExecutionComplete);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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
            catch (OperationCanceledException ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool ValidateSequence(out string errorMessage)
        {
            errorMessage = string.Empty;

            for(int i = 0; i < sequence.Actions.Count; i++)
            {
                if (!sequence.Actions[i].Validate(out string errorMsg))
                {
                    string invalidActionAtIndex = string.Format(Resources.Strings.ErrorMessageInvalidActionAtIndex, i + 1);
                    errorMessage = invalidActionAtIndex + "\r\n" + errorMsg;
                    return false;
                }
            }

            return true;
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

        public void StopSequence()
        {
            sequenceExecutionToken.Cancel();
            Logger.Log($"Execution stopped");
        }

    }
}
