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
            this.clickPanel = new System.Windows.Forms.Panel();
            this.clickTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.actionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.actionLabel = new System.Windows.Forms.Label();
            this.dragAndDropRadioButton = new System.Windows.Forms.RadioButton();
            this.clickRadioButton = new System.Windows.Forms.RadioButton();
            this.scrollRadioButton = new System.Windows.Forms.RadioButton();
            this.doubleClickRadioButton = new System.Windows.Forms.RadioButton();
            this.startCoordsPanel = new System.Windows.Forms.Panel();
            this.startCoordsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.endCoordsPanel = new System.Windows.Forms.Panel();
            this.endCoordsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.endYCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endXCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endImageCoordCheckBox = new System.Windows.Forms.CheckBox();
            this.endCoordinateLabel = new System.Windows.Forms.Label();
            this.speedPanel = new System.Windows.Forms.Panel();
            this.speedTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.speedLabel = new System.Windows.Forms.Label();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.scrollTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.scrollAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scrollAmountLabel = new System.Windows.Forms.Label();
            this.clickDurationPanel = new System.Windows.Forms.Panel();
            this.clickDurationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.clickDurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.clickDurationLabel = new System.Windows.Forms.Label();
            this.overlayPanel = new System.Windows.Forms.Panel();
            this.overlayTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.startXCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYCoordinateNumericUpDown)).BeginInit();
            this.clickPanel.SuspendLayout();
            this.clickTableLayoutPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.actionTableLayoutPanel.SuspendLayout();
            this.startCoordsPanel.SuspendLayout();
            this.startCoordsTableLayoutPanel.SuspendLayout();
            this.endCoordsPanel.SuspendLayout();
            this.endCoordsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endYCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endXCoordinateNumericUpDown)).BeginInit();
            this.speedPanel.SuspendLayout();
            this.speedTableLayoutPanel.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.scrollTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAmountNumericUpDown)).BeginInit();
            this.clickDurationPanel.SuspendLayout();
            this.clickDurationTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clickDurationNumericUpDown)).BeginInit();
            this.overlayPanel.SuspendLayout();
            this.overlayTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // clickTypeLabel
            // 
            this.clickTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clickTypeLabel.AutoSize = true;
            this.clickTypeLabel.Location = new System.Drawing.Point(3, 13);
            this.clickTypeLabel.Name = "clickTypeLabel";
            this.clickTypeLabel.Size = new System.Drawing.Size(94, 13);
            this.clickTypeLabel.TabIndex = 0;
            this.clickTypeLabel.Text = "Click";
            this.clickTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startXCoordinateNumericUpDown
            // 
            this.startXCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startXCoordinateNumericUpDown.AutoSize = true;
            this.startXCoordinateNumericUpDown.Location = new System.Drawing.Point(103, 9);
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
            this.startXCoordinateNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.startXCoordinateNumericUpDown.TabIndex = 3;
            this.startXCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // useCurrentPositionCheckBox
            // 
            this.useCurrentPositionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useCurrentPositionCheckBox.AutoSize = true;
            this.useCurrentPositionCheckBox.Location = new System.Drawing.Point(347, 3);
            this.useCurrentPositionCheckBox.Name = "useCurrentPositionCheckBox";
            this.useCurrentPositionCheckBox.Size = new System.Drawing.Size(116, 33);
            this.useCurrentPositionCheckBox.TabIndex = 4;
            this.useCurrentPositionCheckBox.Text = "Use current position";
            this.useCurrentPositionCheckBox.UseVisualStyleBackColor = true;
            this.useCurrentPositionCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // startYCoordinateNumericUpDown
            // 
            this.startYCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startYCoordinateNumericUpDown.AutoSize = true;
            this.startYCoordinateNumericUpDown.Location = new System.Drawing.Point(225, 9);
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
            this.startYCoordinateNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.startYCoordinateNumericUpDown.TabIndex = 6;
            this.startYCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // leftClickRadioButton
            // 
            this.leftClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftClickRadioButton.AutoSize = true;
            this.leftClickRadioButton.Location = new System.Drawing.Point(103, 3);
            this.leftClickRadioButton.Name = "leftClickRadioButton";
            this.leftClickRadioButton.Size = new System.Drawing.Size(116, 33);
            this.leftClickRadioButton.TabIndex = 19;
            this.leftClickRadioButton.Text = "Left click";
            this.leftClickRadioButton.UseVisualStyleBackColor = true;
            this.leftClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // middleClickRadioButton
            // 
            this.middleClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.middleClickRadioButton.AutoSize = true;
            this.middleClickRadioButton.Location = new System.Drawing.Point(225, 3);
            this.middleClickRadioButton.Name = "middleClickRadioButton";
            this.middleClickRadioButton.Size = new System.Drawing.Size(116, 33);
            this.middleClickRadioButton.TabIndex = 20;
            this.middleClickRadioButton.Text = "Middle click";
            this.middleClickRadioButton.UseVisualStyleBackColor = true;
            this.middleClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // rightClickRadioButton
            // 
            this.rightClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightClickRadioButton.AutoSize = true;
            this.rightClickRadioButton.Location = new System.Drawing.Point(347, 3);
            this.rightClickRadioButton.Name = "rightClickRadioButton";
            this.rightClickRadioButton.Size = new System.Drawing.Size(116, 33);
            this.rightClickRadioButton.TabIndex = 21;
            this.rightClickRadioButton.Text = "Right click";
            this.rightClickRadioButton.UseVisualStyleBackColor = true;
            this.rightClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // noneClickRadioButton
            // 
            this.noneClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noneClickRadioButton.AutoSize = true;
            this.noneClickRadioButton.Location = new System.Drawing.Point(469, 3);
            this.noneClickRadioButton.Name = "noneClickRadioButton";
            this.noneClickRadioButton.Size = new System.Drawing.Size(117, 33);
            this.noneClickRadioButton.TabIndex = 22;
            this.noneClickRadioButton.Text = "No click";
            this.noneClickRadioButton.UseVisualStyleBackColor = true;
            this.noneClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // startCoordinateLabel
            // 
            this.startCoordinateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startCoordinateLabel.AutoSize = true;
            this.startCoordinateLabel.Location = new System.Drawing.Point(3, 13);
            this.startCoordinateLabel.Name = "startCoordinateLabel";
            this.startCoordinateLabel.Size = new System.Drawing.Size(94, 13);
            this.startCoordinateLabel.TabIndex = 11;
            this.startCoordinateLabel.Text = "Start coords";
            this.startCoordinateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startImageCoordCheckBox
            // 
            this.startImageCoordCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startImageCoordCheckBox.AutoSize = true;
            this.startImageCoordCheckBox.Location = new System.Drawing.Point(469, 3);
            this.startImageCoordCheckBox.Name = "startImageCoordCheckBox";
            this.startImageCoordCheckBox.Size = new System.Drawing.Size(117, 33);
            this.startImageCoordCheckBox.TabIndex = 26;
            this.startImageCoordCheckBox.Text = "Use image coordinates";
            this.startImageCoordCheckBox.UseVisualStyleBackColor = true;
            this.startImageCoordCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // speedComboBox
            // 
            this.speedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.speedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedComboBox.FormattingEnabled = true;
            this.speedComboBox.Location = new System.Drawing.Point(103, 9);
            this.speedComboBox.Name = "speedComboBox";
            this.speedComboBox.Size = new System.Drawing.Size(483, 21);
            this.speedComboBox.TabIndex = 14;
            // 
            // overlayCheckBox
            // 
            this.overlayCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayCheckBox.AutoSize = true;
            this.overlayCheckBox.Checked = true;
            this.overlayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overlayCheckBox.Location = new System.Drawing.Point(103, 11);
            this.overlayCheckBox.Name = "overlayCheckBox";
            this.overlayCheckBox.Size = new System.Drawing.Size(483, 17);
            this.overlayCheckBox.TabIndex = 28;
            this.overlayCheckBox.Text = "Enable overlay";
            this.overlayCheckBox.UseVisualStyleBackColor = true;
            this.overlayCheckBox.CheckedChanged += new System.EventHandler(this.OverlayCheckBox_CheckedChanged);
            // 
            // clickPanel
            // 
            this.clickPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clickPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.clickPanel.Controls.Add(this.clickTableLayoutPanel);
            this.clickPanel.Location = new System.Drawing.Point(8, 71);
            this.clickPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.clickPanel.Name = "clickPanel";
            this.clickPanel.Padding = new System.Windows.Forms.Padding(8);
            this.clickPanel.Size = new System.Drawing.Size(605, 55);
            this.clickPanel.TabIndex = 7;
            // 
            // clickTableLayoutPanel
            // 
            this.clickTableLayoutPanel.ColumnCount = 5;
            this.clickTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.clickTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.clickTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.clickTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.clickTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.clickTableLayoutPanel.Controls.Add(this.clickTypeLabel, 0, 0);
            this.clickTableLayoutPanel.Controls.Add(this.rightClickRadioButton, 3, 0);
            this.clickTableLayoutPanel.Controls.Add(this.noneClickRadioButton, 4, 0);
            this.clickTableLayoutPanel.Controls.Add(this.middleClickRadioButton, 2, 0);
            this.clickTableLayoutPanel.Controls.Add(this.leftClickRadioButton, 1, 0);
            this.clickTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clickTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.clickTableLayoutPanel.Name = "clickTableLayoutPanel";
            this.clickTableLayoutPanel.RowCount = 1;
            this.clickTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.clickTableLayoutPanel.Size = new System.Drawing.Size(589, 39);
            this.clickTableLayoutPanel.TabIndex = 33;
            // 
            // actionPanel
            // 
            this.actionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.actionPanel.Controls.Add(this.actionTableLayoutPanel);
            this.actionPanel.Location = new System.Drawing.Point(8, 8);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Padding = new System.Windows.Forms.Padding(8);
            this.actionPanel.Size = new System.Drawing.Size(605, 55);
            this.actionPanel.TabIndex = 8;
            // 
            // actionTableLayoutPanel
            // 
            this.actionTableLayoutPanel.ColumnCount = 5;
            this.actionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.actionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.actionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.actionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.actionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.actionTableLayoutPanel.Controls.Add(this.actionLabel, 0, 0);
            this.actionTableLayoutPanel.Controls.Add(this.dragAndDropRadioButton, 4, 0);
            this.actionTableLayoutPanel.Controls.Add(this.clickRadioButton, 1, 0);
            this.actionTableLayoutPanel.Controls.Add(this.scrollRadioButton, 3, 0);
            this.actionTableLayoutPanel.Controls.Add(this.doubleClickRadioButton, 2, 0);
            this.actionTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.actionTableLayoutPanel.Name = "actionTableLayoutPanel";
            this.actionTableLayoutPanel.RowCount = 1;
            this.actionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionTableLayoutPanel.Size = new System.Drawing.Size(589, 39);
            this.actionTableLayoutPanel.TabIndex = 32;
            // 
            // actionLabel
            // 
            this.actionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(3, 13);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(94, 13);
            this.actionLabel.TabIndex = 31;
            this.actionLabel.Text = "Action";
            this.actionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dragAndDropRadioButton
            // 
            this.dragAndDropRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dragAndDropRadioButton.AutoSize = true;
            this.dragAndDropRadioButton.Location = new System.Drawing.Point(469, 3);
            this.dragAndDropRadioButton.Name = "dragAndDropRadioButton";
            this.dragAndDropRadioButton.Size = new System.Drawing.Size(117, 33);
            this.dragAndDropRadioButton.TabIndex = 30;
            this.dragAndDropRadioButton.TabStop = true;
            this.dragAndDropRadioButton.Text = "Drag and Drop";
            this.dragAndDropRadioButton.UseVisualStyleBackColor = true;
            this.dragAndDropRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // clickRadioButton
            // 
            this.clickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clickRadioButton.AutoSize = true;
            this.clickRadioButton.Location = new System.Drawing.Point(103, 3);
            this.clickRadioButton.Name = "clickRadioButton";
            this.clickRadioButton.Size = new System.Drawing.Size(116, 33);
            this.clickRadioButton.TabIndex = 27;
            this.clickRadioButton.TabStop = true;
            this.clickRadioButton.Text = "Click";
            this.clickRadioButton.UseVisualStyleBackColor = true;
            this.clickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // scrollRadioButton
            // 
            this.scrollRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollRadioButton.AutoSize = true;
            this.scrollRadioButton.Location = new System.Drawing.Point(347, 3);
            this.scrollRadioButton.Name = "scrollRadioButton";
            this.scrollRadioButton.Size = new System.Drawing.Size(116, 33);
            this.scrollRadioButton.TabIndex = 29;
            this.scrollRadioButton.TabStop = true;
            this.scrollRadioButton.Text = "Scroll";
            this.scrollRadioButton.UseVisualStyleBackColor = true;
            this.scrollRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // doubleClickRadioButton
            // 
            this.doubleClickRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleClickRadioButton.AutoSize = true;
            this.doubleClickRadioButton.Location = new System.Drawing.Point(225, 3);
            this.doubleClickRadioButton.Name = "doubleClickRadioButton";
            this.doubleClickRadioButton.Size = new System.Drawing.Size(116, 33);
            this.doubleClickRadioButton.TabIndex = 28;
            this.doubleClickRadioButton.TabStop = true;
            this.doubleClickRadioButton.Text = "Double click";
            this.doubleClickRadioButton.UseVisualStyleBackColor = true;
            this.doubleClickRadioButton.CheckedChanged += new System.EventHandler(this.ClickRadioButton_CheckedChanged);
            // 
            // startCoordsPanel
            // 
            this.startCoordsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startCoordsPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.startCoordsPanel.Controls.Add(this.startCoordsTableLayoutPanel);
            this.startCoordsPanel.Location = new System.Drawing.Point(8, 134);
            this.startCoordsPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.startCoordsPanel.Name = "startCoordsPanel";
            this.startCoordsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.startCoordsPanel.Size = new System.Drawing.Size(605, 55);
            this.startCoordsPanel.TabIndex = 9;
            // 
            // startCoordsTableLayoutPanel
            // 
            this.startCoordsTableLayoutPanel.ColumnCount = 5;
            this.startCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.startCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.startCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.startCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.startCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.startCoordsTableLayoutPanel.Controls.Add(this.useCurrentPositionCheckBox, 3, 0);
            this.startCoordsTableLayoutPanel.Controls.Add(this.startYCoordinateNumericUpDown, 2, 0);
            this.startCoordsTableLayoutPanel.Controls.Add(this.startXCoordinateNumericUpDown, 1, 0);
            this.startCoordsTableLayoutPanel.Controls.Add(this.startImageCoordCheckBox, 4, 0);
            this.startCoordsTableLayoutPanel.Controls.Add(this.startCoordinateLabel, 0, 0);
            this.startCoordsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startCoordsTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.startCoordsTableLayoutPanel.Name = "startCoordsTableLayoutPanel";
            this.startCoordsTableLayoutPanel.RowCount = 1;
            this.startCoordsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startCoordsTableLayoutPanel.Size = new System.Drawing.Size(589, 39);
            this.startCoordsTableLayoutPanel.TabIndex = 34;
            // 
            // endCoordsPanel
            // 
            this.endCoordsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endCoordsPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.endCoordsPanel.Controls.Add(this.endCoordsTableLayoutPanel);
            this.endCoordsPanel.Location = new System.Drawing.Point(8, 197);
            this.endCoordsPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.endCoordsPanel.Name = "endCoordsPanel";
            this.endCoordsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.endCoordsPanel.Size = new System.Drawing.Size(605, 55);
            this.endCoordsPanel.TabIndex = 27;
            // 
            // endCoordsTableLayoutPanel
            // 
            this.endCoordsTableLayoutPanel.ColumnCount = 5;
            this.endCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.endCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.endCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.endCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.endCoordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.endCoordsTableLayoutPanel.Controls.Add(this.endYCoordinateNumericUpDown, 2, 0);
            this.endCoordsTableLayoutPanel.Controls.Add(this.endXCoordinateNumericUpDown, 1, 0);
            this.endCoordsTableLayoutPanel.Controls.Add(this.endImageCoordCheckBox, 4, 0);
            this.endCoordsTableLayoutPanel.Controls.Add(this.endCoordinateLabel, 0, 0);
            this.endCoordsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endCoordsTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.endCoordsTableLayoutPanel.Name = "endCoordsTableLayoutPanel";
            this.endCoordsTableLayoutPanel.RowCount = 1;
            this.endCoordsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.endCoordsTableLayoutPanel.Size = new System.Drawing.Size(589, 39);
            this.endCoordsTableLayoutPanel.TabIndex = 35;
            // 
            // endYCoordinateNumericUpDown
            // 
            this.endYCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endYCoordinateNumericUpDown.AutoSize = true;
            this.endYCoordinateNumericUpDown.Location = new System.Drawing.Point(225, 9);
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
            this.endYCoordinateNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.endYCoordinateNumericUpDown.TabIndex = 6;
            this.endYCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // endXCoordinateNumericUpDown
            // 
            this.endXCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endXCoordinateNumericUpDown.AutoSize = true;
            this.endXCoordinateNumericUpDown.Location = new System.Drawing.Point(103, 9);
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
            this.endXCoordinateNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.endXCoordinateNumericUpDown.TabIndex = 3;
            this.endXCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // endImageCoordCheckBox
            // 
            this.endImageCoordCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endImageCoordCheckBox.AutoSize = true;
            this.endImageCoordCheckBox.Location = new System.Drawing.Point(469, 3);
            this.endImageCoordCheckBox.Name = "endImageCoordCheckBox";
            this.endImageCoordCheckBox.Size = new System.Drawing.Size(117, 33);
            this.endImageCoordCheckBox.TabIndex = 26;
            this.endImageCoordCheckBox.Text = "Use image coordinates";
            this.endImageCoordCheckBox.UseVisualStyleBackColor = true;
            // 
            // endCoordinateLabel
            // 
            this.endCoordinateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endCoordinateLabel.AutoSize = true;
            this.endCoordinateLabel.Location = new System.Drawing.Point(3, 13);
            this.endCoordinateLabel.Name = "endCoordinateLabel";
            this.endCoordinateLabel.Size = new System.Drawing.Size(94, 13);
            this.endCoordinateLabel.TabIndex = 11;
            this.endCoordinateLabel.Text = "End coords";
            this.endCoordinateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // speedPanel
            // 
            this.speedPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.speedPanel.Controls.Add(this.speedTableLayoutPanel);
            this.speedPanel.Location = new System.Drawing.Point(8, 260);
            this.speedPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.speedPanel.Name = "speedPanel";
            this.speedPanel.Padding = new System.Windows.Forms.Padding(8);
            this.speedPanel.Size = new System.Drawing.Size(605, 55);
            this.speedPanel.TabIndex = 28;
            // 
            // speedTableLayoutPanel
            // 
            this.speedTableLayoutPanel.ColumnCount = 2;
            this.speedTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.speedTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.speedTableLayoutPanel.Controls.Add(this.speedLabel, 0, 0);
            this.speedTableLayoutPanel.Controls.Add(this.speedComboBox, 1, 0);
            this.speedTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.speedTableLayoutPanel.Name = "speedTableLayoutPanel";
            this.speedTableLayoutPanel.RowCount = 1;
            this.speedTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.speedTableLayoutPanel.Size = new System.Drawing.Size(589, 39);
            this.speedTableLayoutPanel.TabIndex = 15;
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(3, 13);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(94, 13);
            this.speedLabel.TabIndex = 11;
            this.speedLabel.Text = "Speed";
            this.speedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scrollPanel
            // 
            this.scrollPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.scrollPanel.Controls.Add(this.scrollTableLayoutPanel);
            this.scrollPanel.Location = new System.Drawing.Point(8, 323);
            this.scrollPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Padding = new System.Windows.Forms.Padding(8);
            this.scrollPanel.Size = new System.Drawing.Size(605, 55);
            this.scrollPanel.TabIndex = 29;
            // 
            // scrollTableLayoutPanel
            // 
            this.scrollTableLayoutPanel.ColumnCount = 2;
            this.scrollTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.scrollTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scrollTableLayoutPanel.Controls.Add(this.scrollAmountNumericUpDown, 1, 0);
            this.scrollTableLayoutPanel.Controls.Add(this.scrollAmountLabel, 0, 0);
            this.scrollTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.scrollTableLayoutPanel.Name = "scrollTableLayoutPanel";
            this.scrollTableLayoutPanel.RowCount = 1;
            this.scrollTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scrollTableLayoutPanel.Size = new System.Drawing.Size(589, 39);
            this.scrollTableLayoutPanel.TabIndex = 16;
            // 
            // scrollAmountNumericUpDown
            // 
            this.scrollAmountNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollAmountNumericUpDown.Location = new System.Drawing.Point(103, 9);
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
            this.scrollAmountNumericUpDown.Size = new System.Drawing.Size(483, 20);
            this.scrollAmountNumericUpDown.TabIndex = 3;
            // 
            // scrollAmountLabel
            // 
            this.scrollAmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollAmountLabel.AutoSize = true;
            this.scrollAmountLabel.Location = new System.Drawing.Point(3, 13);
            this.scrollAmountLabel.Name = "scrollAmountLabel";
            this.scrollAmountLabel.Size = new System.Drawing.Size(94, 13);
            this.scrollAmountLabel.TabIndex = 11;
            this.scrollAmountLabel.Text = "Scroll amount";
            this.scrollAmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clickDurationPanel
            // 
            this.clickDurationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clickDurationPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.clickDurationPanel.Controls.Add(this.clickDurationTableLayoutPanel);
            this.clickDurationPanel.Location = new System.Drawing.Point(8, 386);
            this.clickDurationPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.clickDurationPanel.Name = "clickDurationPanel";
            this.clickDurationPanel.Padding = new System.Windows.Forms.Padding(8);
            this.clickDurationPanel.Size = new System.Drawing.Size(605, 55);
            this.clickDurationPanel.TabIndex = 30;
            // 
            // clickDurationTableLayoutPanel
            // 
            this.clickDurationTableLayoutPanel.ColumnCount = 2;
            this.clickDurationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.clickDurationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.clickDurationTableLayoutPanel.Controls.Add(this.clickDurationNumericUpDown, 1, 0);
            this.clickDurationTableLayoutPanel.Controls.Add(this.clickDurationLabel, 0, 0);
            this.clickDurationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clickDurationTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.clickDurationTableLayoutPanel.Name = "clickDurationTableLayoutPanel";
            this.clickDurationTableLayoutPanel.RowCount = 1;
            this.clickDurationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.clickDurationTableLayoutPanel.Size = new System.Drawing.Size(589, 39);
            this.clickDurationTableLayoutPanel.TabIndex = 17;
            // 
            // clickDurationNumericUpDown
            // 
            this.clickDurationNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clickDurationNumericUpDown.Location = new System.Drawing.Point(103, 9);
            this.clickDurationNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.clickDurationNumericUpDown.Name = "clickDurationNumericUpDown";
            this.clickDurationNumericUpDown.Size = new System.Drawing.Size(483, 20);
            this.clickDurationNumericUpDown.TabIndex = 3;
            this.clickDurationNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // clickDurationLabel
            // 
            this.clickDurationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clickDurationLabel.AutoSize = true;
            this.clickDurationLabel.Location = new System.Drawing.Point(3, 13);
            this.clickDurationLabel.Name = "clickDurationLabel";
            this.clickDurationLabel.Size = new System.Drawing.Size(94, 13);
            this.clickDurationLabel.TabIndex = 11;
            this.clickDurationLabel.Text = "Click duration";
            this.clickDurationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overlayPanel
            // 
            this.overlayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.overlayPanel.Controls.Add(this.overlayTableLayoutPanel);
            this.overlayPanel.Location = new System.Drawing.Point(8, 449);
            this.overlayPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.overlayPanel.Name = "overlayPanel";
            this.overlayPanel.Padding = new System.Windows.Forms.Padding(8);
            this.overlayPanel.Size = new System.Drawing.Size(605, 55);
            this.overlayPanel.TabIndex = 31;
            // 
            // overlayTableLayoutPanel
            // 
            this.overlayTableLayoutPanel.ColumnCount = 2;
            this.overlayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.overlayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.overlayTableLayoutPanel.Controls.Add(this.overlayCheckBox, 1, 0);
            this.overlayTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.overlayTableLayoutPanel.Name = "overlayTableLayoutPanel";
            this.overlayTableLayoutPanel.RowCount = 1;
            this.overlayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.overlayTableLayoutPanel.Size = new System.Drawing.Size(589, 39);
            this.overlayTableLayoutPanel.TabIndex = 29;
            // 
            // MouseActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.overlayPanel);
            this.Controls.Add(this.clickDurationPanel);
            this.Controls.Add(this.scrollPanel);
            this.Controls.Add(this.speedPanel);
            this.Controls.Add(this.endCoordsPanel);
            this.Controls.Add(this.startCoordsPanel);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.clickPanel);
            this.DoubleBuffered = true;
            this.Name = "MouseActionPropertiesPanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(621, 512);
            this.VisibleChanged += new System.EventHandler(this.MouseActionPropertiesPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.startXCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYCoordinateNumericUpDown)).EndInit();
            this.clickPanel.ResumeLayout(false);
            this.clickTableLayoutPanel.ResumeLayout(false);
            this.clickTableLayoutPanel.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.actionTableLayoutPanel.ResumeLayout(false);
            this.actionTableLayoutPanel.PerformLayout();
            this.startCoordsPanel.ResumeLayout(false);
            this.startCoordsTableLayoutPanel.ResumeLayout(false);
            this.startCoordsTableLayoutPanel.PerformLayout();
            this.endCoordsPanel.ResumeLayout(false);
            this.endCoordsTableLayoutPanel.ResumeLayout(false);
            this.endCoordsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endYCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endXCoordinateNumericUpDown)).EndInit();
            this.speedPanel.ResumeLayout(false);
            this.speedTableLayoutPanel.ResumeLayout(false);
            this.speedTableLayoutPanel.PerformLayout();
            this.scrollPanel.ResumeLayout(false);
            this.scrollTableLayoutPanel.ResumeLayout(false);
            this.scrollTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAmountNumericUpDown)).EndInit();
            this.clickDurationPanel.ResumeLayout(false);
            this.clickDurationTableLayoutPanel.ResumeLayout(false);
            this.clickDurationTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clickDurationNumericUpDown)).EndInit();
            this.overlayPanel.ResumeLayout(false);
            this.overlayTableLayoutPanel.ResumeLayout(false);
            this.overlayTableLayoutPanel.PerformLayout();
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
        private System.Windows.Forms.Panel clickPanel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.RadioButton dragAndDropRadioButton;
        private System.Windows.Forms.RadioButton scrollRadioButton;
        private System.Windows.Forms.RadioButton doubleClickRadioButton;
        private System.Windows.Forms.RadioButton clickRadioButton;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Panel startCoordsPanel;
        private System.Windows.Forms.Panel endCoordsPanel;
        private System.Windows.Forms.CheckBox endImageCoordCheckBox;
        private System.Windows.Forms.NumericUpDown endYCoordinateNumericUpDown;
        private System.Windows.Forms.NumericUpDown endXCoordinateNumericUpDown;
        private System.Windows.Forms.Label endCoordinateLabel;
        private System.Windows.Forms.Panel speedPanel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.NumericUpDown scrollAmountNumericUpDown;
        private System.Windows.Forms.Label scrollAmountLabel;
        private System.Windows.Forms.Panel clickDurationPanel;
        private System.Windows.Forms.NumericUpDown clickDurationNumericUpDown;
        private System.Windows.Forms.Label clickDurationLabel;
        private System.Windows.Forms.Panel overlayPanel;
        private System.Windows.Forms.TableLayoutPanel actionTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel clickTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel startCoordsTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel endCoordsTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel speedTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel scrollTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel clickDurationTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel overlayTableLayoutPanel;
    }
}
