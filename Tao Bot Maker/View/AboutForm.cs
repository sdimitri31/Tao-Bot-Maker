using System;
using System.Reflection;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class AboutForm : Form
    {
        private AppTheme appTheme;
        public AboutForm()
        {
            InitializeComponent();
            InitializeAboutForm();

            LoadThemeSettings();
        }
        private void LoadThemeSettings()
        {
            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
            appTheme = AppThemeHelper.GetAppThemeFromName(theme);
            AppThemeHelper.ApplyTheme(appTheme, this, 1);
        }

        private void InitializeAboutForm()
        {
            appNameLabel.Text = Resources.Strings.AppName;
            versionLabel.Text = Resources.Strings.LabelVersion;
            versionNumberLabel.Text = Assembly.GetEntryAssembly().GetName().Version.ToString() + "-beta";
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
