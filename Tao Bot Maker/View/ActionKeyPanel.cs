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
        public ActionKeyPanel(Action action = null)
        {
            InitializeComponent();
            Localization();
            if( action != null)
            {
                Key = ((ActionKey)action).Key;
            }
        }

        private void Localization()
        {
            label_Key.Text = Properties.strings.label_Key;
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
