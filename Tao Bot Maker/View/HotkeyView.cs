using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Tao_Bot_Maker.Controller;
using BlueMystic;

namespace Tao_Bot_Maker.View
{
    public partial class HotkeyView : Form
    {
        public Hotkey ReturnHotkeyStartBot { get; set; }
        public Hotkey ReturnHotkeyStopBot { get; set; }
        public Hotkey ReturnHotkeyXY { get; set; }
        public Hotkey ReturnHotkeyXY2 { get; set; }

        public HotkeyView()
        {
            InitializeComponent();
            Localization();

            DarkModeCS DM = new DarkModeCS(this, SettingsController.GetTheme(), false);

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
            int modifier = 0;
            
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
            
            if(keyStartBot == keyStopBot)
                return true;
            else if (keyStartBot == keyXY)
                return true;
            else if (keyStartBot == keyXY2)
                return true;
            else if (keyStopBot == keyXY) 
                return true;
            else if (keyStopBot == keyXY2)
                return true;
            else if (keyXY == keyXY2)
                return true;

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
        
    }
}