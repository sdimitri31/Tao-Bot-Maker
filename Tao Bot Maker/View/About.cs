using BlueMystic;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            DarkModeCS DM = new DarkModeCS(this, SettingsController.GetTheme(), false);
            labelAboutVersionNumber.Text = Constants.VERSION;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
