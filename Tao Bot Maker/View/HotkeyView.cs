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

namespace Tao_Bot_Maker.View
{
    public partial class HotkeyView : Form
    {
        public Hotkey ReturnHotkeyStartBot { get; set; }
        public Hotkey ReturnHotkeyStopBot { get; set; }
        public Hotkey ReturnHotkeyXY { get; set; }
        public Hotkey ReturnHotkeyXY2 { get; set; }

        public HotkeyView(HotKeyController startBot, HotKeyController stopBot, HotKeyController XY, HotKeyController XY2)
        {
            InitializeComponent();
            Localization();

            comboBox_StartBot_Key.DataSource = Enum.GetValues(typeof(Keys));
            comboBox_StartBot_Key.SelectedItem = startBot.GetKey();
            Hotkey.KeyModifier modifier = (Hotkey.KeyModifier)startBot.GetModifier();
            checkBox_StartBot_Ctrl.Checked = (modifier & Hotkey.KeyModifier.Control) != Hotkey.KeyModifier.None;
            checkBox_StartBot_Alt.Checked = (modifier & Hotkey.KeyModifier.Alt) != Hotkey.KeyModifier.None;
            checkBox_StartBot_Shift.Checked = (modifier & Hotkey.KeyModifier.Shift) != Hotkey.KeyModifier.None;

            comboBox_StopBot_Key.DataSource = Enum.GetValues(typeof(Keys));
            comboBox_StopBot_Key.SelectedItem = stopBot.GetKey();
            modifier = (Hotkey.KeyModifier)stopBot.GetModifier();
            checkBox_StopBot_Ctrl.Checked = (modifier & Hotkey.KeyModifier.Control) != Hotkey.KeyModifier.None;
            checkBox_StopBot_Alt.Checked = (modifier & Hotkey.KeyModifier.Alt) != Hotkey.KeyModifier.None;
            checkBox_StopBot_Shift.Checked = (modifier & Hotkey.KeyModifier.Shift) != Hotkey.KeyModifier.None;

            comboBox_XY_Key.DataSource = Enum.GetValues(typeof(Keys));
            comboBox_XY_Key.SelectedItem = XY.GetKey();
            modifier = (Hotkey.KeyModifier)XY.GetModifier();
            checkBox_XY_Ctrl.Checked = (modifier & Hotkey.KeyModifier.Control) != Hotkey.KeyModifier.None;
            checkBox_XY_Alt.Checked = (modifier & Hotkey.KeyModifier.Alt) != Hotkey.KeyModifier.None;
            checkBox_XY_Shift.Checked = (modifier & Hotkey.KeyModifier.Shift) != Hotkey.KeyModifier.None;

            comboBox_XY2_Key.DataSource = Enum.GetValues(typeof(Keys));
            comboBox_XY2_Key.SelectedItem = XY2.GetKey();
            modifier = (Hotkey.KeyModifier)XY2.GetModifier();
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

        private void button_Shortcuts_OK_Click(object sender, EventArgs e)
        {
            ReturnHotkeyStartBot = new Hotkey(
                GetStartBotModifier(), 
                (Keys)comboBox_StartBot_Key.SelectedItem);

            ReturnHotkeyStopBot = new Hotkey(
                GetStopBotModifier(),
                (Keys)comboBox_StopBot_Key.SelectedItem);

            ReturnHotkeyXY = new Hotkey(
                GetXYModifier(),
                (Keys)comboBox_XY_Key.SelectedItem);

            ReturnHotkeyXY2 = new Hotkey(
                GetXY2Modifier(),
                (Keys)comboBox_XY2_Key.SelectedItem);
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
