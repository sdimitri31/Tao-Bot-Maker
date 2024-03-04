namespace Tao_Bot_Maker.View
{
    partial class ActionLoopPanel
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
            this.label_Sequence = new System.Windows.Forms.Label();
            this.label_RepeatNumber = new System.Windows.Forms.Label();
            this.flatComboBox_SequenceName = new DarkModeForms.FlatComboBox();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_RepeatNumber = new System.Windows.Forms.NumericUpDown();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RepeatNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Sequence
            // 
            this.label_Sequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Sequence.AutoSize = true;
            this.label_Sequence.Location = new System.Drawing.Point(3, 55);
            this.label_Sequence.Name = "label_Sequence";
            this.label_Sequence.Size = new System.Drawing.Size(234, 16);
            this.label_Sequence.TabIndex = 2;
            this.label_Sequence.Text = "Séquence :";
            this.label_Sequence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_RepeatNumber
            // 
            this.label_RepeatNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RepeatNumber.AutoSize = true;
            this.label_RepeatNumber.Location = new System.Drawing.Point(3, 13);
            this.label_RepeatNumber.Name = "label_RepeatNumber";
            this.label_RepeatNumber.Size = new System.Drawing.Size(234, 16);
            this.label_RepeatNumber.TabIndex = 0;
            this.label_RepeatNumber.Text = "Nombre de répétitions :";
            this.label_RepeatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flatComboBox_SequenceName
            // 
            this.flatComboBox_SequenceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flatComboBox_SequenceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox_SequenceName.FormattingEnabled = true;
            this.flatComboBox_SequenceName.Location = new System.Drawing.Point(243, 51);
            this.flatComboBox_SequenceName.Name = "flatComboBox_SequenceName";
            this.flatComboBox_SequenceName.Size = new System.Drawing.Size(235, 24);
            this.flatComboBox_SequenceName.TabIndex = 4;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.label_RepeatNumber, 0, 0);
            this.tableLayout.Controls.Add(this.flatComboBox_SequenceName, 1, 1);
            this.tableLayout.Controls.Add(this.label_Sequence, 0, 1);
            this.tableLayout.Controls.Add(this.numericUpDown_RepeatNumber, 1, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(8, 8);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Size = new System.Drawing.Size(481, 84);
            this.tableLayout.TabIndex = 5;
            // 
            // numericUpDown_RepeatNumber
            // 
            this.numericUpDown_RepeatNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_RepeatNumber.Location = new System.Drawing.Point(243, 10);
            this.numericUpDown_RepeatNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_RepeatNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_RepeatNumber.Name = "numericUpDown_RepeatNumber";
            this.numericUpDown_RepeatNumber.Size = new System.Drawing.Size(235, 22);
            this.numericUpDown_RepeatNumber.TabIndex = 5;
            this.numericUpDown_RepeatNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ActionLoopPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActionLoopPanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(497, 100);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RepeatNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_Sequence;
        private System.Windows.Forms.Label label_RepeatNumber;
        private DarkModeForms.FlatComboBox flatComboBox_SequenceName;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.NumericUpDown numericUpDown_RepeatNumber;
    }
}
