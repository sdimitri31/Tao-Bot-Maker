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
            this.comboBoxPanelActionLoopSequence = new System.Windows.Forms.ComboBox();
            this.label_Sequence = new System.Windows.Forms.Label();
            this.textBoxPanelBoucle_NbRepetition = new System.Windows.Forms.TextBox();
            this.label_NumberRepetitions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxPanelActionLoopSequence
            // 
            this.comboBoxPanelActionLoopSequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPanelActionLoopSequence.FormattingEnabled = true;
            this.comboBoxPanelActionLoopSequence.Location = new System.Drawing.Point(134, 34);
            this.comboBoxPanelActionLoopSequence.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPanelActionLoopSequence.Name = "comboBoxPanelActionLoopSequence";
            this.comboBoxPanelActionLoopSequence.Size = new System.Drawing.Size(214, 21);
            this.comboBoxPanelActionLoopSequence.TabIndex = 3;
            // 
            // label_Sequence
            // 
            this.label_Sequence.AutoSize = true;
            this.label_Sequence.Location = new System.Drawing.Point(2, 36);
            this.label_Sequence.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Sequence.Name = "label_Sequence";
            this.label_Sequence.Size = new System.Drawing.Size(62, 13);
            this.label_Sequence.TabIndex = 2;
            this.label_Sequence.Text = "Séquence :";
            // 
            // textBoxPanelBoucle_NbRepetition
            // 
            this.textBoxPanelBoucle_NbRepetition.Location = new System.Drawing.Point(134, 13);
            this.textBoxPanelBoucle_NbRepetition.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPanelBoucle_NbRepetition.Name = "textBoxPanelBoucle_NbRepetition";
            this.textBoxPanelBoucle_NbRepetition.Size = new System.Drawing.Size(214, 20);
            this.textBoxPanelBoucle_NbRepetition.TabIndex = 1;
            // 
            // label_NumberRepetitions
            // 
            this.label_NumberRepetitions.AutoSize = true;
            this.label_NumberRepetitions.Location = new System.Drawing.Point(2, 15);
            this.label_NumberRepetitions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_NumberRepetitions.Name = "label_NumberRepetitions";
            this.label_NumberRepetitions.Size = new System.Drawing.Size(116, 13);
            this.label_NumberRepetitions.TabIndex = 0;
            this.label_NumberRepetitions.Text = "Nombre de répétitions :";
            // 
            // ActionLoopPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxPanelActionLoopSequence);
            this.Controls.Add(this.label_Sequence);
            this.Controls.Add(this.label_NumberRepetitions);
            this.Controls.Add(this.textBoxPanelBoucle_NbRepetition);
            this.Name = "ActionLoopPanel";
            this.Size = new System.Drawing.Size(361, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPanelActionLoopSequence;
        private System.Windows.Forms.Label label_Sequence;
        private System.Windows.Forms.TextBox textBoxPanelBoucle_NbRepetition;
        private System.Windows.Forms.Label label_NumberRepetitions;
    }
}
