using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tao_Bot_Maker.View
{
    public partial class ActionWaitPanel : UserControl
    {
        public ActionWaitPanel(Action action = null)
        {
            InitializeComponent();
            Localization();

            if (action != null)
                WaitTime = ((ActionWait)action).WaitTime;
        }

        private void Localization()
        {
            label_WaitTime.Text = Properties.strings.label_WaitTime;
        }

        public int WaitTime
        {
            get 
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_WaitTime.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { numericUpDown_WaitTime.Text = value.ToString(); }
        }
    }
}
