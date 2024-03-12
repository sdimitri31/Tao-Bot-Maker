using System.Windows.Forms;

namespace Tao_Bot_Maker.View
{
    public partial class ActionTextPanel : UserControl
    {
        ActionView actionView;
        public ActionTextPanel(ActionView actionView, Action action = null)
        {
            InitializeComponent();
            Localization();
            this.actionView = actionView;

            if( action != null)
            {
                Text = ((ActionText)action).Text;
            }
        }

        private void Localization()
        {
            label_Text.Text = Properties.strings.label_Text;
        }

        public new string Text
        {
            get
            {
                try
                {
                    if (textBox_Text.Text != null)
                    {
                        string text = textBox_Text.Text;
                        return text;
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            set { textBox_Text.Text = value.ToString(); }
        }

        private void textBox_Text_Enter(object sender, System.EventArgs e)
        {
            actionView.CausesValidation = false;
        }

        private void textBox_Text_Leave(object sender, System.EventArgs e)
        {
            actionView.CausesValidation = true;
        }
    }
}
