using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class ImageActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        private ActionForm addActionForm;
        private DrawingForm drawingForm;
        private Action actionIfFound;
        private Action actionNotFound;
        private string selectedImageName;

        public ImageActionPropertiesPanel(ActionForm addActionForm)
        {
            InitializeComponent();
            UpdateUI();
            drawingForm = new DrawingForm();
            drawingForm.Show();
            this.addActionForm = addActionForm;
            this.Disposed += ImageActionPropertiesPanel_Disposed;
        }

        private void ImageActionPropertiesPanel_Disposed(object sender, EventArgs e)
        {
            drawingForm.Close();
        }

        private void UpdateUI()
        {
            selectImageButton.Text = Resources.Strings.ButtonSelectImage;
            selectedImageNameLabel.Text = Resources.Strings.LabelNoImageSelected;
            startCoordinatesLabel.Text = Resources.Strings.LabelStartCoordinates;
            endCoordinatesLabel.Text = Resources.Strings.LabelEndCoordinates;
            thresholdLabel.Text = Resources.Strings.LabelThreshold;
            expirationLabel.Text = Resources.Strings.LabelExpiration;
            actionIfImageFoundLabel.Text = Resources.Strings.LabelActionIfImageFound;
            actionIfImageNotFoundLabel.Text = Resources.Strings.LabelActionIfImageNotFound;
            searchImageButton.Text = Resources.Strings.ButtonSearchImage;
            actionIfImageFoundButton.Text = Resources.Strings.ButtonAddAction;
            actionIfImageNotFoundButton.Text = Resources.Strings.ButtonAddAction;
            overlayCheckBox.Text = Resources.Strings.LabelEnableDrawingOverlay;
        }

        public Action GetAction()
        {
            ImageAction imageAction = new ImageAction(
                imageFilePath: selectedImageName,
                startX: (int)this.startXCoordinateNumericUpDown.Value,
                startY: (int)this.startYCoordinateNumericUpDown.Value,
                endX: (int)this.endXCoordinateNumericUpDown.Value,
                endY: (int)this.endYCoordinateNumericUpDown.Value,
                threshold: (int)this.thresholdNumericUpDown.Value,
                expiration: (int)this.expirationNumericUpDown.Value,
                actionIfFound: this.actionIfFound,
                actionIfNotFound: this.actionNotFound
            );

            return imageAction;
        }

        public void SetAction(Action action)
        {
            if (action != null && action is ImageAction imageAction)
            {
                SetImageName(imageAction.ImageName);
                SetPictureFromName(imageAction.ImageName);
                this.startXCoordinateNumericUpDown.Value = imageAction.StartX;
                this.startYCoordinateNumericUpDown.Value = imageAction.StartY;
                this.endXCoordinateNumericUpDown.Value = imageAction.EndX;
                this.endYCoordinateNumericUpDown.Value = imageAction.EndY;
                this.thresholdNumericUpDown.Value = imageAction.Threshold;
                this.expirationNumericUpDown.Value = imageAction.Expiration;
                this.actionIfFound = imageAction.ActionIfFound;
                actionIfImageFoundButton.Text = actionIfFound.Type.ToString();
                this.actionNotFound = imageAction.ActionIfNotFound;
                actionIfImageNotFoundButton.Text = actionNotFound.Type.ToString();
            }
        }

        private void SetImageName(string imageName)
        {
            this.selectedImageNameLabel.Text = imageName;
            selectedImageName = imageName;
        }

        private void SetPictureFromName(string imageName)
        {
            string imagePath = Path.Combine(ImageAction.imagesFolderPath, imageName);
            selectedImagePictureBox.Image = Image.FromFile(imagePath);
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select an image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string errorMessage;

                    // Use ImportImage to get the imported image name
                    string importedImageName = ImportImage(selectedImagePath, out errorMessage);

                    if (!string.IsNullOrEmpty(importedImageName))
                    {
                        SetImageName(importedImageName);
                        SetPictureFromName(importedImageName);
                    }
                    else if (!string.IsNullOrEmpty(errorMessage))
                    {
                        // Show error message
                        string error = Resources.Strings.Error;
                        string fullMessage = string.Format(Resources.Strings.ErrorMessageFormat, error, errorMessage);
                        MessageBox.Show(fullMessage, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string ImportImage(string originalPath, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!File.Exists(originalPath))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageFileNotFound, originalPath);
                return null;
            }

            string imageName = Path.GetFileName(originalPath);
            string targetFolderPath = Path.Combine(Directory.GetCurrentDirectory(), ImageAction.imagesFolderPath);
            string targetFullPath = Path.Combine(targetFolderPath, imageName);

            // Create images folder if not present
            Directory.CreateDirectory(targetFolderPath);

            if (Path.GetDirectoryName(originalPath) == targetFolderPath)
            {
                return imageName;
            }

            // Handle file already exists in the target folder
            if (File.Exists(targetFullPath))
            {
                string questionMessage = string.Format(Resources.Strings.InfoMessageFileExists, imageName);
                string question = Resources.Strings.QuestionMessageReplace;
                string questionMessageCaption = Resources.Strings.CaptionMessageFileExists;
                DialogResult result = MessageBox.Show($"{questionMessage}\r\n{question}", questionMessageCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (!TryReplaceFile(originalPath, targetFullPath, out errorMessage))
                        {
                            return null;
                        }
                        break;

                    case DialogResult.No:
                        if (!TryCopyFileWithNewName(originalPath, targetFolderPath, out targetFullPath, out errorMessage))
                        {
                            return null;
                        }
                        imageName = Path.GetFileName(targetFullPath);
                        break;

                    case DialogResult.Cancel:
                        return null;
                }
            }
            else
            {
                // No file with the same name exists, simply copy the file
                if (!TryCopyFile(originalPath, targetFullPath, out errorMessage))
                {
                    return null;
                }
            }

            return imageName;
        }

        private bool TryReplaceFile(string sourcePath, string targetPath, out string errorMessage)
        {
            try
            {
                File.Delete(targetPath);
                File.Copy(sourcePath, targetPath);
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"{Resources.Strings.ErrorMessageUnableToReplaceFile}\r\n{ex.Message}";
                return false;
            }
        }

        private bool TryCopyFile(string sourcePath, string targetPath, out string errorMessage)
        {
            try
            {
                File.Copy(sourcePath, targetPath);
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"{Resources.Strings.ErrorMessageUnableToCopyFile}\r\n{ex.Message}";
                return false;
            }
        }

        private bool TryCopyFileWithNewName(string sourcePath, string targetFolderPath, out string newFilePath, out string errorMessage)
        {
            try
            {
                string extension = Path.GetExtension(sourcePath);
                string newFileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;
                newFilePath = Path.Combine(targetFolderPath, newFileName);
                File.Copy(sourcePath, newFilePath);
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                newFilePath = null;
                errorMessage = $"{Resources.Strings.ErrorMessageUnableToRenameAndCopyFile1}\r\n{ex.Message}";
                return false;
            }
        }

        private void SearchImageButton_Click(object sender, EventArgs e)
        {
            string targetFolderPath = Path.Combine(Directory.GetCurrentDirectory(), ImageAction.imagesFolderPath);
            string imagePath = Path.Combine(targetFolderPath, selectedImageName);
            int threshold = (int)thresholdNumericUpDown.Value;
            int x1 = (int)startXCoordinateNumericUpDown.Value;
            int y1 = (int)startYCoordinateNumericUpDown.Value;
            int x2 = (int)endXCoordinateNumericUpDown.Value;
            int y2 = (int)endYCoordinateNumericUpDown.Value;

            int[] imageCoordinates = ImageSearchHelper.FindImage(imagePath, threshold, x1, y1, x2, y2);

            if (imageCoordinates != null)
            {
                drawingForm.DrawRectangle(imageCoordinates[0], imageCoordinates[1], imageCoordinates[2], imageCoordinates[3], KnownColor.Green);
                int[] centerCoordinates = CoordinatesHelper.GetCenterCoords(imageCoordinates[0], imageCoordinates[1], imageCoordinates[2], imageCoordinates[3]);
                string coordinates = string.Format(Resources.Strings.CoordinatesFormat, centerCoordinates[0], centerCoordinates[1]);
                string message = string.Format(Resources.Strings.InfoMessageImageFoundAtCoords, coordinates);
                string caption = Resources.Strings.InfoMessageImageFound;
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string caption = Resources.Strings.InfoMessageImageNotFound;
                MessageBox.Show(caption, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Assign values in numboxX1 and numboxY1
        /// </summary>
        /// <param name="x">Value for X1</param>
        /// <param name="y">Value for Y1</param>
        public void HotkeyXY(int x, int y)
        {
            startXCoordinateNumericUpDown.Value = x;
            startYCoordinateNumericUpDown.Value = y;
        }

        /// <summary>
        /// Assign values in numboxX2 and numboxY2
        /// </summary>
        /// <param name="x">Value for X2</param>
        /// <param name="y">Value for Y2</param>
        public void HotkeyXY2(int x, int y)
        {
            endXCoordinateNumericUpDown.Value = x;
            endYCoordinateNumericUpDown.Value = y;
        }

        /// <summary>
        /// Draw rectangles from coords using values X1, Y1, X2 and Y2
        /// </summary>
        public void DrawArea()
        {
            if (!overlayCheckBox.Checked)
                return;

            ClearArea();

            int[] xy = CoordinatesHelper.GetTopLeftCoords((int)startXCoordinateNumericUpDown.Value, (int)startYCoordinateNumericUpDown.Value, (int)endXCoordinateNumericUpDown.Value, (int)endYCoordinateNumericUpDown.Value);
            int[] xy2 = CoordinatesHelper.GetBottomRightCoords((int)startXCoordinateNumericUpDown.Value, (int)startYCoordinateNumericUpDown.Value, (int)endXCoordinateNumericUpDown.Value, (int)endYCoordinateNumericUpDown.Value);

            drawingForm.DrawRectangleAtCoords(xy[0], xy[1], xy2[0], xy2[1], KnownColor.Green);
        }

        public void ClearArea()
        {
            drawingForm.ClearRectangles();
        }

        private void ActionIfFoundButton_Click(object sender, EventArgs e)
        {
            addActionForm.UnregisterHotkeys();
            using (var addActionForm = new ActionForm(true, actionIfFound))
            {
                if (addActionForm.ShowDialog() == DialogResult.OK)
                {
                    actionIfFound = addActionForm.Action;
                    actionIfImageFoundButton.Text = actionIfFound.Type.ToString();
                }
            }
            addActionForm.RegisterHotkeys();
        }

        private void ActionIfNotFoundButton_Click(object sender, EventArgs e)
        {
            addActionForm.UnregisterHotkeys();
            using (var addActionForm = new ActionForm(false, actionNotFound))
            {
                if (addActionForm.ShowDialog() == DialogResult.OK)
                {
                    actionNotFound = addActionForm.Action;
                    actionIfImageNotFoundButton.Text = actionNotFound.Type.ToString();
                }
            }
            addActionForm.RegisterHotkeys();
        }

        ActionType IActionPropertiesPanel.GetType()
        {
            return ActionType.ImageAction;
        }

        private void ImageActionPropertiesPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                DrawArea();
            else
                ClearArea();
        }

        private void CoordinatesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                DrawArea();
        }

        private void OverlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overlayCheckBox.Checked)
                DrawArea();
            else
                ClearArea();
        }
    }
}
