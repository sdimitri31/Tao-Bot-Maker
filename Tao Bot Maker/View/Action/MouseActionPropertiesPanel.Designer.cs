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
            this.startXCoordinateLabel = new System.Windows.Forms.Label();
            this.startXCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.useCurrentPositionCheckBox = new System.Windows.Forms.CheckBox();
            this.startYCoordinateLabel = new System.Windows.Forms.Label();
            this.startYCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scrollAmountLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedComboBox = new System.Windows.Forms.ComboBox();
            this.scrollAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.clickDurationLabel = new System.Windows.Forms.Label();
            this.clickDurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.leftClickRadioButton = new System.Windows.Forms.RadioButton();
            this.middleClickRadioButton = new System.Windows.Forms.RadioButton();
            this.rightClickRadioButton = new System.Windows.Forms.RadioButton();
            this.endYCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endYCoordinateLabel = new System.Windows.Forms.Label();
            this.endXCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endXCoordinateLabel = new System.Windows.Forms.Label();
            this.endCoordinateLabel = new System.Windows.Forms.Label();
            this.startCoordinateLabel = new System.Windows.Forms.Label();
            this.noneClickRadioButton = new System.Windows.Forms.RadioButton();
            this.doubleClickCheckBox = new System.Windows.Forms.CheckBox();
            this.dragAndDropCheckBox = new System.Windows.Forms.CheckBox();
            this.scrollCheckBox = new System.Windows.Forms.CheckBox();
            this.startImageCoordCheckBox = new System.Windows.Forms.CheckBox();
            this.endImageCoordCheckBox = new System.Windows.Forms.CheckBox();
            this.useImageCoordsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.startXCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYCoordinateNumericUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAmountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clickDurationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endYCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endXCoordinateNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // clickTypeLabel
            // 
            this.clickTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clickTypeLabel.AutoSize = true;
            this.clickTypeLabel.Location = new System.Drawing.Point(3, 14);
            this.clickTypeLabel.Name = "clickTypeLabel";
            this.clickTypeLabel.Size = new System.Drawing.Size(94, 13);
            this.clickTypeLabel.TabIndex = 0;
            this.clickTypeLabel.Text = "Mouse action";
            this.clickTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startXCoordinateLabel
            // 
            this.startXCoordinateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startXCoordinateLabel.AutoSize = true;
            this.startXCoordinateLabel.Location = new System.Drawing.Point(103, 140);
            this.startXCoordinateLabel.Name = "startXCoordinateLabel";
            this.startXCoordinateLabel.Size = new System.Drawing.Size(94, 13);
            this.startXCoordinateLabel.TabIndex = 2;
            this.startXCoordinateLabel.Text = "X";
            // 
            // startXCoordinateNumericUpDown
            // 
            this.startXCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startXCoordinateNumericUpDown.Location = new System.Drawing.Point(203, 137);
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
            // 
            // useCurrentPositionCheckBox
            // 
            this.useCurrentPositionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useCurrentPositionCheckBox.AutoSize = true;
            this.useCurrentPositionCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tableLayoutPanel1.SetColumnSpan(this.useCurrentPositionCheckBox, 2);
            this.useCurrentPositionCheckBox.Location = new System.Drawing.Point(103, 171);
            this.useCurrentPositionCheckBox.Name = "useCurrentPositionCheckBox";
            this.useCurrentPositionCheckBox.Size = new System.Drawing.Size(194, 36);
            this.useCurrentPositionCheckBox.TabIndex = 4;
            this.useCurrentPositionCheckBox.Text = "Use current position";
            this.useCurrentPositionCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.useCurrentPositionCheckBox.UseVisualStyleBackColor = true;
            this.useCurrentPositionCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // startYCoordinateLabel
            // 
            this.startYCoordinateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startYCoordinateLabel.AutoSize = true;
            this.startYCoordinateLabel.Location = new System.Drawing.Point(303, 140);
            this.startYCoordinateLabel.Name = "startYCoordinateLabel";
            this.startYCoordinateLabel.Size = new System.Drawing.Size(94, 13);
            this.startYCoordinateLabel.TabIndex = 5;
            this.startYCoordinateLabel.Text = "Y";
            // 
            // startYCoordinateNumericUpDown
            // 
            this.startYCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startYCoordinateNumericUpDown.Location = new System.Drawing.Point(403, 137);
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
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.scrollAmountLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.clickTypeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.speedLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.speedComboBox, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.scrollAmountNumericUpDown, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.clickDurationLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.clickDurationNumericUpDown, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.leftClickRadioButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.middleClickRadioButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightClickRadioButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.useCurrentPositionCheckBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.startYCoordinateNumericUpDown, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.startYCoordinateLabel, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.startXCoordinateNumericUpDown, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.startXCoordinateLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.startCoordinateLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.noneClickRadioButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.doubleClickCheckBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dragAndDropCheckBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.scrollCheckBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.endCoordinateLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.endXCoordinateLabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.endXCoordinateNumericUpDown, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.endYCoordinateLabel, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.endYCoordinateNumericUpDown, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.startImageCoordCheckBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.endImageCoordCheckBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.useImageCoordsLabel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 421);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // scrollAmountLabel
            // 
            this.scrollAmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollAmountLabel.AutoSize = true;
            this.scrollAmountLabel.Location = new System.Drawing.Point(3, 350);
            this.scrollAmountLabel.Name = "scrollAmountLabel";
            this.scrollAmountLabel.Size = new System.Drawing.Size(94, 13);
            this.scrollAmountLabel.TabIndex = 15;
            this.scrollAmountLabel.Text = "Scroll amount";
            this.scrollAmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(3, 308);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(94, 13);
            this.speedLabel.TabIndex = 13;
            this.speedLabel.Text = "Speed";
            this.speedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // speedComboBox
            // 
            this.speedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.speedComboBox, 2);
            this.speedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedComboBox.FormattingEnabled = true;
            this.speedComboBox.Location = new System.Drawing.Point(203, 304);
            this.speedComboBox.Name = "speedComboBox";
            this.speedComboBox.Size = new System.Drawing.Size(194, 21);
            this.speedComboBox.TabIndex = 14;
            // 
            // scrollDurationNumericUpDown
            // 
            this.scrollAmountNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollAmountNumericUpDown.Location = new System.Drawing.Point(203, 347);
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
            this.scrollAmountNumericUpDown.Name = "scrollDurationNumericUpDown";
            this.scrollAmountNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.scrollAmountNumericUpDown.TabIndex = 16;
            // 
            // clickDurationLabel
            // 
            this.clickDurationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clickDurationLabel.AutoSize = true;
            this.clickDurationLabel.Location = new System.Drawing.Point(3, 393);
            this.clickDurationLabel.Name = "clickDurationLabel";
            this.clickDurationLabel.Size = new System.Drawing.Size(94, 13);
            this.clickDurationLabel.TabIndex = 17;
            this.clickDurationLabel.Text = "Click duration";
            this.clickDurationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clickDurationNumericUpDown
            // 
            this.clickDurationNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clickDurationNumericUpDown.Location = new System.Drawing.Point(203, 389);
            this.clickDurationNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.clickDurationNumericUpDown.Name = "clickDurationNumericUpDown";
            this.clickDurationNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.clickDurationNumericUpDown.TabIndex = 18;
            this.clickDurationNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // leftClickRadioButton
            // 
            this.leftClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftClickRadioButton.AutoSize = true;
            this.leftClickRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.leftClickRadioButton.Location = new System.Drawing.Point(103, 3);
            this.leftClickRadioButton.Name = "leftClickRadioButton";
            this.leftClickRadioButton.Size = new System.Drawing.Size(94, 36);
            this.leftClickRadioButton.TabIndex = 19;
            this.leftClickRadioButton.Text = "Left click";
            this.leftClickRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.leftClickRadioButton.UseVisualStyleBackColor = true;
            this.leftClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // middleClickRadioButton
            // 
            this.middleClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.middleClickRadioButton.AutoSize = true;
            this.middleClickRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.middleClickRadioButton.Location = new System.Drawing.Point(203, 3);
            this.middleClickRadioButton.Name = "middleClickRadioButton";
            this.middleClickRadioButton.Size = new System.Drawing.Size(94, 36);
            this.middleClickRadioButton.TabIndex = 20;
            this.middleClickRadioButton.Text = "Middle click";
            this.middleClickRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.middleClickRadioButton.UseVisualStyleBackColor = true;
            this.middleClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // rightClickRadioButton
            // 
            this.rightClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightClickRadioButton.AutoSize = true;
            this.rightClickRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rightClickRadioButton.Location = new System.Drawing.Point(303, 3);
            this.rightClickRadioButton.Name = "rightClickRadioButton";
            this.rightClickRadioButton.Size = new System.Drawing.Size(94, 36);
            this.rightClickRadioButton.TabIndex = 21;
            this.rightClickRadioButton.Text = "Right click";
            this.rightClickRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rightClickRadioButton.UseVisualStyleBackColor = true;
            this.rightClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // endYCoordinateNumericUpDown
            // 
            this.endYCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endYCoordinateNumericUpDown.Location = new System.Drawing.Point(403, 221);
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
            this.endYCoordinateNumericUpDown.TabIndex = 8;
            // 
            // endYCoordinateLabel
            // 
            this.endYCoordinateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endYCoordinateLabel.AutoSize = true;
            this.endYCoordinateLabel.Location = new System.Drawing.Point(303, 224);
            this.endYCoordinateLabel.Name = "endYCoordinateLabel";
            this.endYCoordinateLabel.Size = new System.Drawing.Size(94, 13);
            this.endYCoordinateLabel.TabIndex = 9;
            this.endYCoordinateLabel.Text = "Y";
            // 
            // endXCoordinateNumericUpDown
            // 
            this.endXCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endXCoordinateNumericUpDown.Location = new System.Drawing.Point(203, 221);
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
            this.endXCoordinateNumericUpDown.TabIndex = 10;
            // 
            // endXCoordinateLabel
            // 
            this.endXCoordinateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endXCoordinateLabel.AutoSize = true;
            this.endXCoordinateLabel.Location = new System.Drawing.Point(103, 224);
            this.endXCoordinateLabel.Name = "endXCoordinateLabel";
            this.endXCoordinateLabel.Size = new System.Drawing.Size(94, 13);
            this.endXCoordinateLabel.TabIndex = 7;
            this.endXCoordinateLabel.Text = "X";
            // 
            // endCoordinateLabel
            // 
            this.endCoordinateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endCoordinateLabel.AutoSize = true;
            this.endCoordinateLabel.Location = new System.Drawing.Point(3, 224);
            this.endCoordinateLabel.Name = "endCoordinateLabel";
            this.endCoordinateLabel.Size = new System.Drawing.Size(94, 13);
            this.endCoordinateLabel.TabIndex = 12;
            this.endCoordinateLabel.Text = "End coords";
            // 
            // startCoordinateLabel
            // 
            this.startCoordinateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startCoordinateLabel.AutoSize = true;
            this.startCoordinateLabel.Location = new System.Drawing.Point(3, 140);
            this.startCoordinateLabel.Name = "startCoordinateLabel";
            this.startCoordinateLabel.Size = new System.Drawing.Size(94, 13);
            this.startCoordinateLabel.TabIndex = 11;
            this.startCoordinateLabel.Text = "Start coords";
            // 
            // noneClickRadioButton
            // 
            this.noneClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noneClickRadioButton.AutoSize = true;
            this.noneClickRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.noneClickRadioButton.Location = new System.Drawing.Point(403, 3);
            this.noneClickRadioButton.Name = "noneClickRadioButton";
            this.noneClickRadioButton.Size = new System.Drawing.Size(94, 36);
            this.noneClickRadioButton.TabIndex = 22;
            this.noneClickRadioButton.Text = "No click";
            this.noneClickRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.noneClickRadioButton.UseVisualStyleBackColor = true;
            this.noneClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // doubleClickCheckBox
            // 
            this.doubleClickCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleClickCheckBox.AutoSize = true;
            this.doubleClickCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.doubleClickCheckBox.Location = new System.Drawing.Point(103, 45);
            this.doubleClickCheckBox.Name = "doubleClickCheckBox";
            this.doubleClickCheckBox.Size = new System.Drawing.Size(94, 36);
            this.doubleClickCheckBox.TabIndex = 24;
            this.doubleClickCheckBox.Text = "Double click";
            this.doubleClickCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.doubleClickCheckBox.UseVisualStyleBackColor = true;
            this.doubleClickCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // dragAndDropCheckBox
            // 
            this.dragAndDropCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dragAndDropCheckBox.AutoSize = true;
            this.dragAndDropCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.dragAndDropCheckBox.Location = new System.Drawing.Point(303, 45);
            this.dragAndDropCheckBox.Name = "dragAndDropCheckBox";
            this.dragAndDropCheckBox.Size = new System.Drawing.Size(94, 36);
            this.dragAndDropCheckBox.TabIndex = 23;
            this.dragAndDropCheckBox.Text = "Drag and drop";
            this.dragAndDropCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.dragAndDropCheckBox.UseVisualStyleBackColor = true;
            this.dragAndDropCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // scrollCheckBox
            // 
            this.scrollCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollCheckBox.AutoSize = true;
            this.scrollCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.scrollCheckBox.Location = new System.Drawing.Point(203, 45);
            this.scrollCheckBox.Name = "scrollCheckBox";
            this.scrollCheckBox.Size = new System.Drawing.Size(94, 36);
            this.scrollCheckBox.TabIndex = 25;
            this.scrollCheckBox.Text = "Scroll";
            this.scrollCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.scrollCheckBox.UseVisualStyleBackColor = true;
            this.scrollCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // startImageCoordCheckBox
            // 
            this.startImageCoordCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startImageCoordCheckBox.AutoSize = true;
            this.startImageCoordCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.startImageCoordCheckBox.Location = new System.Drawing.Point(103, 87);
            this.startImageCoordCheckBox.Name = "startImageCoordCheckBox";
            this.startImageCoordCheckBox.Size = new System.Drawing.Size(94, 36);
            this.startImageCoordCheckBox.TabIndex = 26;
            this.startImageCoordCheckBox.Text = "As start position";
            this.startImageCoordCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.startImageCoordCheckBox.UseVisualStyleBackColor = true;
            this.startImageCoordCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // endImageCoordCheckBox
            // 
            this.endImageCoordCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endImageCoordCheckBox.AutoSize = true;
            this.endImageCoordCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.endImageCoordCheckBox.Location = new System.Drawing.Point(203, 87);
            this.endImageCoordCheckBox.Name = "endImageCoordCheckBox";
            this.endImageCoordCheckBox.Size = new System.Drawing.Size(94, 36);
            this.endImageCoordCheckBox.TabIndex = 27;
            this.endImageCoordCheckBox.Text = "As end position";
            this.endImageCoordCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.endImageCoordCheckBox.UseVisualStyleBackColor = true;
            this.endImageCoordCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // useImageCoordsLabel
            // 
            this.useImageCoordsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.useImageCoordsLabel.AutoSize = true;
            this.useImageCoordsLabel.Location = new System.Drawing.Point(3, 98);
            this.useImageCoordsLabel.Name = "useImageCoordsLabel";
            this.useImageCoordsLabel.Size = new System.Drawing.Size(94, 13);
            this.useImageCoordsLabel.TabIndex = 28;
            this.useImageCoordsLabel.Text = "Use image coords";
            this.useImageCoordsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MouseActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MouseActionPropertiesPanel";
            this.Size = new System.Drawing.Size(500, 421);
            ((System.ComponentModel.ISupportInitialize)(this.startXCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYCoordinateNumericUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAmountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clickDurationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endYCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endXCoordinateNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label clickTypeLabel;
        private System.Windows.Forms.Label startXCoordinateLabel;
        private System.Windows.Forms.NumericUpDown startXCoordinateNumericUpDown;
        private System.Windows.Forms.Label startYCoordinateLabel;
        private System.Windows.Forms.NumericUpDown startYCoordinateNumericUpDown;
        private System.Windows.Forms.CheckBox useCurrentPositionCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown endYCoordinateNumericUpDown;
        private System.Windows.Forms.Label endXCoordinateLabel;
        private System.Windows.Forms.NumericUpDown endXCoordinateNumericUpDown;
        private System.Windows.Forms.Label endYCoordinateLabel;
        private System.Windows.Forms.Label startCoordinateLabel;
        private System.Windows.Forms.Label endCoordinateLabel;
        private System.Windows.Forms.Label scrollAmountLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.ComboBox speedComboBox;
        private System.Windows.Forms.NumericUpDown scrollAmountNumericUpDown;
        private System.Windows.Forms.Label clickDurationLabel;
        private System.Windows.Forms.NumericUpDown clickDurationNumericUpDown;
        private System.Windows.Forms.RadioButton leftClickRadioButton;
        private System.Windows.Forms.RadioButton middleClickRadioButton;
        private System.Windows.Forms.RadioButton rightClickRadioButton;
        private System.Windows.Forms.RadioButton noneClickRadioButton;
        private System.Windows.Forms.CheckBox dragAndDropCheckBox;
        private System.Windows.Forms.CheckBox doubleClickCheckBox;
        private System.Windows.Forms.CheckBox scrollCheckBox;
        private System.Windows.Forms.CheckBox startImageCoordCheckBox;
        private System.Windows.Forms.CheckBox endImageCoordCheckBox;
        private System.Windows.Forms.Label useImageCoordsLabel;
    }
}
