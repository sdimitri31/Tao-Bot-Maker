namespace Tao_Bot_Maker.View
{
    partial class SaveSequenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveSequenceForm));
            this.savedSequencesListView = new System.Windows.Forms.ListView();
            this.sequenceNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sequencePanel = new System.Windows.Forms.Panel();
            this.sequenceNamePanel = new System.Windows.Forms.Panel();
            this.sequenceNameTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sequenceNameLabel = new System.Windows.Forms.Label();
            this.sequenceNameTextBox = new System.Windows.Forms.TextBox();
            this.savedSequencesPanel = new System.Windows.Forms.Panel();
            this.savedSequencesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.savedSequencesLabel = new System.Windows.Forms.Label();
            this.openSequencesFolderPanel = new System.Windows.Forms.Panel();
            this.openSequencesFolderTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.openSequencesFolderButton = new System.Windows.Forms.Button();
            this.bottomPanel.SuspendLayout();
            this.sequencePanel.SuspendLayout();
            this.sequenceNamePanel.SuspendLayout();
            this.sequenceNameTableLayoutPanel.SuspendLayout();
            this.savedSequencesPanel.SuspendLayout();
            this.savedSequencesTableLayoutPanel.SuspendLayout();
            this.openSequencesFolderPanel.SuspendLayout();
            this.openSequencesFolderTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // savedSequencesListView
            // 
            this.savedSequencesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sequenceNameColumnHeader});
            this.savedSequencesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savedSequencesListView.FullRowSelect = true;
            this.savedSequencesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.savedSequencesListView.HideSelection = false;
            this.savedSequencesListView.Location = new System.Drawing.Point(145, 0);
            this.savedSequencesListView.Margin = new System.Windows.Forms.Padding(0);
            this.savedSequencesListView.MultiSelect = false;
            this.savedSequencesListView.Name = "savedSequencesListView";
            this.savedSequencesListView.Size = new System.Drawing.Size(243, 159);
            this.savedSequencesListView.TabIndex = 0;
            this.savedSequencesListView.UseCompatibleStateImageBehavior = false;
            this.savedSequencesListView.View = System.Windows.Forms.View.Details;
            this.savedSequencesListView.SelectedIndexChanged += new System.EventHandler(this.SavedSequencesListView_SelectedIndexChanged);
            this.savedSequencesListView.Resize += new System.EventHandler(this.SavedSequencesListView_Resize);
            // 
            // sequenceNameColumnHeader
            // 
            this.sequenceNameColumnHeader.Text = "Name";
            this.sequenceNameColumnHeader.Width = 144;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 303);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(421, 47);
            this.bottomPanel.TabIndex = 6;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(253, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Add";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(334, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // sequencePanel
            // 
            this.sequencePanel.Controls.Add(this.sequenceNamePanel);
            this.sequencePanel.Controls.Add(this.savedSequencesPanel);
            this.sequencePanel.Controls.Add(this.openSequencesFolderPanel);
            this.sequencePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sequencePanel.Location = new System.Drawing.Point(0, 0);
            this.sequencePanel.Name = "sequencePanel";
            this.sequencePanel.Padding = new System.Windows.Forms.Padding(8);
            this.sequencePanel.Size = new System.Drawing.Size(421, 303);
            this.sequencePanel.TabIndex = 7;
            // 
            // sequenceNamePanel
            // 
            this.sequenceNamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceNamePanel.Controls.Add(this.sequenceNameTableLayoutPanel);
            this.sequenceNamePanel.Location = new System.Drawing.Point(9, 247);
            this.sequenceNamePanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.sequenceNamePanel.Name = "sequenceNamePanel";
            this.sequenceNamePanel.Padding = new System.Windows.Forms.Padding(8);
            this.sequenceNamePanel.Size = new System.Drawing.Size(404, 49);
            this.sequenceNamePanel.TabIndex = 5;
            // 
            // sequenceNameTableLayoutPanel
            // 
            this.sequenceNameTableLayoutPanel.ColumnCount = 2;
            this.sequenceNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.62886F));
            this.sequenceNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.37114F));
            this.sequenceNameTableLayoutPanel.Controls.Add(this.sequenceNameLabel, 0, 0);
            this.sequenceNameTableLayoutPanel.Controls.Add(this.sequenceNameTextBox, 1, 0);
            this.sequenceNameTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sequenceNameTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.sequenceNameTableLayoutPanel.Name = "sequenceNameTableLayoutPanel";
            this.sequenceNameTableLayoutPanel.RowCount = 1;
            this.sequenceNameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sequenceNameTableLayoutPanel.Size = new System.Drawing.Size(388, 33);
            this.sequenceNameTableLayoutPanel.TabIndex = 0;
            // 
            // sequenceNameLabel
            // 
            this.sequenceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceNameLabel.AutoSize = true;
            this.sequenceNameLabel.Location = new System.Drawing.Point(3, 10);
            this.sequenceNameLabel.Name = "sequenceNameLabel";
            this.sequenceNameLabel.Size = new System.Drawing.Size(139, 13);
            this.sequenceNameLabel.TabIndex = 2;
            this.sequenceNameLabel.Text = "Sequence name:";
            // 
            // sequenceNameTextBox
            // 
            this.sequenceNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceNameTextBox.Location = new System.Drawing.Point(148, 6);
            this.sequenceNameTextBox.Name = "sequenceNameTextBox";
            this.sequenceNameTextBox.Size = new System.Drawing.Size(237, 20);
            this.sequenceNameTextBox.TabIndex = 1;
            // 
            // savedSequencesPanel
            // 
            this.savedSequencesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.savedSequencesPanel.Controls.Add(this.savedSequencesTableLayoutPanel);
            this.savedSequencesPanel.Location = new System.Drawing.Point(9, 64);
            this.savedSequencesPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.savedSequencesPanel.Name = "savedSequencesPanel";
            this.savedSequencesPanel.Padding = new System.Windows.Forms.Padding(8);
            this.savedSequencesPanel.Size = new System.Drawing.Size(404, 175);
            this.savedSequencesPanel.TabIndex = 4;
            // 
            // savedSequencesTableLayoutPanel
            // 
            this.savedSequencesTableLayoutPanel.ColumnCount = 2;
            this.savedSequencesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.37114F));
            this.savedSequencesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.62886F));
            this.savedSequencesTableLayoutPanel.Controls.Add(this.savedSequencesListView, 1, 0);
            this.savedSequencesTableLayoutPanel.Controls.Add(this.savedSequencesLabel, 0, 0);
            this.savedSequencesTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savedSequencesTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.savedSequencesTableLayoutPanel.Name = "savedSequencesTableLayoutPanel";
            this.savedSequencesTableLayoutPanel.RowCount = 1;
            this.savedSequencesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.savedSequencesTableLayoutPanel.Size = new System.Drawing.Size(388, 159);
            this.savedSequencesTableLayoutPanel.TabIndex = 0;
            // 
            // savedSequencesLabel
            // 
            this.savedSequencesLabel.AutoSize = true;
            this.savedSequencesLabel.Location = new System.Drawing.Point(3, 0);
            this.savedSequencesLabel.Name = "savedSequencesLabel";
            this.savedSequencesLabel.Size = new System.Drawing.Size(93, 13);
            this.savedSequencesLabel.TabIndex = 1;
            this.savedSequencesLabel.Text = "Saved sequences";
            // 
            // openSequencesFolderPanel
            // 
            this.openSequencesFolderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openSequencesFolderPanel.Controls.Add(this.openSequencesFolderTableLayoutPanel);
            this.openSequencesFolderPanel.Location = new System.Drawing.Point(9, 9);
            this.openSequencesFolderPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.openSequencesFolderPanel.Name = "openSequencesFolderPanel";
            this.openSequencesFolderPanel.Padding = new System.Windows.Forms.Padding(8);
            this.openSequencesFolderPanel.Size = new System.Drawing.Size(404, 47);
            this.openSequencesFolderPanel.TabIndex = 3;
            // 
            // openSequencesFolderTableLayoutPanel
            // 
            this.openSequencesFolderTableLayoutPanel.ColumnCount = 1;
            this.openSequencesFolderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openSequencesFolderTableLayoutPanel.Controls.Add(this.openSequencesFolderButton, 0, 0);
            this.openSequencesFolderTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openSequencesFolderTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.openSequencesFolderTableLayoutPanel.Name = "openSequencesFolderTableLayoutPanel";
            this.openSequencesFolderTableLayoutPanel.RowCount = 1;
            this.openSequencesFolderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openSequencesFolderTableLayoutPanel.Size = new System.Drawing.Size(388, 31);
            this.openSequencesFolderTableLayoutPanel.TabIndex = 0;
            // 
            // openSequencesFolderButton
            // 
            this.openSequencesFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.openSequencesFolderButton.Location = new System.Drawing.Point(3, 4);
            this.openSequencesFolderButton.Name = "openSequencesFolderButton";
            this.openSequencesFolderButton.Size = new System.Drawing.Size(382, 23);
            this.openSequencesFolderButton.TabIndex = 0;
            this.openSequencesFolderButton.Text = "Open sequences folder";
            this.openSequencesFolderButton.UseVisualStyleBackColor = true;
            this.openSequencesFolderButton.Click += new System.EventHandler(this.OpenSequencesFolderButton_Click);
            // 
            // SaveSequenceForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(421, 350);
            this.Controls.Add(this.sequencePanel);
            this.Controls.Add(this.bottomPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaveSequenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SaveSequenceForm";
            this.bottomPanel.ResumeLayout(false);
            this.sequencePanel.ResumeLayout(false);
            this.sequenceNamePanel.ResumeLayout(false);
            this.sequenceNameTableLayoutPanel.ResumeLayout(false);
            this.sequenceNameTableLayoutPanel.PerformLayout();
            this.savedSequencesPanel.ResumeLayout(false);
            this.savedSequencesTableLayoutPanel.ResumeLayout(false);
            this.savedSequencesTableLayoutPanel.PerformLayout();
            this.openSequencesFolderPanel.ResumeLayout(false);
            this.openSequencesFolderTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView savedSequencesListView;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel sequencePanel;
        private System.Windows.Forms.Label sequenceNameLabel;
        private System.Windows.Forms.TextBox sequenceNameTextBox;
        private System.Windows.Forms.ColumnHeader sequenceNameColumnHeader;
        private System.Windows.Forms.Panel openSequencesFolderPanel;
        private System.Windows.Forms.Panel savedSequencesPanel;
        private System.Windows.Forms.TableLayoutPanel openSequencesFolderTableLayoutPanel;
        private System.Windows.Forms.Button openSequencesFolderButton;
        private System.Windows.Forms.TableLayoutPanel savedSequencesTableLayoutPanel;
        private System.Windows.Forms.Label savedSequencesLabel;
        private System.Windows.Forms.Panel sequenceNamePanel;
        private System.Windows.Forms.TableLayoutPanel sequenceNameTableLayoutPanel;
    }
}