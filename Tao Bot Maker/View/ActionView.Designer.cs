namespace Tao_Bot_Maker.View
{
    partial class ActionView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionView));
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.panelSelectedAction = new System.Windows.Forms.Panel();
            this.flatComboBoxActions = new DarkModeForms.FlatComboBox();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(12, 98);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(225, 28);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "Annuler";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Ok.Location = new System.Drawing.Point(282, 98);
            this.button_Ok.Margin = new System.Windows.Forms.Padding(4);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(225, 28);
            this.button_Ok.TabIndex = 5;
            this.button_Ok.Text = "OK";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // panelSelectedAction
            // 
            this.panelSelectedAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelectedAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSelectedAction.Location = new System.Drawing.Point(12, 43);
            this.panelSelectedAction.Margin = new System.Windows.Forms.Padding(4);
            this.panelSelectedAction.Name = "panelSelectedAction";
            this.panelSelectedAction.Size = new System.Drawing.Size(497, 47);
            this.panelSelectedAction.TabIndex = 7;
            // 
            // flatComboBoxActions
            // 
            this.flatComboBoxActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBoxActions.FormattingEnabled = true;
            this.flatComboBoxActions.Location = new System.Drawing.Point(12, 12);
            this.flatComboBoxActions.Name = "flatComboBoxActions";
            this.flatComboBoxActions.Size = new System.Drawing.Size(498, 24);
            this.flatComboBoxActions.TabIndex = 8;
            this.flatComboBoxActions.SelectedIndexChanged += new System.EventHandler(this.flatComboBoxActions_SelectedIndexChanged);
            // 
            // ActionView
            // 
            this.AcceptButton = this.button_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(522, 133);
            this.Controls.Add(this.flatComboBoxActions);
            this.Controls.Add(this.panelSelectedAction);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 180);
            this.Name = "ActionView";
            this.Text = "Action";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActionView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Panel panelSelectedAction;
        private DarkModeForms.FlatComboBox flatComboBoxActions;
    }
}