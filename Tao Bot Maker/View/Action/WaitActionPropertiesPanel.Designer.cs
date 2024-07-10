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
            this.maximumWaitLabel = new System.Windows.Forms.Label();
            this.randomizeWaitCheckBox = new System.Windows.Forms.CheckBox();
            this.minimumWaitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maximumWaitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.minimumWaitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumWaitNumericUpDown)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimumWaitLabel
            // 
            this.minimumWaitLabel.Location = new System.Drawing.Point(3, 3);
            this.minimumWaitLabel.Margin = new System.Windows.Forms.Padding(3);
            this.minimumWaitLabel.Name = "minimumWaitLabel";
            this.minimumWaitLabel.Size = new System.Drawing.Size(104, 36);
            this.minimumWaitLabel.TabIndex = 0;
            this.minimumWaitLabel.Text = "Minimum wait (ms)";
            this.minimumWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maximumWaitLabel
            // 
            this.maximumWaitLabel.Location = new System.Drawing.Point(3, 3);
            this.maximumWaitLabel.Margin = new System.Windows.Forms.Padding(3);
            this.maximumWaitLabel.Name = "maximumWaitLabel";
            this.maximumWaitLabel.Size = new System.Drawing.Size(104, 36);
            this.maximumWaitLabel.TabIndex = 18;
            this.maximumWaitLabel.Text = "Maximum wait (ms)";
            this.maximumWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // randomizeWaitCheckBox
            // 
            this.randomizeWaitCheckBox.Location = new System.Drawing.Point(113, 3);
            this.randomizeWaitCheckBox.Name = "randomizeWaitCheckBox";
            this.randomizeWaitCheckBox.Size = new System.Drawing.Size(181, 36);
            this.randomizeWaitCheckBox.TabIndex = 17;
            this.randomizeWaitCheckBox.Text = "Random interval";
            this.randomizeWaitCheckBox.UseVisualStyleBackColor = true;
            this.randomizeWaitCheckBox.CheckedChanged += new System.EventHandler(this.RandomizeWaitCheckBox_CheckedChanged);
            // 
            // minimumWaitNumericUpDown
            // 
            this.minimumWaitNumericUpDown.Location = new System.Drawing.Point(113, 13);
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
            this.maximumWaitNumericUpDown.Location = new System.Drawing.Point(113, 13);
            this.maximumWaitNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.maximumWaitNumericUpDown.Name = "maximumWaitNumericUpDown";
            this.maximumWaitNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.maximumWaitNumericUpDown.TabIndex = 16;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Controls.Add(this.minimumWaitLabel);
            this.panel6.Controls.Add(this.minimumWaitNumericUpDown);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(491, 42);
            this.panel6.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.randomizeWaitCheckBox);
            this.panel1.Location = new System.Drawing.Point(3, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 42);
            this.panel1.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.maximumWaitNumericUpDown);
            this.panel2.Controls.Add(this.maximumWaitLabel);
            this.panel2.Location = new System.Drawing.Point(3, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 42);
            this.panel2.TabIndex = 32;
            // 
            // WaitActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Name = "WaitActionPropertiesPanel";
            this.Size = new System.Drawing.Size(497, 148);
            ((System.ComponentModel.ISupportInitialize)(this.minimumWaitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumWaitNumericUpDown)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label minimumWaitLabel;
        private System.Windows.Forms.NumericUpDown minimumWaitNumericUpDown;
        private System.Windows.Forms.NumericUpDown maximumWaitNumericUpDown;
        private System.Windows.Forms.CheckBox randomizeWaitCheckBox;
        private System.Windows.Forms.Label maximumWaitLabel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
