using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;

namespace Tao_Bot_Maker.View
{
    public partial class panel_ActionClick : UserControl
    {
        ActionView actionView;

        public panel_ActionClick(ActionView actionView, Action action = null)
        {
            InitializeComponent();
            Localization();
            AddHotkeysToLabels();
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
            }
            UpdateButtonState();
        }
        private void Localization()
        {
            label_Drag.Text = Properties.strings.label_Drag;
            label_DragSpeed.Text = Properties.strings.label_DragSpeed;
            label_LeftClick.Text = Properties.strings.label_LeftClick;
            label_MiddleClick.Text = Properties.strings.label_MiddleClick;
            label_RightClick.Text = Properties.strings.label_RightClick;
            button_ShowArea.Text = Properties.strings.button_ShowDrawingArea;
            button_ClearArea.Text = Properties.strings.button_ClearArea;
        }
        public String SelectedClick
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
                    default:
                        radioButton_LeftClick.Checked = true; break;
                }
            }
        }
        public bool IsDoubleClick
        {
            get { return checkBox_DoubleClick.Checked; }
            set { checkBox_DoubleClick.Checked = value; }
        }
        public int X1
        {
            get { return ((int)numericUpDown_X1.Value); }
            set { numericUpDown_X1.Value = value; }
        }
        public int Y1
        {
            get { return ((int)numericUpDown_Y1.Value); }
            set { numericUpDown_Y1.Value = value; }
        }
        public int X2
        {
            get { return ((int)numericUpDown_X2.Value); }
            set { numericUpDown_X2.Value = value; }
        }
        public int Y2
        {
            get { return ((int)numericUpDown_Y2.Value); }
            set { numericUpDown_Y2.Value = value; }
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
        private void AddHotkeysToLabels()
        {
            int modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY()) << 16;
            Keys hotkeyXY = (Keys)((int)SettingsController.GetHotkeyKeyXY() | modifier);
            label_X1.Text += " (" + hotkeyXY.ToString() + ")";
            label_Y1.Text += " (" + hotkeyXY.ToString() + ")";

            modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY2()) << 16;
            Keys hotkeyXY2 = (Keys)((int)SettingsController.GetHotkeyKeyXY2() | modifier);
            label_X2.Text += " (" + hotkeyXY2.ToString() + ")";
            label_Y2.Text += " (" + hotkeyXY2.ToString() + ")";
        }
        public void HotkeyXY(int x, int y)
        {
            X1 = x;
            Y1 = y;
            DrawFromTextBoxValues();
        }

        public void HotkeyXY2(int x, int y)
        {
            if(IsDrag)
            {
                X2 = x; 
                Y2 = y;
                DrawFromTextBoxValues();
            }
        }

        private void UpdateButtonState()
        {
            trackBar_DragSpeed.Enabled = false;
            numericUpDown_X2.Enabled = false;
            numericUpDown_Y2.Enabled = false;
        }
        private void UpdateButtonStateDoubleClick()
        {
            if (IsDoubleClick)
            {
                IsDrag = false;
                trackBar_DragSpeed.Enabled = false;
                numericUpDown_X2.Enabled = false;
                numericUpDown_Y2.Enabled = false;
            }
        }
        private void UpdateButtonStateDrag()
        {
            if(IsDrag)
            {
                IsDoubleClick = false;
                trackBar_DragSpeed.Enabled = true;
                numericUpDown_X2.Enabled = true;
                numericUpDown_Y2.Enabled = true;
            }
            DrawFromTextBoxValues();
        }


        public void DrawFromTextBoxValues()
        {
            actionView.ClearRectangles();
            actionView.DrawRectangleAtCoords(X1 - 5, Y1 - 5, X1 + 5, Y1 + 5);
            if(IsDrag)
                actionView.DrawRectangleAtCoords(X2 - 5, Y2 - 5, X2 + 5, Y2 + 5);
            actionView.RefreshRectangles();
        }

        private void Button_ShowArea_Click(object sender, EventArgs e)
        {
            DrawFromTextBoxValues();
        }

        private void Button_ClearArea_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
            actionView.RefreshRectangles();
        }

        private void checkBox_DoubleClick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
            UpdateButtonStateDoubleClick();
        }

        private void checkBox_Drag_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
            UpdateButtonStateDrag();
        }
    }
}
