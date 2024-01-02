using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tao_Bot_Maker.View
{
    public partial class ActionKeyPanel : UserControl
    {
        public ActionKeyPanel()
        {
            InitializeComponent();
        }
        public ActionKeyPanel(Action action)
        {
            InitializeComponent();
            Key = ((ActionKey)action).Key;
        }

        public String Key
        {
            get
            {
                try
                {
                    if (textBoxPanelActionKey.Text != null)
                    {
                        String Key = textBoxPanelActionKey.Text;
                        return Key;
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            set { textBoxPanelActionKey.Text = value.ToString(); }
        }
    }
}
