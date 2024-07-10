namespace Tao_Bot_Maker.View
{
    partial class ActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionForm));
            this.actionPropertiesPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.actionTypeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // actionPropertiesPanel
            // 
            this.actionPropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionPropertiesPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.actionPropertiesPanel.Location = new System.Drawing.Point(219, 12);
            this.actionPropertiesPanel.Name = "actionPropertiesPanel";
            this.actionPropertiesPanel.Size = new System.Drawing.Size(569, 397);
            this.actionPropertiesPanel.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(713, 415);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(632, 415);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Add";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // actionTypeFlowLayoutPanel
            // 
            this.actionTypeFlowLayoutPanel.Location = new System.Drawing.Point(13, 12);
            this.actionTypeFlowLayoutPanel.Name = "actionTypeFlowLayoutPanel";
            this.actionTypeFlowLayoutPanel.Size = new System.Drawing.Size(200, 397);
            this.actionTypeFlowLayoutPanel.TabIndex = 4;
            // 
            // ActionForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.actionTypeFlowLayoutPanel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.actionPropertiesPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Action";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActionForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel actionPropertiesPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FlowLayoutPanel actionTypeFlowLayoutPanel;
    }
}