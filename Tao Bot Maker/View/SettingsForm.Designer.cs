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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.settingsPropertiesPanel = new System.Windows.Forms.Panel();
            this.settingsTypelistBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(632, 415);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(713, 415);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // settingsPropertiesPanel
            // 
            this.settingsPropertiesPanel.Location = new System.Drawing.Point(219, 12);
            this.settingsPropertiesPanel.Name = "settingsPropertiesPanel";
            this.settingsPropertiesPanel.Size = new System.Drawing.Size(569, 397);
            this.settingsPropertiesPanel.TabIndex = 5;
            // 
            // settingsTypelistBox
            // 
            this.settingsTypelistBox.FormattingEnabled = true;
            this.settingsTypelistBox.IntegralHeight = false;
            this.settingsTypelistBox.Location = new System.Drawing.Point(12, 12);
            this.settingsTypelistBox.Name = "settingsTypelistBox";
            this.settingsTypelistBox.Size = new System.Drawing.Size(201, 397);
            this.settingsTypelistBox.TabIndex = 4;
            this.settingsTypelistBox.SelectedIndexChanged += new System.EventHandler(this.SettingsTypelistBox_SelectedIndexChanged);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.settingsPropertiesPanel);
            this.Controls.Add(this.settingsTypelistBox);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel settingsPropertiesPanel;
        private System.Windows.Forms.ListBox settingsTypelistBox;
    }
}