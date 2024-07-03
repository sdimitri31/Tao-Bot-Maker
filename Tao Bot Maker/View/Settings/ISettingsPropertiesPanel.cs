using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public interface ISettingsPropertiesPanel
    {
        SettingsType GetType();

        void LoadSettings();
        void SaveSettings();
    }
}
