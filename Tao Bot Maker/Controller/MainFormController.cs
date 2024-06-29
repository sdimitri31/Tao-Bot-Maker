using System;
using System.Collections.Generic;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.Properties;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.Controller
{
    public class MainFormController
    {
        private SequenceController sequenceController;
        private string currentSequenceName;

        private SettingsController settingsController;


        public MainFormController()
        {
            sequenceController = new SequenceController();
            currentSequenceName = null;
            settingsController = new SettingsController();
        }

        public void OpenSettingsForm(SettingsType settingsType = SettingsType.General)
        {
            settingsController.OpenSettingsForm(settingsType);
        }

        public void SetSettingValue(string name, string value, SettingsType type)
        {
            settingsController.SetSettingValue(name, value, type);
        }

        public T GetSettingValue<T>(string name)
        {
            return settingsController.GetSettingValue<T>(name);
        }

        public List<string> GetAllSequenceNames()
        {
            return sequenceController.GetAllSequenceNames();
        }

        public bool RemoveSequence(string sequenceName)
        {
            return sequenceController.RemoveSequence(sequenceName);
        }

        public void LoadSequence(string sequenceName)
        {
            try
            {
                currentSequenceName = sequenceController.LoadSequence(sequenceName) != null ? sequenceName : null;
            }
            catch (Exception e)
            {
                currentSequenceName = sequenceName;
                Console.WriteLine($"Error loading sequence '{sequenceName}': {e.Message}");
            }
        }

        public async Task LoadSequenceAsync(string sequenceName, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();
                await Task.Run(() =>
                {
                    LoadSequence(sequenceName);
                }, token);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"LoadSequenceAsync OperationCanceledException");
                throw new OperationCanceledException(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"LoadSequenceAsync Error loading sequence '{sequenceName}': {e.Message}");
                throw new Exception($"Error loading sequence '{sequenceName}': {e.Message}", e);
            }

        }

        public Sequence GetCurrentSequence()
        {
            return sequenceController.GetSequence();
        }

        public string GetCurrentSequenceName()
        {
            return currentSequenceName;
        }

        public void AddAction()
        {
            sequenceController.AddAction();
        }

        public void UpdateAction(Action oldAction)
        {
            sequenceController.UpdateAction(oldAction);
        }

        public void RemoveActionFromCurrentSequence(Action action)
        {
            sequenceController.RemoveAction(action);
        }

        public void SaveCurrentSequence()
        {
            sequenceController.SaveSequence(currentSequenceName);
        }

        public void SaveAsCurrentSequence()
        {
            currentSequenceName = sequenceController.SaveSequence(null);
        }

        public async Task ExecuteSequence(CancellationToken token)
        {
            Console.WriteLine("Starting execution of sequence.");
            try
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }

                try { await sequenceController.ExecuteSequence(token); }
                catch (OperationCanceledException) { Console.WriteLine("Execution of sequence was cancelled."); }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Execution of sequence was cancelled.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        public void PauseSequence()
        {
            sequenceController.PauseSequence();
        }

        public void ResumeSequence()
        {
            sequenceController.ResumeSequence();
        }

        public void TogglePause()
        {
            sequenceController.TogglePause();
        }

        public void StopSequence(CancellationTokenSource cancellationTokenSource)
        {
            sequenceController.StopSequence(cancellationTokenSource);
        }
    }
}
