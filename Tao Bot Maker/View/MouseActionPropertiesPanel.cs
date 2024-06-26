using System;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class MouseActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        public MouseActionPropertiesPanel()
        {
            InitializeComponent();
            InitializeMoveSpeed();
            leftClickRadioButton.Checked = true;
        }

        /// <summary>
        /// Assign values in numboxX1 and numboxY1
        /// </summary>
        /// <param name="x">Value for X1</param>
        /// <param name="y">Value for Y1</param>
        public void HotkeyXY(int x, int y)
        {
            startXCoordinateNumericUpDown.Value = x;
            startYCoordinateNumericUpDown.Value = y;
        }

        /// <summary>
        /// Assign values in numboxX2 and numboxY2
        /// </summary>
        /// <param name="x">Value for X2</param>
        /// <param name="y">Value for Y2</param>
        public void HotkeyXY2(int x, int y)
        {
            endXCoordinateNumericUpDown.Value = x;
            endYCoordinateNumericUpDown.Value = y;
        }

        public Action GetAction()
        {
            MouseAction mouseAction = new MouseAction(
                clickType: GetMouseActionType(),
                doubleClick: doubleClickCheckBox.Enabled ? doubleClickCheckBox.Checked : false,
                scroll: scrollCheckBox.Enabled ? scrollCheckBox.Checked : false,
                dragAndDrop: dragAndDropCheckBox.Enabled ? dragAndDropCheckBox.Checked : false,
                startX: (int)startXCoordinateNumericUpDown.Value,
                startY: (int)startYCoordinateNumericUpDown.Value,
                useCurrentPosition: useCurrentPositionCheckBox.Enabled ? useCurrentPositionCheckBox.Checked : false,
                endX: endXCoordinateNumericUpDown.Enabled ? (int?)endXCoordinateNumericUpDown.Value : null,
                endY: endYCoordinateNumericUpDown.Enabled ? (int?)endYCoordinateNumericUpDown.Value : null,
                moveSpeed: speedComboBox.SelectedItem != null ? speedComboBox.SelectedItem.ToString() : null,
                scrollDuration: (int)scrollDurationNumericUpDown.Value,
                clickDuration: (int)clickDurationNumericUpDown.Value
            );

            return mouseAction;
        }

        private MouseAction.MouseActionType GetMouseActionType()
        {
            if (leftClickRadioButton.Checked) return MouseAction.MouseActionType.LeftClick;
            if (middleClickRadioButton.Checked) return MouseAction.MouseActionType.MiddleClick;
            if (rightClickRadioButton.Checked) return MouseAction.MouseActionType.RightClick;
            return MouseAction.MouseActionType.NoClick;
        }

        public void InitializeMoveSpeed()
        {
            this.speedComboBox.Items.AddRange(new object[] {
                "Slow",
                "Medium",
                "Fast"
            });
            this.speedComboBox.SelectedIndex = 0;
        }

        private void UseCurrentPositionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private void ClickRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                // Assure que seulement un RadioButton est sélectionné
                DeselectOtherRadioButtons((RadioButton)sender);
            }
            UpdateControlStates();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                DeselectIncompatibleCheckBoxes((CheckBox)sender);
            }
            UpdateControlStates();
        }

        private void UpdateControlStates()
        {
            bool isClickSelected = leftClickRadioButton.Checked || middleClickRadioButton.Checked || rightClickRadioButton.Checked;
            bool isNoClickSelected = noneClickRadioButton.Checked;
            bool isDragAndDrop = dragAndDropCheckBox.Checked;
            bool isScroll = scrollCheckBox.Checked;
            bool isDoubleClick = doubleClickCheckBox.Checked;

            startXCoordinateNumericUpDown.Enabled = !useCurrentPositionCheckBox.Checked;
            startYCoordinateNumericUpDown.Enabled = !useCurrentPositionCheckBox.Checked;

            endXCoordinateNumericUpDown.Enabled = isDragAndDrop;
            endYCoordinateNumericUpDown.Enabled = isDragAndDrop;
            endCoordinateLabel.Enabled = isDragAndDrop;
            endXCoordinateLabel.Enabled = isDragAndDrop;
            endYCoordinateLabel.Enabled = isDragAndDrop;

            scrollAmountLabel.Enabled = isScroll;
            scrollDurationNumericUpDown.Enabled = isScroll;

            clickDurationLabel.Enabled = isClickSelected || isNoClickSelected;
            clickDurationNumericUpDown.Enabled = isClickSelected || isNoClickSelected;

            // Désactiver les RadioButton en fonction des CheckBox
            if (isScroll)
            {
                noneClickRadioButton.Checked = true;
                leftClickRadioButton.Enabled = false;
                middleClickRadioButton.Enabled = false;
                rightClickRadioButton.Enabled = false;
                doubleClickCheckBox.Checked = false;
                dragAndDropCheckBox.Checked = false;
            }
            else
            {
                leftClickRadioButton.Enabled = true;
                middleClickRadioButton.Enabled = true;
                rightClickRadioButton.Enabled = true;
            }

            if (isDoubleClick)
            {
                noneClickRadioButton.Enabled = false;
            }
            else
            {
                noneClickRadioButton.Enabled = true;
            }

            if (isDoubleClick && noneClickRadioButton.Checked)
            {
                leftClickRadioButton.Checked = true;
            }
        }

        private void DeselectOtherRadioButtons(RadioButton selectedRadioButton)
        {
            // Désélectionner tous les autres RadioButton
            foreach (Control control in selectedRadioButton.Parent.Controls)
            {
                if (control is RadioButton radioButton && radioButton != selectedRadioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private void DeselectIncompatibleCheckBoxes(CheckBox selectedCheckBox)
        {
            if (selectedCheckBox == doubleClickCheckBox && selectedCheckBox.Checked)
            {
                scrollCheckBox.Checked = false;
                dragAndDropCheckBox.Checked = false;
            }
            else if (selectedCheckBox == scrollCheckBox && selectedCheckBox.Checked)
            {
                doubleClickCheckBox.Checked = false;
                dragAndDropCheckBox.Checked = false;
            }
            else if (selectedCheckBox == dragAndDropCheckBox && selectedCheckBox.Checked)
            {
                doubleClickCheckBox.Checked = false;
                scrollCheckBox.Checked = false;
            }
        }

    }
}
