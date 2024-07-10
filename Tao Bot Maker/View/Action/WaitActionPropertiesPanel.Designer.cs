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
            this.minimumWaitPanel = new System.Windows.Forms.Panel();
            this.minimumWaitTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.randomizeWaitPanel = new System.Windows.Forms.Panel();
            this.randomizeWaitTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.maximumWaitPanel = new System.Windows.Forms.Panel();
            this.maximumWaitTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.minimumWaitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumWaitNumericUpDown)).BeginInit();
            this.minimumWaitPanel.SuspendLayout();
            this.minimumWaitTableLayoutPanel.SuspendLayout();
            this.randomizeWaitPanel.SuspendLayout();
            this.randomizeWaitTableLayoutPanel.SuspendLayout();
            this.maximumWaitPanel.SuspendLayout();
            this.maximumWaitTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimumWaitLabel
            // 
            this.minimumWaitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumWaitLabel.AutoSize = true;
            this.minimumWaitLabel.Location = new System.Drawing.Point(3, 10);
            this.minimumWaitLabel.Margin = new System.Windows.Forms.Padding(3);
            this.minimumWaitLabel.Name = "minimumWaitLabel";
            this.minimumWaitLabel.Size = new System.Drawing.Size(110, 13);
            this.minimumWaitLabel.TabIndex = 0;
            this.minimumWaitLabel.Text = "Minimum wait (ms)";
            this.minimumWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maximumWaitLabel
            // 
            this.maximumWaitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumWaitLabel.AutoSize = true;
            this.maximumWaitLabel.Location = new System.Drawing.Point(3, 10);
            this.maximumWaitLabel.Margin = new System.Windows.Forms.Padding(3);
            this.maximumWaitLabel.Name = "maximumWaitLabel";
            this.maximumWaitLabel.Size = new System.Drawing.Size(110, 13);
            this.maximumWaitLabel.TabIndex = 18;
            this.maximumWaitLabel.Text = "Maximum wait (ms)";
            this.maximumWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // randomizeWaitCheckBox
            // 
            this.randomizeWaitCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.randomizeWaitCheckBox.AutoSize = true;
            this.randomizeWaitCheckBox.Location = new System.Drawing.Point(119, 3);
            this.randomizeWaitCheckBox.Name = "randomizeWaitCheckBox";
            this.randomizeWaitCheckBox.Size = new System.Drawing.Size(343, 28);
            this.randomizeWaitCheckBox.TabIndex = 17;
            this.randomizeWaitCheckBox.Text = "Random interval";
            this.randomizeWaitCheckBox.UseVisualStyleBackColor = true;
            this.randomizeWaitCheckBox.CheckedChanged += new System.EventHandler(this.RandomizeWaitCheckBox_CheckedChanged);
            // 
            // minimumWaitNumericUpDown
            // 
            this.minimumWaitNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumWaitNumericUpDown.Location = new System.Drawing.Point(119, 7);
            this.minimumWaitNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.minimumWaitNumericUpDown.Name = "minimumWaitNumericUpDown";
            this.minimumWaitNumericUpDown.Size = new System.Drawing.Size(343, 20);
            this.minimumWaitNumericUpDown.TabIndex = 15;
            // 
            // maximumWaitNumericUpDown
            // 
            this.maximumWaitNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumWaitNumericUpDown.Location = new System.Drawing.Point(119, 7);
            this.maximumWaitNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.maximumWaitNumericUpDown.Name = "maximumWaitNumericUpDown";
            this.maximumWaitNumericUpDown.Size = new System.Drawing.Size(343, 20);
            this.maximumWaitNumericUpDown.TabIndex = 16;
            // 
            // minimumWaitPanel
            // 
            this.minimumWaitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumWaitPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.minimumWaitPanel.Controls.Add(this.minimumWaitTableLayoutPanel);
            this.minimumWaitPanel.Location = new System.Drawing.Point(8, 8);
            this.minimumWaitPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.minimumWaitPanel.Name = "minimumWaitPanel";
            this.minimumWaitPanel.Padding = new System.Windows.Forms.Padding(8);
            this.minimumWaitPanel.Size = new System.Drawing.Size(481, 50);
            this.minimumWaitPanel.TabIndex = 30;
            // 
            // minimumWaitTableLayoutPanel
            // 
            this.minimumWaitTableLayoutPanel.ColumnCount = 2;
            this.minimumWaitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.minimumWaitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.minimumWaitTableLayoutPanel.Controls.Add(this.minimumWaitNumericUpDown, 1, 0);
            this.minimumWaitTableLayoutPanel.Controls.Add(this.minimumWaitLabel, 0, 0);
            this.minimumWaitTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minimumWaitTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.minimumWaitTableLayoutPanel.Name = "minimumWaitTableLayoutPanel";
            this.minimumWaitTableLayoutPanel.RowCount = 1;
            this.minimumWaitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.minimumWaitTableLayoutPanel.Size = new System.Drawing.Size(465, 34);
            this.minimumWaitTableLayoutPanel.TabIndex = 19;
            // 
            // randomizeWaitPanel
            // 
            this.randomizeWaitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.randomizeWaitPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.randomizeWaitPanel.Controls.Add(this.randomizeWaitTableLayoutPanel);
            this.randomizeWaitPanel.Location = new System.Drawing.Point(8, 66);
            this.randomizeWaitPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.randomizeWaitPanel.Name = "randomizeWaitPanel";
            this.randomizeWaitPanel.Padding = new System.Windows.Forms.Padding(8);
            this.randomizeWaitPanel.Size = new System.Drawing.Size(481, 50);
            this.randomizeWaitPanel.TabIndex = 31;
            // 
            // randomizeWaitTableLayoutPanel
            // 
            this.randomizeWaitTableLayoutPanel.ColumnCount = 2;
            this.randomizeWaitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.randomizeWaitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.randomizeWaitTableLayoutPanel.Controls.Add(this.randomizeWaitCheckBox, 1, 0);
            this.randomizeWaitTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.randomizeWaitTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.randomizeWaitTableLayoutPanel.Name = "randomizeWaitTableLayoutPanel";
            this.randomizeWaitTableLayoutPanel.RowCount = 1;
            this.randomizeWaitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.randomizeWaitTableLayoutPanel.Size = new System.Drawing.Size(465, 34);
            this.randomizeWaitTableLayoutPanel.TabIndex = 20;
            // 
            // maximumWaitPanel
            // 
            this.maximumWaitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumWaitPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.maximumWaitPanel.Controls.Add(this.maximumWaitTableLayoutPanel);
            this.maximumWaitPanel.Location = new System.Drawing.Point(8, 124);
            this.maximumWaitPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.maximumWaitPanel.Name = "maximumWaitPanel";
            this.maximumWaitPanel.Padding = new System.Windows.Forms.Padding(8);
            this.maximumWaitPanel.Size = new System.Drawing.Size(481, 50);
            this.maximumWaitPanel.TabIndex = 32;
            // 
            // maximumWaitTableLayoutPanel
            // 
            this.maximumWaitTableLayoutPanel.ColumnCount = 2;
            this.maximumWaitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.maximumWaitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.maximumWaitTableLayoutPanel.Controls.Add(this.maximumWaitNumericUpDown, 1, 0);
            this.maximumWaitTableLayoutPanel.Controls.Add(this.maximumWaitLabel, 0, 0);
            this.maximumWaitTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maximumWaitTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.maximumWaitTableLayoutPanel.Name = "maximumWaitTableLayoutPanel";
            this.maximumWaitTableLayoutPanel.RowCount = 1;
            this.maximumWaitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.maximumWaitTableLayoutPanel.Size = new System.Drawing.Size(465, 34);
            this.maximumWaitTableLayoutPanel.TabIndex = 21;
            // 
            // WaitActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.maximumWaitPanel);
            this.Controls.Add(this.randomizeWaitPanel);
            this.Controls.Add(this.minimumWaitPanel);
            this.Name = "WaitActionPropertiesPanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(497, 187);
            ((System.ComponentModel.ISupportInitialize)(this.minimumWaitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumWaitNumericUpDown)).EndInit();
            this.minimumWaitPanel.ResumeLayout(false);
            this.minimumWaitTableLayoutPanel.ResumeLayout(false);
            this.minimumWaitTableLayoutPanel.PerformLayout();
            this.randomizeWaitPanel.ResumeLayout(false);
            this.randomizeWaitTableLayoutPanel.ResumeLayout(false);
            this.randomizeWaitTableLayoutPanel.PerformLayout();
            this.maximumWaitPanel.ResumeLayout(false);
            this.maximumWaitTableLayoutPanel.ResumeLayout(false);
            this.maximumWaitTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label minimumWaitLabel;
        private System.Windows.Forms.NumericUpDown minimumWaitNumericUpDown;
        private System.Windows.Forms.NumericUpDown maximumWaitNumericUpDown;
        private System.Windows.Forms.CheckBox randomizeWaitCheckBox;
        private System.Windows.Forms.Label maximumWaitLabel;
        private System.Windows.Forms.Panel minimumWaitPanel;
        private System.Windows.Forms.Panel randomizeWaitPanel;
        private System.Windows.Forms.Panel maximumWaitPanel;
        private System.Windows.Forms.TableLayoutPanel minimumWaitTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel randomizeWaitTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel maximumWaitTableLayoutPanel;
    }
}
