namespace Tao_Bot_Maker.View
{
    partial class ActionCustomListItem
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
            this.actionTextLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dragPictureBox = new System.Windows.Forms.PictureBox();
            this.actionIconPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dragPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // actionTextLabel
            // 
            this.actionTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionTextLabel.Location = new System.Drawing.Point(28, 3);
            this.actionTextLabel.Margin = new System.Windows.Forms.Padding(3);
            this.actionTextLabel.Name = "actionTextLabel";
            this.actionTextLabel.Size = new System.Drawing.Size(352, 28);
            this.actionTextLabel.TabIndex = 1;
            this.actionTextLabel.Text = "label1";
            this.actionTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Controls.Add(this.dragPictureBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionIconPictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionTextLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 34);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dragPictureBox
            // 
            this.dragPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dragPictureBox.Image = global::Tao_Bot_Maker.Properties.Resources.icons8_drag_48;
            this.dragPictureBox.Location = new System.Drawing.Point(383, 4);
            this.dragPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.dragPictureBox.Name = "dragPictureBox";
            this.dragPictureBox.Size = new System.Drawing.Size(25, 25);
            this.dragPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dragPictureBox.TabIndex = 2;
            this.dragPictureBox.TabStop = false;
            this.dragPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPictureBox_MouseDown);
            // 
            // actionIconPictureBox
            // 
            this.actionIconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.actionIconPictureBox.Location = new System.Drawing.Point(0, 4);
            this.actionIconPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.actionIconPictureBox.Name = "actionIconPictureBox";
            this.actionIconPictureBox.Size = new System.Drawing.Size(25, 25);
            this.actionIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.actionIconPictureBox.TabIndex = 0;
            this.actionIconPictureBox.TabStop = false;
            // 
            // ActionCustomListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.MinimumSize = new System.Drawing.Size(0, 50);
            this.Name = "ActionCustomListItem";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(424, 50);
            this.MouseEnter += new System.EventHandler(this.ActionTypeCustomListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ActionTypeCustomListItem_MouseLeave);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dragPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionIconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox actionIconPictureBox;
        private System.Windows.Forms.Label actionTextLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox dragPictureBox;
    }
}
