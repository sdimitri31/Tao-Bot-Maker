namespace Tao_Bot_Maker.View
{
    partial class MouseActionPropertiesPanel
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
            this.clickTypeLabel = new System.Windows.Forms.Label();
            this.startXCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.useCurrentPositionCheckBox = new System.Windows.Forms.CheckBox();
            this.startYCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.leftClickRadioButton = new System.Windows.Forms.RadioButton();
            this.middleClickRadioButton = new System.Windows.Forms.RadioButton();
            this.rightClickRadioButton = new System.Windows.Forms.RadioButton();
            this.noneClickRadioButton = new System.Windows.Forms.RadioButton();
            this.startCoordinateLabel = new System.Windows.Forms.Label();
            this.startImageCoordCheckBox = new System.Windows.Forms.CheckBox();
            this.speedComboBox = new System.Windows.Forms.ComboBox();
            this.overlayCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.actionLabel = new System.Windows.Forms.Label();
            this.dragAndDropRadioButton = new System.Windows.Forms.RadioButton();
            this.scrollRadioButton = new System.Windows.Forms.RadioButton();
            this.doubleClickRadioButton = new System.Windows.Forms.RadioButton();
            this.clickRadioButton = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.endImageCoordCheckBox = new System.Windows.Forms.CheckBox();
            this.endYCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endXCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endCoordinateLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.speedLabel = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.scrollAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scrollAmountLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.clickDurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.clickDurationLabel = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.startXCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYCoordinateNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endYCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endXCoordinateNumericUpDown)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAmountNumericUpDown)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clickDurationNumericUpDown)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // clickTypeLabel
            // 
            this.clickTypeLabel.Location = new System.Drawing.Point(3, 3);
            this.clickTypeLabel.Name = "clickTypeLabel";
            this.clickTypeLabel.Size = new System.Drawing.Size(91, 30);
            this.clickTypeLabel.TabIndex = 0;
            this.clickTypeLabel.Text = "Click";
            this.clickTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startXCoordinateNumericUpDown
            // 
            this.startXCoordinateNumericUpDown.Location = new System.Drawing.Point(100, 11);
            this.startXCoordinateNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.startXCoordinateNumericUpDown.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.startXCoordinateNumericUpDown.Name = "startXCoordinateNumericUpDown";
            this.startXCoordinateNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.startXCoordinateNumericUpDown.TabIndex = 3;
            this.startXCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // useCurrentPositionCheckBox
            // 
            this.useCurrentPositionCheckBox.Location = new System.Drawing.Point(300, 3);
            this.useCurrentPositionCheckBox.Name = "useCurrentPositionCheckBox";
            this.useCurrentPositionCheckBox.Size = new System.Drawing.Size(93, 36);
            this.useCurrentPositionCheckBox.TabIndex = 4;
            this.useCurrentPositionCheckBox.Text = "Use current position";
            this.useCurrentPositionCheckBox.UseVisualStyleBackColor = true;
            this.useCurrentPositionCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // startYCoordinateNumericUpDown
            // 
            this.startYCoordinateNumericUpDown.Location = new System.Drawing.Point(200, 11);
            this.startYCoordinateNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.startYCoordinateNumericUpDown.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.startYCoordinateNumericUpDown.Name = "startYCoordinateNumericUpDown";
            this.startYCoordinateNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.startYCoordinateNumericUpDown.TabIndex = 6;
            this.startYCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // leftClickRadioButton
            // 
            this.leftClickRadioButton.Location = new System.Drawing.Point(100, 3);
            this.leftClickRadioButton.Name = "leftClickRadioButton";
            this.leftClickRadioButton.Size = new System.Drawing.Size(94, 30);
            this.leftClickRadioButton.TabIndex = 19;
            this.leftClickRadioButton.Text = "Left click";
            this.leftClickRadioButton.UseVisualStyleBackColor = true;
            this.leftClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // middleClickRadioButton
            // 
            this.middleClickRadioButton.Location = new System.Drawing.Point(200, 3);
            this.middleClickRadioButton.Name = "middleClickRadioButton";
            this.middleClickRadioButton.Size = new System.Drawing.Size(94, 30);
            this.middleClickRadioButton.TabIndex = 20;
            this.middleClickRadioButton.Text = "Middle click";
            this.middleClickRadioButton.UseVisualStyleBackColor = true;
            this.middleClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // rightClickRadioButton
            // 
            this.rightClickRadioButton.Location = new System.Drawing.Point(300, 3);
            this.rightClickRadioButton.Name = "rightClickRadioButton";
            this.rightClickRadioButton.Size = new System.Drawing.Size(94, 30);
            this.rightClickRadioButton.TabIndex = 21;
            this.rightClickRadioButton.Text = "Right click";
            this.rightClickRadioButton.UseVisualStyleBackColor = true;
            this.rightClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // noneClickRadioButton
            // 
            this.noneClickRadioButton.Location = new System.Drawing.Point(400, 3);
            this.noneClickRadioButton.Name = "noneClickRadioButton";
            this.noneClickRadioButton.Size = new System.Drawing.Size(94, 30);
            this.noneClickRadioButton.TabIndex = 22;
            this.noneClickRadioButton.Text = "No click";
            this.noneClickRadioButton.UseVisualStyleBackColor = true;
            this.noneClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // startCoordinateLabel
            // 
            this.startCoordinateLabel.Location = new System.Drawing.Point(3, 3);
            this.startCoordinateLabel.Name = "startCoordinateLabel";
            this.startCoordinateLabel.Size = new System.Drawing.Size(91, 36);
            this.startCoordinateLabel.TabIndex = 11;
            this.startCoordinateLabel.Text = "Start coords";
            this.startCoordinateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startImageCoordCheckBox
            // 
            this.startImageCoordCheckBox.Location = new System.Drawing.Point(399, 3);
            this.startImageCoordCheckBox.Name = "startImageCoordCheckBox";
            this.startImageCoordCheckBox.Size = new System.Drawing.Size(95, 36);
            this.startImageCoordCheckBox.TabIndex = 26;
            this.startImageCoordCheckBox.Text = "Use image coordinates";
            this.startImageCoordCheckBox.UseVisualStyleBackColor = true;
            this.startImageCoordCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // speedComboBox
            // 
            this.speedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedComboBox.FormattingEnabled = true;
            this.speedComboBox.Location = new System.Drawing.Point(100, 12);
            this.speedComboBox.Name = "speedComboBox";
            this.speedComboBox.Size = new System.Drawing.Size(194, 21);
            this.speedComboBox.TabIndex = 14;
            // 
            // overlayCheckBox
            // 
            this.overlayCheckBox.Location = new System.Drawing.Point(100, 3);
            this.overlayCheckBox.Name = "overlayCheckBox";
            this.overlayCheckBox.Size = new System.Drawing.Size(194, 36);
            this.overlayCheckBox.TabIndex = 28;
            this.overlayCheckBox.Text = "Enable overlay";
            this.overlayCheckBox.UseVisualStyleBackColor = true;
            this.overlayCheckBox.CheckedChanged += new System.EventHandler(this.OverlayCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.noneClickRadioButton);
            this.panel1.Controls.Add(this.rightClickRadioButton);
            this.panel1.Controls.Add(this.middleClickRadioButton);
            this.panel1.Controls.Add(this.clickTypeLabel);
            this.panel1.Controls.Add(this.leftClickRadioButton);
            this.panel1.Location = new System.Drawing.Point(3, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 36);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.actionLabel);
            this.panel2.Controls.Add(this.dragAndDropRadioButton);
            this.panel2.Controls.Add(this.scrollRadioButton);
            this.panel2.Controls.Add(this.doubleClickRadioButton);
            this.panel2.Controls.Add(this.clickRadioButton);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 34);
            this.panel2.TabIndex = 8;
            // 
            // actionLabel
            // 
            this.actionLabel.Location = new System.Drawing.Point(3, 3);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(91, 28);
            this.actionLabel.TabIndex = 31;
            this.actionLabel.Text = "Action";
            this.actionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dragAndDropRadioButton
            // 
            this.dragAndDropRadioButton.Location = new System.Drawing.Point(399, 3);
            this.dragAndDropRadioButton.Name = "dragAndDropRadioButton";
            this.dragAndDropRadioButton.Size = new System.Drawing.Size(95, 28);
            this.dragAndDropRadioButton.TabIndex = 30;
            this.dragAndDropRadioButton.TabStop = true;
            this.dragAndDropRadioButton.Text = "Drag and Drop";
            this.dragAndDropRadioButton.UseVisualStyleBackColor = true;
            this.dragAndDropRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // scrollRadioButton
            // 
            this.scrollRadioButton.Location = new System.Drawing.Point(300, 3);
            this.scrollRadioButton.Name = "scrollRadioButton";
            this.scrollRadioButton.Size = new System.Drawing.Size(84, 28);
            this.scrollRadioButton.TabIndex = 29;
            this.scrollRadioButton.TabStop = true;
            this.scrollRadioButton.Text = "Scroll";
            this.scrollRadioButton.UseVisualStyleBackColor = true;
            this.scrollRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // doubleClickRadioButton
            // 
            this.doubleClickRadioButton.Location = new System.Drawing.Point(200, 3);
            this.doubleClickRadioButton.Name = "doubleClickRadioButton";
            this.doubleClickRadioButton.Size = new System.Drawing.Size(94, 28);
            this.doubleClickRadioButton.TabIndex = 28;
            this.doubleClickRadioButton.TabStop = true;
            this.doubleClickRadioButton.Text = "Double click";
            this.doubleClickRadioButton.UseVisualStyleBackColor = true;
            this.doubleClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // clickRadioButton
            // 
            this.clickRadioButton.Location = new System.Drawing.Point(100, 3);
            this.clickRadioButton.Name = "clickRadioButton";
            this.clickRadioButton.Size = new System.Drawing.Size(94, 28);
            this.clickRadioButton.TabIndex = 27;
            this.clickRadioButton.TabStop = true;
            this.clickRadioButton.Text = "Click";
            this.clickRadioButton.UseVisualStyleBackColor = true;
            this.clickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.startImageCoordCheckBox);
            this.panel3.Controls.Add(this.useCurrentPositionCheckBox);
            this.panel3.Controls.Add(this.startYCoordinateNumericUpDown);
            this.panel3.Controls.Add(this.startXCoordinateNumericUpDown);
            this.panel3.Controls.Add(this.startCoordinateLabel);
            this.panel3.Location = new System.Drawing.Point(3, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 42);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.endImageCoordCheckBox);
            this.panel4.Controls.Add(this.endYCoordinateNumericUpDown);
            this.panel4.Controls.Add(this.endXCoordinateNumericUpDown);
            this.panel4.Controls.Add(this.endCoordinateLabel);
            this.panel4.Location = new System.Drawing.Point(3, 133);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 42);
            this.panel4.TabIndex = 27;
            // 
            // endImageCoordCheckBox
            // 
            this.endImageCoordCheckBox.Location = new System.Drawing.Point(399, 3);
            this.endImageCoordCheckBox.Name = "endImageCoordCheckBox";
            this.endImageCoordCheckBox.Size = new System.Drawing.Size(95, 36);
            this.endImageCoordCheckBox.TabIndex = 26;
            this.endImageCoordCheckBox.Text = "Use image coordinates";
            this.endImageCoordCheckBox.UseVisualStyleBackColor = true;
            // 
            // endYCoordinateNumericUpDown
            // 
            this.endYCoordinateNumericUpDown.Location = new System.Drawing.Point(200, 11);
            this.endYCoordinateNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.endYCoordinateNumericUpDown.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.endYCoordinateNumericUpDown.Name = "endYCoordinateNumericUpDown";
            this.endYCoordinateNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.endYCoordinateNumericUpDown.TabIndex = 6;
            // 
            // endXCoordinateNumericUpDown
            // 
            this.endXCoordinateNumericUpDown.Location = new System.Drawing.Point(100, 11);
            this.endXCoordinateNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.endXCoordinateNumericUpDown.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.endXCoordinateNumericUpDown.Name = "endXCoordinateNumericUpDown";
            this.endXCoordinateNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.endXCoordinateNumericUpDown.TabIndex = 3;
            // 
            // endCoordinateLabel
            // 
            this.endCoordinateLabel.Location = new System.Drawing.Point(3, 3);
            this.endCoordinateLabel.Name = "endCoordinateLabel";
            this.endCoordinateLabel.Size = new System.Drawing.Size(91, 36);
            this.endCoordinateLabel.TabIndex = 11;
            this.endCoordinateLabel.Text = "End coords";
            this.endCoordinateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.speedComboBox);
            this.panel5.Controls.Add(this.speedLabel);
            this.panel5.Location = new System.Drawing.Point(3, 181);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(500, 42);
            this.panel5.TabIndex = 28;
            // 
            // speedLabel
            // 
            this.speedLabel.Location = new System.Drawing.Point(3, 3);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(91, 36);
            this.speedLabel.TabIndex = 11;
            this.speedLabel.Text = "Speed";
            this.speedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Controls.Add(this.scrollAmountNumericUpDown);
            this.panel6.Controls.Add(this.scrollAmountLabel);
            this.panel6.Location = new System.Drawing.Point(3, 229);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(500, 42);
            this.panel6.TabIndex = 29;
            // 
            // scrollAmountNumericUpDown
            // 
            this.scrollAmountNumericUpDown.Location = new System.Drawing.Point(100, 11);
            this.scrollAmountNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.scrollAmountNumericUpDown.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.scrollAmountNumericUpDown.Name = "scrollAmountNumericUpDown";
            this.scrollAmountNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.scrollAmountNumericUpDown.TabIndex = 3;
            // 
            // scrollAmountLabel
            // 
            this.scrollAmountLabel.Location = new System.Drawing.Point(3, 3);
            this.scrollAmountLabel.Name = "scrollAmountLabel";
            this.scrollAmountLabel.Size = new System.Drawing.Size(91, 36);
            this.scrollAmountLabel.TabIndex = 11;
            this.scrollAmountLabel.Text = "Scroll amount";
            this.scrollAmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.Controls.Add(this.clickDurationNumericUpDown);
            this.panel7.Controls.Add(this.clickDurationLabel);
            this.panel7.Location = new System.Drawing.Point(3, 277);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(500, 42);
            this.panel7.TabIndex = 30;
            // 
            // clickDurationNumericUpDown
            // 
            this.clickDurationNumericUpDown.Location = new System.Drawing.Point(100, 11);
            this.clickDurationNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.clickDurationNumericUpDown.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.clickDurationNumericUpDown.Name = "clickDurationNumericUpDown";
            this.clickDurationNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.clickDurationNumericUpDown.TabIndex = 3;
            // 
            // clickDurationLabel
            // 
            this.clickDurationLabel.Location = new System.Drawing.Point(3, 3);
            this.clickDurationLabel.Name = "clickDurationLabel";
            this.clickDurationLabel.Size = new System.Drawing.Size(91, 36);
            this.clickDurationLabel.TabIndex = 11;
            this.clickDurationLabel.Text = "Click duration";
            this.clickDurationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.Gainsboro;
            this.panel8.Controls.Add(this.overlayCheckBox);
            this.panel8.Location = new System.Drawing.Point(3, 325);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(500, 42);
            this.panel8.TabIndex = 31;
            // 
            // MouseActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MouseActionPropertiesPanel";
            this.Size = new System.Drawing.Size(506, 371);
            this.VisibleChanged += new System.EventHandler(this.MouseActionPropertiesPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.startXCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYCoordinateNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.endYCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endXCoordinateNumericUpDown)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrollAmountNumericUpDown)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clickDurationNumericUpDown)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label clickTypeLabel;
        private System.Windows.Forms.NumericUpDown startXCoordinateNumericUpDown;
        private System.Windows.Forms.NumericUpDown startYCoordinateNumericUpDown;
        private System.Windows.Forms.CheckBox useCurrentPositionCheckBox;
        private System.Windows.Forms.Label startCoordinateLabel;
        private System.Windows.Forms.ComboBox speedComboBox;
        private System.Windows.Forms.RadioButton leftClickRadioButton;
        private System.Windows.Forms.RadioButton middleClickRadioButton;
        private System.Windows.Forms.RadioButton rightClickRadioButton;
        private System.Windows.Forms.RadioButton noneClickRadioButton;
        private System.Windows.Forms.CheckBox startImageCoordCheckBox;
        private System.Windows.Forms.CheckBox overlayCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton dragAndDropRadioButton;
        private System.Windows.Forms.RadioButton scrollRadioButton;
        private System.Windows.Forms.RadioButton doubleClickRadioButton;
        private System.Windows.Forms.RadioButton clickRadioButton;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox endImageCoordCheckBox;
        private System.Windows.Forms.NumericUpDown endYCoordinateNumericUpDown;
        private System.Windows.Forms.NumericUpDown endXCoordinateNumericUpDown;
        private System.Windows.Forms.Label endCoordinateLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.NumericUpDown scrollAmountNumericUpDown;
        private System.Windows.Forms.Label scrollAmountLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.NumericUpDown clickDurationNumericUpDown;
        private System.Windows.Forms.Label clickDurationLabel;
        private System.Windows.Forms.Panel panel8;
    }
}
