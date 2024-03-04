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
            this.panel_SelectedAction = new System.Windows.Forms.Panel();
            this.listBox_Actions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(446, 346);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(125, 28);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Annuler";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Ok.Location = new System.Drawing.Point(579, 346);
            this.button_Ok.Margin = new System.Windows.Forms.Padding(4);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(125, 28);
            this.button_Ok.TabIndex = 4;
            this.button_Ok.Text = "OK";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.Button_Ok_Click);
            // 
            // panel_SelectedAction
            // 
            this.panel_SelectedAction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_SelectedAction.Location = new System.Drawing.Point(210, 13);
            this.panel_SelectedAction.Margin = new System.Windows.Forms.Padding(4);
            this.panel_SelectedAction.Name = "panel_SelectedAction";
            this.panel_SelectedAction.Size = new System.Drawing.Size(497, 325);
            this.panel_SelectedAction.TabIndex = 2;
            // 
            // listBox_Actions
            // 
            this.listBox_Actions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_Actions.FormattingEnabled = true;
            this.listBox_Actions.IntegralHeight = false;
            this.listBox_Actions.ItemHeight = 16;
            this.listBox_Actions.Location = new System.Drawing.Point(12, 12);
            this.listBox_Actions.Name = "listBox_Actions";
            this.listBox_Actions.Size = new System.Drawing.Size(192, 326);
            this.listBox_Actions.TabIndex = 1;
            this.listBox_Actions.SelectedIndexChanged += new System.EventHandler(this.FlatComboBox_Actions_SelectedIndexChanged);
            // 
            // ActionView
            // 
            this.AcceptButton = this.button_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(717, 386);
            this.Controls.Add(this.listBox_Actions);
            this.Controls.Add(this.panel_SelectedAction);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Panel panel_SelectedAction;
        private System.Windows.Forms.ListBox listBox_Actions;
    }
}