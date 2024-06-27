using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class WaitActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        public WaitActionPropertiesPanel()
        {
            InitializeComponent();
        }

        public Action GetAction()
        {
            WaitAction waitAction = new WaitAction(
                minimumWait: (int)this.minimumWaitNumericUpDown.Value, 
                maximumWait: (int)this.maximumWaitNumericUpDown.Value, 
                randomizeWait: this.randomizeWaitCheckBox.Checked
            );

            if (!waitAction.Validate(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return waitAction;
;
        }

        public void SetAction(Action action)
        {
            if (action != null && action is WaitAction waitAction)
            {
                this.minimumWaitNumericUpDown.Value = waitAction.MinimumWait;
                this.maximumWaitNumericUpDown.Value = waitAction.MaximumWait;
                this.randomizeWaitCheckBox.Checked = waitAction.RandomizeWait;
            }
        }

    }
}
