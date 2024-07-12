using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public interface IActionPropertiesPanel
    {
        ActionType GetType();

        Action GetAction();

        void SetAction(Action action);

        void SetTheme(AppTheme theme);

    }
}
