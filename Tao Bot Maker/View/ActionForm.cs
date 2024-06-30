using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class ActionForm : Form
    {
        public ActionType SelectedActionType { get; set; }
        public Action Action { get; set; }

        private bool isFromImageAction;
        private HotKeyController hotkeyXY;
        private HotKeyController hotkeyXY2;

        public ActionForm(bool isFromImageAction = false, Action existingAction = null)
        {
            InitializeComponent();
            UpdateUI();
            this.isFromImageAction = isFromImageAction;
            this.Action = existingAction;
            FillActionTypeListBox();
            RegisterHotkeys();
            if (existingAction != null)
            {
                actionTypelistBox.SelectedItem = existingAction.Type;
                SetPropertiesPanel(existingAction.Type);
                FillPropertiesPanelWithExistingAction(existingAction);
            }
            else
            {
                actionTypelistBox.SelectedIndex = 0;
            }
        }

        private void UpdateUI()
        {
            this.Text = Resources.Strings.FormTitleNewAction;

            okButton.Text = Resources.Strings.ButtonAdd;
            cancelButton.Text = Resources.Strings.ButtonCancel;
        }

        private void FillPropertiesPanelWithExistingAction(Action existingAction)
        {
            switch (existingAction.Type)
            {
                case ActionType.MouseAction:
                    var mousePanel = actionPropertiesPanel.Controls[0] as MouseActionPropertiesPanel;
                    mousePanel?.SetAction(existingAction as MouseAction);
                    break;
                case ActionType.TextAction:
                    var textPanel = actionPropertiesPanel.Controls[0] as TextActionPropertiesPanel;
                    textPanel?.SetAction(existingAction as TextAction);
                    break;
                case ActionType.WaitAction:
                    var waitPanel = actionPropertiesPanel.Controls[0] as WaitActionPropertiesPanel;
                    waitPanel?.SetAction(existingAction as WaitAction);
                    break;
                case ActionType.SequenceAction:
                    var sequencePanel = actionPropertiesPanel.Controls[0] as SequenceActionPropertiesPanel;
                    sequencePanel?.SetAction(existingAction as SequenceAction);
                    break;
                case ActionType.KeyAction:
                    var keyPanel = actionPropertiesPanel.Controls[0] as KeyActionPropertiesPanel;
                    keyPanel?.SetAction(existingAction as KeyAction);
                    break;
                case ActionType.ImageAction:
                    var imagePanel = actionPropertiesPanel.Controls[0] as ImageActionPropertiesPanel;
                    imagePanel?.SetAction(existingAction as ImageAction);
                    break;
                // Ajoutez des cas pour d'autres types d'actions selon votre structure
                default:
                    break;
            }
        }

        public void RegisterHotkeys()
        {
            hotkeyXY = new HotKeyController(Keys.F1, this);
            hotkeyXY.Register();

            hotkeyXY2 = new HotKeyController(Keys.F2, this);
            hotkeyXY2.Register();
        }

        public void UnregisterHotkeys()
        {
            hotkeyXY.Unregister();
            hotkeyXY2.Unregister();
        }

        private void SetPropertiesPanel(ActionType actionType)
        {
            actionPropertiesPanel.Controls.Clear();
            RegisterHotkeys();
            UserControl panel = null;

            switch (actionType)
            {
                case ActionType.MouseAction:
                    panel = new MouseActionPropertiesPanel(isFromImageAction);
                    break;
                case ActionType.TextAction:
                    panel = new TextActionPropertiesPanel();
                    break;
                case ActionType.WaitAction:
                    panel = new WaitActionPropertiesPanel();
                    break;
                case ActionType.SequenceAction:
                    panel = new SequenceActionPropertiesPanel();
                    break;
                case ActionType.KeyAction:
                    panel = new KeyActionPropertiesPanel(this);
                    break;
                case ActionType.ImageAction:
                    panel = new ImageActionPropertiesPanel(this);
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
            foreach (ActionType actionType in Enum.GetValues(typeof(ActionType)))
            {
                actionTypelistBox.Items.Add(actionType);
            }
        }

        private void ActionTypeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedActionType = (ActionType)actionTypelistBox.SelectedIndex;
            SetPropertiesPanel(SelectedActionType);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (actionPropertiesPanel.Controls[0] is IActionPropertiesPanel panel)
            {
                var newAction = panel.GetAction();

                if (newAction == null)
                {
                    DialogResult = DialogResult.None;
                }
                else
                {
                    Action = newAction;
                    DialogResult = DialogResult.OK;
                }
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
                        case ActionType.MouseAction:
                            //Send info hotkeyXY has been pressed
                            ((MouseActionPropertiesPanel)actionPropertiesPanel.Controls[0]).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                        case ActionType.ImageAction:
                            //Send info hotkeyXY has been pressed
                            ((ImageActionPropertiesPanel)actionPropertiesPanel.Controls[0]).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
                else if (pressedHotkey == hotkeyXY2.GetKey())
                {
                    switch (SelectedActionType)
                    {
                        case ActionType.MouseAction:
                            var panel = actionPropertiesPanel.Controls[0] as MouseActionPropertiesPanel;
                            panel.HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;
                        case ActionType.ImageAction:
                            //Send info hotkeyXY has been pressed
                            ((ImageActionPropertiesPanel)actionPropertiesPanel.Controls[0]).HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
            }
        }
    }
}
