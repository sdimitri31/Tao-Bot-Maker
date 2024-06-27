﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View.Setting
{
    public partial class HotkeySettingsPropertiesPanel : UserControl, ISettingsPropertiesPanel
    {
        private readonly Color textColor; //Default label color
        private string modifyingHotkey = ""; //Store current hotkey beeing assigned
        private Keys hotkeyStartSequence = Keys.None;
        private Keys hotkeyStopSequence = Keys.None;
        private Keys hotkeyStartCoords = Keys.None;
        private Keys hotkeyEndCoords = Keys.None;

        public HotkeySettingsPropertiesPanel()
        {
            InitializeComponent();
            textColor = hotkeyStartSequenceLabel.ForeColor;
        }

        public void LoadSettings(Settings settings)
        {
            hotkeyStartSequence = (Keys)settings.GetSettingValue<int>(Settings.SETTING_HOTKEYSTARTSEQUENCE);
            hotkeyStopSequence = (Keys)settings.GetSettingValue<int>(Settings.SETTING_HOTKEYSTOPSEQUENCE);
            hotkeyStartCoords = (Keys)settings.GetSettingValue<int>(Settings.SETTING_HOTKEYSTARTCOORDS);
            hotkeyEndCoords = (Keys)settings.GetSettingValue<int>(Settings.SETTING_HOTKEYENDCOORDS);

            hotkeyStartSequenceButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStartSequence);
            hotkeyStopSequenceButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStopSequence);
            hotkeyStartCoordsButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyStartCoords);
            hotkeyEndCoordsButton.Text = KeyboardSimulator.GetFormatedKeysString(hotkeyEndCoords);
        }

        public void SaveSettings(Settings settings)
        {
            settings.SetSettingValue(Settings.SETTING_HOTKEYSTARTSEQUENCE, (int)hotkeyStartSequence, SettingsType.Hotkeys);
            settings.SetSettingValue(Settings.SETTING_HOTKEYSTOPSEQUENCE, (int)hotkeyStopSequence, SettingsType.Hotkeys);
            settings.SetSettingValue(Settings.SETTING_HOTKEYSTARTCOORDS, (int)hotkeyStartCoords, SettingsType.Hotkeys);
            settings.SetSettingValue(Settings.SETTING_HOTKEYENDCOORDS, (int)hotkeyEndCoords, SettingsType.Hotkeys);
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.Hotkeys;
        }

        private bool IsDuplicate()
        {
            bool isDuplicate = false;

            hotkeyStartSequenceLabel.ForeColor = textColor;
            hotkeyStopSequenceLabel.ForeColor = textColor;
            hotkeyStartCoordsLabel.ForeColor = textColor;
            hotkeyEndCoordsLabel.ForeColor = textColor;

            if (hotkeyStartSequence == hotkeyStopSequence)
            {
                hotkeyStartSequenceLabel.ForeColor = Color.Red;
                hotkeyStopSequenceLabel.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (hotkeyStartSequence == hotkeyStartCoords)
            {
                hotkeyStartSequenceLabel.ForeColor = Color.Red;
                hotkeyStartCoordsLabel.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (hotkeyStartSequence == hotkeyEndCoords)
            {
                hotkeyStartSequenceLabel.ForeColor = Color.Red;
                hotkeyEndCoordsLabel.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (hotkeyStopSequence == hotkeyStartCoords)
            {
                hotkeyStopSequenceLabel.ForeColor = Color.Red;
                hotkeyStartCoordsLabel.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (hotkeyStopSequence == hotkeyEndCoords)
            {
                hotkeyStopSequenceLabel.ForeColor = Color.Red;
                hotkeyEndCoordsLabel.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (hotkeyStartCoordsLabel == hotkeyEndCoordsLabel)
            {
                hotkeyStartCoordsLabel.ForeColor = Color.Red;
                hotkeyEndCoordsLabel.ForeColor = Color.Red;
                isDuplicate = true;
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
                    hotkeyStartSequenceButton.Text = Properties.strings.button_Key_WaitForInput;
                    break;

                case Settings.SETTING_HOTKEYSTOPSEQUENCE:
                    hotkeyStopSequenceButton.Text = Properties.strings.button_Key_WaitForInput;
                    break;

                case Settings.SETTING_HOTKEYSTARTCOORDS:
                    hotkeyStartCoordsButton.Text = Properties.strings.button_Key_WaitForInput;
                    break;

                case Settings.SETTING_HOTKEYENDCOORDS:
                    hotkeyEndCoordsButton.Text = Properties.strings.button_Key_WaitForInput;
                    break;
            }
        }
    }
}
