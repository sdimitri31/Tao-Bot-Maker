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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPanelActionKey
            // 
            this.textBoxPanelActionKey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxPanelActionKey.Location = new System.Drawing.Point(251, 14);
            this.textBoxPanelActionKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPanelActionKey.MaxLength = 1;
            this.textBoxPanelActionKey.Name = "textBoxPanelActionKey";
            this.textBoxPanelActionKey.Size = new System.Drawing.Size(243, 22);
            this.textBoxPanelActionKey.TabIndex = 1;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxPanelActionKey, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Key, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 50);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ActionKeyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActionKeyPanel";
            this.Size = new System.Drawing.Size(497, 50);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPanelActionKey;
        private System.Windows.Forms.Label label_Key;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
