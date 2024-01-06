namespace Tao_Bot_Maker.View
{
    partial class ActionWaitPanel
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
            this.label_WaitTime = new System.Windows.Forms.Label();
            this.textBoxWaitTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_WaitTime
            // 
            this.label_WaitTime.AutoSize = true;
            this.label_WaitTime.Location = new System.Drawing.Point(2, 9);
            this.label_WaitTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_WaitTime.Name = "label_WaitTime";
            this.label_WaitTime.Size = new System.Drawing.Size(59, 13);
            this.label_WaitTime.TabIndex = 6;
            this.label_WaitTime.Text = "Délai (ms) :";
            // 
            // textBoxWaitTime
            // 
            this.textBoxWaitTime.Location = new System.Drawing.Point(65, 6);
            this.textBoxWaitTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxWaitTime.Name = "textBoxWaitTime";
            this.textBoxWaitTime.Size = new System.Drawing.Size(139, 20);
            this.textBoxWaitTime.TabIndex = 5;
            // 
            // ActionWaitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_WaitTime);
            this.Controls.Add(this.textBoxWaitTime);
            this.Name = "ActionWaitPanel";
            this.Size = new System.Drawing.Size(211, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_WaitTime;
        private System.Windows.Forms.TextBox textBoxWaitTime;
    }
}
