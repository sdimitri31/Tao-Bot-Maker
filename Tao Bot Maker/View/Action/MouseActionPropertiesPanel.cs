using System;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using static Tao_Bot_Maker.Model.MouseAction;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class MouseActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        private bool isFromImageAction;

        public MouseActionPropertiesPanel(bool isFromImageAction = false)
        {
            InitializeComponent();
            UpdateUI();
            InitializeMoveSpeed();
            leftClickRadioButton.Checked = true;
            this.isFromImageAction = isFromImageAction;
            ShowCoordsFromImage(isFromImageAction);
        }

        private void UpdateUI()
        {
            clickTypeLabel.Text = Resources.Strings.LabelClickType;
            leftClickRadioButton.Text = Resources.Strings.LabelLeftClick;
            middleClickRadioButton.Text = Resources.Strings.LabelMiddleClick;
            rightClickRadioButton.Text = Resources.Strings.LabelRightClick;
            noneClickRadioButton.Text = Resources.Strings.LabelNoClick;
            doubleClickCheckBox.Text = Resources.Strings.LabelDoubleClick;
            scrollCheckBox.Text = Resources.Strings.LabelScroll;
            dragAndDropCheckBox.Text = Resources.Strings.LabelDragAndDrop;

            startCoordinateLabel.Text = Resources.Strings.LabelStartCoordinates;
            useCurrentPositionCheckBox.Text = Resources.Strings.LabelUseCurrentPosition;
            startImageCoordCheckBox.Text = Resources.Strings.LabelUseImageCoordinates;

            endCoordinateLabel.Text = Resources.Strings.LabelEndCoordinates;
            endImageCoordCheckBox.Text = Resources.Strings.LabelUseImageCoordinates;

            speedLabel.Text = Resources.Strings.LabelSpeed;
            scrollAmountLabel.Text = Resources.Strings.LabelScrollAmount;
            clickDurationLabel.Text = Resources.Strings.LabelClickDuration;
        }

        private void ShowCoordsFromImage(bool isFromImageAction)
        {
            startImageCoordCheckBox.Visible = isFromImageAction;
            endImageCoordCheckBox.Visible = isFromImageAction;
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
                useImageCoordsAsStart: startImageCoordCheckBox.Visible ? startImageCoordCheckBox.Checked : false,
                useImageCoordsAsEnd: endImageCoordCheckBox.Visible ? endImageCoordCheckBox.Checked : false,
                useCurrentPosition: useCurrentPositionCheckBox.Enabled ? useCurrentPositionCheckBox.Checked : false,
                endX: (int)endXCoordinateNumericUpDown.Value,
                endY: (int)endYCoordinateNumericUpDown.Value,
                moveSpeed: speedComboBox.SelectedIndex,
                scrollAmount: (int)scrollAmountNumericUpDown.Value,
                clickDuration: (int)clickDurationNumericUpDown.Value
            );

            if (!mouseAction.Validate(out string errorMessage))
            {
                MessageBox.Show(errorMessage, Resources.Strings.ErrorMessageCaptionInvalidAction, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return mouseAction;
        }

        public void SetAction(Action action)
        {
            if (action != null && action is MouseAction mouseAction)
            {
                SetMouseActionType(mouseAction.ClickType);
                doubleClickCheckBox.Checked = mouseAction.DoubleClick;
                scrollCheckBox.Checked = mouseAction.Scroll;
                dragAndDropCheckBox.Checked = mouseAction.DragAndDrop;
                startXCoordinateNumericUpDown.Value = mouseAction.StartX;
                startYCoordinateNumericUpDown.Value = mouseAction.StartY;
                startImageCoordCheckBox.Checked = mouseAction.UseImageCoordsAsStart;
                endImageCoordCheckBox.Checked = mouseAction.UseImageCoordsAsEnd;
                useCurrentPositionCheckBox.Checked = mouseAction.UseCurrentPosition;
                endXCoordinateNumericUpDown.Value = mouseAction.EndX;
                endYCoordinateNumericUpDown.Value = mouseAction.EndY;
                speedComboBox.SelectedIndex = mouseAction.MoveSpeed;
                scrollAmountNumericUpDown.Value = mouseAction.ScrollAmount;
                clickDurationNumericUpDown.Value = mouseAction.ClickDuration;
                UpdateControlStates();
            }
        }

        private MouseAction.MouseActionType GetMouseActionType()
        {
            if (leftClickRadioButton.Checked) return MouseAction.MouseActionType.LeftClick;
            if (middleClickRadioButton.Checked) return MouseAction.MouseActionType.MiddleClick;
            if (rightClickRadioButton.Checked) return MouseAction.MouseActionType.RightClick;
            return MouseAction.MouseActionType.NoClick;
        }

        private void SetMouseActionType(MouseActionType mouseActionType)
        {
            switch (mouseActionType)
            {
                case MouseActionType.LeftClick:
                    leftClickRadioButton.Checked = true;
                    break;
                case MouseActionType.MiddleClick:
                    middleClickRadioButton.Checked = true;
                    break;
                case MouseActionType.RightClick:
                    rightClickRadioButton.Checked = true;
                    break;
                default:
                    noneClickRadioButton.Checked = true;
                    break;
            }
        }

        public void InitializeMoveSpeed()
        {
            this.speedComboBox.Items.AddRange(new object[] {
                Resources.Strings.ComboBoxSpeedSlow,
                Resources.Strings.ComboBoxSpeedMedium,
                Resources.Strings.ComboBoxSpeedFast
            });
            this.speedComboBox.SelectedIndex = 0;
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
            bool isStartImageCoord = startImageCoordCheckBox.Checked;
            bool isEndImageCoord = endImageCoordCheckBox.Checked;

            startXCoordinateNumericUpDown.Enabled = !useCurrentPositionCheckBox.Checked && !isStartImageCoord;
            startYCoordinateNumericUpDown.Enabled = !useCurrentPositionCheckBox.Checked && !isStartImageCoord;

            endXCoordinateNumericUpDown.Enabled = isDragAndDrop && !isEndImageCoord;
            endYCoordinateNumericUpDown.Enabled = isDragAndDrop && !isEndImageCoord;
            endCoordinateLabel.Enabled = isDragAndDrop;

            endImageCoordCheckBox.Enabled = isDragAndDrop;

            scrollAmountLabel.Enabled = isScroll;
            scrollAmountNumericUpDown.Enabled = isScroll;

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
                endImageCoordCheckBox.Checked = false;
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

            if(!isDragAndDrop)
            {
                endImageCoordCheckBox.Checked = false;
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
                endImageCoordCheckBox.Checked = false;
            }
            else if (selectedCheckBox == scrollCheckBox && selectedCheckBox.Checked)
            {
                doubleClickCheckBox.Checked = false;
                dragAndDropCheckBox.Checked = false;
                endImageCoordCheckBox.Checked = false;
            }
            else if (selectedCheckBox == dragAndDropCheckBox && selectedCheckBox.Checked)
            {
                doubleClickCheckBox.Checked = false;
                scrollCheckBox.Checked = false;
            }
            else if (selectedCheckBox == startImageCoordCheckBox && selectedCheckBox.Checked)
            {
                endImageCoordCheckBox.Checked = false;
                useCurrentPositionCheckBox.Checked = false;
            }
            else if (selectedCheckBox == endImageCoordCheckBox && selectedCheckBox.Checked)
            {
                startImageCoordCheckBox.Checked = false;
            }
            else if (selectedCheckBox == useCurrentPositionCheckBox && selectedCheckBox.Checked)
            {
                startImageCoordCheckBox.Checked = false;
            }
        }
    }
}
