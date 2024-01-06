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
            this.comboBoxPanelActionSequence = new System.Windows.Forms.ComboBox();
            this.label_Sequence = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(-130, 49);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Séquence :";
            // 
            // comboBoxPanelActionSequence
            // 
            this.comboBoxPanelActionSequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPanelActionSequence.FormattingEnabled = true;
            this.comboBoxPanelActionSequence.Location = new System.Drawing.Point(68, 2);
            this.comboBoxPanelActionSequence.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPanelActionSequence.Name = "comboBoxPanelActionSequence";
            this.comboBoxPanelActionSequence.Size = new System.Drawing.Size(214, 21);
            this.comboBoxPanelActionSequence.TabIndex = 18;
            // 
            // label_Sequence
            // 
            this.label_Sequence.AutoSize = true;
            this.label_Sequence.Location = new System.Drawing.Point(2, 5);
            this.label_Sequence.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Sequence.Name = "label_Sequence";
            this.label_Sequence.Size = new System.Drawing.Size(62, 13);
            this.label_Sequence.TabIndex = 20;
            this.label_Sequence.Text = "Séquence :";
            // 
            // ActionSequencePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Sequence);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboBoxPanelActionSequence);
            this.Name = "ActionSequencePanel";
            this.Size = new System.Drawing.Size(303, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxPanelActionSequence;
        private System.Windows.Forms.Label label_Sequence;
    }
}
