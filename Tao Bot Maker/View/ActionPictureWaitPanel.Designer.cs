namespace Tao_Bot_Maker.View
{
    partial class ActionPictureWaitPanel
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
            this.buttonActionPictureWaitShowZone = new System.Windows.Forms.Button();
            this.buttonActionPictureWaitClearDrawing = new System.Windows.Forms.Button();
            this.label_SequenceIfExpired = new System.Windows.Forms.Label();
            this.buttonActionPictureWaitFindImage = new System.Windows.Forms.Button();
            this.textBoxActionPictureWaitWaitTime = new System.Windows.Forms.TextBox();
            this.label_ExpirationTime = new System.Windows.Forms.Label();
            this.textBoxPanelActionPictureWaitThreshold = new System.Windows.Forms.TextBox();
            this.comboBoxActionPictureWaitSequenceIfExpired = new System.Windows.Forms.ComboBox();
            this.label_Threshold = new System.Windows.Forms.Label();
            this.label_Y2 = new System.Windows.Forms.Label();
            this.buttonActionPictureWaitImagePath = new System.Windows.Forms.Button();
            this.textBoxActionPictureWaitY2 = new System.Windows.Forms.TextBox();
            this.label_Y1 = new System.Windows.Forms.Label();
            this.textBoxActionPictureWaitX2 = new System.Windows.Forms.TextBox();
            this.pictureBoxActionPictureWaitImage = new System.Windows.Forms.PictureBox();
            this.label_X2 = new System.Windows.Forms.Label();
            this.textBoxActionPictureWaitY1 = new System.Windows.Forms.TextBox();
            this.label_X1 = new System.Windows.Forms.Label();
            this.textBoxActionPictureWaitX1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActionPictureWaitImage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonActionPictureWaitShowZone
            // 
            this.buttonActionPictureWaitShowZone.Location = new System.Drawing.Point(7, 205);
            this.buttonActionPictureWaitShowZone.Margin = new System.Windows.Forms.Padding(2);
            this.buttonActionPictureWaitShowZone.Name = "buttonActionPictureWaitShowZone";
            this.buttonActionPictureWaitShowZone.Size = new System.Drawing.Size(347, 24);
            this.buttonActionPictureWaitShowZone.TabIndex = 17;
            this.buttonActionPictureWaitShowZone.Text = "Afficher la zone de recherche";
            this.buttonActionPictureWaitShowZone.UseVisualStyleBackColor = false;
            this.buttonActionPictureWaitShowZone.Click += new System.EventHandler(this.buttonPanelActionImage_ShowZone_Click);
            // 
            // buttonActionPictureWaitClearDrawing
            // 
            this.buttonActionPictureWaitClearDrawing.Location = new System.Drawing.Point(195, 58);
            this.buttonActionPictureWaitClearDrawing.Margin = new System.Windows.Forms.Padding(2);
            this.buttonActionPictureWaitClearDrawing.Name = "buttonActionPictureWaitClearDrawing";
            this.buttonActionPictureWaitClearDrawing.Size = new System.Drawing.Size(159, 24);
            this.buttonActionPictureWaitClearDrawing.TabIndex = 24;
            this.buttonActionPictureWaitClearDrawing.Text = "Effacer les zones";
            this.buttonActionPictureWaitClearDrawing.UseVisualStyleBackColor = false;
            this.buttonActionPictureWaitClearDrawing.Click += new System.EventHandler(this.buttonActionPictureWaitClearDrawing_Click);
            // 
            // label_SequenceIfExpired
            // 
            this.label_SequenceIfExpired.AutoSize = true;
            this.label_SequenceIfExpired.Location = new System.Drawing.Point(9, 185);
            this.label_SequenceIfExpired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SequenceIfExpired.Name = "label_SequenceIfExpired";
            this.label_SequenceIfExpired.Size = new System.Drawing.Size(120, 13);
            this.label_SequenceIfExpired.TabIndex = 15;
            this.label_SequenceIfExpired.Text = "Séquence si expiration :";
            // 
            // buttonActionPictureWaitFindImage
            // 
            this.buttonActionPictureWaitFindImage.Location = new System.Drawing.Point(195, 29);
            this.buttonActionPictureWaitFindImage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonActionPictureWaitFindImage.Name = "buttonActionPictureWaitFindImage";
            this.buttonActionPictureWaitFindImage.Size = new System.Drawing.Size(159, 25);
            this.buttonActionPictureWaitFindImage.TabIndex = 23;
            this.buttonActionPictureWaitFindImage.Text = "Chercher l\'image";
            this.buttonActionPictureWaitFindImage.UseVisualStyleBackColor = false;
            this.buttonActionPictureWaitFindImage.Click += new System.EventHandler(this.buttonActionPictureWaitFindImage_Click);
            // 
            // textBoxActionPictureWaitWaitTime
            // 
            this.textBoxActionPictureWaitWaitTime.Location = new System.Drawing.Point(277, 160);
            this.textBoxActionPictureWaitWaitTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxActionPictureWaitWaitTime.Name = "textBoxActionPictureWaitWaitTime";
            this.textBoxActionPictureWaitWaitTime.Size = new System.Drawing.Size(79, 20);
            this.textBoxActionPictureWaitWaitTime.TabIndex = 14;
            // 
            // label_ExpirationTime
            // 
            this.label_ExpirationTime.AutoSize = true;
            this.label_ExpirationTime.Location = new System.Drawing.Point(192, 162);
            this.label_ExpirationTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ExpirationTime.Name = "label_ExpirationTime";
            this.label_ExpirationTime.Size = new System.Drawing.Size(85, 13);
            this.label_ExpirationTime.TabIndex = 13;
            this.label_ExpirationTime.Text = "Expiration (sec) :";
            // 
            // textBoxPanelActionPictureWaitThreshold
            // 
            this.textBoxPanelActionPictureWaitThreshold.Location = new System.Drawing.Point(84, 160);
            this.textBoxPanelActionPictureWaitThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPanelActionPictureWaitThreshold.Name = "textBoxPanelActionPictureWaitThreshold";
            this.textBoxPanelActionPictureWaitThreshold.Size = new System.Drawing.Size(79, 20);
            this.textBoxPanelActionPictureWaitThreshold.TabIndex = 12;
            this.textBoxPanelActionPictureWaitThreshold.Text = "100";
            // 
            // comboBoxActionPictureWaitSequenceIfExpired
            // 
            this.comboBoxActionPictureWaitSequenceIfExpired.BackColor = System.Drawing.Color.DimGray;
            this.comboBoxActionPictureWaitSequenceIfExpired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActionPictureWaitSequenceIfExpired.ForeColor = System.Drawing.Color.White;
            this.comboBoxActionPictureWaitSequenceIfExpired.FormattingEnabled = true;
            this.comboBoxActionPictureWaitSequenceIfExpired.Location = new System.Drawing.Point(142, 183);
            this.comboBoxActionPictureWaitSequenceIfExpired.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxActionPictureWaitSequenceIfExpired.Name = "comboBoxActionPictureWaitSequenceIfExpired";
            this.comboBoxActionPictureWaitSequenceIfExpired.Size = new System.Drawing.Size(214, 21);
            this.comboBoxActionPictureWaitSequenceIfExpired.TabIndex = 12;
            // 
            // label_Threshold
            // 
            this.label_Threshold.AutoSize = true;
            this.label_Threshold.Location = new System.Drawing.Point(9, 162);
            this.label_Threshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Threshold.Name = "label_Threshold";
            this.label_Threshold.Size = new System.Drawing.Size(61, 13);
            this.label_Threshold.TabIndex = 11;
            this.label_Threshold.Text = "Tolerance :";
            // 
            // label_Y2
            // 
            this.label_Y2.AutoSize = true;
            this.label_Y2.Location = new System.Drawing.Point(192, 141);
            this.label_Y2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Y2.Name = "label_Y2";
            this.label_Y2.Size = new System.Drawing.Size(24, 13);
            this.label_Y2.TabIndex = 10;
            this.label_Y2.Text = "y2 :";
            // 
            // buttonActionPictureWaitImagePath
            // 
            this.buttonActionPictureWaitImagePath.Location = new System.Drawing.Point(7, 3);
            this.buttonActionPictureWaitImagePath.Margin = new System.Windows.Forms.Padding(2);
            this.buttonActionPictureWaitImagePath.Name = "buttonActionPictureWaitImagePath";
            this.buttonActionPictureWaitImagePath.Size = new System.Drawing.Size(347, 22);
            this.buttonActionPictureWaitImagePath.TabIndex = 4;
            this.buttonActionPictureWaitImagePath.Text = "Image";
            this.buttonActionPictureWaitImagePath.UseVisualStyleBackColor = false;
            this.buttonActionPictureWaitImagePath.Click += new System.EventHandler(this.buttonActionPictureWaitImagePath_Click);
            // 
            // textBoxActionPictureWaitY2
            // 
            this.textBoxActionPictureWaitY2.Location = new System.Drawing.Point(277, 139);
            this.textBoxActionPictureWaitY2.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxActionPictureWaitY2.Name = "textBoxActionPictureWaitY2";
            this.textBoxActionPictureWaitY2.Size = new System.Drawing.Size(79, 20);
            this.textBoxActionPictureWaitY2.TabIndex = 9;
            // 
            // label_Y1
            // 
            this.label_Y1.AutoSize = true;
            this.label_Y1.Location = new System.Drawing.Point(192, 120);
            this.label_Y1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Y1.Name = "label_Y1";
            this.label_Y1.Size = new System.Drawing.Size(24, 13);
            this.label_Y1.TabIndex = 8;
            this.label_Y1.Text = "y1 :";
            // 
            // textBoxActionPictureWaitX2
            // 
            this.textBoxActionPictureWaitX2.Location = new System.Drawing.Point(84, 139);
            this.textBoxActionPictureWaitX2.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxActionPictureWaitX2.Name = "textBoxActionPictureWaitX2";
            this.textBoxActionPictureWaitX2.Size = new System.Drawing.Size(79, 20);
            this.textBoxActionPictureWaitX2.TabIndex = 7;
            // 
            // pictureBoxActionPictureWaitImage
            // 
            this.pictureBoxActionPictureWaitImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxActionPictureWaitImage.Location = new System.Drawing.Point(12, 29);
            this.pictureBoxActionPictureWaitImage.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxActionPictureWaitImage.Name = "pictureBoxActionPictureWaitImage";
            this.pictureBoxActionPictureWaitImage.Size = new System.Drawing.Size(150, 85);
            this.pictureBoxActionPictureWaitImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxActionPictureWaitImage.TabIndex = 2;
            this.pictureBoxActionPictureWaitImage.TabStop = false;
            // 
            // label_X2
            // 
            this.label_X2.AutoSize = true;
            this.label_X2.Location = new System.Drawing.Point(9, 141);
            this.label_X2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_X2.Name = "label_X2";
            this.label_X2.Size = new System.Drawing.Size(24, 13);
            this.label_X2.TabIndex = 6;
            this.label_X2.Text = "x2 :";
            // 
            // textBoxActionPictureWaitY1
            // 
            this.textBoxActionPictureWaitY1.Location = new System.Drawing.Point(277, 119);
            this.textBoxActionPictureWaitY1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxActionPictureWaitY1.Name = "textBoxActionPictureWaitY1";
            this.textBoxActionPictureWaitY1.Size = new System.Drawing.Size(79, 20);
            this.textBoxActionPictureWaitY1.TabIndex = 5;
            // 
            // label_X1
            // 
            this.label_X1.AutoSize = true;
            this.label_X1.Location = new System.Drawing.Point(9, 120);
            this.label_X1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_X1.Name = "label_X1";
            this.label_X1.Size = new System.Drawing.Size(27, 13);
            this.label_X1.TabIndex = 4;
            this.label_X1.Text = "x1 : ";
            // 
            // textBoxActionPictureWaitX1
            // 
            this.textBoxActionPictureWaitX1.Location = new System.Drawing.Point(84, 119);
            this.textBoxActionPictureWaitX1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxActionPictureWaitX1.Name = "textBoxActionPictureWaitX1";
            this.textBoxActionPictureWaitX1.Size = new System.Drawing.Size(79, 20);
            this.textBoxActionPictureWaitX1.TabIndex = 3;
            // 
            // ActionPictureWaitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonActionPictureWaitShowZone);
            this.Controls.Add(this.buttonActionPictureWaitClearDrawing);
            this.Controls.Add(this.pictureBoxActionPictureWaitImage);
            this.Controls.Add(this.label_SequenceIfExpired);
            this.Controls.Add(this.textBoxActionPictureWaitX1);
            this.Controls.Add(this.buttonActionPictureWaitFindImage);
            this.Controls.Add(this.label_X1);
            this.Controls.Add(this.textBoxActionPictureWaitWaitTime);
            this.Controls.Add(this.textBoxActionPictureWaitY1);
            this.Controls.Add(this.label_ExpirationTime);
            this.Controls.Add(this.label_X2);
            this.Controls.Add(this.textBoxPanelActionPictureWaitThreshold);
            this.Controls.Add(this.textBoxActionPictureWaitX2);
            this.Controls.Add(this.comboBoxActionPictureWaitSequenceIfExpired);
            this.Controls.Add(this.label_Y1);
            this.Controls.Add(this.label_Threshold);
            this.Controls.Add(this.textBoxActionPictureWaitY2);
            this.Controls.Add(this.label_Y2);
            this.Controls.Add(this.buttonActionPictureWaitImagePath);
            this.Name = "ActionPictureWaitPanel";
            this.Size = new System.Drawing.Size(366, 238);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActionPictureWaitImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonActionPictureWaitShowZone;
        private System.Windows.Forms.Button buttonActionPictureWaitClearDrawing;
        private System.Windows.Forms.Label label_SequenceIfExpired;
        private System.Windows.Forms.Button buttonActionPictureWaitFindImage;
        private System.Windows.Forms.TextBox textBoxActionPictureWaitWaitTime;
        private System.Windows.Forms.Label label_ExpirationTime;
        private System.Windows.Forms.TextBox textBoxPanelActionPictureWaitThreshold;
        private System.Windows.Forms.ComboBox comboBoxActionPictureWaitSequenceIfExpired;
        private System.Windows.Forms.Label label_Threshold;
        private System.Windows.Forms.Label label_Y2;
        private System.Windows.Forms.Button buttonActionPictureWaitImagePath;
        private System.Windows.Forms.TextBox textBoxActionPictureWaitY2;
        private System.Windows.Forms.Label label_Y1;
        private System.Windows.Forms.TextBox textBoxActionPictureWaitX2;
        private System.Windows.Forms.PictureBox pictureBoxActionPictureWaitImage;
        private System.Windows.Forms.Label label_X2;
        private System.Windows.Forms.TextBox textBoxActionPictureWaitY1;
        private System.Windows.Forms.Label label_X1;
        private System.Windows.Forms.TextBox textBoxActionPictureWaitX1;
    }
}
