using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
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
            SequenceController.SetIsRunning(false);
            settingsController = new SettingsController();
            this.mainForm = mainForm;
        }

        #region Hotkey

        /// <summary>
        /// Initializes the hotkeys by unregistering existing hotkeys and registering new hotkeys based on settings.
        /// </summary>
        public void InitializeHotkeys()
        {
            // Unregister existing hotkeys
            UnregisterHotkeys();

            // Initialize and register hotkey for starting the sequence
            hotkeyStartSequence = new HotKeyController((Keys)settingsController.GetSettingValue<int>("HotkeyStartSequence"), mainForm);
            hotkeyStartSequence.Register();

            // Initialize and register hotkey for pausing the sequence
            hotkeyPauseSequence = new HotKeyController((Keys)settingsController.GetSettingValue<int>("HotkeyPauseSequence"), mainForm);
            hotkeyPauseSequence.Register();

            // Initialize and register hotkey for stopping the sequence
            hotkeyStopSequence = new HotKeyController((Keys)settingsController.GetSettingValue<int>("HotkeyStopSequence"), mainForm);
            hotkeyStopSequence.Register();
        }

        /// <summary>
        /// Unregisters the existing hotkeys for starting, pausing, and stopping sequences.
        /// </summary>
        public void UnregisterHotkeys()
        {
            hotkeyStartSequence?.Unregister();
            hotkeyPauseSequence?.Unregister();
            hotkeyStopSequence?.Unregister();
        }

        /// <summary>
        /// Executes the action associated with the provided hotkey.
        /// </summary>
        /// <param name="LParam">The parameter containing information about the pressed key and modifier.</param>
        public void ExecuteHotkey(IntPtr LParam)
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

        #endregion

        #region Settings

        /// <summary>
        /// Opens the settings form.
        /// </summary>
        /// <param name="settingsType">The type of settings to open the form for.</param>
        public void OpenSettingsForm(SettingsType settingsType = SettingsType.General)
        {
            UnregisterHotkeys();
            settingsController.OpenSettingsForm(settingsType);
            InitializeHotkeys();
        }

        /// <summary>
        /// Sets the value of a setting.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        /// <param name="type">The type of the setting.</param>
        public void SetSettingValue(string name, string value, SettingsType type)
        {
            settingsController.SetSettingValue(name, value, type);
        }

        /// <summary>
        /// Gets the value of a setting.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <returns>The value of the setting.</returns>
        public T GetSettingValue<T>(string name)
        {
            return settingsController.GetSettingValue<T>(name);
        }

        #endregion

        #region Sequence

        /// <summary>
        /// Gets all sequence names.
        /// </summary>
        /// <returns>A list of all sequence names.</returns>
        public List<string> GetAllSequenceNames()
        {
            return sequenceController.GetAllSequenceNames();
        }

        /// <summary>
        /// Gets the name of the current sequence.
        /// </summary>
        /// <returns>The name of the current sequence.</returns>
        public string GetCurrentSequenceName()
        {
            return currentSequenceName;
        }

        /// <summary>
        /// Gets the current sequence from the sequence controller.
        /// </summary>
        /// <returns>The current sequence.</returns>
        public Sequence GetSequence()
        {
            return sequenceController.GetSequence();
        }

        /// <summary>
        /// Creates a new sequence by instantiating a SequenceController and resetting the current sequence name.
        /// </summary>
        public void NewSequence()
        {
            sequenceController = new SequenceController();
            currentSequenceName = null;
        }

        /// <summary>
        /// Removes a sequence by name.
        /// </summary>
        /// <param name="sequenceName">The name of the sequence to be removed.</param>
        /// <returns>True if the sequence was successfully removed, otherwise false.</returns>
        public bool RemoveSequence(string sequenceName)
        {
            if (sequenceController.RemoveSequence(sequenceName))
            {
                string message = string.Format(Resources.Strings.InfoMessageDeletedSequence, sequenceName);
                Logger.Log(message);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Loads a sequence asynchronously based on the provided sequence name.
        /// </summary>
        /// <param name="sequenceName">The name of the sequence to load.</param>
        public async Task LoadSequenceAsync(string sequenceName)
        {
            try
            {
                currentSequenceName = await sequenceController.LoadSequenceAsync(sequenceName) != null ? sequenceName : null;
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

        /// <summary>
        /// Saves the current sequence.
        /// </summary>
        public void SaveSequence()
        {
            sequenceController.SaveSequence(currentSequenceName);
        }

        /// <summary>
        /// Saves the current sequence as a new sequence.
        /// </summary>
        public void SaveAsSequence()
        {
            currentSequenceName = sequenceController.SaveSequence(null);
        }

        #endregion

        #region Actions

        /// <summary>
        /// Open form to add an action.
        /// </summary>
        public void AddAction()
        {
            UnregisterHotkeys();
            sequenceController.AddAction();
            InitializeHotkeys();
        }

        /// <summary>
        /// Open form to update an action.
        /// </summary>
        /// <param name="oldAction">Action to update.</param>
        public void UpdateAction(Action oldAction)
        {
            UnregisterHotkeys();
            sequenceController.UpdateAction(oldAction);
            InitializeHotkeys();
        }

        /// <summary>
        /// Removes an action.
        /// </summary>
        /// <param name="action">Action to remove.</param>
        public void RemoveAction(Action action)
        {
            sequenceController.RemoveAction(action);
        }

        #endregion

        #region Sequence execution

        /// <summary>
        /// Starts the sequence.
        /// </summary>
        /// <exception cref="Exception">Exception thrown if there is an error during sequence execution.</exception>
        public async void StartSequence()
        {
            if (SequenceController.GetIsRunning())
                return;

            try
            {
                if (!sequenceController.ValidateSequence(out string errorMessage))
                {
                    throw new Exception(errorMessage);
                }

                await sequenceController.StartSequence();
            }
            catch (Exception ex)
            {
                string error = Resources.Strings.Error;
                string fullMessage = string.Format(Resources.Strings.ErrorMessageFormat, error, ex.Message);

                Logger.Log(fullMessage, TraceEventType.Error);
                MessageBox.Show(fullMessage, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool GetIsSequenceRunning()
        {
            return SequenceController.GetIsRunning();
        }

        /// <summary>
        /// Toggles the pause of the sequence.
        /// </summary>
        public void TogglePause()
        {
            if (!SequenceController.GetIsRunning())
                return;

            sequenceController.TogglePause();
        }

        /// <summary>
        /// Stops the sequence.
        /// </summary>
        public void StopSequence()
        {
            if (!SequenceController.GetIsRunning())
                return;

            sequenceController.StopSequence();
        }

        #endregion
    }
}
