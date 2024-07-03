namespace Tao_Bot_Maker.View.Setting
{
    partial class OtherSettingsPropertiesPanel
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveLogCheckBox = new System.Windows.Forms.CheckBox();
            this.showLogLevelLabel = new System.Windows.Forms.Label();
            this.saveLogLevelInformationCheckBox = new System.Windows.Forms.CheckBox();
            this.saveLogLevelWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.saveLogLevelErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.saveLogLevelDebugCheckBox = new System.Windows.Forms.CheckBox();
            this.saveLogLevelLabel = new System.Windows.Forms.Label();
            this.openLogFolderButton = new System.Windows.Forms.Button();
            this.showLogLevelInformationCheckBox = new System.Windows.Forms.CheckBox();
            this.showLogLevelWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.showLogLevelErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.showLogLevelDebugCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.showLogLevelLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.openLogFolderButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.saveLogCheckBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.saveLogLevelLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.saveLogLevelInformationCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.saveLogLevelWarningCheckBox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.saveLogLevelErrorCheckBox, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.saveLogLevelDebugCheckBox, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.showLogLevelInformationCheckBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.showLogLevelWarningCheckBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.showLogLevelErrorCheckBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.showLogLevelDebugCheckBox, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 300);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // saveLogCheckBox
            // 
            this.saveLogCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLogCheckBox.AutoSize = true;
            this.saveLogCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveLogCheckBox.Location = new System.Drawing.Point(103, 134);
            this.saveLogCheckBox.Name = "saveLogCheckBox";
            this.saveLogCheckBox.Size = new System.Drawing.Size(94, 31);
            this.saveLogCheckBox.TabIndex = 3;
            this.saveLogCheckBox.Text = "Save Logs";
            this.saveLogCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveLogCheckBox.UseVisualStyleBackColor = true;
            this.saveLogCheckBox.CheckedChanged += new System.EventHandler(this.SaveLogCheckBox_CheckedChanged);
            // 
            // showLogLevelLabel
            // 
            this.showLogLevelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.showLogLevelLabel.AutoSize = true;
            this.showLogLevelLabel.Location = new System.Drawing.Point(3, 23);
            this.showLogLevelLabel.Name = "showLogLevelLabel";
            this.showLogLevelLabel.Size = new System.Drawing.Size(94, 13);
            this.showLogLevelLabel.TabIndex = 4;
            this.showLogLevelLabel.Text = "Show log level";
            // 
            // saveLogLevelInformationCheckBox
            // 
            this.saveLogLevelInformationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLogLevelInformationCheckBox.AutoSize = true;
            this.saveLogLevelInformationCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveLogLevelInformationCheckBox.Location = new System.Drawing.Point(103, 194);
            this.saveLogLevelInformationCheckBox.Name = "saveLogLevelInformationCheckBox";
            this.saveLogLevelInformationCheckBox.Size = new System.Drawing.Size(94, 31);
            this.saveLogLevelInformationCheckBox.TabIndex = 5;
            this.saveLogLevelInformationCheckBox.Text = "Information";
            this.saveLogLevelInformationCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveLogLevelInformationCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveLogLevelWarningCheckBox
            // 
            this.saveLogLevelWarningCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLogLevelWarningCheckBox.AutoSize = true;
            this.saveLogLevelWarningCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveLogLevelWarningCheckBox.Location = new System.Drawing.Point(203, 194);
            this.saveLogLevelWarningCheckBox.Name = "saveLogLevelWarningCheckBox";
            this.saveLogLevelWarningCheckBox.Size = new System.Drawing.Size(94, 31);
            this.saveLogLevelWarningCheckBox.TabIndex = 6;
            this.saveLogLevelWarningCheckBox.Text = "Warning";
            this.saveLogLevelWarningCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveLogLevelWarningCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveLogLevelErrorCheckBox
            // 
            this.saveLogLevelErrorCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLogLevelErrorCheckBox.AutoSize = true;
            this.saveLogLevelErrorCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveLogLevelErrorCheckBox.Location = new System.Drawing.Point(303, 194);
            this.saveLogLevelErrorCheckBox.Name = "saveLogLevelErrorCheckBox";
            this.saveLogLevelErrorCheckBox.Size = new System.Drawing.Size(94, 31);
            this.saveLogLevelErrorCheckBox.TabIndex = 7;
            this.saveLogLevelErrorCheckBox.Text = "Error";
            this.saveLogLevelErrorCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveLogLevelErrorCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveLogLevelDebugCheckBox
            // 
            this.saveLogLevelDebugCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLogLevelDebugCheckBox.AutoSize = true;
            this.saveLogLevelDebugCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveLogLevelDebugCheckBox.Location = new System.Drawing.Point(403, 194);
            this.saveLogLevelDebugCheckBox.Name = "saveLogLevelDebugCheckBox";
            this.saveLogLevelDebugCheckBox.Size = new System.Drawing.Size(94, 31);
            this.saveLogLevelDebugCheckBox.TabIndex = 8;
            this.saveLogLevelDebugCheckBox.Text = "Debug";
            this.saveLogLevelDebugCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveLogLevelDebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveLogLevelLabel
            // 
            this.saveLogLevelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLogLevelLabel.AutoSize = true;
            this.saveLogLevelLabel.Location = new System.Drawing.Point(3, 203);
            this.saveLogLevelLabel.Name = "saveLogLevelLabel";
            this.saveLogLevelLabel.Size = new System.Drawing.Size(94, 13);
            this.saveLogLevelLabel.TabIndex = 9;
            this.saveLogLevelLabel.Text = "Save log level";
            // 
            // openLogFolderButton
            // 
            this.openLogFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.openLogFolderButton.Location = new System.Drawing.Point(203, 138);
            this.openLogFolderButton.Name = "openLogFolderButton";
            this.openLogFolderButton.Size = new System.Drawing.Size(94, 23);
            this.openLogFolderButton.TabIndex = 10;
            this.openLogFolderButton.Text = "Open log folder";
            this.openLogFolderButton.UseVisualStyleBackColor = true;
            this.openLogFolderButton.Click += new System.EventHandler(this.OpenLogFolderButton_Click);
            // 
            // showLogLevelInformationCheckBox
            // 
            this.showLogLevelInformationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.showLogLevelInformationCheckBox.AutoSize = true;
            this.showLogLevelInformationCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.showLogLevelInformationCheckBox.Location = new System.Drawing.Point(103, 14);
            this.showLogLevelInformationCheckBox.Name = "showLogLevelInformationCheckBox";
            this.showLogLevelInformationCheckBox.Size = new System.Drawing.Size(94, 31);
            this.showLogLevelInformationCheckBox.TabIndex = 11;
            this.showLogLevelInformationCheckBox.Text = "Information";
            this.showLogLevelInformationCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.showLogLevelInformationCheckBox.UseVisualStyleBackColor = true;
            // 
            // showLogLevelWarningCheckBox
            // 
            this.showLogLevelWarningCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.showLogLevelWarningCheckBox.AutoSize = true;
            this.showLogLevelWarningCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.showLogLevelWarningCheckBox.Location = new System.Drawing.Point(203, 14);
            this.showLogLevelWarningCheckBox.Name = "showLogLevelWarningCheckBox";
            this.showLogLevelWarningCheckBox.Size = new System.Drawing.Size(94, 31);
            this.showLogLevelWarningCheckBox.TabIndex = 12;
            this.showLogLevelWarningCheckBox.Text = "Warning";
            this.showLogLevelWarningCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.showLogLevelWarningCheckBox.UseVisualStyleBackColor = true;
            // 
            // showLogLevelErrorCheckBox
            // 
            this.showLogLevelErrorCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.showLogLevelErrorCheckBox.AutoSize = true;
            this.showLogLevelErrorCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.showLogLevelErrorCheckBox.Location = new System.Drawing.Point(303, 14);
            this.showLogLevelErrorCheckBox.Name = "showLogLevelErrorCheckBox";
            this.showLogLevelErrorCheckBox.Size = new System.Drawing.Size(94, 31);
            this.showLogLevelErrorCheckBox.TabIndex = 13;
            this.showLogLevelErrorCheckBox.Text = "Error";
            this.showLogLevelErrorCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.showLogLevelErrorCheckBox.UseVisualStyleBackColor = true;
            // 
            // showLogLevelDebugCheckBox
            // 
            this.showLogLevelDebugCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.showLogLevelDebugCheckBox.AutoSize = true;
            this.showLogLevelDebugCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.showLogLevelDebugCheckBox.Location = new System.Drawing.Point(403, 14);
            this.showLogLevelDebugCheckBox.Name = "showLogLevelDebugCheckBox";
            this.showLogLevelDebugCheckBox.Size = new System.Drawing.Size(94, 31);
            this.showLogLevelDebugCheckBox.TabIndex = 14;
            this.showLogLevelDebugCheckBox.Text = "Debug";
            this.showLogLevelDebugCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.showLogLevelDebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // OtherSettingsPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OtherSettingsPropertiesPanel";
            this.Size = new System.Drawing.Size(500, 300);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox saveLogCheckBox;
        private System.Windows.Forms.Label showLogLevelLabel;
        private System.Windows.Forms.CheckBox saveLogLevelInformationCheckBox;
        private System.Windows.Forms.CheckBox saveLogLevelWarningCheckBox;
        private System.Windows.Forms.CheckBox saveLogLevelErrorCheckBox;
        private System.Windows.Forms.CheckBox saveLogLevelDebugCheckBox;
        private System.Windows.Forms.Button openLogFolderButton;
        private System.Windows.Forms.Label saveLogLevelLabel;
        private System.Windows.Forms.CheckBox showLogLevelInformationCheckBox;
        private System.Windows.Forms.CheckBox showLogLevelWarningCheckBox;
        private System.Windows.Forms.CheckBox showLogLevelErrorCheckBox;
        private System.Windows.Forms.CheckBox showLogLevelDebugCheckBox;
    }
}
