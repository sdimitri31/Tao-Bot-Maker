using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class ActionTypeCustomListItem : UserControl
    {
        public new event EventHandler Click;
        public new event EventHandler MouseEnter;
        public new event EventHandler MouseLeave;

        public ActionTypeCustomListItem()
        {
            InitializeComponent();
            AttachEvents(this);
        }

        private ActionType _actionType;

        public ActionType ActionType { 
            get { return _actionType; } 
            set { _actionType = value; } 
        }

        private string _name;

        public string ActionName
        {
            get { return _name; }
            set
            {
                _name = value;
                nameLabel.Text = _name;
            }
        }

        private Image _icon;

        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                iconPictureBox.Image = value;
            }
        }

        private bool _isSelected;

        public bool Selected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                ForeColor = value ? SystemColors.HighlightText : Color.Black;
                BackColor = value ? SystemColors.Highlight : Color.LightGray;
            }
        }

        private void AttachEvents(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Click += RelayClickEvent;
                control.MouseEnter += RelayMouseEnterEvent;
                control.MouseLeave += RelayMouseLeaveEvent;
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

        private void RelayMouseLeaveEvent(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            MouseLeave?.Invoke(this, e);
            base.OnMouseLeave(e);
        }

        private void ActionTypeCustomListItem_MouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = Color.Gainsboro;
            }
        }

        private void ActionTypeCustomListItem_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = Color.LightGray;
            }
        }
    }
}
