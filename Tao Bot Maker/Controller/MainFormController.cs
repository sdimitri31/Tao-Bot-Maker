using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
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
    public class MainFormController
    {
        private readonly MainForm mainForm;

        private HotKeyController hotkeyStartSequence;
        private HotKeyController hotkeyPauseSequence;
        private HotKeyController hotkeyStopSequence;

        private SequenceController sequenceController;
        private string currentSequenceName;

        private readonly SettingsController settingsController;


        public MainFormController(MainForm mainForm)
        {
            NewSequence();
            settingsController = new SettingsController();
            this.mainForm = mainForm;
        }

        public void NewSequence()
        {
            sequenceController = new SequenceController();
            currentSequenceName = null;
        }

        public void InitializeHotkeys()
        {
            UnregisterHotkeys();
            hotkeyStartSequence = new HotKeyController((Keys)settingsController.GetSettingValue<int>("HotkeyStartSequence"), mainForm);
            hotkeyStartSequence.Register();

            hotkeyPauseSequence = new HotKeyController((Keys)settingsController.GetSettingValue<int>("HotkeyPauseSequence"), mainForm);
            hotkeyPauseSequence.Register();

            hotkeyStopSequence = new HotKeyController((Keys)settingsController.GetSettingValue<int>("HotkeyStopSequence"), mainForm);
            hotkeyStopSequence.Register();
        }

        public void UnregisterHotkeys()
        {
            hotkeyStartSequence?.Unregister();
            hotkeyPauseSequence?.Unregister();
            hotkeyStopSequence?.Unregister();
        }

        public void HotkeySend(IntPtr LParam)
        {
            //m.LParam = 0xKKKKMMMM, K is Key, M is modifier
            Keys pressedKey = (Keys)(((int)LParam >> 16) & 0xFFFF);
            Keys pressedModifier = (Keys)HotKeyController.Reverse3Bits(((int)LParam & 0xFFFF));

            //Converting to same format as regular Keys
            Keys pressedHotkey = (Keys)(((int)pressedModifier << 16) | (int)pressedKey);

            if (hotkeyStartSequence.GetKey() == pressedHotkey)
            {
                StartSequence();
            }
            else if (hotkeyPauseSequence.GetKey() == pressedHotkey)
            {
                TogglePause();
            }
            else if (hotkeyStopSequence.GetKey() == pressedHotkey)
            {
                StopSequence();
            }
        }

        public void OpenSettingsForm(SettingsType settingsType = SettingsType.General)
        {
            UnregisterHotkeys();
            settingsController.OpenSettingsForm(settingsType);
            InitializeHotkeys();
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
            UnregisterHotkeys();
            sequenceController.AddAction();
            InitializeHotkeys();
        }

        public void UpdateAction(Action oldAction)
        {
            UnregisterHotkeys();
            sequenceController.UpdateAction(oldAction);
            InitializeHotkeys();
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

        public async void StartSequence()
        {
            try
            {
                await sequenceController.StartSequence();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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

        public void StopSequence()
        {
            sequenceController.StopSequence();
        }

    }
}
