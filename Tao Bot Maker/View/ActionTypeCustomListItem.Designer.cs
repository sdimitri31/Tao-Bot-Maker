namespace Tao_Bot_Maker.View
{
    partial class ActionTypeCustomListItem
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.Location = new System.Drawing.Point(38, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(109, 25);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "label1";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Location = new System.Drawing.Point(5, 2);
            this.iconPictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(25, 25);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // ActionTypeCustomListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.iconPictureBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ActionTypeCustomListItem";
            this.Size = new System.Drawing.Size(150, 30);
            this.MouseEnter += new System.EventHandler(this.ActionTypeCustomListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ActionTypeCustomListItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label nameLabel;
    }
}
