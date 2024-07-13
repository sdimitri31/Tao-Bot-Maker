namespace Tao_Bot_Maker.View
{
    partial class ImageActionPropertiesPanel
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
            this.selectImageButton = new System.Windows.Forms.Button();
            this.endCoordinatesLabel = new System.Windows.Forms.Label();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.expirationLabel = new System.Windows.Forms.Label();
            this.thresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.expirationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectedImageNameLabel = new System.Windows.Forms.Label();
            this.searchImageButton = new System.Windows.Forms.Button();
            this.selectedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.actionIfImageFoundLabel = new System.Windows.Forms.Label();
            this.actionIfImageNotFoundLabel = new System.Windows.Forms.Label();
            this.actionIfImageFoundButton = new System.Windows.Forms.Button();
            this.actionIfImageNotFoundButton = new System.Windows.Forms.Button();
            this.endYCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endXCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startCoordinatesLabel = new System.Windows.Forms.Label();
            this.startYCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startXCoordinateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.overlayCheckBox = new System.Windows.Forms.CheckBox();
            this.imageSelectionPanel = new System.Windows.Forms.Panel();
            this.imageSelectionTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.coordinatesPanel = new System.Windows.Forms.Panel();
            this.coordinatesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.overlayPanel = new System.Windows.Forms.Panel();
            this.overlayTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.thresholdPanel = new System.Windows.Forms.Panel();
            this.thresholdTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.expirationPanel = new System.Windows.Forms.Panel();
            this.expirationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.actionIfFoundPanel = new System.Windows.Forms.Panel();
            this.actionIfFoundTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.actionIfNotFoundPanel = new System.Windows.Forms.Panel();
            this.actionIfNotFoundTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endYCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endXCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYCoordinateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startXCoordinateNumericUpDown)).BeginInit();
            this.imageSelectionPanel.SuspendLayout();
            this.imageSelectionTableLayoutPanel2.SuspendLayout();
            this.coordinatesPanel.SuspendLayout();
            this.coordinatesTableLayoutPanel.SuspendLayout();
            this.overlayPanel.SuspendLayout();
            this.overlayTableLayoutPanel.SuspendLayout();
            this.thresholdPanel.SuspendLayout();
            this.thresholdTableLayoutPanel.SuspendLayout();
            this.expirationPanel.SuspendLayout();
            this.expirationTableLayoutPanel.SuspendLayout();
            this.actionIfFoundPanel.SuspendLayout();
            this.actionIfFoundTableLayoutPanel.SuspendLayout();
            this.actionIfNotFoundPanel.SuspendLayout();
            this.actionIfNotFoundTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectImageButton
            // 
            this.selectImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectImageButton.Location = new System.Drawing.Point(3, 3);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(119, 23);
            this.selectImageButton.TabIndex = 0;
            this.selectImageButton.Text = "Select image";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // endCoordinatesLabel
            // 
            this.endCoordinatesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endCoordinatesLabel.AutoSize = true;
            this.endCoordinatesLabel.Location = new System.Drawing.Point(3, 56);
            this.endCoordinatesLabel.Name = "endCoordinatesLabel";
            this.endCoordinatesLabel.Size = new System.Drawing.Size(119, 13);
            this.endCoordinatesLabel.TabIndex = 5;
            this.endCoordinatesLabel.Text = "End coordinates";
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(3, 10);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(119, 13);
            this.thresholdLabel.TabIndex = 6;
            this.thresholdLabel.Text = "Threshold";
            // 
            // expirationLabel
            // 
            this.expirationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expirationLabel.AutoSize = true;
            this.expirationLabel.Location = new System.Drawing.Point(3, 10);
            this.expirationLabel.Name = "expirationLabel";
            this.expirationLabel.Size = new System.Drawing.Size(119, 13);
            this.expirationLabel.TabIndex = 7;
            this.expirationLabel.Text = "Expiration";
            // 
            // thresholdNumericUpDown
            // 
            this.thresholdNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.thresholdNumericUpDown.Location = new System.Drawing.Point(128, 7);
            this.thresholdNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.thresholdNumericUpDown.Name = "thresholdNumericUpDown";
            this.thresholdNumericUpDown.Size = new System.Drawing.Size(337, 20);
            this.thresholdNumericUpDown.TabIndex = 12;
            this.thresholdNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // expirationNumericUpDown
            // 
            this.expirationNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expirationNumericUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.expirationNumericUpDown.Location = new System.Drawing.Point(128, 7);
            this.expirationNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.expirationNumericUpDown.Name = "expirationNumericUpDown";
            this.expirationNumericUpDown.Size = new System.Drawing.Size(337, 20);
            this.expirationNumericUpDown.TabIndex = 13;
            this.expirationNumericUpDown.ThousandsSeparator = true;
            // 
            // selectedImageNameLabel
            // 
            this.selectedImageNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedImageNameLabel.AutoSize = true;
            this.selectedImageNameLabel.Location = new System.Drawing.Point(128, 162);
            this.selectedImageNameLabel.Name = "selectedImageNameLabel";
            this.selectedImageNameLabel.Size = new System.Drawing.Size(337, 13);
            this.selectedImageNameLabel.TabIndex = 14;
            this.selectedImageNameLabel.Text = "No image selected";
            // 
            // searchImageButton
            // 
            this.searchImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchImageButton.Location = new System.Drawing.Point(3, 157);
            this.searchImageButton.Name = "searchImageButton";
            this.searchImageButton.Size = new System.Drawing.Size(119, 23);
            this.searchImageButton.TabIndex = 15;
            this.searchImageButton.Text = "Search image";
            this.searchImageButton.UseVisualStyleBackColor = true;
            this.searchImageButton.Click += new System.EventHandler(this.SearchImageButton_Click);
            // 
            // selectedImagePictureBox
            // 
            this.selectedImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedImagePictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.selectedImagePictureBox.Location = new System.Drawing.Point(128, 3);
            this.selectedImagePictureBox.Name = "selectedImagePictureBox";
            this.selectedImagePictureBox.Size = new System.Drawing.Size(337, 148);
            this.selectedImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectedImagePictureBox.TabIndex = 1;
            this.selectedImagePictureBox.TabStop = false;
            // 
            // actionIfImageFoundLabel
            // 
            this.actionIfImageFoundLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.actionIfImageFoundLabel.AutoSize = true;
            this.actionIfImageFoundLabel.Location = new System.Drawing.Point(3, 10);
            this.actionIfImageFoundLabel.Name = "actionIfImageFoundLabel";
            this.actionIfImageFoundLabel.Size = new System.Drawing.Size(119, 13);
            this.actionIfImageFoundLabel.TabIndex = 18;
            this.actionIfImageFoundLabel.Text = "Action if image found";
            // 
            // actionIfImageNotFoundLabel
            // 
            this.actionIfImageNotFoundLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.actionIfImageNotFoundLabel.AutoSize = true;
            this.actionIfImageNotFoundLabel.Location = new System.Drawing.Point(3, 4);
            this.actionIfImageNotFoundLabel.Name = "actionIfImageNotFoundLabel";
            this.actionIfImageNotFoundLabel.Size = new System.Drawing.Size(119, 26);
            this.actionIfImageNotFoundLabel.TabIndex = 19;
            this.actionIfImageNotFoundLabel.Text = "Action if image not found";
            // 
            // actionIfImageFoundButton
            // 
            this.actionIfImageFoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.actionIfImageFoundButton.Location = new System.Drawing.Point(128, 5);
            this.actionIfImageFoundButton.Name = "actionIfImageFoundButton";
            this.actionIfImageFoundButton.Size = new System.Drawing.Size(337, 23);
            this.actionIfImageFoundButton.TabIndex = 16;
            this.actionIfImageFoundButton.Text = "Add action";
            this.actionIfImageFoundButton.UseVisualStyleBackColor = true;
            this.actionIfImageFoundButton.Click += new System.EventHandler(this.ActionIfFoundButton_Click);
            // 
            // actionIfImageNotFoundButton
            // 
            this.actionIfImageNotFoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.actionIfImageNotFoundButton.Location = new System.Drawing.Point(128, 5);
            this.actionIfImageNotFoundButton.Name = "actionIfImageNotFoundButton";
            this.actionIfImageNotFoundButton.Size = new System.Drawing.Size(337, 23);
            this.actionIfImageNotFoundButton.TabIndex = 17;
            this.actionIfImageNotFoundButton.Text = "Add action";
            this.actionIfImageNotFoundButton.UseVisualStyleBackColor = true;
            this.actionIfImageNotFoundButton.Click += new System.EventHandler(this.ActionIfNotFoundButton_Click);
            // 
            // endYCoordinateNumericUpDown
            // 
            this.endYCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endYCoordinateNumericUpDown.Location = new System.Drawing.Point(299, 53);
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
            this.endYCoordinateNumericUpDown.Size = new System.Drawing.Size(166, 20);
            this.endYCoordinateNumericUpDown.TabIndex = 11;
            this.endYCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // endXCoordinateNumericUpDown
            // 
            this.endXCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endXCoordinateNumericUpDown.Location = new System.Drawing.Point(128, 53);
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
            this.endXCoordinateNumericUpDown.Size = new System.Drawing.Size(165, 20);
            this.endXCoordinateNumericUpDown.TabIndex = 10;
            this.endXCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // startCoordinatesLabel
            // 
            this.startCoordinatesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startCoordinatesLabel.AutoSize = true;
            this.startCoordinatesLabel.Location = new System.Drawing.Point(3, 14);
            this.startCoordinatesLabel.Name = "startCoordinatesLabel";
            this.startCoordinatesLabel.Size = new System.Drawing.Size(119, 13);
            this.startCoordinatesLabel.TabIndex = 2;
            this.startCoordinatesLabel.Text = "Start coordinates";
            // 
            // startYCoordinateNumericUpDown
            // 
            this.startYCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startYCoordinateNumericUpDown.Location = new System.Drawing.Point(299, 11);
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
            this.startYCoordinateNumericUpDown.Size = new System.Drawing.Size(166, 20);
            this.startYCoordinateNumericUpDown.TabIndex = 9;
            this.startYCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // startXCoordinateNumericUpDown
            // 
            this.startXCoordinateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startXCoordinateNumericUpDown.Location = new System.Drawing.Point(128, 11);
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
            this.startXCoordinateNumericUpDown.Size = new System.Drawing.Size(165, 20);
            this.startXCoordinateNumericUpDown.TabIndex = 8;
            this.startXCoordinateNumericUpDown.ValueChanged += new System.EventHandler(this.CoordinatesNumericUpDown_ValueChanged);
            // 
            // overlayCheckBox
            // 
            this.overlayCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayCheckBox.AutoSize = true;
            this.overlayCheckBox.Location = new System.Drawing.Point(128, 8);
            this.overlayCheckBox.Name = "overlayCheckBox";
            this.overlayCheckBox.Size = new System.Drawing.Size(337, 17);
            this.overlayCheckBox.TabIndex = 29;
            this.overlayCheckBox.Text = "Enable overlay";
            this.overlayCheckBox.UseVisualStyleBackColor = true;
            this.overlayCheckBox.CheckedChanged += new System.EventHandler(this.OverlayCheckBox_CheckedChanged);
            // 
            // imageSelectionPanel
            // 
            this.imageSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageSelectionPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.imageSelectionPanel.Controls.Add(this.imageSelectionTableLayoutPanel2);
            this.imageSelectionPanel.Location = new System.Drawing.Point(8, 8);
            this.imageSelectionPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.imageSelectionPanel.Name = "imageSelectionPanel";
            this.imageSelectionPanel.Padding = new System.Windows.Forms.Padding(8);
            this.imageSelectionPanel.Size = new System.Drawing.Size(484, 200);
            this.imageSelectionPanel.TabIndex = 34;
            // 
            // imageSelectionTableLayoutPanel2
            // 
            this.imageSelectionTableLayoutPanel2.ColumnCount = 2;
            this.imageSelectionTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.imageSelectionTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.imageSelectionTableLayoutPanel2.Controls.Add(this.selectImageButton, 0, 0);
            this.imageSelectionTableLayoutPanel2.Controls.Add(this.selectedImagePictureBox, 1, 0);
            this.imageSelectionTableLayoutPanel2.Controls.Add(this.selectedImageNameLabel, 1, 1);
            this.imageSelectionTableLayoutPanel2.Controls.Add(this.searchImageButton, 0, 1);
            this.imageSelectionTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSelectionTableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.imageSelectionTableLayoutPanel2.Name = "imageSelectionTableLayoutPanel2";
            this.imageSelectionTableLayoutPanel2.RowCount = 2;
            this.imageSelectionTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.imageSelectionTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.imageSelectionTableLayoutPanel2.Size = new System.Drawing.Size(468, 184);
            this.imageSelectionTableLayoutPanel2.TabIndex = 0;
            // 
            // coordinatesPanel
            // 
            this.coordinatesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coordinatesPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.coordinatesPanel.Controls.Add(this.coordinatesTableLayoutPanel);
            this.coordinatesPanel.Location = new System.Drawing.Point(8, 216);
            this.coordinatesPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.coordinatesPanel.Name = "coordinatesPanel";
            this.coordinatesPanel.Padding = new System.Windows.Forms.Padding(8);
            this.coordinatesPanel.Size = new System.Drawing.Size(484, 100);
            this.coordinatesPanel.TabIndex = 35;
            // 
            // coordinatesTableLayoutPanel
            // 
            this.coordinatesTableLayoutPanel.ColumnCount = 3;
            this.coordinatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.coordinatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.coordinatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.coordinatesTableLayoutPanel.Controls.Add(this.endCoordinatesLabel, 0, 1);
            this.coordinatesTableLayoutPanel.Controls.Add(this.startCoordinatesLabel, 0, 0);
            this.coordinatesTableLayoutPanel.Controls.Add(this.startXCoordinateNumericUpDown, 1, 0);
            this.coordinatesTableLayoutPanel.Controls.Add(this.startYCoordinateNumericUpDown, 2, 0);
            this.coordinatesTableLayoutPanel.Controls.Add(this.endXCoordinateNumericUpDown, 1, 1);
            this.coordinatesTableLayoutPanel.Controls.Add(this.endYCoordinateNumericUpDown, 2, 1);
            this.coordinatesTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coordinatesTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.coordinatesTableLayoutPanel.Name = "coordinatesTableLayoutPanel";
            this.coordinatesTableLayoutPanel.RowCount = 2;
            this.coordinatesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.coordinatesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.coordinatesTableLayoutPanel.Size = new System.Drawing.Size(468, 84);
            this.coordinatesTableLayoutPanel.TabIndex = 0;
            // 
            // overlayPanel
            // 
            this.overlayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.overlayPanel.Controls.Add(this.overlayTableLayoutPanel);
            this.overlayPanel.Location = new System.Drawing.Point(8, 324);
            this.overlayPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.overlayPanel.Name = "overlayPanel";
            this.overlayPanel.Padding = new System.Windows.Forms.Padding(8);
            this.overlayPanel.Size = new System.Drawing.Size(484, 50);
            this.overlayPanel.TabIndex = 36;
            // 
            // overlayTableLayoutPanel
            // 
            this.overlayTableLayoutPanel.ColumnCount = 2;
            this.overlayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.overlayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.overlayTableLayoutPanel.Controls.Add(this.overlayCheckBox, 1, 0);
            this.overlayTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.overlayTableLayoutPanel.Name = "overlayTableLayoutPanel";
            this.overlayTableLayoutPanel.RowCount = 1;
            this.overlayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.overlayTableLayoutPanel.Size = new System.Drawing.Size(468, 34);
            this.overlayTableLayoutPanel.TabIndex = 29;
            // 
            // thresholdPanel
            // 
            this.thresholdPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thresholdPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.thresholdPanel.Controls.Add(this.thresholdTableLayoutPanel);
            this.thresholdPanel.Location = new System.Drawing.Point(8, 382);
            this.thresholdPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.thresholdPanel.Name = "thresholdPanel";
            this.thresholdPanel.Padding = new System.Windows.Forms.Padding(8);
            this.thresholdPanel.Size = new System.Drawing.Size(484, 50);
            this.thresholdPanel.TabIndex = 37;
            // 
            // thresholdTableLayoutPanel
            // 
            this.thresholdTableLayoutPanel.ColumnCount = 2;
            this.thresholdTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.thresholdTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.thresholdTableLayoutPanel.Controls.Add(this.thresholdLabel, 0, 0);
            this.thresholdTableLayoutPanel.Controls.Add(this.thresholdNumericUpDown, 1, 0);
            this.thresholdTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thresholdTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.thresholdTableLayoutPanel.Name = "thresholdTableLayoutPanel";
            this.thresholdTableLayoutPanel.RowCount = 1;
            this.thresholdTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.thresholdTableLayoutPanel.Size = new System.Drawing.Size(468, 34);
            this.thresholdTableLayoutPanel.TabIndex = 29;
            // 
            // expirationPanel
            // 
            this.expirationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expirationPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.expirationPanel.Controls.Add(this.expirationTableLayoutPanel);
            this.expirationPanel.Location = new System.Drawing.Point(8, 440);
            this.expirationPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.expirationPanel.Name = "expirationPanel";
            this.expirationPanel.Padding = new System.Windows.Forms.Padding(8);
            this.expirationPanel.Size = new System.Drawing.Size(484, 50);
            this.expirationPanel.TabIndex = 38;
            // 
            // expirationTableLayoutPanel
            // 
            this.expirationTableLayoutPanel.ColumnCount = 2;
            this.expirationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.expirationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expirationTableLayoutPanel.Controls.Add(this.expirationNumericUpDown, 1, 0);
            this.expirationTableLayoutPanel.Controls.Add(this.expirationLabel, 0, 0);
            this.expirationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expirationTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.expirationTableLayoutPanel.Name = "expirationTableLayoutPanel";
            this.expirationTableLayoutPanel.RowCount = 1;
            this.expirationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expirationTableLayoutPanel.Size = new System.Drawing.Size(468, 34);
            this.expirationTableLayoutPanel.TabIndex = 29;
            // 
            // actionIfFoundPanel
            // 
            this.actionIfFoundPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionIfFoundPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.actionIfFoundPanel.Controls.Add(this.actionIfFoundTableLayoutPanel);
            this.actionIfFoundPanel.Location = new System.Drawing.Point(8, 498);
            this.actionIfFoundPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.actionIfFoundPanel.Name = "actionIfFoundPanel";
            this.actionIfFoundPanel.Padding = new System.Windows.Forms.Padding(8);
            this.actionIfFoundPanel.Size = new System.Drawing.Size(484, 50);
            this.actionIfFoundPanel.TabIndex = 39;
            // 
            // actionIfFoundTableLayoutPanel
            // 
            this.actionIfFoundTableLayoutPanel.ColumnCount = 2;
            this.actionIfFoundTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.actionIfFoundTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionIfFoundTableLayoutPanel.Controls.Add(this.actionIfImageFoundLabel, 0, 0);
            this.actionIfFoundTableLayoutPanel.Controls.Add(this.actionIfImageFoundButton, 1, 0);
            this.actionIfFoundTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionIfFoundTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.actionIfFoundTableLayoutPanel.Name = "actionIfFoundTableLayoutPanel";
            this.actionIfFoundTableLayoutPanel.RowCount = 1;
            this.actionIfFoundTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionIfFoundTableLayoutPanel.Size = new System.Drawing.Size(468, 34);
            this.actionIfFoundTableLayoutPanel.TabIndex = 29;
            // 
            // actionIfNotFoundPanel
            // 
            this.actionIfNotFoundPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionIfNotFoundPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.actionIfNotFoundPanel.Controls.Add(this.actionIfNotFoundTableLayoutPanel);
            this.actionIfNotFoundPanel.Location = new System.Drawing.Point(8, 556);
            this.actionIfNotFoundPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.actionIfNotFoundPanel.Name = "actionIfNotFoundPanel";
            this.actionIfNotFoundPanel.Padding = new System.Windows.Forms.Padding(8);
            this.actionIfNotFoundPanel.Size = new System.Drawing.Size(484, 50);
            this.actionIfNotFoundPanel.TabIndex = 40;
            // 
            // actionIfNotFoundTableLayoutPanel
            // 
            this.actionIfNotFoundTableLayoutPanel.ColumnCount = 2;
            this.actionIfNotFoundTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.actionIfNotFoundTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionIfNotFoundTableLayoutPanel.Controls.Add(this.actionIfImageNotFoundLabel, 0, 0);
            this.actionIfNotFoundTableLayoutPanel.Controls.Add(this.actionIfImageNotFoundButton, 1, 0);
            this.actionIfNotFoundTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionIfNotFoundTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.actionIfNotFoundTableLayoutPanel.Name = "actionIfNotFoundTableLayoutPanel";
            this.actionIfNotFoundTableLayoutPanel.RowCount = 1;
            this.actionIfNotFoundTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionIfNotFoundTableLayoutPanel.Size = new System.Drawing.Size(468, 34);
            this.actionIfNotFoundTableLayoutPanel.TabIndex = 29;
            // 
            // ImageActionPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actionIfNotFoundPanel);
            this.Controls.Add(this.actionIfFoundPanel);
            this.Controls.Add(this.expirationPanel);
            this.Controls.Add(this.thresholdPanel);
            this.Controls.Add(this.overlayPanel);
            this.Controls.Add(this.coordinatesPanel);
            this.Controls.Add(this.imageSelectionPanel);
            this.Name = "ImageActionPropertiesPanel";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(500, 617);
            this.VisibleChanged += new System.EventHandler(this.ImageActionPropertiesPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endYCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endXCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYCoordinateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startXCoordinateNumericUpDown)).EndInit();
            this.imageSelectionPanel.ResumeLayout(false);
            this.imageSelectionTableLayoutPanel2.ResumeLayout(false);
            this.imageSelectionTableLayoutPanel2.PerformLayout();
            this.coordinatesPanel.ResumeLayout(false);
            this.coordinatesTableLayoutPanel.ResumeLayout(false);
            this.coordinatesTableLayoutPanel.PerformLayout();
            this.overlayPanel.ResumeLayout(false);
            this.overlayTableLayoutPanel.ResumeLayout(false);
            this.overlayTableLayoutPanel.PerformLayout();
            this.thresholdPanel.ResumeLayout(false);
            this.thresholdTableLayoutPanel.ResumeLayout(false);
            this.thresholdTableLayoutPanel.PerformLayout();
            this.expirationPanel.ResumeLayout(false);
            this.expirationTableLayoutPanel.ResumeLayout(false);
            this.expirationTableLayoutPanel.PerformLayout();
            this.actionIfFoundPanel.ResumeLayout(false);
            this.actionIfFoundTableLayoutPanel.ResumeLayout(false);
            this.actionIfFoundTableLayoutPanel.PerformLayout();
            this.actionIfNotFoundPanel.ResumeLayout(false);
            this.actionIfNotFoundTableLayoutPanel.ResumeLayout(false);
            this.actionIfNotFoundTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.PictureBox selectedImagePictureBox;
        private System.Windows.Forms.Label startCoordinatesLabel;
        private System.Windows.Forms.Label endCoordinatesLabel;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.Label expirationLabel;
        private System.Windows.Forms.NumericUpDown startXCoordinateNumericUpDown;
        private System.Windows.Forms.NumericUpDown startYCoordinateNumericUpDown;
        private System.Windows.Forms.NumericUpDown endXCoordinateNumericUpDown;
        private System.Windows.Forms.NumericUpDown endYCoordinateNumericUpDown;
        private System.Windows.Forms.NumericUpDown thresholdNumericUpDown;
        private System.Windows.Forms.NumericUpDown expirationNumericUpDown;
        private System.Windows.Forms.Label selectedImageNameLabel;
        private System.Windows.Forms.Button searchImageButton;
        private System.Windows.Forms.Button actionIfImageFoundButton;
        private System.Windows.Forms.Button actionIfImageNotFoundButton;
        private System.Windows.Forms.Label actionIfImageFoundLabel;
        private System.Windows.Forms.Label actionIfImageNotFoundLabel;
        private System.Windows.Forms.CheckBox overlayCheckBox;
        private System.Windows.Forms.Panel imageSelectionPanel;
        private System.Windows.Forms.TableLayoutPanel imageSelectionTableLayoutPanel2;
        private System.Windows.Forms.Panel coordinatesPanel;
        private System.Windows.Forms.TableLayoutPanel coordinatesTableLayoutPanel;
        private System.Windows.Forms.Panel overlayPanel;
        private System.Windows.Forms.TableLayoutPanel overlayTableLayoutPanel;
        private System.Windows.Forms.Panel thresholdPanel;
        private System.Windows.Forms.TableLayoutPanel thresholdTableLayoutPanel;
        private System.Windows.Forms.Panel expirationPanel;
        private System.Windows.Forms.TableLayoutPanel expirationTableLayoutPanel;
        private System.Windows.Forms.Panel actionIfFoundPanel;
        private System.Windows.Forms.TableLayoutPanel actionIfFoundTableLayoutPanel;
        private System.Windows.Forms.Panel actionIfNotFoundPanel;
        private System.Windows.Forms.TableLayoutPanel actionIfNotFoundTableLayoutPanel;
    }
}
