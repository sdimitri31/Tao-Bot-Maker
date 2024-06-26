using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class AddActionForm : Form
    {
        public ActionTypes SelectedActionType { get; set; }
        public Action Action { get; set; }


        private HotKeyController hotkeyXY;
        private HotKeyController hotkeyXY2;

        public AddActionForm()
        {
            InitializeComponent();
            FillActionTypeListBox();
            SetupHotkeys();
        }
        private void SetupHotkeys()
        {
            hotkeyXY = new HotKeyController(Keys.F1, this);
            hotkeyXY.Register();

            hotkeyXY2 = new HotKeyController(Keys.F2, this);
            hotkeyXY2.Register();
        }

        private void SetPropertiesPanel(ActionTypes actionType)
        {
            actionPropertiesPanel.Controls.Clear();

            UserControl panel = null;

            switch (actionType)
            {
                case ActionTypes.MouseAction:
                    panel = new MouseActionPropertiesPanel();
                    break;
                case ActionTypes.TextAction:
                    panel = new TextActionPropertiesPanel();
                    break;
                case ActionTypes.WaitAction:
                    panel = new WaitActionPropertiesPanel();
                    break;
                case ActionTypes.SequenceAction:
                    panel = new SequenceActionPropertiesPanel();
                    break;
                case ActionTypes.KeyAction:
                    panel = new KeyActionPropertiesPanel();
                    break;
                case ActionTypes.ImageAction:
                    panel = new ImageActionPropertiesPanel();
                    break;
                // Ajoutez des cas pour d'autres types d'actions selon votre structure
                default:
                    break;
            }

            if (panel != null)
            {
                actionPropertiesPanel.Controls.Add(panel);
            }
        }
        
        private void FillActionTypeListBox()
        {
            foreach (ActionTypes actionType in Enum.GetValues(typeof(ActionTypes)))
            {
                actionTypelistBox.Items.Add(actionType);
            }
        }

        private void ActionTypeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedActionType = (ActionTypes)actionTypelistBox.SelectedIndex;
            SetPropertiesPanel(SelectedActionType);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var panel = actionPropertiesPanel.Controls[0] as IActionPropertiesPanel;
            if (panel != null)
            {
                Action = panel.GetAction();
                DialogResult = DialogResult.OK;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                //Keys pressedKey = (Keys)(int)m.LParam;

                Keys pressedKey = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                Keys pressedModifier = (Keys)HotKeyController.Reverse3Bits(((int)m.LParam & 0xFFFF));

                //Converting to same format as regular Keys
                Keys pressedHotkey = (Keys)(((int)pressedModifier << 16) | (int)pressedKey);

                if (pressedHotkey == hotkeyXY.GetKey())
                {
                    switch (SelectedActionType)
                    {
                        case ActionTypes.MouseAction:
                            //Send info hotkeyXY has been pressed
                            ((MouseActionPropertiesPanel)actionPropertiesPanel.Controls[0]).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                        case ActionTypes.ImageAction:
                            //Send info hotkeyXY has been pressed
                            ((ImageActionPropertiesPanel)actionPropertiesPanel.Controls[0]).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
                else if (pressedHotkey == hotkeyXY2.GetKey())
                {
                    switch (SelectedActionType)
                    {
                        case ActionTypes.MouseAction:
                            var panel = actionPropertiesPanel.Controls[0] as MouseActionPropertiesPanel;
                            panel.HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;
                        case ActionTypes.ImageAction:
                            //Send info hotkeyXY has been pressed
                            ((ImageActionPropertiesPanel)actionPropertiesPanel.Controls[0]).HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
            }
        }
    }
}
