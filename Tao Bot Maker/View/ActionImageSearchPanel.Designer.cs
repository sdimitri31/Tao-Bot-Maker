namespace Tao_Bot_Maker.View
{
    partial class ActionImageSearchPanel
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
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            this.button_ShowArea = new System.Windows.Forms.Button();
            this.label_IfNotFound = new System.Windows.Forms.Label();
            this.label_IfFound = new System.Windows.Forms.Label();
            this.label_Threshold = new System.Windows.Forms.Label();
            this.label_Y2 = new System.Windows.Forms.Label();
            this.button_PathImage = new System.Windows.Forms.Button();
            this.label_Y1 = new System.Windows.Forms.Label();
            this.label_X2 = new System.Windows.Forms.Label();
            this.label_X1 = new System.Windows.Forms.Label();
            this.button_ClearArea = new System.Windows.Forms.Button();
            this.button_FindImage = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flatComboBox_IfFound = new DarkModeForms.FlatComboBox();
            this.flatComboBox_IfNotFound = new DarkModeForms.FlatComboBox();
            this.numericUpDown_X1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Y1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_X2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Y2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Threshold = new System.Windows.Forms.NumericUpDown();
            this.label_Expiration = new System.Windows.Forms.Label();
            this.numericUpDown_Expiration = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Expiration)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel.SetColumnSpan(this.pictureBox_Image, 2);
            this.pictureBox_Image.Location = new System.Drawing.Point(243, 2);
            this.pictureBox_Image.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.tableLayoutPanel.SetRowSpan(this.pictureBox_Image, 3);
            this.pictureBox_Image.Size = new System.Drawing.Size(235, 110);
            this.pictureBox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Image.TabIndex = 25;
            this.pictureBox_Image.TabStop = false;
            // 
            // button_ShowArea
            // 
            this.button_ShowArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ShowArea.Location = new System.Drawing.Point(123, 273);
            this.button_ShowArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ShowArea.Name = "button_ShowArea";
            this.button_ShowArea.Size = new System.Drawing.Size(114, 28);
            this.button_ShowArea.TabIndex = 12;
            this.button_ShowArea.Text = "Afficher la zone de recherche";
            this.button_ShowArea.UseVisualStyleBackColor = false;
            this.button_ShowArea.Click += new System.EventHandler(this.Button_ShowArea_Click);
            // 
            // label_IfNotFound
            // 
            this.label_IfNotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_IfNotFound.AutoSize = true;
            this.label_IfNotFound.Location = new System.Drawing.Point(243, 279);
            this.label_IfNotFound.Name = "label_IfNotFound";
            this.label_IfNotFound.Size = new System.Drawing.Size(114, 16);
            this.label_IfNotFound.TabIndex = 15;
            this.label_IfNotFound.Text = "Sinon séquence :";
            this.label_IfNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_IfFound
            // 
            this.label_IfFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_IfFound.AutoSize = true;
            this.label_IfFound.Location = new System.Drawing.Point(243, 231);
            this.label_IfFound.Name = "label_IfFound";
            this.label_IfFound.Size = new System.Drawing.Size(114, 32);
            this.label_IfFound.TabIndex = 14;
            this.label_IfFound.Text = "Séquence si image :";
            this.label_IfFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Threshold
            // 
            this.label_Threshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Threshold.AutoSize = true;
            this.label_Threshold.Location = new System.Drawing.Point(243, 125);
            this.label_Threshold.Name = "label_Threshold";
            this.label_Threshold.Size = new System.Drawing.Size(114, 16);
            this.label_Threshold.TabIndex = 11;
            this.label_Threshold.Text = "Tolerance :";
            this.label_Threshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Y2
            // 
            this.label_Y2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Y2.AutoSize = true;
            this.label_Y2.Location = new System.Drawing.Point(3, 201);
            this.label_Y2.Name = "label_Y2";
            this.label_Y2.Size = new System.Drawing.Size(114, 16);
            this.label_Y2.TabIndex = 10;
            this.label_Y2.Text = "y2 :";
            this.label_Y2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_PathImage
            // 
            this.button_PathImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.button_PathImage, 2);
            this.button_PathImage.Location = new System.Drawing.Point(3, 24);
            this.button_PathImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_PathImage.Name = "button_PathImage";
            this.tableLayoutPanel.SetRowSpan(this.button_PathImage, 2);
            this.button_PathImage.Size = new System.Drawing.Size(234, 28);
            this.button_PathImage.TabIndex = 1;
            this.button_PathImage.Text = "Image";
            this.button_PathImage.UseVisualStyleBackColor = false;
            this.button_PathImage.Click += new System.EventHandler(this.Button_PathImage_Click);
            // 
            // label_Y1
            // 
            this.label_Y1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Y1.AutoSize = true;
            this.label_Y1.Location = new System.Drawing.Point(3, 125);
            this.label_Y1.Name = "label_Y1";
            this.label_Y1.Size = new System.Drawing.Size(114, 16);
            this.label_Y1.TabIndex = 8;
            this.label_Y1.Text = "y1 :";
            this.label_Y1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_X2
            // 
            this.label_X2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_X2.AutoSize = true;
            this.label_X2.Location = new System.Drawing.Point(3, 163);
            this.label_X2.Name = "label_X2";
            this.label_X2.Size = new System.Drawing.Size(114, 16);
            this.label_X2.TabIndex = 6;
            this.label_X2.Text = "x2 :";
            this.label_X2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_X1
            // 
            this.label_X1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_X1.AutoSize = true;
            this.label_X1.Location = new System.Drawing.Point(3, 87);
            this.label_X1.Name = "label_X1";
            this.label_X1.Size = new System.Drawing.Size(114, 16);
            this.label_X1.TabIndex = 2;
            this.label_X1.Text = "x1 :";
            this.label_X1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_ClearArea
            // 
            this.button_ClearArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ClearArea.Location = new System.Drawing.Point(3, 273);
            this.button_ClearArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ClearArea.Name = "button_ClearArea";
            this.button_ClearArea.Size = new System.Drawing.Size(114, 28);
            this.button_ClearArea.TabIndex = 11;
            this.button_ClearArea.Text = "Effacer les zones";
            this.button_ClearArea.UseVisualStyleBackColor = false;
            this.button_ClearArea.Click += new System.EventHandler(this.Button_ClearArea_Click);
            // 
            // button_FindImage
            // 
            this.button_FindImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.button_FindImage, 2);
            this.button_FindImage.Location = new System.Drawing.Point(3, 233);
            this.button_FindImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_FindImage.Name = "button_FindImage";
            this.button_FindImage.Size = new System.Drawing.Size(234, 28);
            this.button_FindImage.TabIndex = 10;
            this.button_FindImage.Text = "Chercher l\'image";
            this.button_FindImage.UseVisualStyleBackColor = false;
            this.button_FindImage.Click += new System.EventHandler(this.Button_FindImage_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(this.button_ShowArea, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.label_IfFound, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.pictureBox_Image, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.button_FindImage, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.button_ClearArea, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.label_X1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label_Y1, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label_X2, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.label_Y2, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.label_Threshold, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.label_IfNotFound, 2, 7);
            this.tableLayoutPanel.Controls.Add(this.flatComboBox_IfFound, 3, 6);
            this.tableLayoutPanel.Controls.Add(this.flatComboBox_IfNotFound, 3, 7);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_X1, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_Y1, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_X2, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_Y2, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_Threshold, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.button_PathImage, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label_Expiration, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_Expiration, 3, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 8;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(481, 309);
            this.tableLayoutPanel.TabIndex = 27;
            // 
            // flatComboBox_IfFound
            // 
            this.flatComboBox_IfFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flatComboBox_IfFound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox_IfFound.FormattingEnabled = true;
            this.flatComboBox_IfFound.Location = new System.Drawing.Point(363, 235);
            this.flatComboBox_IfFound.Name = "flatComboBox_IfFound";
            this.flatComboBox_IfFound.Size = new System.Drawing.Size(115, 24);
            this.flatComboBox_IfFound.TabIndex = 8;
            // 
            // flatComboBox_IfNotFound
            // 
            this.flatComboBox_IfNotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flatComboBox_IfNotFound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox_IfNotFound.FormattingEnabled = true;
            this.flatComboBox_IfNotFound.Location = new System.Drawing.Point(363, 275);
            this.flatComboBox_IfNotFound.Name = "flatComboBox_IfNotFound";
            this.flatComboBox_IfNotFound.Size = new System.Drawing.Size(115, 24);
            this.flatComboBox_IfNotFound.TabIndex = 9;
            // 
            // numericUpDown_X1
            // 
            this.numericUpDown_X1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_X1.Location = new System.Drawing.Point(123, 84);
            this.numericUpDown_X1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_X1.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericUpDown_X1.Name = "numericUpDown_X1";
            this.numericUpDown_X1.Size = new System.Drawing.Size(114, 22);
            this.numericUpDown_X1.TabIndex = 2;
            // 
            // numericUpDown_Y1
            // 
            this.numericUpDown_Y1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Y1.Location = new System.Drawing.Point(123, 122);
            this.numericUpDown_Y1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_Y1.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericUpDown_Y1.Name = "numericUpDown_Y1";
            this.numericUpDown_Y1.Size = new System.Drawing.Size(114, 22);
            this.numericUpDown_Y1.TabIndex = 3;
            // 
            // numericUpDown_X2
            // 
            this.numericUpDown_X2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_X2.Location = new System.Drawing.Point(123, 160);
            this.numericUpDown_X2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_X2.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericUpDown_X2.Name = "numericUpDown_X2";
            this.numericUpDown_X2.Size = new System.Drawing.Size(114, 22);
            this.numericUpDown_X2.TabIndex = 4;
            // 
            // numericUpDown_Y2
            // 
            this.numericUpDown_Y2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Y2.Location = new System.Drawing.Point(123, 198);
            this.numericUpDown_Y2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_Y2.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericUpDown_Y2.Name = "numericUpDown_Y2";
            this.numericUpDown_Y2.Size = new System.Drawing.Size(114, 22);
            this.numericUpDown_Y2.TabIndex = 5;
            // 
            // numericUpDown_Threshold
            // 
            this.numericUpDown_Threshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Threshold.Location = new System.Drawing.Point(363, 122);
            this.numericUpDown_Threshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Threshold.Name = "numericUpDown_Threshold";
            this.numericUpDown_Threshold.Size = new System.Drawing.Size(115, 22);
            this.numericUpDown_Threshold.TabIndex = 6;
            this.numericUpDown_Threshold.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label_Expiration
            // 
            this.label_Expiration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Expiration.AutoSize = true;
            this.label_Expiration.Location = new System.Drawing.Point(243, 163);
            this.label_Expiration.Name = "label_Expiration";
            this.label_Expiration.Size = new System.Drawing.Size(114, 16);
            this.label_Expiration.TabIndex = 33;
            this.label_Expiration.Text = "Expiration :";
            this.label_Expiration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_Expiration
            // 
            this.numericUpDown_Expiration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Expiration.Location = new System.Drawing.Point(363, 160);
            this.numericUpDown_Expiration.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_Expiration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_Expiration.Name = "numericUpDown_Expiration";
            this.numericUpDown_Expiration.Size = new System.Drawing.Size(115, 22);
            this.numericUpDown_Expiration.TabIndex = 7;
            // 
            // ActionImageSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActionImageSearchPanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(497, 325);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Expiration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.Button button_ShowArea;
        private System.Windows.Forms.Label label_IfNotFound;
        private System.Windows.Forms.Label label_IfFound;
        private System.Windows.Forms.Label label_Threshold;
        private System.Windows.Forms.Label label_Y2;
        private System.Windows.Forms.Button button_PathImage;
        private System.Windows.Forms.Label label_Y1;
        private System.Windows.Forms.Label label_X2;
        private System.Windows.Forms.Label label_X1;
        private System.Windows.Forms.Button button_ClearArea;
        private System.Windows.Forms.Button button_FindImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DarkModeForms.FlatComboBox flatComboBox_IfFound;
        private DarkModeForms.FlatComboBox flatComboBox_IfNotFound;
        private System.Windows.Forms.NumericUpDown numericUpDown_X1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y1;
        private System.Windows.Forms.NumericUpDown numericUpDown_X2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Threshold;
        private System.Windows.Forms.Label label_Expiration;
        private System.Windows.Forms.NumericUpDown numericUpDown_Expiration;
    }
}
