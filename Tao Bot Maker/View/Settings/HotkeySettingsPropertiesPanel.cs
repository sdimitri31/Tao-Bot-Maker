﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View.Setting
{
    public partial class HotkeySettingsPropertiesPanel : UserControl, ISettingsPropertiesPanel
    {
        private readonly Color defaultTextColor; //Default label color
        private string modifyingHotkey = ""; //Store current hotkey beeing assigned
        private Keys hotkeyStartSequence = Keys.None;
        private Keys hotkeyStopSequence = Keys.None;
        private Keys hotkeyStartCoords = Keys.None;
        private Keys hotkeyEndCoords = Keys.None;

        public HotkeySettingsPropertiesPanel()
        {
            InitializeComponent();
            UpdateUI();
            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
            AppTheme appTheme = AppThemeHelper.GetAppThemeFromName(theme);
            defaultTextColor = appTheme.ForeColor;
        }

        private void UpdateUI()
        {
            hotkeyStartSequenceLabel.Text = Resources.Strings.MenuBotStart;
            hotkeyStopSequenceLabel.Text = Resources.Strings.MenuBotStop;
            hotkeyStartCoordsLabel.Text = Resources.Strings.LabelHotkeyStartCoords;
            hotkeyEndCoordsLabel.Text = Resources.Strings.LabelHotkeyEndCoords;
        }

        public void LoadSettings()
        {
            hotkeyStartSequence = (Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYSTARTSEQUENCE);
            hotkeyStopSequence = (Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYSTOPSEQUENCE);
            hotkeyStartCoords = (Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYSTARTCOORDS);
            hotkeyEndCoords = (Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYENDCOORDS);

            hotkeyStartSequenceButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStartSequence);
            hotkeyStopSequenceButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStopSequence);
            hotkeyStartCoordsButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStartCoords);
            hotkeyEndCoordsButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyEndCoords);
        }

        public void SaveSettings()
        {
            SettingsController.SetSettingValue(Settings.SETTING_HOTKEYSTARTSEQUENCE, (int)hotkeyStartSequence, SettingsType.Hotkeys);
            SettingsController.SetSettingValue(Settings.SETTING_HOTKEYSTOPSEQUENCE, (int)hotkeyStopSequence, SettingsType.Hotkeys);
            SettingsController.SetSettingValue(Settings.SETTING_HOTKEYSTARTCOORDS, (int)hotkeyStartCoords, SettingsType.Hotkeys);
            SettingsController.SetSettingValue(Settings.SETTING_HOTKEYENDCOORDS, (int)hotkeyEndCoords, SettingsType.Hotkeys);
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.Hotkeys;
        }

        private bool IsDuplicate()
        {
            bool isDuplicate = false;

            // Reset all label colors
            hotkeyStartSequenceLabel.ForeColor = defaultTextColor;
            hotkeyStopSequenceLabel.ForeColor = defaultTextColor;
            hotkeyStartCoordsLabel.ForeColor = defaultTextColor;
            hotkeyEndCoordsLabel.ForeColor = defaultTextColor;

            // Define hotkeys and corresponding labels
            var hotkeys = new (Keys Key, Label Label)[]
            {
                (hotkeyStartSequence, hotkeyStartSequenceLabel),
                (hotkeyStopSequence, hotkeyStopSequenceLabel),
                (hotkeyStartCoords, hotkeyStartCoordsLabel),
                (hotkeyEndCoords, hotkeyEndCoordsLabel)
            };

            // Check for duplicates
            for (int i = 0; i < hotkeys.Length; i++)
            {
                for (int j = i + 1; j < hotkeys.Length; j++)
                {
                    if (hotkeys[i].Key == hotkeys[j].Key)
                    {
                        hotkeys[i].Label.ForeColor = Color.Red;
                        hotkeys[j].Label.ForeColor = Color.Red;
                        isDuplicate = true;
                    }
                }
            }

            return isDuplicate;
        }


        protected override bool ProcessKeyPreview(ref Message m)
        {
            //Stops detection when a key is released
            if (m.Msg == KeyboardSimulator.WM_KEYUP)
            {
                switch (modifyingHotkey)
                {
                    case Settings.SETTING_HOTKEYSTARTSEQUENCE:
                        modifyingHotkey = "";
                        hotkeyStartSequenceButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStartSequence);
                        IsDuplicate();
                        return true;

                    case Settings.SETTING_HOTKEYSTOPSEQUENCE:
                        modifyingHotkey = "";
                        hotkeyStopSequenceButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStopSequence);
                        IsDuplicate();
                        return true;

                    case Settings.SETTING_HOTKEYSTARTCOORDS:
                        modifyingHotkey = "";
                        hotkeyStartCoordsButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStartCoords);
                        IsDuplicate();
                        return true;

                    case Settings.SETTING_HOTKEYENDCOORDS:
                        modifyingHotkey = "";
                        hotkeyEndCoordsButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyEndCoords);
                        IsDuplicate();
                        return true;
                }
            }

            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (modifyingHotkey)
            {
                case Settings.SETTING_HOTKEYSTARTSEQUENCE:
                    hotkeyStartSequence = keyData;
                    return true;

                case Settings.SETTING_HOTKEYSTOPSEQUENCE:
                    hotkeyStopSequence = keyData;
                    return true;

                case Settings.SETTING_HOTKEYSTARTCOORDS:
                    hotkeyStartCoords = keyData;
                    return true;

                case Settings.SETTING_HOTKEYENDCOORDS:
                    hotkeyEndCoords = keyData;
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void HotkeyStartSequenceButton_Click(object sender, EventArgs e)
        {
            //Toggle hotkey capture
            if (modifyingHotkey == Settings.SETTING_HOTKEYSTARTSEQUENCE)
                SetModifyingHotkey("");
            else
                SetModifyingHotkey(Settings.SETTING_HOTKEYSTARTSEQUENCE);
        }

        private void HotkeyStopSequenceButton_Click(object sender, EventArgs e)
        {
            //Toggle hotkey capture
            if (modifyingHotkey == Settings.SETTING_HOTKEYSTOPSEQUENCE)
                SetModifyingHotkey("");
            else
                SetModifyingHotkey(Settings.SETTING_HOTKEYSTOPSEQUENCE);
        }

        private void HotkeyStartCoordsButton_Click(object sender, EventArgs e)
        {
            //Toggle hotkey capture
            if (modifyingHotkey == Settings.SETTING_HOTKEYSTARTCOORDS)
                SetModifyingHotkey("");
            else
                SetModifyingHotkey(Settings.SETTING_HOTKEYSTARTCOORDS);
        }

        private void HotkeyEndCoordsButton_Click(object sender, EventArgs e)
        {
            if (modifyingHotkey == Settings.SETTING_HOTKEYENDCOORDS)
                SetModifyingHotkey("");
            else
                SetModifyingHotkey(Settings.SETTING_HOTKEYENDCOORDS);
        }

        private void SetModifyingHotkey(string modifying)
        {
            //Reset buttons
            hotkeyStartSequenceButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStartSequence);
            hotkeyStopSequenceButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStopSequence);
            hotkeyStartCoordsButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStartCoords);
            hotkeyEndCoordsButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyEndCoords);

            modifyingHotkey = modifying;

            switch (modifyingHotkey)
            {
                case Settings.SETTING_HOTKEYSTARTSEQUENCE:
                    hotkeyStartSequenceButton.Text = Resources.Strings.ButtonWaitForInput;
                    break;

                case Settings.SETTING_HOTKEYSTOPSEQUENCE:
                    hotkeyStopSequenceButton.Text = Resources.Strings.ButtonWaitForInput;
                    break;

                case Settings.SETTING_HOTKEYSTARTCOORDS:
                    hotkeyStartCoordsButton.Text = Resources.Strings.ButtonWaitForInput;
                    break;

                case Settings.SETTING_HOTKEYENDCOORDS:
                    hotkeyEndCoordsButton.Text = Resources.Strings.ButtonWaitForInput;
                    break;
            }
        }
    }
}
