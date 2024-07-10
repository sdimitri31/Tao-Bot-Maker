using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class TextActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        public TextActionPropertiesPanel()
        {
            InitializeComponent();
            UpdateUI();
            InitializeSpeed();
        }

        private void UpdateUI()
        {
            textToTypeLabel.Text = Resources.Strings.LabelTextToType;
            speedLabel.Text = Resources.Strings.LabelTypingSpeed;
        }

        public Action GetAction()
        {
            TextAction textAction = new TextAction(
                textToType: this.textToTypeTextBox.Text,
                typingSpeed: this.speedComboBox.SelectedIndex
            );

            return textAction;
        }

        public void InitializeSpeed()
        {
            this.speedComboBox.Items.AddRange(new object[] {
                Resources.Strings.ComboBoxSpeedSlow,
                Resources.Strings.ComboBoxSpeedMedium,
                Resources.Strings.ComboBoxSpeedFast
            });
            this.speedComboBox.SelectedIndex = 0;
        }

        public void SetAction(Action action)
        {
            if (action != null && action is TextAction textAction)
            {
                this.textToTypeTextBox.Text = textAction.TextToType;
                this.speedComboBox.SelectedIndex = textAction.TypingSpeed;
            }
        }

        ActionType IActionPropertiesPanel.GetType()
        {
            return ActionType.TextAction;
        }
    }
}
