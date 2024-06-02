using BlueMystic;
using System.Security.Policy;
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

        private void linkLabelDarkMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BlueMystical/Dark-Mode-Forms");
        }

        private void linkLabelAboutWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/sdimitri31/Tao-Bot-Maker");
        }
    }
}
