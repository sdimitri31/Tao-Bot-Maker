namespace Tao_Bot_Maker.View
{
    partial class SequenceActionPropertiesPanel
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
            this.sequenceLabel = new System.Windows.Forms.Label();
            this.repeatCountLabel = new System.Windows.Forms.Label();
            this.repeatCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sequenceComboBox = new System.Windows.Forms.ComboBox();
            this.sequencePanel = new System.Windows.Forms.Panel();
            this.sequenceTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.repeatCountPanel = new System.Windows.Forms.Panel();
            this.repeatCountTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.repeatCountNumericUpDown)).BeginInit();
            this.sequencePanel.SuspendLayout();
            this.sequenceTableLayoutPanel.SuspendLayout();
            this.repeatCountPanel.SuspendLayout();
            this.repeatCountTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sequenceLabel
            // 
            this.sequenceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceLabel.AutoSize = true;
            this.sequenceLabel.Location = new System.Drawing.Point(3, 10);
            this.sequenceLabel.Name = "sequenceLabel";
            this.sequenceLabel.Size = new System.Drawing.Size(111, 13);
            this.sequenceLabel.TabIndex = 0;
            this.sequenceLabel.Text = "Sequence";
            this.sequenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // repeatCountLabel
            // 
            this.repeatCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatCountLabel.AutoSize = true;
            this.repeatCountLabel.Location = new System.Drawing.Point(3, 10);
            this.repeatCountLabel.Name = "repeatCountLabel";
            this.repeatCountLabel.Size = new System.Drawing.Size(111, 13);
            this.repeatCountLabel.TabIndex = 18;
            this.repeatCountLabel.Text = "Repeat count";
            this.repeatCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // repeatCountNumericUpDown
            // 
            this.repeatCountNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatCountNumericUpDown.Location = new System.Drawing.Point(120, 7);
            this.repeatCountNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.repeatCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.repeatCountNumericUpDown.Name = "repeatCountNumericUpDown";
            this.repeatCountNumericUpDown.Size = new System.Drawing.Size(345, 20);
            this.repeatCountNumericUpDown.TabIndex = 16;
            this.repeatCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // sequenceComboBox
            // 
            this.sequenceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sequenceComboBox.FormattingEnabled = true;
            this.sequenceComboBox.Location = new System.Drawing.Point(120, 6);
            this.sequenceComboBox.Name = "sequenceComboBox";
            this.sequenceComboBox.Size = new System.Drawing.Size(345, 21);
            this.sequenceComboBox.TabIndex = 19;
            // 
            // sequencePanel
            // 
            this.sequencePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequencePanel.BackColor = System.Drawing.Color.Gainsboro;
            this.sequencePanel.Controls.Add(this.sequenceTableLayoutPanel);
            this.sequencePanel.Location = new System.Drawing.Point(8, 8);
            this.sequencePanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.sequencePanel.Name = "sequencePanel";
            this.sequencePanel.Padding = new System.Windows.Forms.Padding(8);
            this.sequencePanel.Size = new System.Drawing.Size(484, 50);
            this.sequencePanel.TabIndex = 32;
            // 
            // sequenceTableLayoutPanel
            // 
            this.sequenceTableLayoutPanel.ColumnCount = 2;
            this.sequenceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.sequenceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.sequenceTableLayoutPanel.Controls.Add(this.sequenceLabel, 0, 0);
            this.sequenceTableLayoutPanel.Controls.Add(this.sequenceComboBox, 1, 0);
            this.sequenceTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sequenceTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.sequenceTableLayoutPanel.Name = "sequenceTableLayoutPanel";
            this.sequenceTableLayoutPanel.RowCount = 1;
            this.sequenceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sequenceTableLayoutPanel.Size = new System.Drawing.Size(468, 34);
            this.sequenceTableLayoutPanel.TabIndex = 20;
            // 
            // repeatCountPanel
            // 
            this.repeatCountPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatCountPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.repeatCountPanel.Controls.Add(this.repeatCountTableLayoutPanel);
            this.repeatCountPanel.Location = new System.Drawing.Point(8, 66);
            this.repeatCountPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.repeatCountPanel.Name = "repeatCountPanel";
            this.repeatCountPanel.Padding = new System.Windows.Forms.Padding(8);
            this.repeatCountPanel.Size = new System.Drawing.Size(484, 50);
            this.repeatCountPanel.TabIndex = 33;
            // 
            // repeatCountTableLayoutPanel
            // 
            this.repeatCountTableLayoutPanel.ColumnCount = 2;
            this.repeatCountTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.repeatCountTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.repeatCountTableLayoutPanel.Controls.Add(this.repeatCountNumericUpDown, 1, 0);
            this.repeatCountTableLayoutPanel.Controls.Add(this.repeatCountLabel, 0, 0);
            this.repeatCountTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repeatCountTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.repeatCountTableLayoutPanel.Name = "repeatCountTableLayoutPanel";
            this.repeatCountTableLayoutPanel.RowCount = 1;
            this.repeatCountTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.repeatCountTableLayoutPanel.Size = new System.Drawing.Size(468, 34);
            this.repeatCountTableLayoutPanel.TabIndex = 20;
            // 
            // SequenceActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.repeatCountPanel);
            this.Controls.Add(this.sequencePanel);
            this.DoubleBuffered = true;
            this.Name = "SequenceActionPropertiesPanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(500, 128);
            ((System.ComponentModel.ISupportInitialize)(this.repeatCountNumericUpDown)).EndInit();
            this.sequencePanel.ResumeLayout(false);
            this.sequenceTableLayoutPanel.ResumeLayout(false);
            this.sequenceTableLayoutPanel.PerformLayout();
            this.repeatCountPanel.ResumeLayout(false);
            this.repeatCountTableLayoutPanel.ResumeLayout(false);
            this.repeatCountTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label sequenceLabel;
        private System.Windows.Forms.NumericUpDown repeatCountNumericUpDown;
        private System.Windows.Forms.Label repeatCountLabel;
        private System.Windows.Forms.ComboBox sequenceComboBox;
        private System.Windows.Forms.Panel sequencePanel;
        private System.Windows.Forms.TableLayoutPanel sequenceTableLayoutPanel;
        private System.Windows.Forms.Panel repeatCountPanel;
        private System.Windows.Forms.TableLayoutPanel repeatCountTableLayoutPanel;
    }
}
