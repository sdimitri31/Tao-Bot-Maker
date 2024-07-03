using System;
using System.Reflection;
using System.Windows.Forms;

namespace Tao_Bot_Maker.View
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            InitializeAboutForm();
        }

        private void InitializeAboutForm()
        {
            appNameLabel.Text = Resources.Strings.AppName;
            versionLabel.Text = Resources.Strings.LabelVersion;
            versionNumberLabel.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
            authorLabel.Text = Resources.Strings.LabelAuthor;
            sourceCodeLabel.Text = Resources.Strings.LabelSourceCode;
            specialThanksLabel.Text = Resources.Strings.LabelSpecialThanks;
            iconLinkLabel.Text = Resources.Strings.LinkLabelIconEight;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void DevelopperNameLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.susodimitri.fr/",
                UseShellExecute = true
            });
        }

        private void SourceCodeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/sdimitri31/Tao-Bot-Maker",
                UseShellExecute = true
            });
        }

        private void IconLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://icons8.com/icons/fluency",
                UseShellExecute = true
            });
        }
    }
}
