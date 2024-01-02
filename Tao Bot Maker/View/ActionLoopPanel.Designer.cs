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
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxPanelBoucle_NbRepetition = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
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
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(2, 36);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Séquence :";
            // 
            // textBoxPanelBoucle_NbRepetition
            // 
            this.textBoxPanelBoucle_NbRepetition.Location = new System.Drawing.Point(134, 13);
            this.textBoxPanelBoucle_NbRepetition.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPanelBoucle_NbRepetition.Name = "textBoxPanelBoucle_NbRepetition";
            this.textBoxPanelBoucle_NbRepetition.Size = new System.Drawing.Size(214, 20);
            this.textBoxPanelBoucle_NbRepetition.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(2, 15);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(116, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Nombre de répétitions :";
            // 
            // ActionLoopPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxPanelActionLoopSequence);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxPanelBoucle_NbRepetition);
            this.Name = "ActionLoopPanel";
            this.Size = new System.Drawing.Size(361, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPanelActionLoopSequence;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxPanelBoucle_NbRepetition;
        private System.Windows.Forms.Label label20;
    }
}
