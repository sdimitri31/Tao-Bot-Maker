namespace Tao_Bot_Maker.View
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.settingsPropertiesPanel = new System.Windows.Forms.Panel();
            this.settingsTypeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(632, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(713, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 403);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(800, 47);
            this.bottomPanel.TabIndex = 8;
            // 
            // settingsPropertiesPanel
            // 
            this.settingsPropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsPropertiesPanel.BackColor = System.Drawing.Color.Silver;
            this.settingsPropertiesPanel.Location = new System.Drawing.Point(213, 0);
            this.settingsPropertiesPanel.Margin = new System.Windows.Forms.Padding(0);
            this.settingsPropertiesPanel.Name = "settingsPropertiesPanel";
            this.settingsPropertiesPanel.Size = new System.Drawing.Size(587, 403);
            this.settingsPropertiesPanel.TabIndex = 10;
            // 
            // settingsTypeFlowLayoutPanel
            // 
            this.settingsTypeFlowLayoutPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.settingsTypeFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.settingsTypeFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsTypeFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.settingsTypeFlowLayoutPanel.Name = "settingsTypeFlowLayoutPanel";
            this.settingsTypeFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.settingsTypeFlowLayoutPanel.Size = new System.Drawing.Size(213, 403);
            this.settingsTypeFlowLayoutPanel.TabIndex = 5;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.settingsTypeFlowLayoutPanel);
            this.Controls.Add(this.settingsPropertiesPanel);
            this.Controls.Add(this.bottomPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel settingsPropertiesPanel;
        private System.Windows.Forms.FlowLayoutPanel settingsTypeFlowLayoutPanel;
    }
}