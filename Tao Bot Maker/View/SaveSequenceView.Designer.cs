namespace Tao_Bot_Maker.View
{
    partial class SaveSequenceView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveSequenceView));
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.flatTabControl1 = new BlueMystic.FlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox_SaveName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flatComboBox_SelectSave = new DarkModeForms.FlatComboBox();
            this.flatTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Ok
            // 
            this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Ok.Location = new System.Drawing.Point(205, 101);
            this.button_Ok.Margin = new System.Windows.Forms.Padding(4);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(150, 28);
            this.button_Ok.TabIndex = 3;
            this.button_Ok.Text = "OK";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(24, 101);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(150, 28);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // flatTabControl1
            // 
            this.flatTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.flatTabControl1.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.flatTabControl1.Controls.Add(this.tabPage1);
            this.flatTabControl1.Controls.Add(this.tabPage2);
            this.flatTabControl1.ItemSize = new System.Drawing.Size(120, 24);
            this.flatTabControl1.LineColor = System.Drawing.SystemColors.Highlight;
            this.flatTabControl1.Location = new System.Drawing.Point(20, 12);
            this.flatTabControl1.Name = "flatTabControl1";
            this.flatTabControl1.SelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.flatTabControl1.SelectedIndex = 0;
            this.flatTabControl1.SelectTabColor = System.Drawing.SystemColors.ControlLight;
            this.flatTabControl1.Size = new System.Drawing.Size(339, 82);
            this.flatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.flatTabControl1.TabColor = System.Drawing.SystemColors.ControlLight;
            this.flatTabControl1.TabIndex = 5;
            this.flatTabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.textBox_SaveName);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(331, 50);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage3";
            // 
            // textBox_SaveName
            // 
            this.textBox_SaveName.Location = new System.Drawing.Point(14, 14);
            this.textBox_SaveName.Name = "textBox_SaveName";
            this.textBox_SaveName.Size = new System.Drawing.Size(300, 22);
            this.textBox_SaveName.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Controls.Add(this.flatComboBox_SelectSave);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(331, 50);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage4";
            // 
            // flatComboBox_SelectSave
            // 
            this.flatComboBox_SelectSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox_SelectSave.FormattingEnabled = true;
            this.flatComboBox_SelectSave.Location = new System.Drawing.Point(14, 14);
            this.flatComboBox_SelectSave.Name = "flatComboBox_SelectSave";
            this.flatComboBox_SelectSave.Size = new System.Drawing.Size(300, 24);
            this.flatComboBox_SelectSave.TabIndex = 0;
            // 
            // SaveSequenceView
            // 
            this.AcceptButton = this.button_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(376, 142);
            this.Controls.Add(this.flatTabControl1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(394, 174);
            this.Name = "SaveSequenceView";
            this.Text = "Save";
            this.flatTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Button button_Cancel;
        private BlueMystic.FlatTabControl flatTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox_SaveName;
        private System.Windows.Forms.TabPage tabPage2;
        private DarkModeForms.FlatComboBox flatComboBox_SelectSave;
    }
}