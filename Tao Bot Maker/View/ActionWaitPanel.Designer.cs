namespace Tao_Bot_Maker.View
{
    partial class ActionWaitPanel
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
            this.label_WaitTime = new System.Windows.Forms.Label();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_WaitTime = new System.Windows.Forms.NumericUpDown();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WaitTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label_WaitTime
            // 
            this.label_WaitTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_WaitTime.AutoSize = true;
            this.label_WaitTime.Location = new System.Drawing.Point(3, 17);
            this.label_WaitTime.Name = "label_WaitTime";
            this.label_WaitTime.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_WaitTime.Size = new System.Drawing.Size(242, 16);
            this.label_WaitTime.TabIndex = 6;
            this.label_WaitTime.Text = "Délai (ms) :";
            this.label_WaitTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.label_WaitTime, 0, 0);
            this.tableLayout.Controls.Add(this.numericUpDown_WaitTime, 1, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayout.Size = new System.Drawing.Size(497, 50);
            this.tableLayout.TabIndex = 7;
            // 
            // numericUpDown_WaitTime
            // 
            this.numericUpDown_WaitTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_WaitTime.Location = new System.Drawing.Point(251, 14);
            this.numericUpDown_WaitTime.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_WaitTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_WaitTime.Name = "numericUpDown_WaitTime";
            this.numericUpDown_WaitTime.Size = new System.Drawing.Size(243, 22);
            this.numericUpDown_WaitTime.TabIndex = 7;
            this.numericUpDown_WaitTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ActionWaitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActionWaitPanel";
            this.Size = new System.Drawing.Size(497, 50);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WaitTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_WaitTime;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.NumericUpDown numericUpDown_WaitTime;
    }
}
