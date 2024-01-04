using LogFramework;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tao_Bot_Maker.View
{
    public partial class ActionView : Form
    {
        public int ReturnValueActionType { get; set; }
        public Action ReturnValueAction { get; set; }

        DrawingRectangle drawingForm;
        public void DrawRectangleAtCoords(int x1, int y1, int x2, int y2)
        {
            //Draw a rectangle at coordinates
            try
            {
                drawingForm.DrawRectangleAtCoords(x1, y1, x2, y2);
                Log.Write(Log.TRACE, "Rectangle drawn at coords");
                Log.Write(Log.TRACE, "x1 = " + x1 + "; y1 = " + y1 + "; x2 = " + x2 + "; y2 = " + y2);
            }
            catch (ArgumentException e)
            {
                Log.Write(Log.ERROR, "ActionView.cs Line 25");
                Log.Write(Log.ERROR, e.Message);
                Log.Write(Log.ERROR, "x1 = " + x1 + "; y1 = " + y1 + "; x2 = " + x2 + "; y2 = " + y2);
            }
        }
        public void DrawRectangle(int x1, int y1, int width, int height)
        {
            //Draw a rectangle at coordinates
            try
            {
                drawingForm.DrawRectangle(x1, y1, width, height);
                Log.Write(Log.TRACE, "Rectangle drawn");
                Log.Write(Log.TRACE, "x1 = " + x1 + "; y1 = " + y1 + "; width = " + width + "; height = " + height);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
                Log.Write(Log.ERROR, e.Message);
                Log.Write(Log.ERROR, "x1 = " + x1 + "; y1 = " + y1 + "; width = " + width + "; height = " + height);
            }
        }
        public void ClearRectangles()
        {
            drawingForm.ClearRectangles();
            Log.Write(Log.TRACE, "Rectangles cleared");
        }
        public void RefreshRectangles()
        {
            drawingForm.Refresh();
        }
        
        //Get Key Shortcut when form is Focused
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                switch (comboBoxActions.SelectedIndex)
                {
                    case (int)Action.ActionType.PictureWait:
                        //Get Mouse coords
                        ((ActionPictureWaitPanel)actionPanel).X1 = Cursor.Position.X;
                        ((ActionPictureWaitPanel)actionPanel).Y1 = Cursor.Position.Y;
                        //Try to draw a rectangle
                        ((ActionPictureWaitPanel)actionPanel).DrawFromTextBoxValues();
                        break;
                    case (int)Action.ActionType.IfPicture:
                        //Get Mouse coords
                        ((ActionIfPicturePanel)actionPanel).X1 = Cursor.Position.X;
                        ((ActionIfPicturePanel)actionPanel).Y1 = Cursor.Position.Y;
                        //Try to draw a rectangle
                        ((ActionIfPicturePanel)actionPanel).DrawFromTextBoxValues();
                        break;
                    case (int)Action.ActionType.Click:
                        //Get Mouse coords
                        ((ActionClickPanel)actionPanel).X = Cursor.Position.X;
                        ((ActionClickPanel)actionPanel).Y = Cursor.Position.Y;
                        //Try to draw a rectangle
                        ((ActionClickPanel)actionPanel).DrawFromTextBoxValues();
                        break;
                }
            }
            else if (keyData == (Keys.F2))
            {
                switch (comboBoxActions.SelectedIndex)
                {
                    case (int)Action.ActionType.PictureWait:
                        //Get Mouse coords
                        ((ActionPictureWaitPanel)actionPanel).X2 = Cursor.Position.X;
                        ((ActionPictureWaitPanel)actionPanel).Y2 = Cursor.Position.Y;
                        //Try to draw a rectangle
                        ((ActionPictureWaitPanel)actionPanel).DrawFromTextBoxValues();
                        break;
                    case (int)Action.ActionType.IfPicture:
                        //Get Mouse coords
                        ((ActionIfPicturePanel)actionPanel).X2 = Cursor.Position.X;
                        ((ActionIfPicturePanel)actionPanel).Y2 = Cursor.Position.Y;
                        //Try to draw a rectangle
                        ((ActionIfPicturePanel)actionPanel).DrawFromTextBoxValues();
                        break;
                        }
                }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //UserControl of selected action
        Control actionPanel;

        public ActionView()
        {
            InitializeComponent();

            //Create a form to enable drawing
            drawingForm = new DrawingRectangle();
            drawingForm.Show();

            //No panel selected
            actionPanel = null;

            //Populate combobox with actions
            comboBoxActions.Items.AddRange(ActionController.GetActionTypeNames());
            comboBoxActions.SelectedIndex = 0;
        }

        public ActionView(Action action)
        {
            InitializeComponent();

            //Create a form to enable drawing
            drawingForm = new DrawingRectangle();
            drawingForm.Show();

            //Populate combobox with actions
            comboBoxActions.Items.AddRange(ActionController.GetActionTypeNames());
            comboBoxActions.SelectedIndex = action.Type;

            actionPanel = CreatePanelFromAction(action);
            ShowPanel(actionPanel);

        }

        private Control CreatePanelFromAction(Action action)
        {
            switch (action.Type)
            {
                case (int)Action.ActionType.Key:
                    return new ActionKeyPanel(action);
                case (int)Action.ActionType.Wait:
                    return new ActionWaitPanel(action);
                case (int)Action.ActionType.PictureWait:
                    return new ActionPictureWaitPanel(this, action);
                case (int)Action.ActionType.IfPicture:
                    return new ActionIfPicturePanel(this, action);
                case (int)Action.ActionType.Sequence:
                    return new ActionSequencePanel(action);
                case (int)Action.ActionType.Click:
                    return new ActionClickPanel(this, action);
                case (int)Action.ActionType.Loop:
                    return new ActionLoopPanel(action);
                default:
                    return null;
            }
        }

        private void ShowPanel(Control panel)
        {
            if (panel != null)
            {
                panelSelectedAction.Controls.Clear();
                panelSelectedAction.Controls.Add(panel);
                panel.Show();
            }
        }

        private void comboBoxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Show panel of the selected action
            ClearRectangles();
            RefreshRectangles();
            actionPanel = ActionController.GetControlView(comboBoxActions.SelectedIndex, this);
            ShowPanel(actionPanel);
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            //Test if the inputs are valid
            ReturnValueAction = ActionController.GetActionFromControl(comboBoxActions.SelectedIndex, actionPanel);
            if(ReturnValueAction != null)
            {
                //Send results to the controller

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                //Prevent closing
                this.DialogResult = DialogResult.None;
            }
        }

        private void ActionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            drawingForm.Close();
        }
    }
}
