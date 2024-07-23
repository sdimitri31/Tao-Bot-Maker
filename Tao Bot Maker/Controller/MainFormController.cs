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
        private HotKeyController hotkeyStopSequence;

        private readonly SequenceController sequenceController;
        private string currentSequenceName;

        public bool IsSequenceRunning { get { return SequenceController.GetIsRunning(); } }
        public bool IsSequencePaused { get { return SequenceController.GetIsPaused(); } }
        public bool IsSequenceSaved { get { return SequenceController.GetIsSaved(); } }
        public Keys KeyStartSequence { get { return hotkeyStartSequence.GetKey(); } }
        public Keys KeyStopSequence { get { return hotkeyStopSequence.GetKey(); } }

        public MainFormController(MainForm mainForm)
        {
            this.mainForm = mainForm;
            sequenceController = new SequenceController();
            NewSequence();
            SequenceController.SetIsRunning(false);
            InitializeHotkeys();
        }

        #region Hotkey

        /// <summary>
        /// Initializes hotkeys by unregistering existing hotkeys and registering new hotkeys based on settings.
        /// </summary>
        public void InitializeHotkeys()
        {
            Logger.Log($"Initializing Hotkeys", TraceEventType.Verbose);
            // Unregister existing hotkeys
            UnregisterHotkeys();

            Logger.Log($"Registering Hotkeys", TraceEventType.Verbose);
            // Initialize and register hotkey for starting the sequence
            hotkeyStartSequence = new HotKeyController((Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYSTARTSEQUENCE), mainForm);
            hotkeyStartSequence.Register();

            // Initialize and register hotkey for stopping the sequence
            hotkeyStopSequence = new HotKeyController((Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYSTOPSEQUENCE), mainForm);
            hotkeyStopSequence.Register();
        }

        /// <summary>
        /// Unregisters existing hotkeys for starting, pausing, and stopping sequences.
        /// </summary>
        public void UnregisterHotkeys()
        {
            Logger.Log($"Unregistering Hotkeys", TraceEventType.Verbose);
            hotkeyStartSequence?.Unregister();
            hotkeyStopSequence?.Unregister();
        }

        /// <summary>
        /// Executes the action associated with the provided hotkey.
        /// </summary>
        /// <param name="LParam">The parameter containing information about the pressed key and modifier.</param>
        public void ExecuteHotkey(IntPtr LParam)
        {
            Logger.Log($"Executing Hotkeys", TraceEventType.Verbose);

            //m.LParam = 0xKKKKMMMM, K is Key, M is modifier
            Keys pressedKey = (Keys)(((int)LParam >> 16) & 0xFFFF);
            Keys pressedModifier = (Keys)HotKeyController.Reverse3Bits(((int)LParam & 0xFFFF));

            //Converting to same format as regular Keys
            Keys pressedHotkey = (Keys)(((int)pressedModifier << 16) | (int)pressedKey);

            if (hotkeyStartSequence.GetKey() == pressedHotkey)
            {
                if (SequenceController.GetIsRunning())
                {
                    TogglePause();
                }
                else
                {
                    StartSequence();
                }
            }
            else if (hotkeyStopSequence.GetKey() == pressedHotkey)
            {
                StopSequence();
            }
        }

        #endregion

        #region Settings

        /// <summary>
        /// Opens settings form.
        /// </summary>
        /// <param name="settingsType">Setting type to show when opening settings form.</param>
        public void OpenSettingsForm(SettingsType settingsType = SettingsType.General)
        {
            UnregisterHotkeys();
            SettingsController.OpenSettingsForm(settingsType);
            InitializeHotkeys();
        }

        /// <summary>
        /// Sets the value of a setting.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        /// <param name="type">The type of the setting.</param>
        private void SetSettingValue<T>(string name, T value, SettingsType type)
        {
            SettingsController.SetSettingValue(name, value, type);
        }

        /// <summary>
        /// Gets the value of a setting.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="name">Parameter name</param>
        /// <returns>Value of the parameter</returns>
        private T GetSettingValue<T>(string name)
        {
            return SettingsController.GetSettingValue<T>(name);
        }

        public void SetLanguageSettings(string language)
        {
            SetSettingValue(Settings.SETTING_LANGUAGE, language, SettingsType.General);
        }

        public string GetLanguageSettings()
        {
            string language = GetSettingValue<string>(Settings.SETTING_LANGUAGE);
            switch (language)
            {
                case "English":
                    CultureManager.ChangeCulture("en");
                    break;
                case "Français":
                    CultureManager.ChangeCulture("fr");
                    break;
            }
            return language;
        }

        public void SetThemeSettings(string theme)
        {
            SetSettingValue(Settings.SETTING_THEME, theme, SettingsType.General);
        }

        public string GetThemeSettings()
        {
            return GetSettingValue<string>(Settings.SETTING_THEME);
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
            sequenceController.NewSequence();
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
        /// Saves current sequence.
        /// </summary>
        public void SaveSequence()
        {
            try
            {
                sequenceController.SaveSequence(currentSequenceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves current sequence as a new sequence.
        /// </summary>
        public void SaveAsSequence()
        {
            using (var dialog = new SaveSequenceForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentSequenceName = dialog.FileName;
                    SaveSequence();
                }
            }
        }

        #endregion

        #region Actions

        /// <summary>
        /// Open form to add an action.
        /// </summary>
        /// <returns>The added action. null if the user cancels.</returns>
        public Action AddAction()
        {
            UnregisterHotkeys();
            Action action = null;
            using (var actionForm = new ActionForm())
            {
                if (actionForm.ShowDialog() == DialogResult.OK)
                {
                    sequenceController.AddAction(actionForm.Action);
                    action = actionForm.Action;
                }
            }
            InitializeHotkeys();
            return action;
        }

        /// <summary>
        /// Open form to update an action.
        /// </summary>
        /// <param name="oldAction">Action to update.</param>
        /// <returns>The updated action. null if the user cancels.</returns>
        public Action UpdateAction(Action oldAction)
        {
            UnregisterHotkeys();
            Action action = null;
            using (var actionForm = new ActionForm(false, oldAction))
            {
                if (actionForm.ShowDialog() == DialogResult.OK)
                {
                    sequenceController.UpdateAction(oldAction, actionForm.Action);
                    action = actionForm.Action;
                }
            }
            InitializeHotkeys();
            return action;
        }

        /// <summary>
        /// Moves an action to a new index.
        /// </summary>
        /// <param name="newIndex">New index.</param>
        /// <param name="action">Action to move.</param>
        public void MoveAction(int newIndex, Action action)
        {
            sequenceController.MoveAction(newIndex, action);
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
            if (IsSequenceRunning)
            {
                TogglePause();
                return;
            }

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

        /// <summary>
        /// Toggles the pause of the sequence.
        /// </summary>
        public void TogglePause()
        {
            if (!IsSequenceRunning)
                return;

            sequenceController.TogglePause();
        }

        /// <summary>
        /// Stops the execution of the sequence.
        /// </summary>
        public void StopSequence()
        {
            if (!IsSequenceRunning)
                return;

            sequenceController.StopSequence();
        }

        #endregion

        #region About

        /// <summary>
        /// Opens About form.
        /// </summary>
        public void About()
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        #endregion
    }
}
