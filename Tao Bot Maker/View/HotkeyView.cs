using BlueMystic;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class HotkeyView : Form
    {
        private Color textColor;//Default label color
        private string modifyingHotkey = "";//Store current hotkey beeing assigned

        private Keys hotkeyStartBot;
        private Keys hotkeyStopBot;
        private Keys hotkeyXY;
        private Keys hotkeyXY2;

        public Keys HotkeyStartBot 
        {
            get => hotkeyStartBot;
            private set
            {
                hotkeyStartBot = value;
                button_StartBot.Text = Utils.GetFormatedKeysString(value);
            } 
        }

        public Keys HotkeyStopBot
        {
            get => hotkeyStopBot;
            private set
            {
                hotkeyStopBot = value;
                button_StopBot.Text = Utils.GetFormatedKeysString(value);
            }
        }

        public Keys HotkeyXY
        {
            get => hotkeyXY;
            private set
            {
                hotkeyXY = value;
                button_XY.Text = Utils.GetFormatedKeysString(value);
            }
        }

        public Keys HotkeyXY2
        {
            get => hotkeyXY2;
            private set
            {
                hotkeyXY2 = value;
                button_XY2.Text = Utils.GetFormatedKeysString(value);
            }
        }

        public HotkeyView()
        {
            InitializeComponent();
            Localization();

            DarkModeCS DM = new DarkModeCS(this, SettingsController.GetTheme(), false);
            textColor = label_StartBot.ForeColor;

            HotkeyStartBot = SettingsController.GetHotkeyStartBot();
            HotkeyStopBot = SettingsController.GetHotkeyStopBot();
            HotkeyXY = SettingsController.GetHotkeyXY();
            HotkeyXY2 = SettingsController.GetHotkeyXY2();

            IsDuplicate();
        }
        
        private void Localization()
        {
            Text = Properties.strings.title_Hotkeys;

            label_StartBot.Text = Properties.strings.label_StartBot;
            label_StopBot.Text = Properties.strings.label_StopBot;
            label_XY.Text = Properties.strings.label_SetXY;
            label_XY2.Text = Properties.strings.label_SetXY2;

            button_Cancel.Text = Properties.strings.button_Cancel;
            button_OK.Text = Properties.strings.button_OK;
        }

        private bool IsDuplicate()
        {
            bool isDuplicate = false;

            label_StartBot.ForeColor = textColor;
            label_StopBot.ForeColor = textColor;
            label_XY.ForeColor = textColor;
            label_XY2.ForeColor = textColor;

            if (HotkeyStartBot == HotkeyStopBot)
            {
                label_StartBot.ForeColor = Color.Red;
                label_StopBot.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (HotkeyStartBot == HotkeyXY)
            {
                label_StartBot.ForeColor = Color.Red;
                label_XY.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (HotkeyStartBot == HotkeyXY2)
            {
                label_StartBot.ForeColor = Color.Red;
                label_XY2.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (HotkeyStopBot == HotkeyXY)
            {
                label_StopBot.ForeColor = Color.Red;
                label_XY.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (HotkeyStopBot == HotkeyXY2)
            {
                label_StopBot.ForeColor = Color.Red;
                label_XY2.ForeColor = Color.Red;
                isDuplicate = true;
            }
            if (HotkeyXY == HotkeyXY2)
            {
                label_XY.ForeColor = Color.Red;
                label_XY2.ForeColor = Color.Red;
                isDuplicate = true;
            }

            return isDuplicate;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (IsDuplicate())
            {
                MessageBox.Show(Properties.strings.MessageBox_Error_HotkeyDuplicate);
                this.DialogResult = DialogResult.None;
            }
        }
        
        protected override bool ProcessKeyPreview(ref Message m)
        {
            //Stops detection when a key is released
            if (m.Msg == Constants.WM_KEYUP )
            {
                switch (modifyingHotkey)
                {
                    case "startbot":
                        modifyingHotkey = "";
                        button_StartBot.Text = Utils.GetFormatedKeysString(HotkeyStartBot);
                        IsDuplicate();
                        return true;

                    case "stopbot":
                        modifyingHotkey = "";
                        button_StopBot.Text = Utils.GetFormatedKeysString(HotkeyStopBot);
                        IsDuplicate();
                        return true;

                    case "xy":
                        modifyingHotkey = "";
                        button_XY.Text = Utils.GetFormatedKeysString(HotkeyXY);
                        IsDuplicate();
                        return true;

                    case "xy2":
                        modifyingHotkey = "";
                        button_XY2.Text = Utils.GetFormatedKeysString(HotkeyXY2);
                        IsDuplicate();
                        return true;
                }
            }

            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ////Detects which keys are pressed
            //if (msg.Msg == Constants.WM_KEYDOWN)
            //{
                //Saving input
                switch (modifyingHotkey)
                {
                    case "startbot":
                        HotkeyStartBot = keyData;
                        return true;

                    case "stopbot":
                        HotkeyStopBot = keyData;
                        return true;

                    case "xy":
                        HotkeyXY = keyData;
                        return true;

                    case "xy2":
                        HotkeyXY2 = keyData;
                        return true;
                }

            //}

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Button_StartBot_Click(object sender, EventArgs e)
        {
            //Toggle hotkey capture
            if(modifyingHotkey == "startbot")
                SetModifyingHotkey("");
            else
                SetModifyingHotkey("startbot");
        }

        private void Button_StopBot_Click(object sender, EventArgs e)
        {
            //Toggle hotkey capture
            if (modifyingHotkey == "stopbot")
                SetModifyingHotkey("");
            else
                SetModifyingHotkey("stopbot");
        }

        private void Button_XY_Click(object sender, EventArgs e)
        {
            //Toggle hotkey capture
            if (modifyingHotkey == "xy")
                SetModifyingHotkey("");
            else
                SetModifyingHotkey("xy");
        }

        private void Button_XY2_Click(object sender, EventArgs e)
        {
            if (modifyingHotkey == "xy2")
                SetModifyingHotkey("");
            else
                SetModifyingHotkey("xy2");
        }

        private void SetModifyingHotkey(string modifying)
        {
            //Reset buttons
            HotkeyStartBot = hotkeyStartBot;
            HotkeyStopBot = hotkeyStopBot;
            HotkeyXY = hotkeyXY;
            HotkeyXY2 = hotkeyXY2;

            modifyingHotkey = modifying;

            switch (modifyingHotkey)
            {
                case "startbot":
                    button_StartBot.Text = Properties.strings.button_Key_WaitForInput;
                    break;

                case "stopbot":
                    button_StopBot.Text = Properties.strings.button_Key_WaitForInput;
                    break;

                case "xy":
                    button_XY.Text = Properties.strings.button_Key_WaitForInput;
                    break;

                case "xy2":
                    button_XY2.Text = Properties.strings.button_Key_WaitForInput;
                    break;
            }
        }
    }
}