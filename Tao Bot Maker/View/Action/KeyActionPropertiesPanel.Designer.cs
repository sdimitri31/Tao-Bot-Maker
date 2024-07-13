namespace Tao_Bot_Maker.View
{
    partial class KeyActionPropertiesPanel
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
            this.keyLabel = new System.Windows.Forms.Label();
            this.keyButton = new System.Windows.Forms.Button();
            this.keyPanel = new System.Windows.Forms.Panel();
            this.keyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.keyPanel.SuspendLayout();
            this.keyTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyLabel
            // 
            this.keyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(3, 10);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(113, 13);
            this.keyLabel.TabIndex = 0;
            this.keyLabel.Text = "Key";
            this.keyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // keyButton
            // 
            this.keyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.keyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyButton.Location = new System.Drawing.Point(122, 5);
            this.keyButton.Name = "keyButton";
            this.keyButton.Size = new System.Drawing.Size(354, 23);
            this.keyButton.TabIndex = 1;
            this.keyButton.Text = "Unassigned";
            this.keyButton.UseVisualStyleBackColor = false;
            this.keyButton.Click += new System.EventHandler(this.KeyButton_Click);
            // 
            // keyPanel
            // 
            this.keyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.keyPanel.Controls.Add(this.keyTableLayoutPanel);
            this.keyPanel.Location = new System.Drawing.Point(8, 8);
            this.keyPanel.Margin = new System.Windows.Forms.Padding(0);
            this.keyPanel.Name = "keyPanel";
            this.keyPanel.Padding = new System.Windows.Forms.Padding(8);
            this.keyPanel.Size = new System.Drawing.Size(495, 50);
            this.keyPanel.TabIndex = 33;
            // 
            // keyTableLayoutPanel
            // 
            this.keyTableLayoutPanel.ColumnCount = 2;
            this.keyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.keyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.keyTableLayoutPanel.Controls.Add(this.keyButton, 1, 0);
            this.keyTableLayoutPanel.Controls.Add(this.keyLabel, 0, 0);
            this.keyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.keyTableLayoutPanel.Name = "keyTableLayoutPanel";
            this.keyTableLayoutPanel.RowCount = 1;
            this.keyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.keyTableLayoutPanel.Size = new System.Drawing.Size(479, 34);
            this.keyTableLayoutPanel.TabIndex = 0;
            // 
            // KeyActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.keyPanel);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.Name = "KeyActionPropertiesPanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(511, 68);
            this.keyPanel.ResumeLayout(false);
            this.keyTableLayoutPanel.ResumeLayout(false);
            this.keyTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Button keyButton;
        private System.Windows.Forms.Panel keyPanel;
        private System.Windows.Forms.TableLayoutPanel keyTableLayoutPanel;
    }
}
