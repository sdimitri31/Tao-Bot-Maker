using BlueMystic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using Log = Tao_Bot_Maker.Controller.Log;

namespace Tao_Bot_Maker.View
{
    public partial class ActionView : Form
    {
        public Action ReturnValueAction { get; set; }

        private MainApp app;
        private HotKeyController hotkeyXY;
        private HotKeyController hotkeyXY2;
        private List<Control> panelList;

        readonly DrawingRectangle drawingForm;

        /// <summary>
        /// Draw a rectangle from top left angle
        /// </summary>
        /// <param name="x1">Top left coord X</param>
        /// <param name="y1">Top left coord Y</param>
        /// <param name="width">Width : must be greater than 0</param>
        /// <param name="height">Height : must be greater than 0</param>
        /// <returns>true if drawing success. false if there is an error in parameters</returns>
        public bool DrawRectangle(int x1, int y1, int width, int height, KnownColor color = KnownColor.Red)
        {
            try
            {
                drawingForm.DrawRectangle(x1, y1, width, height, color);
                return true;
            }
            catch
            {

            }
            return false;
        }
        
        public void ClearRectangles()
        {
            drawingForm.ClearRectangles();
        }

        public ActionView(MainApp app, Action action = null)
        {
            InitializeComponent();
            this.app = app;

            //Create a form to enable drawing
            drawingForm = new DrawingRectangle();
            drawingForm.Show();

            //Load all panels to prevent flickering
            LoadPanels(action);

            DarkModeCS DM = new DarkModeCS(this, SettingsController.GetTheme(), false);

            Localization();

            //Populate listBox with actions names
            listBox_Actions.Items.AddRange(ActionController.GetActionItems());

            //No panel selected
            if (action == null)
            {
                Log.Write(Properties.strings.log_ActionView_AddMode, Log.TRACE);
                listBox_Actions.SelectedIndex = 0;
            }
            else
            {
                Log.Write(Properties.strings.log_ActionView_EditMode, Log.TRACE);
                //Get index to select from type name
                int selectedIndex = listBox_Actions.FindStringExact(ActionController.GetTypeName(action.Type));

                //If no result, probably a deprecated type is being edited
                if (selectedIndex < 0) selectedIndex = 0;

                listBox_Actions.SelectedIndex = selectedIndex;
            }

            ShowPanel(listBox_Actions.SelectedIndex);

            SetupHotkeys();
        }

        public string GetLoadedSequenceName()
        {
            return app.LoadedSequenceName;
        }

        private void Localization()
        {
            button_Cancel.Text = Properties.strings.button_Cancel;
            button_Ok.Text = Properties.strings.button_OK;
            Text = Properties.strings.title_NewActionDialog;
            
            Log.Write(Properties.strings.log_LocalizationUpdated, Log.TRACE);
        }

        private void SetupHotkeys()
        {
            hotkeyXY = new HotKeyController(SettingsController.GetHotkeyModifierXY(), SettingsController.GetHotkeyKeyXY(), this);
            hotkeyXY.Register();

            hotkeyXY2 = new HotKeyController(SettingsController.GetHotkeyModifierXY2(), SettingsController.GetHotkeyKeyXY2(), this);
            hotkeyXY2.Register();
        }

        private void LoadPanels(Action action = null)
        {
            panelList = new List<Control>();

            foreach (int actionType in Enum.GetValues(typeof(Action.ActionType)))
            {
                Control panel;

                if ((action != null) && (action.Type == actionType))
                    panel = ActionController.CreatePanel(actionType, this, action);
                else
                    panel = ActionController.CreatePanel(actionType, this);
                if(panel != null)
                {
                    panel.Visible = false;
                    panelList.Add(panel);
                }
            }
            panel_SelectedAction.Controls.AddRange(panelList.ToArray());
        }

        void HidePanel(Control panel)
        {
            panel.Visible = false;
        }

        private void ShowPanel(int selectedIndex = 0)
        {
            panelList.ForEach(HidePanel);
            panelList[selectedIndex].Visible = true;

            Log.Write(Properties.strings.log_ActionView_SelectedPanel + panelList[selectedIndex].Name, Log.TRACE);
        }

        private void Button_Ok_Click(object sender, EventArgs e)
        {
            //Test if the inputs are valid
            Action action = ActionController.GetActionFromControl((int)(listBox_Actions.SelectedItem as ComboboxItemActionType).ActionTypeId, panelList[listBox_Actions.SelectedIndex]);
            
            //if valid action has been created
            if(string.IsNullOrEmpty(action.ErrorMessage))
            {
                //Send results to the controller
                ReturnValueAction = action;
                Log.Write(Properties.strings.log_DialogResult_Ok, Log.TRACE);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Prevent closing
                MessageBox.Show(action.ErrorMessage);
                ReturnValueAction = null;
                Log.Write(Properties.strings.log_DialogResult_None, Log.TRACE);
                this.DialogResult = DialogResult.None;
            }
        }

        private void ActionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            drawingForm.Close();
            hotkeyXY.Unregiser();
            hotkeyXY2.Unregiser();
            Log.Write(Properties.strings.log_ActionView_Closed, Log.TRACE);
        }

        private void FlatComboBox_Actions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Show panel of the selected action
            ClearRectangles();
            ShowPanel(listBox_Actions.SelectedIndex);
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
                    switch ((int)(listBox_Actions.SelectedItem as ComboboxItemActionType).ActionTypeId)
                    {
                        case (int)Action.ActionType.ImageSearch:
                            //Send info hotkeyXY has been pressed
                            ((ActionImageSearchPanel)panelList[listBox_Actions.SelectedIndex]).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                        case (int)Action.ActionType.Click:
                            //Send info hotkeyXY has been pressed
                            ((ActionClickPanel)panelList[listBox_Actions.SelectedIndex]).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
                else if ((modifier == hotkeyXY2.GetModifier()) && (key == hotkeyXY2.GetKey()))
                {
                    switch ((int)(listBox_Actions.SelectedItem as ComboboxItemActionType).ActionTypeId)
                    {
                        case (int)Action.ActionType.ImageSearch:
                            //Send info hotkeyXY2 has been pressed
                            ((ActionImageSearchPanel)panelList[listBox_Actions.SelectedIndex]).HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;

                        case (int)Action.ActionType.Click:
                            //Send info hotkeyXY2 has been pressed
                            ((ActionClickPanel)panelList[listBox_Actions.SelectedIndex]).HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
            }
        }

    }
}
