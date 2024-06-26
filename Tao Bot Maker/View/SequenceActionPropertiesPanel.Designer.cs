﻿namespace Tao_Bot_Maker.View
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.repeatCountLabel = new System.Windows.Forms.Label();
            this.repeatCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sequenceComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // sequenceLabel
            // 
            this.sequenceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.sequenceLabel, 2);
            this.sequenceLabel.Location = new System.Drawing.Point(3, 8);
            this.sequenceLabel.Name = "sequenceLabel";
            this.sequenceLabel.Size = new System.Drawing.Size(194, 13);
            this.sequenceLabel.TabIndex = 0;
            this.sequenceLabel.Text = "Sequence";
            this.sequenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sequenceLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.repeatCountLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.repeatCountNumericUpDown, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.sequenceComboBox, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 300);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // repeatCountLabel
            // 
            this.repeatCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatCountLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.repeatCountLabel, 2);
            this.repeatCountLabel.Location = new System.Drawing.Point(3, 68);
            this.repeatCountLabel.Name = "repeatCountLabel";
            this.repeatCountLabel.Size = new System.Drawing.Size(194, 13);
            this.repeatCountLabel.TabIndex = 18;
            this.repeatCountLabel.Text = "Repeat count";
            this.repeatCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // repeatCountNumericUpDown
            // 
            this.repeatCountNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatCountNumericUpDown.Location = new System.Drawing.Point(203, 65);
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
            this.repeatCountNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.repeatCountNumericUpDown.TabIndex = 16;
            // 
            // sequenceComboBox
            // 
            this.sequenceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.sequenceComboBox, 2);
            this.sequenceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sequenceComboBox.FormattingEnabled = true;
            this.sequenceComboBox.Location = new System.Drawing.Point(203, 4);
            this.sequenceComboBox.Name = "sequenceComboBox";
            this.sequenceComboBox.Size = new System.Drawing.Size(194, 21);
            this.sequenceComboBox.TabIndex = 19;
            // 
            // SequenceActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SequenceActionPropertiesPanel";
            this.Size = new System.Drawing.Size(500, 300);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label sequenceLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown repeatCountNumericUpDown;
        private System.Windows.Forms.Label repeatCountLabel;
        private System.Windows.Forms.ComboBox sequenceComboBox;
    }
}