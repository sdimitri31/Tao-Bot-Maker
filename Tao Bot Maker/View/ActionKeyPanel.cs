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

        public string Key
        {
            get
            {
                try
                {
                    if (textBox_Key.Text != null)
                    {
                        string Key = textBox_Key.Text;
                        return Key;
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            set { textBox_Key.Text = value.ToString(); }
        }
    }
}
