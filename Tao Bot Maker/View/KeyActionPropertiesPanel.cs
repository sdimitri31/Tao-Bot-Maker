﻿using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class KeyActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        private bool isDetection;

        public Keys Key { get; set; }

        public KeyActionPropertiesPanel()
        {
            InitializeComponent();
        }

        public Action GetAction()
        {
            KeyAction sequenceAction = new KeyAction(keyToPress: Key);

            return sequenceAction;
        }

        private void KeyButton_Click(object sender, EventArgs e)
        {
            if (isDetection)
            {
                isDetection = false;
                if (Key == Keys.None)
                    keyButton.Text = Properties.strings.button_Key_Unassigned;
                else
                    keyButton.Text = KeyboardSimulator.GetFormatedKeysString(Key);
            }
            else
            {
                isDetection = true;
                keyButton.Text = Properties.strings.button_Key_WaitForInput;
            }
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            //Stops detection when a key is released
            if (m.Msg == KeyboardSimulator.WM_KEYUP && isDetection)
            {
                isDetection = false;
                return true;
            }

            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Detects which keys are pressed
            //if (msg.Msg == Constants.WM_KEYDOWN && isDetection)
            if (isDetection)
            {
                //Saving input
                Key = keyData;

                keyButton.Text = KeyboardSimulator.GetFormatedKeysString(Key);

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
