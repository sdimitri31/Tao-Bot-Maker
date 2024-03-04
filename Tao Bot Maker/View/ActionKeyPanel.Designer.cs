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
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.label_Key = new System.Windows.Forms.Label();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Key
            // 
            this.textBox_Key.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_Key.Location = new System.Drawing.Point(251, 14);
            this.textBox_Key.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Key.MaxLength = 1;
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(243, 22);
            this.textBox_Key.TabIndex = 1;
            // 
            // label_Key
            // 
            this.label_Key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Key.AutoSize = true;
            this.label_Key.Location = new System.Drawing.Point(3, 17);
            this.label_Key.Name = "label_Key";
            this.label_Key.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_Key.Size = new System.Drawing.Size(242, 16);
            this.label_Key.TabIndex = 2;
            this.label_Key.Text = "Touche :";
            this.label_Key.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.textBox_Key, 1, 0);
            this.tableLayout.Controls.Add(this.label_Key, 0, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayout.Size = new System.Drawing.Size(497, 50);
            this.tableLayout.TabIndex = 3;
            // 
            // ActionKeyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActionKeyPanel";
            this.Size = new System.Drawing.Size(497, 50);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.Label label_Key;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
    }
}
