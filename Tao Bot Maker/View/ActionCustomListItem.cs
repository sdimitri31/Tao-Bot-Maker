using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class ActionCustomListItem : UserControl
    {
        public new event EventHandler Click;
        public new event EventHandler MouseEnter;
        public new event EventHandler MouseLeave;
        public new event MouseEventHandler MouseDown;
        public new event EventHandler<KeyEventArgs> KeyDown;

        private Action _action;
        private Image _icon;
        private bool _isSelected;

        public ActionCustomListItem()
        {
            InitializeComponent();
            SetAction(new CorruptedAction());
            AttachEvents(this);
        }

        public void SetAction(Action action)
        {
            Action = action;
            Icon = ActionHelper.GetActionTypeIcon(action.Type);
        }

        public Action Action
        {
            get { return _action; }
            set
            {
                _action = value;
                actionTextLabel.Text = value.ToString();
            }
        }

        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                actionIconPictureBox.Image = value;
            }
        }

        public bool Selected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                ForeColor = value ? HighlightForeColor : TextColor;
                BackColor = value ? HighlightBackColor : SurfaceColor;
            }
        }

        private Color _surfaceColor;
        private Color _textColor;

        private Color _highlightBackColor;
        private Color _highlightForeColor;

        private Color _hoverBackColor;
        private Color _hoverForeColor;

        private Color _pressedBackColor;
        private Color _pressedForeColor;

        public Color SurfaceColor
        {
            get { return _surfaceColor; }
            set
            {
                _surfaceColor = value;
                this.BackColor = value;
            }
        }

        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                this.ForeColor = value;
            }
        }

        public Color HighlightBackColor
        {
            get { return _highlightBackColor; }
            set { _highlightBackColor = value; }
        }

        public Color HighlightForeColor
        {
            get { return _highlightForeColor; }
            set { _highlightForeColor = value; }
        }

        public Color HoverBackColor
        {
            get { return _hoverBackColor; }
            set { _hoverBackColor = value; }
        }

        public Color HoverForeColor
        {
            get { return _hoverForeColor; }
            set { _hoverForeColor = value; }
        }

        public Color PressedBackColor
        {
            get { return _pressedBackColor; }
            set { _pressedBackColor = value; }
        }

        public Color PressedForeColor
        {
            get { return _pressedForeColor; }
            set { _pressedForeColor = value; }
        }

        private void AttachEvents(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Click += RelayClickEvent;
                control.MouseEnter += RelayMouseEnterEvent;
                control.MouseLeave += RelayMouseLeaveEvent;
                control.MouseDown += RelayMouseDownEvent;
                control.KeyDown += RelayKeyDownEvent;
                if (control.HasChildren)
                {
                    AttachEvents(control);
                }
            }
        }

        private void RelayClickEvent(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        protected override void OnClick(EventArgs e)
        {
            Click?.Invoke(this, e);
            base.OnClick(e);
        }

        private void RelayMouseEnterEvent(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            MouseEnter?.Invoke(this, e);
            base.OnMouseEnter(e);
        }

        private void ActionTypeCustomListItem_MouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = HoverBackColor;
                ForeColor = HoverForeColor;
            }
        }

        private void RelayMouseLeaveEvent(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            MouseLeave?.Invoke(this, e);
            base.OnMouseLeave(e);
        }

        private void ActionTypeCustomListItem_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = SurfaceColor;
                ForeColor = TextColor;
            }
        }

        private void RelayMouseDownEvent(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseDown?.Invoke(this, e);
            base.OnMouseDown(e);
        }

        private void DragPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(this, DragDropEffects.Move);
            }
        }


        private void RelayKeyDownEvent(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            KeyDown(this, e);
            base.OnKeyDown(e);
        }
    }
}
