namespace Tao_Bot_Maker.View
{
    partial class HotkeyView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyView));
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_StartBot = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label_StopBot = new System.Windows.Forms.Label();
            this.label_StartBot = new System.Windows.Forms.Label();
            this.button_StopBot = new System.Windows.Forms.Button();
            this.button_XY = new System.Windows.Forms.Button();
            this.button_XY2 = new System.Windows.Forms.Button();
            this.label_XY = new System.Windows.Forms.Label();
            this.label_XY2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(459, 229);
            this.button_OK.Margin = new System.Windows.Forms.Padding(4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 28);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(351, 229);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 28);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_StartBot
            // 
            this.button_StartBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_StartBot.Location = new System.Drawing.Point(278, 9);
            this.button_StartBot.Name = "button_StartBot";
            this.button_StartBot.Size = new System.Drawing.Size(270, 28);
            this.button_StartBot.TabIndex = 0;
            this.button_StartBot.Text = "F6";
            this.button_StartBot.UseVisualStyleBackColor = true;
            this.button_StartBot.Click += new System.EventHandler(this.Button_StartBot_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.label_StopBot, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.button_StartBot, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label_StartBot, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.button_StopBot, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.button_XY, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.button_XY2, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.label_XY, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label_XY2, 0, 4);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(551, 210);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // label_StopBot
            // 
            this.label_StopBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_StopBot.AutoSize = true;
            this.label_StopBot.Location = new System.Drawing.Point(3, 62);
            this.label_StopBot.Name = "label_StopBot";
            this.label_StopBot.Size = new System.Drawing.Size(269, 16);
            this.label_StopBot.TabIndex = 5;
            this.label_StopBot.Text = "Stop bot";
            this.label_StopBot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_StartBot
            // 
            this.label_StartBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_StartBot.AutoSize = true;
            this.label_StartBot.Location = new System.Drawing.Point(3, 15);
            this.label_StartBot.Name = "label_StartBot";
            this.label_StartBot.Size = new System.Drawing.Size(269, 16);
            this.label_StartBot.TabIndex = 1;
            this.label_StartBot.Text = "Start bot";
            this.label_StartBot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_StopBot
            // 
            this.button_StopBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_StopBot.Location = new System.Drawing.Point(278, 56);
            this.button_StopBot.Name = "button_StopBot";
            this.button_StopBot.Size = new System.Drawing.Size(270, 28);
            this.button_StopBot.TabIndex = 2;
            this.button_StopBot.Text = "F7";
            this.button_StopBot.UseVisualStyleBackColor = true;
            this.button_StopBot.Click += new System.EventHandler(this.Button_StopBot_Click);
            // 
            // button_XY
            // 
            this.button_XY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_XY.Location = new System.Drawing.Point(278, 122);
            this.button_XY.Name = "button_XY";
            this.button_XY.Size = new System.Drawing.Size(270, 28);
            this.button_XY.TabIndex = 3;
            this.button_XY.Text = "F1";
            this.button_XY.UseVisualStyleBackColor = true;
            this.button_XY.Click += new System.EventHandler(this.Button_XY_Click);
            // 
            // button_XY2
            // 
            this.button_XY2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_XY2.Location = new System.Drawing.Point(278, 171);
            this.button_XY2.Name = "button_XY2";
            this.button_XY2.Size = new System.Drawing.Size(270, 28);
            this.button_XY2.TabIndex = 4;
            this.button_XY2.Text = "F2";
            this.button_XY2.UseVisualStyleBackColor = true;
            this.button_XY2.Click += new System.EventHandler(this.Button_XY2_Click);
            // 
            // label_XY
            // 
            this.label_XY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_XY.AutoSize = true;
            this.label_XY.Location = new System.Drawing.Point(3, 128);
            this.label_XY.Name = "label_XY";
            this.label_XY.Size = new System.Drawing.Size(269, 16);
            this.label_XY.TabIndex = 6;
            this.label_XY.Text = "XY";
            this.label_XY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_XY2
            // 
            this.label_XY2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_XY2.AutoSize = true;
            this.label_XY2.Location = new System.Drawing.Point(3, 177);
            this.label_XY2.Name = "label_XY2";
            this.label_XY2.Size = new System.Drawing.Size(269, 16);
            this.label_XY2.TabIndex = 7;
            this.label_XY2.Text = "XY2";
            this.label_XY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HotkeyView
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(575, 271);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeyView";
            this.Text = "Hotkeys";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_StartBot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button button_XY;
        private System.Windows.Forms.Label label_StartBot;
        private System.Windows.Forms.Button button_StopBot;
        private System.Windows.Forms.Label label_StopBot;
        private System.Windows.Forms.Button button_XY2;
        private System.Windows.Forms.Label label_XY;
        private System.Windows.Forms.Label label_XY2;
    }
}