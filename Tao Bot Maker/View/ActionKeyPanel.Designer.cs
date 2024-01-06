namespace Tao_Bot_Maker.View
{
    partial class ActionKeyPanel
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
            this.textBoxPanelActionKey = new System.Windows.Forms.TextBox();
            this.label_Key = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPanelActionKey
            // 
            this.textBoxPanelActionKey.Location = new System.Drawing.Point(56, 6);
            this.textBoxPanelActionKey.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPanelActionKey.MaxLength = 1;
            this.textBoxPanelActionKey.Name = "textBoxPanelActionKey";
            this.textBoxPanelActionKey.Size = new System.Drawing.Size(179, 20);
            this.textBoxPanelActionKey.TabIndex = 1;
            // 
            // label_Key
            // 
            this.label_Key.AutoSize = true;
            this.label_Key.Location = new System.Drawing.Point(2, 9);
            this.label_Key.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Key.Name = "label_Key";
            this.label_Key.Size = new System.Drawing.Size(50, 13);
            this.label_Key.TabIndex = 2;
            this.label_Key.Text = "Touche :";
            // 
            // ActionKeyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxPanelActionKey);
            this.Controls.Add(this.label_Key);
            this.Name = "ActionKeyPanel";
            this.Size = new System.Drawing.Size(248, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPanelActionKey;
        private System.Windows.Forms.Label label_Key;
    }
}
