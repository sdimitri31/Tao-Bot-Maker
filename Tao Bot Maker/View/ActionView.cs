using BlueMystic;
using LogFramework;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Tao_Bot_Maker.Action;
using Log = Tao_Bot_Maker.Controller.Log;

namespace Tao_Bot_Maker.View
{
    public partial class ActionView : Form
    {
        public int ReturnValueActionType { get; set; }
        public Action ReturnValueAction { get; set; }

        private MainApp app;
        private HotKeyController hotkeyXY;
        private HotKeyController hotkeyXY2;
        private Control actionPanel; //Action panel shown

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
                Log.Write(e.Message, LogFramework.Log.ERROR);
                Log.Write("x1 = " + x1 + "; y1 = " + y1 + "; x2 = " + x2 + "; y2 = " + y2, LogFramework.Log.ERROR);
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
                Log.Write(e.Message, LogFramework.Log.ERROR);
                Log.Write("x1 = " + x1 + "; y1 = " + y1 + "; width = " + width + "; height = " + height, LogFramework.Log.ERROR);
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
            flatComboBox_Actions.Items.AddRange(ActionController.GetActionItems());

            //No panel selected
            if (action == null)
            {
                Log.Write(Properties.strings.log_ActionView_AddMode, LogFramework.Log.TRACE);
                actionPanel = null;
                flatComboBox_Actions.SelectedIndex = 0;
            }
            else
            {
                Log.Write(Properties.strings.log_ActionView_EditMode, LogFramework.Log.TRACE);
                //Get index to select from type name
                int selectedIndex = flatComboBox_Actions.FindStringExact(ActionController.GetTypeName(action.Type));
                
                //If no result, probably a deprecated type is being edited
                if (selectedIndex < 0) selectedIndex = 0;

                flatComboBox_Actions.SelectedIndex = selectedIndex;
                actionPanel = ActionController.CreatePanelFromAction(action, this);
                ShowPanel(actionPanel);
            }

            SetupHotkeys();
        }


        private void Localization()
        {
            button_Cancel.Text = Properties.strings.button_Cancel;
            button_Ok.Text = Properties.strings.button_OK;
            Text = Properties.strings.title_NewActionDialog;
            
            Log.Write(Properties.strings.log_LocalizationUpdated, LogFramework.Log.TRACE);
        }

        private void SetupHotkeys()
        {
            hotkeyXY = new HotKeyController(SettingsController.GetHotkeyModifierXY(), SettingsController.GetHotkeyKeyXY(), this);
            hotkeyXY.Register();

            hotkeyXY2 = new HotKeyController(SettingsController.GetHotkeyModifierXY2(), SettingsController.GetHotkeyKeyXY2(), this);
            hotkeyXY2.Register();
        }

        private void ShowPanel(Control panel)
        {
            if (panel != null)
            {
                panel_SelectedAction.Controls.Clear();
                panel_SelectedAction.Controls.Add(panel);
                panel.Show();
                Log.Write(Properties.strings.log_ActionView_SelectedPanel + panel.Name, LogFramework.Log.TRACE);
            }
        }

        private void Button_Ok_Click(object sender, EventArgs e)
        {
            //Test if the inputs are valid
            ReturnValueAction = ActionController.GetActionFromControl((int)(flatComboBox_Actions.SelectedItem as ComboboxItemActionType).ActionTypeId, actionPanel);
            if(ReturnValueAction != null)
            {
                //Send results to the controller
                Log.Write(Properties.strings.log_DialogResult_Ok, LogFramework.Log.TRACE);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                //Prevent closing
                Log.Write(Properties.strings.log_DialogResult_None, LogFramework.Log.TRACE);
                this.DialogResult = DialogResult.None;
            }
        }

        private void ActionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            drawingForm.Close();
            hotkeyXY.Unregiser();
            hotkeyXY2.Unregiser();
            Log.Write(Properties.strings.log_ActionView_Closed, LogFramework.Log.TRACE);
        }

        private void FlatComboBox_Actions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Show panel of the selected action
            ClearRectangles();
            RefreshRectangles();
            actionPanel = ActionController.GetControlView((int)(flatComboBox_Actions.SelectedItem as ComboboxItemActionType).ActionTypeId, this);
            Size = new System.Drawing.Size(Size.Width, actionPanel.Size.Height + 133);
            ShowPanel(actionPanel);
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
                    switch ((int)(flatComboBox_Actions.SelectedItem as ComboboxItemActionType).ActionTypeId)
                    {
                        case (int)Action.ActionType.ImageSearch:
                            //Get Mouse coords
                            ((ActionImageSearchPanel)actionPanel).X1 = Cursor.Position.X;
                            ((ActionImageSearchPanel)actionPanel).Y1 = Cursor.Position.Y;
                            //Try to draw a rectangle
                            ((ActionImageSearchPanel)actionPanel).DrawFromTextBoxValues();
                            break;
                        case (int)Action.ActionType.Click:
                            //Send info hotkeyXY2 has been pressed
                            ((panel_ActionClick)actionPanel).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
                else if ((modifier == hotkeyXY2.GetModifier()) && (key == hotkeyXY2.GetKey()))
                {
                    switch ((int)(flatComboBox_Actions.SelectedItem as ComboboxItemActionType).ActionTypeId)
                    {
                        case (int)Action.ActionType.ImageSearch:
                            //Get Mouse coords
                            ((ActionImageSearchPanel)actionPanel).X2 = Cursor.Position.X;
                            ((ActionImageSearchPanel)actionPanel).Y2 = Cursor.Position.Y;
                            //Try to draw a rectangle
                            ((ActionImageSearchPanel)actionPanel).DrawFromTextBoxValues();
                            break;

                        case (int)Action.ActionType.Click:
                            //Send info hotkeyXY2 has been pressed
                            ((panel_ActionClick)actionPanel).HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
            }
        }

    }
}
