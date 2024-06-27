using System;
using System.Collections.Generic;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.Properties;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.Controller
{
    public class MainFormController
    {
        private SequenceController sequenceController;
        private Sequence currentSequence;
        private string currentSequenceName;

        private SettingsController settingsController;

        public MainFormController()
        {
            sequenceController = new SequenceController();
            currentSequence = new Sequence();
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

        public bool RemoveSequence()
        {
            return sequenceController.RemoveSequence(currentSequenceName);
        }

        public async Task LoadSequenceAsync(string sequenceName, CancellationToken token)
        {
            // Exemple d'une méthode asynchrone qui prend en compte l'annulation
            // Vous devez adapter cette méthode à votre logique de chargement

            token.ThrowIfCancellationRequested();
            await Task.Run(() =>
            {
                token.ThrowIfCancellationRequested(); // Vérifie si l'annulation est demandée avant de commencer l'opération
                try
                {
                    currentSequence = sequenceController.GetSequence(sequenceName);
                    currentSequenceName = currentSequence != null ? sequenceName : null;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message); // Lève une nouvelle exception avec le message de l'exception capturée
                }
            }, token);
        }

        public Sequence GetCurrentSequence()
        {
            return currentSequence;
        }

        public string GetCurrentSequenceName()
        {
            return currentSequenceName;
        }

        public void AddAction()
        {
            if (currentSequence != null)
            {
                sequenceController.AddActionToSequence(currentSequence);
            }
        }

        public void UpdateAction(Action oldAction)
        {
            if (currentSequence != null)
            {
                sequenceController.UpdateActionInSequence(currentSequence, oldAction);
            }
        }

        public void RemoveActionFromCurrentSequence(Action action)
        {
            if (currentSequence != null)
            {
                sequenceController.RemoveActionFromSequence(currentSequence, action);
            }
        }

        public void SaveCurrentSequence()
        {
            if (currentSequence != null)
            {
                sequenceController.SaveSequence(currentSequence, currentSequenceName);
            }
        }

        public void SaveAsCurrentSequence()
        {
            if (currentSequence != null)
            {
                currentSequenceName = sequenceController.SaveSequence(currentSequence, null);
            }
        }

        public async Task ExecuteSequence(Sequence sequence)
        {
            Logger.Log($"Sequence {currentSequenceName} started");

            await sequenceController.ExecuteSequence(sequence);

            Logger.Log($"Sequence {currentSequenceName} ended");
        }
    }
}
