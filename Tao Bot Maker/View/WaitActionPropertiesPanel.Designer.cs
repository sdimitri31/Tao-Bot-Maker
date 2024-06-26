namespace Tao_Bot_Maker.View
{
    partial class WaitActionPropertiesPanel
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
            this.minimumWaitLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.maximumWaitLabel = new System.Windows.Forms.Label();
            this.randomizeWaitCheckBox = new System.Windows.Forms.CheckBox();
            this.minimumWaitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maximumWaitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumWaitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumWaitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // minimumWaitLabel
            // 
            this.minimumWaitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumWaitLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.minimumWaitLabel, 2);
            this.minimumWaitLabel.Location = new System.Drawing.Point(3, 8);
            this.minimumWaitLabel.Name = "minimumWaitLabel";
            this.minimumWaitLabel.Size = new System.Drawing.Size(194, 13);
            this.minimumWaitLabel.TabIndex = 0;
            this.minimumWaitLabel.Text = "Minimum wait (ms)";
            this.minimumWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.minimumWaitLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.maximumWaitLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.randomizeWaitCheckBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.minimumWaitNumericUpDown, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.maximumWaitNumericUpDown, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 300);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // maximumWaitLabel
            // 
            this.maximumWaitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumWaitLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.maximumWaitLabel, 2);
            this.maximumWaitLabel.Location = new System.Drawing.Point(3, 68);
            this.maximumWaitLabel.Name = "maximumWaitLabel";
            this.maximumWaitLabel.Size = new System.Drawing.Size(194, 13);
            this.maximumWaitLabel.TabIndex = 18;
            this.maximumWaitLabel.Text = "Maximum wait (ms)";
            this.maximumWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // randomizeWaitCheckBox
            // 
            this.randomizeWaitCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.randomizeWaitCheckBox.AutoSize = true;
            this.randomizeWaitCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel1.SetColumnSpan(this.randomizeWaitCheckBox, 3);
            this.randomizeWaitCheckBox.Location = new System.Drawing.Point(3, 36);
            this.randomizeWaitCheckBox.Name = "randomizeWaitCheckBox";
            this.randomizeWaitCheckBox.Size = new System.Drawing.Size(294, 17);
            this.randomizeWaitCheckBox.TabIndex = 17;
            this.randomizeWaitCheckBox.Text = "Random interval";
            this.randomizeWaitCheckBox.UseVisualStyleBackColor = true;
            // 
            // minimumWaitNumericUpDown
            // 
            this.minimumWaitNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumWaitNumericUpDown.Location = new System.Drawing.Point(203, 5);
            this.minimumWaitNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.minimumWaitNumericUpDown.Name = "minimumWaitNumericUpDown";
            this.minimumWaitNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.minimumWaitNumericUpDown.TabIndex = 15;
            // 
            // maximumWaitNumericUpDown
            // 
            this.maximumWaitNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumWaitNumericUpDown.Location = new System.Drawing.Point(203, 65);
            this.maximumWaitNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.maximumWaitNumericUpDown.Name = "maximumWaitNumericUpDown";
            this.maximumWaitNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.maximumWaitNumericUpDown.TabIndex = 16;
            // 
            // WaitActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WaitActionPropertiesPanel";
            this.Size = new System.Drawing.Size(500, 300);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumWaitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumWaitNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label minimumWaitLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown minimumWaitNumericUpDown;
        private System.Windows.Forms.NumericUpDown maximumWaitNumericUpDown;
        private System.Windows.Forms.CheckBox randomizeWaitCheckBox;
        private System.Windows.Forms.Label maximumWaitLabel;
    }
}
