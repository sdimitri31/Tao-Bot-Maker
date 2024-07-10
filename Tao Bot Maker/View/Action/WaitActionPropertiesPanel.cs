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
            UpdateUI();
            UpdateUIState();
        }

        private void UpdateUI()
        {
            minimumWaitLabel.Text = Resources.Strings.LabelMinimumWait;
            maximumWaitLabel.Text = Resources.Strings.LabelMaximumWait;
            randomizeWaitCheckBox.Text = Resources.Strings.LabelRandomizeWait;
        }

        private void UpdateUIState()
        {
            this.maximumWaitLabel.Enabled = randomizeWaitCheckBox.Checked;
            this.maximumWaitNumericUpDown.Enabled = randomizeWaitCheckBox.Checked;
        }

        public Action GetAction()
        {
            WaitAction waitAction = new WaitAction(
                minimumWait: (int)this.minimumWaitNumericUpDown.Value,
                maximumWait: (int)this.maximumWaitNumericUpDown.Value,
                randomizeWait: this.randomizeWaitCheckBox.Checked
            );

            return waitAction;
        }

        public void SetAction(Action action)
        {
            if (action != null && action is WaitAction waitAction)
            {
                this.minimumWaitNumericUpDown.Value = waitAction.MinimumWait;
                this.maximumWaitNumericUpDown.Value = waitAction.MaximumWait;
                this.randomizeWaitCheckBox.Checked = waitAction.RandomizeWait;
            }
            UpdateUIState();
        }

        ActionType IActionPropertiesPanel.GetType()
        {
            return ActionType.WaitAction;
        }

        private void RandomizeWaitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUIState();
        }
    }
}
