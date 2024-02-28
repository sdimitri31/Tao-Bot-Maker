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
    public partial class ActionClickPanel : UserControl
    {
        ActionView actionView;
        public ActionClickPanel(ActionView actionView)
        {
            InitializeComponent(); 
            Localization();
            AddHotkeysToLabels();
            this.actionView = actionView;
        }
        public ActionClickPanel(ActionView actionView, Action action)
        {
            InitializeComponent();
            Localization();
            AddHotkeysToLabels();
            this.actionView = actionView;
            SelectedClick = ((ActionClick)action).SelectedClick;
            X = ((ActionClick)action).X;
            Y = ((ActionClick)action).Y;
        }
        private void Localization()
        {
            radioButtonPanelActionMouseClick_left.Text = Properties.strings.label_LeftClick;
            radioButtonPanelActionMouseClick_right.Text = Properties.strings.label_RightClick;
            buttonPanelActionMouseClick_ShowZone.Text = Properties.strings.button_ShowDrawingArea;
            buttonPanelActionMouseClick_ClearZone.Text = Properties.strings.button_ClearZone;
        }
        private void AddHotkeysToLabels()
        {
            int modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY()) << 16;
            Keys hotkeyXY = (Keys)((int)SettingsController.GetHotkeyKeyXY() | modifier);
            label_X.Text += " (" + hotkeyXY.ToString() + ")";
            label_Y.Text += " (" + hotkeyXY.ToString() + ")";
        }
        public String SelectedClick
        {
            get
            {
                try
                {
                    if (radioButtonPanelActionMouseClick_left.Checked)
                        return "Left";
                    else
                        return "Right";
                }
                catch
                {
                    return null;
                }
            }
            set 
            {
                if (value.ToString() == "Left")
                    radioButtonPanelActionMouseClick_left.Checked = true;
                else
                    radioButtonPanelActionMouseClick_right.Checked = true;
            }
        }
        public int X
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxPanelActionMouseClick_X.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxPanelActionMouseClick_X.Text = value.ToString(); }
        }

        public int Y
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxPanelActionMouseClick_Y.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxPanelActionMouseClick_Y.Text = value.ToString(); }
        }

        public void DrawFromTextBoxValues()
        {
            actionView.ClearRectangles();
            actionView.DrawRectangleAtCoords(X - 5, Y - 5, X + 5, Y + 5);
            actionView.RefreshRectangles();
        }

        private void buttonPanelActionMouseClick_ShowZone_Click(object sender, EventArgs e)
        {
            DrawFromTextBoxValues();
        }

        private void buttonPanelActionMouseClick_ClearZone_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
            actionView.RefreshRectangles();
        }
    }
}
