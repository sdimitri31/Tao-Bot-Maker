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
            this.label16 = new System.Windows.Forms.Label();
            this.label_Sequence = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flatComboBoxPanelActionSequence = new DarkModeForms.FlatComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(-173, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 16);
            this.label16.TabIndex = 19;
            this.label16.Text = "Séquence :";
            // 
            // label_Sequence
            // 
            this.label_Sequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Sequence.AutoSize = true;
            this.label_Sequence.Location = new System.Drawing.Point(3, 17);
            this.label_Sequence.Name = "label_Sequence";
            this.label_Sequence.Size = new System.Drawing.Size(242, 16);
            this.label_Sequence.TabIndex = 20;
            this.label_Sequence.Text = "Séquence :";
            this.label_Sequence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_Sequence, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flatComboBoxPanelActionSequence, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 50);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // flatComboBoxPanelActionSequence
            // 
            this.flatComboBoxPanelActionSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flatComboBoxPanelActionSequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBoxPanelActionSequence.FormattingEnabled = true;
            this.flatComboBoxPanelActionSequence.Location = new System.Drawing.Point(251, 13);
            this.flatComboBoxPanelActionSequence.Name = "flatComboBoxPanelActionSequence";
            this.flatComboBoxPanelActionSequence.Size = new System.Drawing.Size(243, 24);
            this.flatComboBoxPanelActionSequence.TabIndex = 21;
            // 
            // ActionSequencePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label16);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ActionSequencePanel";
            this.Size = new System.Drawing.Size(497, 50);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_Sequence;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DarkModeForms.FlatComboBox flatComboBoxPanelActionSequence;
    }
}
