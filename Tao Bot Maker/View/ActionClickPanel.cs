using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class ActionClickPanel : UserControl
    {
        readonly ActionView actionView;

        public ActionClickPanel(ActionView actionView, Action action = null)
        {
            InitializeComponent();
            this.Visible = false;

            Localization();
            AddHotkeysToLabels();
            UpdateButtonState();
            this.actionView = actionView;

            //Not null = Editing existing action
            if (action != null)
            {
                SelectedClick = ((ActionClick)action).SelectedClick;
                X1 = ((ActionClick)action).X1;
                Y1 = ((ActionClick)action).Y1;
                X2 = ((ActionClick)action).X2;
                Y2 = ((ActionClick)action).Y2;
                IsDoubleClick = ((ActionClick)action).IsDoubleClick;
                IsDrag = ((ActionClick)action).IsDrag;
                DragSpeed = ((ActionClick)action).DragSpeed;
                IsCurrentPosClick = ((ActionClick)action).IsCurrentPosClick;
                UpdateButtonStateCurrentPosClick();
                UpdateButtonStateDrag();
                UpdateButtonStateDoubleClick();
            }
            UpdateLabelsColor();

            //UpdateButtonState();
        }

        //----------------------------------------------
        // Public
        //


        public string SelectedClick
        {
            get
            {
                try
                {
                    if (radioButton_LeftClick.Checked)
                        return "left";
                    else if(radioButton_RightClick.Checked)
                        return "right";
                    else if (radioButton_MiddleClick.Checked)
                        return "middle";
                    else if (radioButton_MoveClick.Checked)
                        return "move";
                    return null;
                }
                catch
                {
                    return null;
                }
            }
            set 
            {
                switch (value.ToString().ToLower())
                {
                    case "left":
                        radioButton_LeftClick.Checked = true; break;
                    case "right":
                        radioButton_RightClick.Checked = true; break;
                    case "middle":
                        radioButton_MiddleClick.Checked = true; break;
                    case "move":
                        radioButton_MoveClick.Checked = true; break;
                    default:
                        radioButton_LeftClick.Checked = true; break;
                }
            }
        }

        public int X1
        {
            get => (int)numericUpDown_X1.Value;
            set => numericUpDown_X1.Value = value;
        }
        
        public int X2
        {
            get => (int)numericUpDown_X2.Value;
            set => numericUpDown_X2.Value = value;
        }
        
        public int Y1
        {
            get => (int)numericUpDown_Y1.Value;
            set => numericUpDown_Y1.Value = value;
        }
        
        public int Y2
        {
            get => (int)numericUpDown_Y2.Value;
            set => numericUpDown_Y2.Value = value;
        }

        public bool IsDoubleClick
        {
            get { return checkBox_DoubleClick.Checked; }
            set { checkBox_DoubleClick.Checked = value; }
        }

        public bool IsDrag
        {
            get { return checkBox_Drag.Checked; }
            set { checkBox_Drag.Checked = value; }
        }

        public int DragSpeed
        {
            get { return trackBar_DragSpeed.Value; }
            set { trackBar_DragSpeed.Value = value; }
        }

        public bool IsCurrentPosClick
        {
            get { return checkBox_CurrentPosClick.Checked; }
            set { checkBox_CurrentPosClick.Checked = value; }
        }

        /// <summary>
        /// Assign values in numboxX1 and numboxY1
        /// </summary>
        /// <param name="x">Value for X1</param>
        /// <param name="y">Value for Y1</param>
        public void HotkeyXY(int x, int y)
        {
            X1 = x;
            Y1 = y;
            DrawArea();
        }

        /// <summary>
        /// Assign values in numboxX2 and numboxY2
        /// </summary>
        /// <param name="x">Value for X2</param>
        /// <param name="y">Value for Y2</param>
        public void HotkeyXY2(int x, int y)
        {
            if(IsDrag)
            {
                X2 = x; 
                Y2 = y;
                DrawArea();
            }
        }

        /// <summary>
        /// Draw rectangles from coords using values X1, Y1, X2 and Y2
        /// </summary>
        public void DrawArea()
        {
            ClearArea();
            if(!IsCurrentPosClick)
                actionView.DrawRectangle(X1 - 5, Y1 - 5, 10, 10, Constants.COLOR_LABEL_XY);
            if (IsDrag)
                actionView.DrawRectangle(X2 - 5, Y2 - 5, 10, 10, Constants.COLOR_LABEL_XY2);
        }

        public void ClearArea()
        {
            actionView.ClearRectangles();
        }

        //----------------------------------------------
        // Private 
        //

        private void Localization()
        {
            label_ClickCurrentPos.Text = Properties.strings.label_CurrentPosClick;
            label_MoveClick.Text = Properties.strings.label_MoveClick;
            label_Drag.Text = Properties.strings.label_Drag;
            label_DragSpeed.Text = Properties.strings.label_DragSpeed;
            label_LeftClick.Text = Properties.strings.label_LeftClick;
            label_MiddleClick.Text = Properties.strings.label_MiddleClick;
            label_RightClick.Text = Properties.strings.label_RightClick;
            button_ShowArea.Text = Properties.strings.button_ShowDrawingArea;
            button_ClearArea.Text = Properties.strings.button_ClearArea;
        }

        private void AddHotkeysToLabels()
        {
            string hotkeyXY = Utils.GetFormatedKeysString((Keys)((int)SettingsController.GetHotkeyXY()));
            label_X1.Text += " (" + hotkeyXY + ")";
            label_Y1.Text += " (" + hotkeyXY + ")";

            string hotkeyXY2 = Utils.GetFormatedKeysString((Keys)((int)SettingsController.GetHotkeyXY2()));
            label_X2.Text += " (" + hotkeyXY2 + ")";
            label_Y2.Text += " (" + hotkeyXY2 + ")";
        }

        private void UpdateLabelsColor()
        {
            label_X1.ForeColor = Color.FromKnownColor(Constants.COLOR_LABEL_XY);
            label_Y1.ForeColor = Color.FromKnownColor(Constants.COLOR_LABEL_XY);

            label_X2.Enabled = false;
            label_Y2.Enabled = false;

            if (IsDrag)
            {
                label_X2.Enabled = true;
                label_Y2.Enabled = true;
                label_X2.ForeColor = Color.FromKnownColor(Constants.COLOR_LABEL_XY2);
                label_Y2.ForeColor = Color.FromKnownColor(Constants.COLOR_LABEL_XY2);
            }
        }

        private void UpdateButtonState()
        {
            label_DragSpeed.Enabled = false;
            trackBar_DragSpeed.Enabled = false;

            label_X2.Enabled = false;
            numericUpDown_X2.Enabled = false;

            label_Y2.Enabled = false;
            numericUpDown_Y2.Enabled = false;

            label_LeftClick.Enabled = true;
            radioButton_LeftClick.Enabled = true;

            label_MiddleClick.Enabled = true;
            radioButton_MiddleClick.Enabled = true;

            label_RightClick.Enabled = true;
            radioButton_RightClick.Enabled = true;

            label_MoveClick.Enabled = true;
            radioButton_MoveClick.Enabled = true;

        }

        
        private void UpdateButtonStateCurrentPosClick()
        {
            if (IsCurrentPosClick)
            {
                label_X1.Enabled = false;
                numericUpDown_X1.Enabled = false;

                label_Y1.Enabled = false;
                numericUpDown_Y1.Enabled = false;

                label_LeftClick.Enabled = true;
                radioButton_LeftClick.Enabled = true;

                label_MiddleClick.Enabled = true;
                radioButton_MiddleClick.Enabled = true;

                label_RightClick.Enabled = true;
                radioButton_RightClick.Enabled = true;

                label_MoveClick.Enabled = false;
                radioButton_MoveClick.Enabled = false;

                //Not possible to select moveclick
                if ((radioButton_MoveClick.Checked) && !IsDrag)
                    //Changing selection to left click
                    radioButton_LeftClick.Checked = true;
            }
            else if (IsDoubleClick)
            {
                label_MoveClick.Enabled = false;
                radioButton_MoveClick.Enabled = false;
            }
            else
            {
                label_X1.Enabled = true;
                numericUpDown_X1.Enabled = true;

                label_Y1.Enabled = true;
                numericUpDown_Y1.Enabled = true;

                label_MoveClick.Enabled = true;
                radioButton_MoveClick.Enabled = true;
            }
        }

        private void UpdateButtonStateDoubleClick()
        {
            if (IsDoubleClick)
            {
                IsDrag = false;

                label_DragSpeed.Enabled = false;
                trackBar_DragSpeed.Enabled = false;

                label_X2.Enabled = false;
                numericUpDown_X2.Enabled = false;

                label_Y2.Enabled = false;
                numericUpDown_Y2.Enabled = false;

                label_MoveClick.Enabled = false;
                radioButton_MoveClick.Enabled = false;

                //Not possible to select moveclick
                if (radioButton_MoveClick.Checked)
                    //Changing selection to left click
                    radioButton_LeftClick.Checked = true;
            }
        }

        private void UpdateButtonStateDrag()
        {
            if(IsDrag)
            {
                IsDoubleClick = false;

                label_DragSpeed.Enabled = true;
                trackBar_DragSpeed.Enabled = true;

                label_X2.Enabled = true;
                numericUpDown_X2.Enabled = true;

                label_Y2.Enabled = true;
                numericUpDown_Y2.Enabled = true;

                label_MoveClick.Enabled = true;
                radioButton_MoveClick.Enabled = true;
            }
            else if (IsCurrentPosClick)
            {
                label_MoveClick.Enabled = false;
                radioButton_MoveClick.Enabled = false;
            }

            if (!IsDrag)
            {
                //Not possible to select moveclick
                if ((radioButton_MoveClick.Checked) && (IsCurrentPosClick))
                    //Changing selection to left click
                    radioButton_LeftClick.Checked = true;
            }
            UpdateLabelsColor();
            DrawArea();
        }

        //----------------------------------------------
        // EVENTS

        private void Button_ShowArea_Click(object sender, EventArgs e)
        {
            DrawArea();
        }

        private void Button_ClearArea_Click(object sender, EventArgs e)
        {
            ClearArea();
        }

        private void CheckBox_DoubleClick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
            UpdateButtonStateDoubleClick();
            UpdateButtonStateCurrentPosClick();
        }

        private void CheckBox_Drag_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
            UpdateButtonStateDrag();
        }

        private void CheckBox_ClickCurrentPos_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
            UpdateButtonStateCurrentPosClick();
            UpdateButtonStateDrag();
        }
       
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                DrawArea();
        }

        private void ActionClickPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                DrawArea();
                UpdateLabelsColor();
            }
        }
    }
}
