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
            InitializeSpeed();
        }

        public Action GetAction()
        {
            TextAction textAction = new TextAction(
                textToType: this.textToTypeTextBox.Text, 
                typingSpeed: this.speedComboBox.SelectedItem.ToString()
            );

            return textAction;
        }

        public void InitializeSpeed()
        {
            this.speedComboBox.Items.AddRange(new object[] {
                "Slow",
                "Medium",
                "Fast"
            });
        }

        public void SetAction(Action action)
        {
            if (action != null && action is TextAction textAction)
            {
                this.textToTypeTextBox.Text = textAction.TextToType;
                this.speedComboBox.SelectedItem = textAction.TypingSpeed;
            }
        }

    }
}
