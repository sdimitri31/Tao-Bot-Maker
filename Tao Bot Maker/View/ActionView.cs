using BlueMystic;
using LogFramework;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;

namespace Tao_Bot_Maker.View
{
    public partial class ActionView : Form
    {
        public int ReturnValueActionType { get; set; }
        public Action ReturnValueAction { get; set; }

        private MainApp app;
        private HotKeyController hotkeyXY;
        private HotKeyController hotkeyXY2;

        public void Log(int level, String message)
        {
            app.Log(message, level);
        }

        DrawingRectangle drawingForm;
        public void DrawRectangleAtCoords(int x1, int y1, int x2, int y2)
        {
            //Draw a rectangle at coordinates
            try
            {
                drawingForm.DrawRectangleAtCoords(x1, y1, x2, y2);
                //app.Log("Rectangle drawn at coords", LogFramework.Log.TRACE);
                //app.Log("x1 = " + x1 + "; y1 = " + y1 + "; x2 = " + x2 + "; y2 = " + y2, LogFramework.Log.TRACE);
            }
            catch (ArgumentException e)
            {
                //app.Log(e.Message, LogFramework.Log.ERROR);
                //app.Log("x1 = " + x1 + "; y1 = " + y1 + "; x2 = " + x2 + "; y2 = " + y2, LogFramework.Log.ERROR);
            }
        }
        public void DrawRectangle(int x1, int y1, int width, int height)
        {
            //Draw a rectangle at coordinates
            try
            {
                drawingForm.DrawRectangle(x1, y1, width, height);
                //app.Log("Rectangle drawn", LogFramework.Log.TRACE);
                //app.Log("x1 = " + x1 + "; y1 = " + y1 + "; width = " + width + "; height = " + height, LogFramework.Log.TRACE);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
                //app.Log(e.Message, LogFramework.Log.ERROR);
                //app.Log("x1 = " + x1 + "; y1 = " + y1 + "; width = " + width + "; height = " + height, LogFramework.Log.ERROR);
            }
        }
        public void ClearRectangles()
        {
            drawingForm.ClearRectangles();
            //app.Log("Rectangles cleared", LogFramework.Log.TRACE);
        }
        public void RefreshRectangles()
        {
            drawingForm.Refresh();
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                int modifier = ((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.


                if ((modifier == hotkeyXY.GetModifier()) && (key == hotkeyXY.GetKey()))
                {
                    switch (flatComboBoxActions.SelectedIndex)
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
                else if ((modifier == hotkeyXY2.GetModifier()) && (key == hotkeyXY2.GetKey()))
                {
                    switch (flatComboBoxActions.SelectedIndex)
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
            }
        }

        Control actionPanel;

        public ActionView(MainApp app, Action action = null)
        {
            InitializeComponent();
            DarkModeCS DM = new DarkModeCS(this, SettingsController.GetTheme(), false);
            this.app = app;

            //Create a form to enable drawing
            drawingForm = new DrawingRectangle();
            drawingForm.Show();

            Localization();

            //Populate combobox with actions
            flatComboBoxActions.Items.AddRange(ActionController.GetActionTypeNames());

            //No panel selected
            if (action == null)
            {
                actionPanel = null;
                flatComboBoxActions.SelectedIndex = 0;
            }
            else
            {
                flatComboBoxActions.SelectedIndex = action.Type;
                actionPanel = CreatePanelFromAction(action);
                ShowPanel(actionPanel);
            }

            SetupHotkeys();
        }


        private void Localization()
        {
            button_Cancel.Text = Properties.strings.button_Cancel;
            button_Ok.Text = Properties.strings.button_OK;
            Text = Properties.strings.title_NewActionDialog;
        }

        private void SetupHotkeys()
        {
            hotkeyXY = new HotKeyController(SettingsController.GetHotkeyModifierXY(), SettingsController.GetHotkeyKeyXY(), this);
            hotkeyXY.Register();

            hotkeyXY2 = new HotKeyController(SettingsController.GetHotkeyModifierXY2(), SettingsController.GetHotkeyKeyXY2(), this);
            hotkeyXY2.Register();
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

        private void button_Ok_Click(object sender, EventArgs e)
        {
            //Test if the inputs are valid
            ReturnValueAction = ActionController.GetActionFromControl(flatComboBoxActions.SelectedIndex, actionPanel);
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
            hotkeyXY.Unregiser();
            hotkeyXY2.Unregiser();
        }

        private void flatComboBoxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Show panel of the selected action
            ClearRectangles();
            RefreshRectangles();
            actionPanel = ActionController.GetControlView(flatComboBoxActions.SelectedIndex, this);
            Size = new System.Drawing.Size(Size.Width, actionPanel.Size.Height + 133);
            ShowPanel(actionPanel);
        }
    }
}
