using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class TestView : Form
    {
        private AppTheme appTheme;
        public TestView()
        {
            InitializeComponent();
            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
            appTheme = AppThemeHelper.GetAppThemeFromName(theme);
            AppThemeHelper.ApplyTheme(appTheme, this, 0);
        }
    }
}
