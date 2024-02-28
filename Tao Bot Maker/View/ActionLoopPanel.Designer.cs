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
            this.textBoxPanelBoucle_NbRepetition = new System.Windows.Forms.TextBox();
            this.label_NumberRepetitions = new System.Windows.Forms.Label();
            this.flatComboBoxPanelActionLoopSequence = new DarkModeForms.FlatComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Sequence
            // 
            this.label_Sequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Sequence.AutoSize = true;
            this.label_Sequence.Location = new System.Drawing.Point(3, 67);
            this.label_Sequence.Name = "label_Sequence";
            this.label_Sequence.Size = new System.Drawing.Size(242, 16);
            this.label_Sequence.TabIndex = 2;
            this.label_Sequence.Text = "Séquence :";
            this.label_Sequence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPanelBoucle_NbRepetition
            // 
            this.textBoxPanelBoucle_NbRepetition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPanelBoucle_NbRepetition.Location = new System.Drawing.Point(251, 14);
            this.textBoxPanelBoucle_NbRepetition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPanelBoucle_NbRepetition.Name = "textBoxPanelBoucle_NbRepetition";
            this.textBoxPanelBoucle_NbRepetition.Size = new System.Drawing.Size(243, 22);
            this.textBoxPanelBoucle_NbRepetition.TabIndex = 1;
            // 
            // label_NumberRepetitions
            // 
            this.label_NumberRepetitions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_NumberRepetitions.AutoSize = true;
            this.label_NumberRepetitions.Location = new System.Drawing.Point(3, 17);
            this.label_NumberRepetitions.Name = "label_NumberRepetitions";
            this.label_NumberRepetitions.Size = new System.Drawing.Size(242, 16);
            this.label_NumberRepetitions.TabIndex = 0;
            this.label_NumberRepetitions.Text = "Nombre de répétitions :";
            this.label_NumberRepetitions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flatComboBoxPanelActionLoopSequence
            // 
            this.flatComboBoxPanelActionLoopSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flatComboBoxPanelActionLoopSequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBoxPanelActionLoopSequence.FormattingEnabled = true;
            this.flatComboBoxPanelActionLoopSequence.Location = new System.Drawing.Point(251, 63);
            this.flatComboBoxPanelActionLoopSequence.Name = "flatComboBoxPanelActionLoopSequence";
            this.flatComboBoxPanelActionLoopSequence.Size = new System.Drawing.Size(243, 24);
            this.flatComboBoxPanelActionLoopSequence.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_NumberRepetitions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flatComboBoxPanelActionLoopSequence, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPanelBoucle_NbRepetition, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Sequence, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 100);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ActionLoopPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ActionLoopPanel";
            this.Size = new System.Drawing.Size(497, 100);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_Sequence;
        private System.Windows.Forms.TextBox textBoxPanelBoucle_NbRepetition;
        private System.Windows.Forms.Label label_NumberRepetitions;
        private DarkModeForms.FlatComboBox flatComboBoxPanelActionLoopSequence;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
