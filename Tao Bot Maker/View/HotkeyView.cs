using BlueMystic;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;

namespace Tao_Bot_Maker.View
{
    public partial class HotkeyView : Form
    {
        Color textColor;

        public Hotkey ReturnHotkeyStartBot { get; set; }
        public Hotkey ReturnHotkeyStopBot { get; set; }
        public Hotkey ReturnHotkeyXY { get; set; }
        public Hotkey ReturnHotkeyXY2 { get; set; }

        public HotkeyView()
        {
            InitializeComponent();
            Localization();

            DarkModeCS DM = new DarkModeCS(this, SettingsController.GetTheme(), false);
            textColor = groupBox_StartBot.ForeColor;

            flatComboBoxStartBotKey.DataSource = Enum.GetValues(typeof(Keys));
            flatComboBoxStartBotKey.SelectedItem = SettingsController.GetHotkeyKeyStartBot();
            Hotkey.KeyModifier modifier = (Hotkey.KeyModifier)SettingsController.GetHotkeyModifierStartBot();
            checkBox_StartBot_Ctrl.Checked = (modifier & Hotkey.KeyModifier.Control) != Hotkey.KeyModifier.None;
            checkBox_StartBot_Alt.Checked = (modifier & Hotkey.KeyModifier.Alt) != Hotkey.KeyModifier.None;
            checkBox_StartBot_Shift.Checked = (modifier & Hotkey.KeyModifier.Shift) != Hotkey.KeyModifier.None;

            flatComboBoxStopBotKey.DataSource = Enum.GetValues(typeof(Keys));
            flatComboBoxStopBotKey.SelectedItem = SettingsController.GetHotkeyKeyStopBot();
            modifier = (Hotkey.KeyModifier)SettingsController.GetHotkeyModifierStopBot();
            checkBox_StopBot_Ctrl.Checked = (modifier & Hotkey.KeyModifier.Control) != Hotkey.KeyModifier.None;
            checkBox_StopBot_Alt.Checked = (modifier & Hotkey.KeyModifier.Alt) != Hotkey.KeyModifier.None;
            checkBox_StopBot_Shift.Checked = (modifier & Hotkey.KeyModifier.Shift) != Hotkey.KeyModifier.None;

            flatComboBoxXYKey.DataSource = Enum.GetValues(typeof(Keys));
            flatComboBoxXYKey.SelectedItem = SettingsController.GetHotkeyKeyXY();
            modifier = (Hotkey.KeyModifier)SettingsController.GetHotkeyModifierXY();
            checkBox_XY_Ctrl.Checked = (modifier & Hotkey.KeyModifier.Control) != Hotkey.KeyModifier.None;
            checkBox_XY_Alt.Checked = (modifier & Hotkey.KeyModifier.Alt) != Hotkey.KeyModifier.None;
            checkBox_XY_Shift.Checked = (modifier & Hotkey.KeyModifier.Shift) != Hotkey.KeyModifier.None;

            flatComboBoxXY2Key.DataSource = Enum.GetValues(typeof(Keys));
            flatComboBoxXY2Key.SelectedItem = SettingsController.GetHotkeyKeyXY2();
            modifier = (Hotkey.KeyModifier)SettingsController.GetHotkeyModifierXY2();
            checkBox_XY2_Ctrl.Checked = (modifier & Hotkey.KeyModifier.Control) != Hotkey.KeyModifier.None;
            checkBox_XY2_Alt.Checked = (modifier & Hotkey.KeyModifier.Alt) != Hotkey.KeyModifier.None;
            checkBox_XY2_Shift.Checked = (modifier & Hotkey.KeyModifier.Shift) != Hotkey.KeyModifier.None;
        }
        private void Localization()
        {
            Text = Properties.strings.title_Hotkeys;

            groupBox_StartBot.Text = Properties.strings.label_StartBot;
            checkBox_StartBot_Ctrl.Text = Properties.strings.label_Ctrl;
            checkBox_StartBot_Alt.Text = Properties.strings.label_Alt;
            checkBox_StartBot_Shift.Text = Properties.strings.label_Shift;

            groupBox_StopBot.Text = Properties.strings.label_StopBot;
            checkBox_StopBot_Ctrl.Text = Properties.strings.label_Ctrl;
            checkBox_StopBot_Alt.Text = Properties.strings.label_Alt;
            checkBox_StopBot_Shift.Text = Properties.strings.label_Shift;

            groupBox_XY.Text = Properties.strings.label_SetXY;
            checkBox_XY_Ctrl.Text = Properties.strings.label_Ctrl;
            checkBox_XY_Alt.Text = Properties.strings.label_Alt;
            checkBox_XY_Shift.Text = Properties.strings.label_Shift;

            groupBox_XY2.Text = Properties.strings.label_SetXY2;
            checkBox_XY2_Ctrl.Text = Properties.strings.label_Ctrl;
            checkBox_XY2_Alt.Text = Properties.strings.label_Alt;
            checkBox_XY2_Shift.Text = Properties.strings.label_Shift;
        }

        private bool IsDuplicate()
        {
            if ((flatComboBoxStartBotKey.SelectedItem != null) &&
                (flatComboBoxStopBotKey.SelectedItem != null) &&
                (flatComboBoxXYKey.SelectedItem != null) &&
                (flatComboBoxXY2Key.SelectedItem != null))
            {
                int modifier;

                //StartBot key
                modifier = MainApp.Reverse3Bits((int)GetStartBotModifier()) << 16;
                Keys keyStartBot = (Keys)((int)flatComboBoxStartBotKey.SelectedItem | modifier);

                //StopBot key
                modifier = MainApp.Reverse3Bits((int)GetStopBotModifier()) << 16;
                Keys keyStopBot = (Keys)((int)flatComboBoxStopBotKey.SelectedItem | modifier);

                //XY key
                modifier = MainApp.Reverse3Bits((int)GetXYModifier()) << 16;
                Keys keyXY = (Keys)((int)flatComboBoxXYKey.SelectedItem | modifier);

                //XY2 key
                modifier = MainApp.Reverse3Bits((int)GetXY2Modifier()) << 16;
                Keys keyXY2 = (Keys)((int)flatComboBoxXY2Key.SelectedItem | modifier);

                bool isDuplicate = false;

                groupBox_StartBot.ForeColor = textColor;
                groupBox_StopBot.ForeColor = textColor;
                groupBox_XY.ForeColor = textColor;
                groupBox_XY2.ForeColor = textColor;

                if (keyStartBot == keyStopBot)
                {
                    groupBox_StartBot.ForeColor = Color.Red;
                    groupBox_StopBot.ForeColor = Color.Red;
                    isDuplicate = true;
                }
                if (keyStartBot == keyXY)
                {
                    groupBox_StartBot.ForeColor = Color.Red;
                    groupBox_XY.ForeColor = Color.Red;
                    isDuplicate = true;
                }
                if (keyStartBot == keyXY2)
                {
                    groupBox_StartBot.ForeColor = Color.Red;
                    groupBox_XY2.ForeColor = Color.Red;
                    isDuplicate = true;
                }
                if (keyStopBot == keyXY)
                {
                    groupBox_StopBot.ForeColor = Color.Red;
                    groupBox_XY.ForeColor = Color.Red;
                    isDuplicate = true;
                }
                if (keyStopBot == keyXY2)
                {
                    groupBox_StopBot.ForeColor = Color.Red;
                    groupBox_XY2.ForeColor = Color.Red;
                    isDuplicate = true;
                }
                if (keyXY == keyXY2)
                {
                    groupBox_XY.ForeColor = Color.Red;
                    groupBox_XY2.ForeColor = Color.Red;
                    isDuplicate = true;
                }

                return isDuplicate;
            }

            return false;
        }

        private void button_Shortcuts_OK_Click(object sender, EventArgs e)
        {
            if (!IsDuplicate())
            {
                ReturnHotkeyStartBot = new Hotkey(
                    GetStartBotModifier(), 
                    (Keys)flatComboBoxStartBotKey.SelectedItem);

                ReturnHotkeyStopBot = new Hotkey(
                    GetStopBotModifier(),
                    (Keys)flatComboBoxStopBotKey.SelectedItem);

                ReturnHotkeyXY = new Hotkey(
                    GetXYModifier(),
                    (Keys)flatComboBoxXYKey.SelectedItem);

                ReturnHotkeyXY2 = new Hotkey(
                    GetXY2Modifier(),
                    (Keys)flatComboBoxXY2Key.SelectedItem);
            }
            else
            {
                MessageBox.Show("Error : multiple hotkeys have same value");
                this.DialogResult = DialogResult.None;
            }
        }

        private int GetStartBotModifier()
        {
            int startbotModifier = (int)Hotkey.KeyModifier.None;
            if (checkBox_StartBot_Ctrl.Checked)
            {
                startbotModifier += (int)Hotkey.KeyModifier.Control;
            }
            if (checkBox_StartBot_Alt.Checked)
            {
                startbotModifier += (int)Hotkey.KeyModifier.Alt;
            }
            if (checkBox_StartBot_Shift.Checked)
            {
                startbotModifier += (int)Hotkey.KeyModifier.Shift;
            }
            return startbotModifier;
        }
        private int GetStopBotModifier()
        {
            int modifier = (int)Hotkey.KeyModifier.None;
            if (checkBox_StopBot_Ctrl.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Control;
            }
            if (checkBox_StopBot_Alt.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Alt;
            }
            if (checkBox_StopBot_Shift.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Shift;
            }
            return modifier;
        }
        private int GetXYModifier()
        {
            int modifier = (int)Hotkey.KeyModifier.None;
            if (checkBox_XY_Ctrl.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Control;
            }
            if (checkBox_XY_Alt.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Alt;
            }
            if (checkBox_XY_Shift.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Shift;
            }
            return modifier;
        }
        private int GetXY2Modifier()
        {
            int modifier = (int)Hotkey.KeyModifier.None;
            if (checkBox_XY2_Ctrl.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Control;
            }
            if (checkBox_XY2_Alt.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Alt;
            }
            if (checkBox_XY2_Shift.Checked)
            {
                modifier += (int)Hotkey.KeyModifier.Shift;
            }
            return modifier;
        }

        private void FlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsDuplicate();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsDuplicate();
        }
    }
}