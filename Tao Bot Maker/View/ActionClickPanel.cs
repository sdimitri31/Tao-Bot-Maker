using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tao_Bot_Maker.View
{
    public partial class ActionClickPanel : UserControl
    {
        ActionView actionView;
        public ActionClickPanel(ActionView actionView)
        {
            InitializeComponent();
            this.actionView = actionView;
        }
        public ActionClickPanel(ActionView actionView, Action action)
        {
            InitializeComponent();
            this.actionView = actionView;
            SelectedClick = ((ActionClick)action).SelectedClick;
            X = ((ActionClick)action).X;
            Y = ((ActionClick)action).Y;
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
        private void buttonPanelActionMouseClick_ShowZone_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
            try
            {
                actionView.DrawRectangle(
                    Int32.Parse(textBoxPanelActionMouseClick_X.Text) - 5,
                    Int32.Parse(textBoxPanelActionMouseClick_Y.Text) - 5,
                    (Int32.Parse(textBoxPanelActionMouseClick_X.Text) + 10) - (Int32.Parse(textBoxPanelActionMouseClick_X.Text)),
                    (Int32.Parse(textBoxPanelActionMouseClick_Y.Text) + 10) - (Int32.Parse(textBoxPanelActionMouseClick_Y.Text)));
            }
            catch { }
            actionView.RefreshRectangles();
        }
    }
}
