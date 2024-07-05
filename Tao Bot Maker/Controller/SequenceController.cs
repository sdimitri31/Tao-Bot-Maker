using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.Controller
{
    public class SequenceController
    {
        public static event System.Action RunningStateChanged;

        private CancellationTokenSource sequenceLoadingToken = new CancellationTokenSource();
        private readonly ISequenceRepository sequenceRepository;
        private Sequence sequence;

        public static event System.Action SavedStatusChanged;
        private static bool isSaved = true;

        private CancellationTokenSource sequenceExecutionToken = new CancellationTokenSource();
        private static bool isPaused;
        private static bool isRunning;

        public SequenceController()
        {
            sequenceRepository = new SequenceRepository();
            NewSequence();
        }

        public void NewSequence()
        {
            sequence = new Sequence();
            SetIsSaved(true);
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
                SetIsSaved(true);
                return sequence;
            }
            catch (OperationCanceledException ex)
            {
                sequence = new Sequence();
                SetIsSaved(false);
                throw new OperationCanceledException(ex.Message);
            }
            catch (Exception ex)
            {
                sequence = new Sequence();
                SetIsSaved(false);
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
                    SetIsSaved(false);
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
                    SetIsSaved(false);
                }
            }
        }

        public void MoveAction(int newIndex, Action action)
        {
            sequence.MoveAction(newIndex, action);
            SetIsSaved(false);
        }

        public void RemoveAction(Action action)
        {
            sequence.RemoveAction(action);
            SetIsSaved(false);
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
                        SetIsSaved(true);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            sequenceRepository.SaveSequence(sequence, name);
            SetIsSaved(true);
            return name;
        }

        public static void SetIsSaved(bool value)
        {
            isSaved = value;
            SavedStatusChanged?.Invoke();
        }

        public static bool GetIsSaved()
        {
            return isSaved;
        }

        public async Task StartSequence()
        {
            sequenceExecutionToken.Cancel();
            sequenceExecutionToken = new CancellationTokenSource();
            var token = sequenceExecutionToken.Token;
            SetIsPaused(false);
            SetIsRunning(true);

            try
            {
                Logger.Log(Resources.Strings.InfoMessageStartingExecution);

                foreach (var action in sequence.Actions)
                {
                    await ExecuteAction(action, token);
                }
                SetIsPaused(false);
                SetIsRunning(false);
                Logger.Log(Resources.Strings.InfoMessageExecutionComplete);
            }
            catch (OperationCanceledException)
            {
                SetIsPaused(false);
                SetIsRunning(false);
                Logger.Log(Resources.Strings.InfoMessageExecutionCancelled, TraceEventType.Information);
            }
            catch (Exception ex)
            {
                SetIsPaused(false);
                SetIsRunning(false);
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Executes the provided action asynchronously with the given token, x, and y coordinates.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="token">The cancellation token.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public static async Task ExecuteAction(Action action, CancellationToken token, int x = 0, int y = 0)
        {
            Exception exception = null;
            // Create a new thread for the action
            var actionThread = new Thread(() =>
            {
                try
                {
                    token.ThrowIfCancellationRequested();

                    PauseIfRequested().GetAwaiter().GetResult();

                    action.Execute(token, x, y).GetAwaiter().GetResult();
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Thread cancelled by user");
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            // Start the action thread
            actionThread.Start();

            // Keep the thread alive until completion or cancellation
            while (actionThread.IsAlive)
            {
                if (token.IsCancellationRequested)
                {
                    actionThread.Abort();
                    token.ThrowIfCancellationRequested();
                }

                await Task.Delay(10);
            }

            if (exception != null)
            {
                throw exception;
            }
        }

        public bool ValidateSequence(out string errorMessage)
        {
            errorMessage = string.Empty;

            for (int i = 0; i < sequence.Actions.Count; i++)
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

        public static void SetIsRunning(bool value)
        {
            isRunning = value;
            Console.WriteLine("isRunning: " + isRunning);
            RunningStateChanged?.Invoke(); // Trigger the event.
        }

        public static void SetIsPaused(bool value)
        {
            isPaused = value;
            Console.WriteLine("isPaused: " + isPaused);
            RunningStateChanged?.Invoke(); // Trigger the event.
        }

        public static bool GetIsPaused()
        {
            return isPaused;
        }

        public static bool GetIsRunning()
        {
            return isRunning;
        }

        public static async Task PauseIfRequested()
        {
            while (GetIsPaused())
            {
                await Task.Delay(100);
            }
        }

        public void TogglePause()
        {
            SetIsPaused(!isPaused);
            string message = isPaused ? Resources.Strings.InfoMessageExecutionPaused : Resources.Strings.InfoMessageExecutionResumed;
            Logger.Log(message);
        }

        public void StopSequence()
        {
            sequenceExecutionToken.Cancel();
        }

    }
}
