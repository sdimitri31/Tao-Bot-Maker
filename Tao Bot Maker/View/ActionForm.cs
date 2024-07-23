using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;
using Settings = Tao_Bot_Maker.Model.Settings;

namespace Tao_Bot_Maker.View
{
    public partial class ActionForm : Form
    {
        private AppTheme appTheme;
        public ActionType SelectedActionType { get; set; }
        public Action Action { get; set; }

        private bool isFromImageAction;
        private HotKeyController hotkeyXY;
        private HotKeyController hotkeyXY2;
        private List<UserControl> panels;

        public ActionForm(bool isFromImageAction = false, Action existingAction = null)
        {
            InitializeComponent();
            RegisterHotkeys();
            panels = new List<UserControl>();
            this.isFromImageAction = isFromImageAction;

            Action = existingAction;
            SelectedActionType = ActionType.MouseAction;

            LoadThemeSettings();
            LoadAllActionType();
            AppThemeHelper.ApplyThemeToControl(appTheme, actionPropertiesPanel, 2);

            if (existingAction != null)
            {
                SelectedActionType = existingAction.Type;
                FillPropertiesPanelWithExistingAction(existingAction);
            }

            SetPropertiesPanel(SelectedActionType);
            SetSelectedActionTypeFlowLayout(SelectedActionType);
            UpdateUI();
        }

        private void LoadThemeSettings()
        {
            string theme = SettingsController.GetSettingValue<string>(Settings.SETTING_THEME);
            appTheme = AppThemeHelper.GetAppThemeFromName(theme);
            AppThemeHelper.ApplyTheme(appTheme, this);
        }

        private void AddCustomItem(ActionType actionType)
        {
            CustomItemControl<ActionType> customItem = new CustomItemControl<ActionType>
            {
                Item = new CustomItem<ActionType>(actionType, ActionHelper.GetActionTypeDisplayName(actionType), ActionHelper.GetActionTypeIcon(actionType)),
                Selected = false
            };
            customItem.Width = actionTypeFlowLayoutPanel.Width - 16;
            customItem.Click += ActionTypeCustomListItem_Click;

            customItem.Margin = new Padding(customItem.Margin.Left, customItem.Margin.Top, customItem.Margin.Right, 8);

            actionTypeFlowLayoutPanel.Controls.Add(customItem);
            AppThemeHelper.ApplyThemeToControl(appTheme, customItem, 2);
        }

        private void ActionTypeCustomListItem_Click(object sender, EventArgs e)
        {
            CustomItemControl<ActionType> item = sender as CustomItemControl<ActionType>;
            if (item != null)
            {
                SelectedActionType = item.Data;
                SetSelectedActionTypeFlowLayout(SelectedActionType);
                SetPropertiesPanel(SelectedActionType);
            }
        }

        private void SetSelectedActionTypeFlowLayout(ActionType actionType)
        {
            foreach (CustomItemControl<ActionType> item in actionTypeFlowLayoutPanel.Controls.OfType<CustomItemControl<ActionType>>())
            {
                item.Selected = item.Data == actionType;
            }
        }

        private void UpdateUI()
        {
            this.Text = Action == null ? Resources.Strings.FormTitleNewAction : Resources.Strings.FormTitleEditAction;

            okButton.Text = Resources.Strings.ButtonAdd;
            cancelButton.Text = Resources.Strings.ButtonCancel;
        }

        private void AddPropertiesPanel(ActionType actionType)
        {
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
                default:
                    break;
            }

            if (panel != null)
            {
                panel.Location = new Point(0, 0);
                panel.Visible = false;
                panel.Width = actionPropertiesPanel.Width;
                panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                actionPropertiesPanel.Controls.Add(panel);
                panels.Add(panel);
            }
        }

        private void FillPropertiesPanelWithExistingAction(Action existingAction)
        {
            foreach (UserControl panel in panels)
            {
                if (existingAction.Type == (panel as IActionPropertiesPanel).GetType())
                    (panel as IActionPropertiesPanel).SetAction(existingAction);
            }
        }

        private void SetPropertiesPanel(ActionType actionType)
        {
            RegisterHotkeys();

            foreach (UserControl panel in panels)
            {
                panel.Visible = (panel as IActionPropertiesPanel).GetType() == actionType;
            }
        }

        private IActionPropertiesPanel GetSelectedPropertiesPanel()
        {
            foreach (UserControl panel in panels)
            {
                if (SelectedActionType == (panel as IActionPropertiesPanel).GetType())
                    return (IActionPropertiesPanel)panel;
            }
            return null;
        }

        private T GetPropertiesPanelByType<T>(ActionType actionType)
        {
            foreach (UserControl panel in panels)
            {
                if (actionType == (panel as IActionPropertiesPanel).GetType())
                    return (T)Convert.ChangeType(panel, typeof(T));
            }
            return default;
        }

        private void LoadAllActionType()
        {
            foreach (ActionType actionType in Enum.GetValues(typeof(ActionType)))
            {
                if (actionType == ActionType.CorruptAction)
                {
                    continue;
                }

                AddPropertiesPanel(actionType);
                AddCustomItem(actionType);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            IActionPropertiesPanel panel = GetSelectedPropertiesPanel();
            if (panel != null)
            {
                var newAction = panel.GetAction();

                if (!newAction.Validate(out string errorMessage))
                {
                    MessageBox.Show(errorMessage, Resources.Strings.ErrorMessageCaptionInvalidAction, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void RegisterHotkeys()
        {
            hotkeyXY = new HotKeyController((Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYSTARTCOORDS), this);
            hotkeyXY.Register();

            hotkeyXY2 = new HotKeyController((Keys)SettingsController.GetSettingValue<int>(Settings.SETTING_HOTKEYENDCOORDS), this);
            hotkeyXY2.Register();
        }

        public void UnregisterHotkeys()
        {
            hotkeyXY.Unregister();
            hotkeyXY2.Unregister();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys pressedKey = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                Keys pressedModifier = (Keys)HotKeyController.Reverse3Bits(((int)m.LParam & 0xFFFF));

                //Converting to same format as regular Keys
                Keys pressedHotkey = (Keys)(((int)pressedModifier << 16) | (int)pressedKey);

                if (pressedHotkey == hotkeyXY.GetKey())
                {
                    switch (SelectedActionType)
                    {
                        case ActionType.MouseAction:
                            GetPropertiesPanelByType<MouseActionPropertiesPanel>(ActionType.MouseAction).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                        case ActionType.ImageAction:
                            GetPropertiesPanelByType<ImageActionPropertiesPanel>(ActionType.ImageAction).HotkeyXY(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
                else if (pressedHotkey == hotkeyXY2.GetKey())
                {
                    switch (SelectedActionType)
                    {
                        case ActionType.MouseAction:
                            GetPropertiesPanelByType<MouseActionPropertiesPanel>(ActionType.MouseAction).HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;
                        case ActionType.ImageAction:
                            GetPropertiesPanelByType<ImageActionPropertiesPanel>(ActionType.ImageAction).HotkeyXY2(Cursor.Position.X, Cursor.Position.Y);
                            break;
                    }
                }
            }
        }

        private void ActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotkeys();
        }
    }
}
