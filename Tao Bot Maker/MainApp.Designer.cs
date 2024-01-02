namespace Tao_Bot_Maker
{
    partial class MainApp
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            this.buttonStopBot = new System.Windows.Forms.Button();
            this.buttonStartBot = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.labelNotice = new System.Windows.Forms.Label();
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.buttonSaveSequence = new System.Windows.Forms.Button();
            this.comboBoxListSequences = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Add_Action = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClearSequence = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStopBot
            // 
            this.buttonStopBot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopBot.BackColor = System.Drawing.Color.DimGray;
            this.buttonStopBot.Location = new System.Drawing.Point(190, 38);
            this.buttonStopBot.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStopBot.Name = "buttonStopBot";
            this.buttonStopBot.Size = new System.Drawing.Size(184, 32);
            this.buttonStopBot.TabIndex = 7;
            this.buttonStopBot.Text = "Stop Bot (F7)";
            this.buttonStopBot.UseVisualStyleBackColor = false;
            this.buttonStopBot.Click += new System.EventHandler(this.buttonStopBot_Click);
            // 
            // buttonStartBot
            // 
            this.buttonStartBot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartBot.BackColor = System.Drawing.Color.DimGray;
            this.buttonStartBot.Location = new System.Drawing.Point(2, 38);
            this.buttonStartBot.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartBot.Name = "buttonStartBot";
            this.buttonStartBot.Size = new System.Drawing.Size(184, 32);
            this.buttonStartBot.TabIndex = 6;
            this.buttonStartBot.Text = "Start Bot (F6)";
            this.buttonStartBot.UseVisualStyleBackColor = false;
            this.buttonStartBot.Click += new System.EventHandler(this.buttonStartBot_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModifier.BackColor = System.Drawing.Color.DimGray;
            this.buttonModifier.Location = new System.Drawing.Point(190, 2);
            this.buttonModifier.Margin = new System.Windows.Forms.Padding(2);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(184, 30);
            this.buttonModifier.TabIndex = 20;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = false;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // labelNotice
            // 
            this.labelNotice.AutoSize = true;
            this.labelNotice.Location = new System.Drawing.Point(4, 17);
            this.labelNotice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNotice.Name = "labelNotice";
            this.labelNotice.Size = new System.Drawing.Size(41, 13);
            this.labelNotice.TabIndex = 12;
            this.labelNotice.Text = "label17";
            // 
            // listBoxActions
            // 
            this.listBoxActions.AllowDrop = true;
            this.listBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxActions.BackColor = System.Drawing.Color.DimGray;
            this.listBoxActions.ForeColor = System.Drawing.Color.White;
            this.listBoxActions.FormattingEnabled = true;
            this.listBoxActions.Location = new System.Drawing.Point(6, 358);
            this.listBoxActions.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxActions.Name = "listBoxActions";
            this.listBoxActions.Size = new System.Drawing.Size(383, 225);
            this.listBoxActions.TabIndex = 5;
            this.listBoxActions.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxActions_DragDrop);
            this.listBoxActions.DragOver += new System.Windows.Forms.DragEventHandler(this.listBoxActions_DragOver);
            this.listBoxActions.DoubleClick += new System.EventHandler(this.listBoxActions_DoubleClick);
            this.listBoxActions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxActions_KeyDown);
            this.listBoxActions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxActions_MouseDown);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.BackColor = System.Drawing.Color.DimGray;
            this.listBoxLog.ForeColor = System.Drawing.Color.White;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(6, 99);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxLog.Size = new System.Drawing.Size(461, 212);
            this.listBoxLog.TabIndex = 8;
            // 
            // buttonSaveSequence
            // 
            this.buttonSaveSequence.BackColor = System.Drawing.Color.DimGray;
            this.buttonSaveSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveSequence.Location = new System.Drawing.Point(192, 2);
            this.buttonSaveSequence.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveSequence.Name = "buttonSaveSequence";
            this.buttonSaveSequence.Size = new System.Drawing.Size(186, 23);
            this.buttonSaveSequence.TabIndex = 9;
            this.buttonSaveSequence.Text = "Sauvegarder la séquence";
            this.buttonSaveSequence.UseVisualStyleBackColor = false;
            this.buttonSaveSequence.Click += new System.EventHandler(this.buttonSaveSequence_Click);
            // 
            // comboBoxListSequences
            // 
            this.comboBoxListSequences.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxListSequences.BackColor = System.Drawing.Color.DimGray;
            this.comboBoxListSequences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListSequences.ForeColor = System.Drawing.Color.White;
            this.comboBoxListSequences.FormattingEnabled = true;
            this.comboBoxListSequences.Location = new System.Drawing.Point(7, 3);
            this.comboBoxListSequences.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxListSequences.Name = "comboBoxListSequences";
            this.comboBoxListSequences.Size = new System.Drawing.Size(175, 21);
            this.comboBoxListSequences.TabIndex = 11;
            this.comboBoxListSequences.SelectedIndexChanged += new System.EventHandler(this.comboBoxListSequences_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.26917F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.73083F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(869, 601);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.button_Add_Action);
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Controls.Add(this.listBoxActions);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(389, 597);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // button_Add_Action
            // 
            this.button_Add_Action.BackColor = System.Drawing.SystemColors.Control;
            this.button_Add_Action.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Add_Action.Location = new System.Drawing.Point(9, 18);
            this.button_Add_Action.Name = "button_Add_Action";
            this.button_Add_Action.Size = new System.Drawing.Size(132, 23);
            this.button_Add_Action.TabIndex = 13;
            this.button_Add_Action.Text = "Ajouter une Action";
            this.button_Add_Action.UseVisualStyleBackColor = false;
            this.button_Add_Action.Click += new System.EventHandler(this.button_Add_Action_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonModifier, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonStartBot, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonStopBot, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 170);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(376, 72);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonSaveSequence, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxListSequences, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonClearSequence, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 99);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(380, 54);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // buttonClearSequence
            // 
            this.buttonClearSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearSequence.AutoSize = true;
            this.buttonClearSequence.BackColor = System.Drawing.Color.DimGray;
            this.buttonClearSequence.Location = new System.Drawing.Point(192, 29);
            this.buttonClearSequence.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClearSequence.Name = "buttonClearSequence";
            this.buttonClearSequence.Size = new System.Drawing.Size(186, 23);
            this.buttonClearSequence.TabIndex = 12;
            this.buttonClearSequence.Text = "Clear Sequence";
            this.buttonClearSequence.UseVisualStyleBackColor = false;
            this.buttonClearSequence.Click += new System.EventHandler(this.buttonClearSequence_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.labelNotice);
            this.groupBox3.Controls.Add(this.listBoxLog);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(395, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(472, 597);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(869, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(836, 532);
            this.Name = "MainApp";
            this.Text = "Tao\'s Bot Maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainApp_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxActions;
        private System.Windows.Forms.Button buttonStartBot;
        private System.Windows.Forms.Button buttonStopBot;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonSaveSequence;
        private System.Windows.Forms.ComboBox comboBoxListSequences;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Label labelNotice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonClearSequence;
        private System.Windows.Forms.Button button_Add_Action;
    }
}

