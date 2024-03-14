using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tao_Bot_Maker.View
{
    public partial class ActionKeyPanel : UserControl
    {
        private bool isDetection;

        public Keys Key { get; set; } 

        public ActionKeyPanel(Action action = null)
        {
            InitializeComponent();
            Localization();

            if(action != null)
            {
                Key = ((ActionKey)action).Key;
                button_Key.Text = Controller.Utils.GetFormatedKeysString(Key);
            }
        }

        private void Localization()
        {
            label_Key.Text = Properties.strings.label_Key;
            button_Key.Text = Properties.strings.button_Key_Unassigned;
        }

        private void Button_Key_Click(object sender, EventArgs e)
        {
            if(isDetection)
            {
                isDetection = false;
                if(Key == Keys.None) 
                    button_Key.Text = Properties.strings.button_Key_Unassigned;
                else
                    button_Key.Text = Controller.Utils.GetFormatedKeysString(Key);
            }
            else
            {
                isDetection = true;
                button_Key.Text = Properties.strings.button_Key_WaitForInput;
            }
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            //Stops detection when a key is released
            if (m.Msg == Constants.WM_KEYUP && isDetection)
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

                button_Key.Text = Controller.Utils.GetFormatedKeysString(Key);

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
