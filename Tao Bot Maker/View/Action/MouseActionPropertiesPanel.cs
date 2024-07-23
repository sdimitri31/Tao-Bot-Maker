using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;
using static Tao_Bot_Maker.Model.MouseAction;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class MouseActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        private bool isFromImageAction;
        private DrawingForm drawingForm;

        public MouseActionPropertiesPanel(bool isFromImageAction = false)
        {
            InitializeComponent();
            UpdateUI();
            InitializeMoveSpeed();
            drawingForm = new DrawingForm();
            leftClickRadioButton.Checked = true;
            clickRadioButton.Checked = true;
            this.isFromImageAction = isFromImageAction;
            ShowCoordsFromImage(isFromImageAction);
            this.Disposed += MouseActionPropertiesPanel_Disposed;
        }

        public void SetTheme(AppTheme theme)
        {
            actionPanel.BackColor = theme.BackColorElevationThree;
            actionPanel.ForeColor = theme.ForeColor;

            clickPanel.BackColor = theme.BackColorElevationThree;
            clickPanel.ForeColor = theme.ForeColor;

            startCoordsPanel.BackColor = theme.BackColorElevationThree;
            startCoordsPanel.ForeColor = theme.ForeColor;

            endCoordsPanel.BackColor = theme.BackColorElevationThree;
            endCoordsPanel.ForeColor = theme.ForeColor;

            speedPanel.BackColor = theme.BackColorElevationThree;
            speedPanel.ForeColor = theme.ForeColor;

            scrollPanel.BackColor = theme.BackColorElevationThree;
            scrollPanel.ForeColor = theme.ForeColor;

            clickDurationPanel.BackColor = theme.BackColorElevationThree;
            clickDurationPanel.ForeColor = theme.ForeColor;

            overlayPanel.BackColor = theme.BackColorElevationThree;
            overlayPanel.ForeColor = theme.ForeColor;
        }

        private void MouseActionPropertiesPanel_Disposed(object sender, EventArgs e)
        {
            drawingForm.Close();
        }

        private void UpdateUI()
        {
            actionLabel.Text = Resources.Strings.LabelMouseActionEventType;
            clickTypeLabel.Text = Resources.Strings.LabelClickType;
            leftClickRadioButton.Text = Resources.Strings.LabelLeftClick;
            middleClickRadioButton.Text = Resources.Strings.LabelMiddleClick;
            rightClickRadioButton.Text = Resources.Strings.LabelRightClick;
            noneClickRadioButton.Text = Resources.Strings.LabelNoClick;
            doubleClickRadioButton.Text = Resources.Strings.LabelDoubleClick;
            scrollRadioButton.Text = Resources.Strings.LabelScroll;
            dragAndDropRadioButton.Text = Resources.Strings.LabelDragAndDrop;

            startCoordinateLabel.Text = Resources.Strings.LabelStartCoordinates;
            useCurrentPositionCheckBox.Text = Resources.Strings.LabelUseCurrentPosition;
            startImageCoordCheckBox.Text = Resources.Strings.LabelUseImageCoordinates;

            endCoordinateLabel.Text = Resources.Strings.LabelEndCoordinates;
            endImageCoordCheckBox.Text = Resources.Strings.LabelUseImageCoordinates;

            speedLabel.Text = Resources.Strings.LabelSpeed;
            scrollAmountLabel.Text = Resources.Strings.LabelScrollAmount;
            clickDurationLabel.Text = Resources.Strings.LabelClickDuration;

            overlayCheckBox.Text = Resources.Strings.LabelEnableDrawingOverlay;
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
            if (dragAndDropRadioButton.Checked)
            {
                endXCoordinateNumericUpDown.Value = x;
                endYCoordinateNumericUpDown.Value = y;
            }
        }

        /// <summary>
        /// Draw rectangles from coords using values X1, Y1, X2 and Y2
        /// </summary>
        public void DrawArea()
        {
            if(!overlayCheckBox.Checked)
                return;
            ClearArea();
            if (!useCurrentPositionCheckBox.Checked)
                drawingForm.DrawRectangle((int)startXCoordinateNumericUpDown.Value - 5, (int)startYCoordinateNumericUpDown.Value - 5, 10, 10, KnownColor.Green);
            if (dragAndDropRadioButton.Checked)
                drawingForm.DrawRectangle((int)endXCoordinateNumericUpDown.Value - 5, (int)endYCoordinateNumericUpDown.Value - 5, 10, 10, KnownColor.Orange);
        }

        public void ClearArea()
        {
            drawingForm.ClearRectangles();
        }

        public Action GetAction()
        {
            MouseAction mouseAction = new MouseAction(
                clickType: GetMouseActionType(),
                eventType: GetMouseActionEventType(),
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

            return mouseAction;
        }

        public void SetAction(Action action)
        {
            if (action != null && action is MouseAction mouseAction)
            {
                SetMouseActionType(mouseAction.ClickType);
                SetMouseActionEventType(mouseAction.EventType);
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

        private MouseAction.MouseActionClickType GetMouseActionType()
        {
            if (leftClickRadioButton.Checked) return MouseAction.MouseActionClickType.LeftClick;
            if (middleClickRadioButton.Checked) return MouseAction.MouseActionClickType.MiddleClick;
            if (rightClickRadioButton.Checked) return MouseAction.MouseActionClickType.RightClick;
            return MouseAction.MouseActionClickType.NoClick;
        }

        private MouseAction.MouseActionEventType GetMouseActionEventType()
        {
            if (clickRadioButton.Checked) return MouseAction.MouseActionEventType.Click;
            if (doubleClickRadioButton.Checked) return MouseAction.MouseActionEventType.DoubleClick;
            if (scrollRadioButton.Checked) return MouseAction.MouseActionEventType.Scroll;
            if (dragAndDropRadioButton.Checked) return MouseAction.MouseActionEventType.DragAndDrop;
            return MouseAction.MouseActionEventType.Click;
        }

        private void SetMouseActionType(MouseActionClickType mouseActionType)
        {
            switch (mouseActionType)
            {
                case MouseActionClickType.LeftClick:
                    leftClickRadioButton.Checked = true;
                    break;
                case MouseActionClickType.MiddleClick:
                    middleClickRadioButton.Checked = true;
                    break;
                case MouseActionClickType.RightClick:
                    rightClickRadioButton.Checked = true;
                    break;
                default:
                    noneClickRadioButton.Checked = true;
                    break;
            }
        }

        private void SetMouseActionEventType(MouseActionEventType mouseActionEventType)
        {
            switch (mouseActionEventType)
            {
                case MouseActionEventType.Click:
                    clickRadioButton.Checked = true;
                    break;
                case MouseActionEventType.DoubleClick:
                    doubleClickRadioButton.Checked = true;
                    break;
                case MouseActionEventType.Scroll:
                    scrollRadioButton.Checked = true;
                    break;
                case MouseActionEventType.DragAndDrop:
                    dragAndDropRadioButton.Checked = true;
                    break;
                default:
                    clickRadioButton.Checked = true;
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
            bool isDragAndDrop = dragAndDropRadioButton.Checked;
            bool isScroll = scrollRadioButton.Checked;
            bool isDoubleClick = doubleClickRadioButton.Checked;
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
            DrawArea();
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
            if (selectedCheckBox == startImageCoordCheckBox && selectedCheckBox.Checked)
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

        ActionType IActionPropertiesPanel.GetType()
        {
            return ActionType.MouseAction;
        }

        private void CoordinatesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                DrawArea();
        }

        private void MouseActionPropertiesPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                drawingForm = new DrawingForm();
                drawingForm.Show();
                DrawArea();
            }
            else
            {
                drawingForm?.Close();
                ClearArea();
            }
        }

        private void OverlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overlayCheckBox.Checked)
                DrawArea();
            else
                ClearArea();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
