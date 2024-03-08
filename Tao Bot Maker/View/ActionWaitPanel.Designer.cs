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
            this.label_IsRandomInterval = new System.Windows.Forms.Label();
            this.label_WaitTimeMax = new System.Windows.Forms.Label();
            this.checkBox_IsRandomInterval = new System.Windows.Forms.CheckBox();
            this.numericUpDown_WaitTimeMax = new System.Windows.Forms.NumericUpDown();
            this.flatComboBox_WaitTimeUnits = new DarkModeForms.FlatComboBox();
            this.flatComboBox_WaitTimeMaxUnits = new DarkModeForms.FlatComboBox();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WaitTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WaitTimeMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label_WaitTime
            // 
            this.label_WaitTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_WaitTime.AutoSize = true;
            this.label_WaitTime.Location = new System.Drawing.Point(3, 11);
            this.label_WaitTime.Name = "label_WaitTime";
            this.label_WaitTime.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_WaitTime.Size = new System.Drawing.Size(114, 16);
            this.label_WaitTime.TabIndex = 6;
            this.label_WaitTime.Text = "Attente";
            this.label_WaitTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 4;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout.Controls.Add(this.label_WaitTime, 0, 0);
            this.tableLayout.Controls.Add(this.numericUpDown_WaitTime, 1, 0);
            this.tableLayout.Controls.Add(this.label_IsRandomInterval, 0, 1);
            this.tableLayout.Controls.Add(this.label_WaitTimeMax, 0, 2);
            this.tableLayout.Controls.Add(this.checkBox_IsRandomInterval, 1, 1);
            this.tableLayout.Controls.Add(this.numericUpDown_WaitTimeMax, 1, 2);
            this.tableLayout.Controls.Add(this.flatComboBox_WaitTimeUnits, 2, 0);
            this.tableLayout.Controls.Add(this.flatComboBox_WaitTimeMaxUnits, 2, 2);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(8, 8);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 8;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout.Size = new System.Drawing.Size(481, 309);
            this.tableLayout.TabIndex = 7;
            // 
            // numericUpDown_WaitTime
            // 
            this.numericUpDown_WaitTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_WaitTime.Location = new System.Drawing.Point(123, 8);
            this.numericUpDown_WaitTime.Maximum = new decimal(new int[] {
            2147483646,
            0,
            0,
            0});
            this.numericUpDown_WaitTime.Name = "numericUpDown_WaitTime";
            this.numericUpDown_WaitTime.Size = new System.Drawing.Size(114, 22);
            this.numericUpDown_WaitTime.TabIndex = 7;
            // 
            // label_IsRandomInterval
            // 
            this.label_IsRandomInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_IsRandomInterval.AutoSize = true;
            this.label_IsRandomInterval.Location = new System.Drawing.Point(3, 49);
            this.label_IsRandomInterval.Name = "label_IsRandomInterval";
            this.label_IsRandomInterval.Size = new System.Drawing.Size(114, 16);
            this.label_IsRandomInterval.TabIndex = 8;
            this.label_IsRandomInterval.Text = "Interval aléatoire";
            this.label_IsRandomInterval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_WaitTimeMax
            // 
            this.label_WaitTimeMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_WaitTimeMax.AutoSize = true;
            this.label_WaitTimeMax.Location = new System.Drawing.Point(3, 87);
            this.label_WaitTimeMax.Name = "label_WaitTimeMax";
            this.label_WaitTimeMax.Size = new System.Drawing.Size(114, 16);
            this.label_WaitTimeMax.TabIndex = 9;
            this.label_WaitTimeMax.Text = "Attente maximum";
            this.label_WaitTimeMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_IsRandomInterval
            // 
            this.checkBox_IsRandomInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_IsRandomInterval.AutoSize = true;
            this.checkBox_IsRandomInterval.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_IsRandomInterval.Location = new System.Drawing.Point(123, 48);
            this.checkBox_IsRandomInterval.Name = "checkBox_IsRandomInterval";
            this.checkBox_IsRandomInterval.Size = new System.Drawing.Size(114, 17);
            this.checkBox_IsRandomInterval.TabIndex = 10;
            this.checkBox_IsRandomInterval.UseVisualStyleBackColor = true;
            this.checkBox_IsRandomInterval.CheckedChanged += new System.EventHandler(this.CheckBox_IsRandomInterval_CheckedChanged);
            // 
            // numericUpDown_WaitTimeMax
            // 
            this.numericUpDown_WaitTimeMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_WaitTimeMax.Location = new System.Drawing.Point(123, 84);
            this.numericUpDown_WaitTimeMax.Maximum = new decimal(new int[] {
            2147483646,
            0,
            0,
            0});
            this.numericUpDown_WaitTimeMax.Name = "numericUpDown_WaitTimeMax";
            this.numericUpDown_WaitTimeMax.Size = new System.Drawing.Size(114, 22);
            this.numericUpDown_WaitTimeMax.TabIndex = 11;
            // 
            // flatComboBox_WaitTimeUnits
            // 
            this.flatComboBox_WaitTimeUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flatComboBox_WaitTimeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox_WaitTimeUnits.FormattingEnabled = true;
            this.flatComboBox_WaitTimeUnits.Location = new System.Drawing.Point(243, 7);
            this.flatComboBox_WaitTimeUnits.Name = "flatComboBox_WaitTimeUnits";
            this.flatComboBox_WaitTimeUnits.Size = new System.Drawing.Size(114, 24);
            this.flatComboBox_WaitTimeUnits.TabIndex = 12;
            this.flatComboBox_WaitTimeUnits.SelectedIndexChanged += new System.EventHandler(this.FlatComboBox_WaitTimeUnits_SelectedIndexChanged);
            // 
            // flatComboBox_WaitTimeMaxUnits
            // 
            this.flatComboBox_WaitTimeMaxUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flatComboBox_WaitTimeMaxUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox_WaitTimeMaxUnits.FormattingEnabled = true;
            this.flatComboBox_WaitTimeMaxUnits.Location = new System.Drawing.Point(243, 83);
            this.flatComboBox_WaitTimeMaxUnits.Name = "flatComboBox_WaitTimeMaxUnits";
            this.flatComboBox_WaitTimeMaxUnits.Size = new System.Drawing.Size(114, 24);
            this.flatComboBox_WaitTimeMaxUnits.TabIndex = 13;
            this.flatComboBox_WaitTimeMaxUnits.SelectedIndexChanged += new System.EventHandler(this.FlatComboBox_WaitTimeMaxUnits_SelectedIndexChanged);
            // 
            // ActionWaitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActionWaitPanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(497, 325);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WaitTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WaitTimeMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_WaitTime;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.NumericUpDown numericUpDown_WaitTime;
        private System.Windows.Forms.Label label_IsRandomInterval;
        private System.Windows.Forms.Label label_WaitTimeMax;
        private System.Windows.Forms.CheckBox checkBox_IsRandomInterval;
        private System.Windows.Forms.NumericUpDown numericUpDown_WaitTimeMax;
        private DarkModeForms.FlatComboBox flatComboBox_WaitTimeUnits;
        private DarkModeForms.FlatComboBox flatComboBox_WaitTimeMaxUnits;
    }
}
