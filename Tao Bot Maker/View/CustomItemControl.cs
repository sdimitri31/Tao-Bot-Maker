using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class CustomItemControl<T> : UserControl
    {
        private PictureBox iconPictureBox;
        private Label textLabel;

        public new event EventHandler Click;
        public new event EventHandler MouseEnter;
        public new event EventHandler MouseLeave;
        public new event MouseEventHandler MouseDown;

        private CustomItem<T> _customDisplayItem;
        private T _data;
        private string _text;
        private Image _icon;
        private bool _isSelected;

        public CustomItem<T> Item
        {
            get { return _customDisplayItem; }
            set
            {
                ItemText = value.DisplayName;
                ItemIcon = value.Image;
                Data = value.Value;
                _customDisplayItem = value;
            }
        }

        public T Data
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }

        public string ItemText
        {
            get { return _text; }
            set
            {
                _text = value;
                textLabel.Text = _text;
            }
        }
        
        public Image ItemIcon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                iconPictureBox.Image = value;
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

        public CustomItemControl()
        {
            InitializeComponent();
            AttachEvents(this);
        }

        private void InitializeComponent()
        {
            this.textLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textLabel.Location = new System.Drawing.Point(38, 3);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(109, 25);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "Item text";
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Location = new System.Drawing.Point(5, 2);
            this.iconPictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(25, 25);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // CustomItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.iconPictureBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.Name = "CustomItemControl";
            this.Size = new System.Drawing.Size(150, 30);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomItemControl_MouseDown);
            this.MouseEnter += new System.EventHandler(this.CustomItemControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CustomItemControl_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomItemControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }


        private void AttachEvents(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Click += RelayClickEvent;
                control.MouseEnter += RelayMouseEnterEvent;
                control.MouseLeave += RelayMouseLeaveEvent;
                control.MouseDown += RelayMouseDownEvent;
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

        private void CustomItemControl_MouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = HoverBackColor;
                ForeColor = HoverForeColor;
            }
        }

        private void CustomItemControl_MouseLeave(object sender, EventArgs e)
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

        private void CustomItemControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Selected)
            {
                BackColor = PressedBackColor;
                ForeColor = PressedForeColor;
            }
        }

        private void CustomItemControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Selected)
            {
                BackColor = SurfaceColor;
                ForeColor = TextColor;
            }
        }
    }
}
