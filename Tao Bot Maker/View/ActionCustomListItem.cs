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
            AttachEvents(this);
            SurfaceColor = Color.Gainsboro;
            HighlightBackColor = SystemColors.Highlight;
            HighlightForeColor = SystemColors.HighlightText;
            TextColor = SystemColors.ControlText;
            HoverColor = Color.WhiteSmoke;
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

        public Color SurfaceColor
        {
            get { return _surfaceColor; }
            set
            {
                _surfaceColor = value;
                this.BackColor = value;
            }
        }

        private Color _highlightBackColor;

        public Color HighlightBackColor
        {
            get { return _highlightBackColor; }
            set { _highlightBackColor = value; }
        }

        private Color _highlightForeColor;

        public Color HighlightForeColor
        {
            get { return _highlightForeColor; }
            set { _highlightForeColor = value; }
        }

        private Color _textColor;

        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                this.ForeColor = value;
            }
        }

        private Color _hoverColor;

        public Color HoverColor
        {
            get { return _hoverColor; }
            set { _hoverColor = value; }
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
                BackColor = HoverColor;
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
