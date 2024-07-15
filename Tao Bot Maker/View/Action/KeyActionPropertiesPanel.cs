using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class KeyActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        private readonly ActionForm addActionForm;
        private bool isDetection;

        public Keys Key { get; set; }

        public KeyActionPropertiesPanel(ActionForm addActionForm)
        {
            InitializeComponent();
            UpdateUI();
            this.addActionForm = addActionForm;
        }

        private void UpdateUI()
        {
            keyLabel.Text = Resources.Strings.LabelKey;
            keyButton.Text = Resources.Strings.ButtonKeyUnassigned;
        }

        public Action GetAction()
        {
            KeyAction keyAction = new KeyAction(key: Key);

            return keyAction;
        }

        public void SetAction(Action action)
        {
            if (action != null && action is KeyAction keyAction)
            {
                Key = keyAction.Key;
                keyButton.Text = KeyboardSimulator.GetFormatedKeysString(Key);
            }
        }

        private void KeyButton_Click(object sender, EventArgs e)
        {
            if (isDetection)
            {
                isDetection = false;
                if (Key == Keys.None)
                    keyButton.Text = Resources.Strings.ButtonKeyUnassigned;
                else
                    keyButton.Text = KeyboardSimulator.GetFormatedKeysString(Key);
            }
            else
            {
                addActionForm.UnregisterHotkeys();
                isDetection = true;
                keyButton.Text = Resources.Strings.ButtonWaitForInput;
            }
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            //Stops detection when a key is released
            if (m.Msg == KeyboardSimulator.WM_KEYUP && isDetection)
            {
                addActionForm.RegisterHotkeys();
                isDetection = false;
                keyLabel.Focus();
                return true;
            }

            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Detects which keys are pressed
            if (isDetection)
            {
                //Saving input
                Key = keyData;

                keyButton.Text = KeyboardSimulator.GetFormatedKeysString(Key);

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        ActionType IActionPropertiesPanel.GetType()
        {
            return ActionType.KeyAction;
        }

        public void SetTheme(AppTheme theme)
        {
            foreach (Control control in this.Controls)
            {
                SetTheme(theme, control);
            }
        }

        public void SetTheme(AppTheme theme, Control control = null)
        {
            if (control is Button)
            {
                ((Button)control).FlatAppearance.BorderColor = theme.BackColorElevationThree;
                ((Button)control).FlatAppearance.MouseOverBackColor = theme.HoverBackColor;
                control.BackColor = theme.BackColorElevationFour;
                control.ForeColor = theme.ForeColor;
            }

            if (control is Panel)
            {
                control.BackColor = theme.BackColorElevationThree;
                control.ForeColor = theme.ForeColor;
            }

            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    SetTheme(theme, child);
                }
            }
        }
    }
}
