namespace Tao_Bot_Maker.View
{
    partial class ActionSequencePanel
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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flatComboBox_SequenceName = new DarkModeForms.FlatComboBox();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Sequence
            // 
            this.label_Sequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Sequence.AutoSize = true;
            this.label_Sequence.Location = new System.Drawing.Point(3, 9);
            this.label_Sequence.Name = "label_Sequence";
            this.label_Sequence.Size = new System.Drawing.Size(234, 16);
            this.label_Sequence.TabIndex = 20;
            this.label_Sequence.Text = "Séquence :";
            this.label_Sequence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.label_Sequence, 0, 0);
            this.tableLayout.Controls.Add(this.flatComboBox_SequenceName, 1, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(8, 8);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayout.Size = new System.Drawing.Size(481, 34);
            this.tableLayout.TabIndex = 21;
            // 
            // flatComboBox_SequenceName
            // 
            this.flatComboBox_SequenceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flatComboBox_SequenceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox_SequenceName.FormattingEnabled = true;
            this.flatComboBox_SequenceName.Location = new System.Drawing.Point(243, 5);
            this.flatComboBox_SequenceName.Name = "flatComboBox_SequenceName";
            this.flatComboBox_SequenceName.Size = new System.Drawing.Size(235, 24);
            this.flatComboBox_SequenceName.TabIndex = 21;
            // 
            // ActionSequencePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActionSequencePanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(497, 50);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_Sequence;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private DarkModeForms.FlatComboBox flatComboBox_SequenceName;
    }
}
