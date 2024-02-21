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
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.comboBoxListSequences = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsm_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_File_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_File_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Bot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Bot_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Bot_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Settings_Language = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Settings_Language_English = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Settings_Language_Francais = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Settings_Hotkeys = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Settings_Theme = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Settings_Logs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_About = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_SaveSequence = new System.Windows.Forms.Button();
            this.button_StopBot = new System.Windows.Forms.Button();
            this.button_AddAction = new System.Windows.Forms.Button();
            this.button_EditAction = new System.Windows.Forms.Button();
            this.button_DeleteAction = new System.Windows.Forms.Button();
            this.button_StartBot = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.listBoxActions.Location = new System.Drawing.Point(0, 55);
            this.listBoxActions.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxActions.Name = "listBoxActions";
            this.listBoxActions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxActions.Size = new System.Drawing.Size(484, 329);
            this.listBoxActions.TabIndex = 5;
            this.listBoxActions.SelectedIndexChanged += new System.EventHandler(this.ListBoxActions_SelectedIndexChanged);
            this.listBoxActions.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxActions_DragDrop);
            this.listBoxActions.DragOver += new System.Windows.Forms.DragEventHandler(this.ListBoxActions_DragOver);
            this.listBoxActions.DoubleClick += new System.EventHandler(this.ListBoxActions_DoubleClick);
            this.listBoxActions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxActions_KeyDown);
            this.listBoxActions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBoxActions_MouseDown);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.BackColor = System.Drawing.Color.DimGray;
            this.listBoxLog.ForeColor = System.Drawing.Color.White;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(0, 390);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxLog.Size = new System.Drawing.Size(484, 121);
            this.listBoxLog.TabIndex = 8;
            // 
            // comboBoxListSequences
            // 
            this.comboBoxListSequences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListSequences.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBoxListSequences.FormattingEnabled = true;
            this.comboBoxListSequences.Location = new System.Drawing.Point(163, 5);
            this.comboBoxListSequences.Name = "comboBoxListSequences";
            this.comboBoxListSequences.Size = new System.Drawing.Size(120, 21);
            this.comboBoxListSequences.TabIndex = 11;
            this.comboBoxListSequences.SelectedIndexChanged += new System.EventHandler(this.ComboBoxListSequences_SelectedIndexChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_File,
            this.tsm_Bot,
            this.tsm_Settings,
            this.tsm_About});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(484, 24);
            this.menuStrip.TabIndex = 22;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsm_File
            // 
            this.tsm_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_File_Save,
            this.tsm_File_SaveAs,
            this.toolStripSeparator1,
            this.tsm_File_Exit});
            this.tsm_File.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsm_File.Name = "tsm_File";
            this.tsm_File.Size = new System.Drawing.Size(37, 20);
            this.tsm_File.Text = "File";
            // 
            // tsm_File_Save
            // 
            this.tsm_File_Save.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_save_48;
            this.tsm_File_Save.Name = "tsm_File_Save";
            this.tsm_File_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsm_File_Save.Size = new System.Drawing.Size(192, 22);
            this.tsm_File_Save.Text = "Save";
            this.tsm_File_Save.Click += new System.EventHandler(this.Tsm_File_Save_Click);
            // 
            // tsm_File_SaveAs
            // 
            this.tsm_File_SaveAs.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_save_as_48;
            this.tsm_File_SaveAs.Name = "tsm_File_SaveAs";
            this.tsm_File_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsm_File_SaveAs.Size = new System.Drawing.Size(192, 22);
            this.tsm_File_SaveAs.Text = "Save as ...";
            this.tsm_File_SaveAs.Click += new System.EventHandler(this.Tsm_File_SaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // tsm_File_Exit
            // 
            this.tsm_File_Exit.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_close_48;
            this.tsm_File_Exit.Name = "tsm_File_Exit";
            this.tsm_File_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsm_File_Exit.Size = new System.Drawing.Size(192, 22);
            this.tsm_File_Exit.Text = "Exit";
            this.tsm_File_Exit.Click += new System.EventHandler(this.Tsm_File_Exit_Click);
            // 
            // tsm_Bot
            // 
            this.tsm_Bot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_Bot_Start,
            this.tsm_Bot_Stop});
            this.tsm_Bot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsm_Bot.Name = "tsm_Bot";
            this.tsm_Bot.Size = new System.Drawing.Size(37, 20);
            this.tsm_Bot.Text = "Bot";
            // 
            // tsm_Bot_Start
            // 
            this.tsm_Bot_Start.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_play_48;
            this.tsm_Bot_Start.Name = "tsm_Bot_Start";
            this.tsm_Bot_Start.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tsm_Bot_Start.Size = new System.Drawing.Size(180, 22);
            this.tsm_Bot_Start.Text = "Start";
            // 
            // tsm_Bot_Stop
            // 
            this.tsm_Bot_Stop.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_stop_48;
            this.tsm_Bot_Stop.Name = "tsm_Bot_Stop";
            this.tsm_Bot_Stop.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.tsm_Bot_Stop.Size = new System.Drawing.Size(180, 22);
            this.tsm_Bot_Stop.Text = "Stop";
            // 
            // tsm_Settings
            // 
            this.tsm_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_Settings_Language,
            this.tsm_Settings_Hotkeys,
            this.tsm_Settings_Theme,
            this.tsm_Settings_Logs});
            this.tsm_Settings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsm_Settings.Name = "tsm_Settings";
            this.tsm_Settings.Size = new System.Drawing.Size(61, 20);
            this.tsm_Settings.Text = "Settings";
            // 
            // tsm_Settings_Language
            // 
            this.tsm_Settings_Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_Settings_Language_English,
            this.tsm_Settings_Language_Francais});
            this.tsm_Settings_Language.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_language_48;
            this.tsm_Settings_Language.Name = "tsm_Settings_Language";
            this.tsm_Settings_Language.Size = new System.Drawing.Size(180, 22);
            this.tsm_Settings_Language.Text = "Language";
            // 
            // tsm_Settings_Language_English
            // 
            this.tsm_Settings_Language_English.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_great_britain_48;
            this.tsm_Settings_Language_English.Name = "tsm_Settings_Language_English";
            this.tsm_Settings_Language_English.Size = new System.Drawing.Size(117, 22);
            this.tsm_Settings_Language_English.Text = "English";
            this.tsm_Settings_Language_English.Click += new System.EventHandler(this.Tsm_Settings_Language_English_Click);
            // 
            // tsm_Settings_Language_Francais
            // 
            this.tsm_Settings_Language_Francais.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_france_48;
            this.tsm_Settings_Language_Francais.Name = "tsm_Settings_Language_Francais";
            this.tsm_Settings_Language_Francais.Size = new System.Drawing.Size(117, 22);
            this.tsm_Settings_Language_Francais.Text = "Français";
            this.tsm_Settings_Language_Francais.Click += new System.EventHandler(this.Tsm_Settings_Language_Francais_Click);
            // 
            // tsm_Settings_Hotkeys
            // 
            this.tsm_Settings_Hotkeys.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_keypad_48;
            this.tsm_Settings_Hotkeys.Name = "tsm_Settings_Hotkeys";
            this.tsm_Settings_Hotkeys.Size = new System.Drawing.Size(180, 22);
            this.tsm_Settings_Hotkeys.Text = "Shortcuts";
            this.tsm_Settings_Hotkeys.Click += new System.EventHandler(this.Tsm_Settings_Hotkeys_Click);
            // 
            // tsm_Settings_Theme
            // 
            this.tsm_Settings_Theme.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_change_theme_48;
            this.tsm_Settings_Theme.Name = "tsm_Settings_Theme";
            this.tsm_Settings_Theme.Size = new System.Drawing.Size(180, 22);
            this.tsm_Settings_Theme.Text = "Theme";
            // 
            // tsm_Settings_Logs
            // 
            this.tsm_Settings_Logs.Name = "tsm_Settings_Logs";
            this.tsm_Settings_Logs.Size = new System.Drawing.Size(180, 22);
            this.tsm_Settings_Logs.Text = "Save logs";
            this.tsm_Settings_Logs.Click += new System.EventHandler(this.Tsm_Settings_Logs_Click);
            // 
            // tsm_About
            // 
            this.tsm_About.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsm_About.Name = "tsm_About";
            this.tsm_About.Size = new System.Drawing.Size(52, 20);
            this.tsm_About.Text = "About";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.button_SaveSequence);
            this.panel1.Controls.Add(this.comboBoxListSequences);
            this.panel1.Controls.Add(this.button_StopBot);
            this.panel1.Controls.Add(this.button_AddAction);
            this.panel1.Controls.Add(this.button_EditAction);
            this.panel1.Controls.Add(this.button_DeleteAction);
            this.panel1.Controls.Add(this.button_StartBot);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 30);
            this.panel1.TabIndex = 23;
            // 
            // button_SaveSequence
            // 
            this.button_SaveSequence.BackgroundImage = global::Tao_Bot_Maker.Properties.Resources.icons8_save_48;
            this.button_SaveSequence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_SaveSequence.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_SaveSequence.Location = new System.Drawing.Point(288, 2);
            this.button_SaveSequence.Margin = new System.Windows.Forms.Padding(2);
            this.button_SaveSequence.Name = "button_SaveSequence";
            this.button_SaveSequence.Size = new System.Drawing.Size(28, 28);
            this.button_SaveSequence.TabIndex = 9;
            this.button_SaveSequence.UseVisualStyleBackColor = false;
            this.button_SaveSequence.Click += new System.EventHandler(this.Button_SaveSequence_Click);
            // 
            // button_StopBot
            // 
            this.button_StopBot.BackgroundImage = global::Tao_Bot_Maker.Properties.Resources.icons8_stop_48;
            this.button_StopBot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_StopBot.Enabled = false;
            this.button_StopBot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_StopBot.Location = new System.Drawing.Point(132, 2);
            this.button_StopBot.Margin = new System.Windows.Forms.Padding(2);
            this.button_StopBot.Name = "button_StopBot";
            this.button_StopBot.Size = new System.Drawing.Size(28, 28);
            this.button_StopBot.TabIndex = 7;
            this.button_StopBot.UseVisualStyleBackColor = false;
            this.button_StopBot.Click += new System.EventHandler(this.Button_StopBot_Click);
            // 
            // button_AddAction
            // 
            this.button_AddAction.BackColor = System.Drawing.SystemColors.Control;
            this.button_AddAction.BackgroundImage = global::Tao_Bot_Maker.Properties.Resources.icons8_add_48;
            this.button_AddAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_AddAction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_AddAction.Location = new System.Drawing.Point(3, 2);
            this.button_AddAction.Name = "button_AddAction";
            this.button_AddAction.Size = new System.Drawing.Size(28, 28);
            this.button_AddAction.TabIndex = 13;
            this.button_AddAction.UseVisualStyleBackColor = false;
            this.button_AddAction.Click += new System.EventHandler(this.Button_Add_Action_Click);
            // 
            // button_EditAction
            // 
            this.button_EditAction.BackgroundImage = global::Tao_Bot_Maker.Properties.Resources.icons8_edit_48;
            this.button_EditAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_EditAction.Enabled = false;
            this.button_EditAction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_EditAction.Location = new System.Drawing.Point(36, 2);
            this.button_EditAction.Margin = new System.Windows.Forms.Padding(2);
            this.button_EditAction.Name = "button_EditAction";
            this.button_EditAction.Size = new System.Drawing.Size(28, 28);
            this.button_EditAction.TabIndex = 20;
            this.button_EditAction.UseVisualStyleBackColor = false;
            this.button_EditAction.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // button_DeleteAction
            // 
            this.button_DeleteAction.BackgroundImage = global::Tao_Bot_Maker.Properties.Resources.icons8_remove_48;
            this.button_DeleteAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_DeleteAction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_DeleteAction.Location = new System.Drawing.Point(68, 2);
            this.button_DeleteAction.Margin = new System.Windows.Forms.Padding(2);
            this.button_DeleteAction.Name = "button_DeleteAction";
            this.button_DeleteAction.Size = new System.Drawing.Size(28, 28);
            this.button_DeleteAction.TabIndex = 12;
            this.button_DeleteAction.UseVisualStyleBackColor = false;
            this.button_DeleteAction.Click += new System.EventHandler(this.Button_ClearSequence_Click);
            // 
            // button_StartBot
            // 
            this.button_StartBot.BackgroundImage = global::Tao_Bot_Maker.Properties.Resources.icons8_play_48;
            this.button_StartBot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_StartBot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_StartBot.Location = new System.Drawing.Point(100, 2);
            this.button_StartBot.Margin = new System.Windows.Forms.Padding(2);
            this.button_StartBot.Name = "button_StartBot";
            this.button_StartBot.Size = new System.Drawing.Size(28, 28);
            this.button_StartBot.TabIndex = 6;
            this.button_StartBot.UseVisualStyleBackColor = false;
            this.button_StartBot.Click += new System.EventHandler(this.Button_StartBot_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.Controls.Add(this.listBoxActions);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainApp";
            this.Text = "Tao\'s Bot Maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainApp_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxActions;
        private System.Windows.Forms.Button button_StartBot;
        private System.Windows.Forms.Button button_StopBot;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button button_SaveSequence;
        private System.Windows.Forms.ComboBox comboBoxListSequences;
        private System.Windows.Forms.Button button_EditAction;
        private System.Windows.Forms.Button button_DeleteAction;
        private System.Windows.Forms.Button button_AddAction;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsm_File;
        private System.Windows.Forms.ToolStripMenuItem tsm_File_Save;
        private System.Windows.Forms.ToolStripMenuItem tsm_File_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsm_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem tsm_Bot;
        private System.Windows.Forms.ToolStripMenuItem tsm_Bot_Start;
        private System.Windows.Forms.ToolStripMenuItem tsm_Bot_Stop;
        private System.Windows.Forms.ToolStripMenuItem tsm_Settings;
        private System.Windows.Forms.ToolStripMenuItem tsm_Settings_Language;
        private System.Windows.Forms.ToolStripMenuItem tsm_Settings_Theme;
        private System.Windows.Forms.ToolStripMenuItem tsm_Settings_Logs;
        private System.Windows.Forms.ToolStripMenuItem tsm_Settings_Hotkeys;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsm_Settings_Language_English;
        private System.Windows.Forms.ToolStripMenuItem tsm_Settings_Language_Francais;
        private System.Windows.Forms.ToolStripMenuItem tsm_About;
    }
}

