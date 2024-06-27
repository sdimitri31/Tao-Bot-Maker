using LogFramework;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class ImageActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        private ActionForm addActionForm;
        private Action actionIfFound;
        private Action actionNotFound;
        private string selectedImageName;

        public ImageActionPropertiesPanel(ActionForm addActionForm)
        {
            InitializeComponent();
            this.addActionForm = addActionForm;
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
                actionIfFoundButton.Text = actionIfFound.Type.ToString();
                this.actionNotFound = imageAction.ActionIfNotFound;
                actionIfNotFoundButton.Text = actionNotFound.Type.ToString();
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
                    else
                    {
                        // Show error message
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string ImportImage(string originalPath, out string errorMessage)
        {
            errorMessage = "";

            if (!File.Exists(originalPath))
            {
                errorMessage = "Error: File not found.";
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
                string message = $"Image \"{imageName}\" already exists in the folder. Do you want to replace it?";
                DialogResult result = MessageBox.Show(message, "Replace Image?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

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
                        errorMessage = "Operation cancelled by the user.";
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
                errorMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Error: Unable to replace the file. {ex.Message}";
                return false;
            }
        }

        private bool TryCopyFile(string sourcePath, string targetPath, out string errorMessage)
        {
            try
            {
                File.Copy(sourcePath, targetPath);
                errorMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Error: Unable to copy the file. {ex.Message}";
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
                errorMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                newFilePath = null;
                errorMessage = $"Error: Unable to rename and copy the file. {ex.Message}";
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

            int[] centerCoordinates = ImageSearchHelper.FindImageCenter(imagePath, threshold, x1, y1, x2, y2);

            if (centerCoordinates != null)
            {
                MessageBox.Show($"Image found at center coordinates: X = {centerCoordinates[0]}, Y = {centerCoordinates[1]}", "Image Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Image not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void ActionIfFoundButton_Click(object sender, EventArgs e)
        {
            addActionForm.UnregisterHotkeys();
            using (var addActionForm = new ActionForm(true, actionIfFound))
            {
                if (addActionForm.ShowDialog() == DialogResult.OK)
                {
                    actionIfFound = addActionForm.Action;
                    actionIfFoundButton.Text = actionIfFound.Type.ToString();
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
                    actionIfNotFoundButton.Text = actionNotFound.Type.ToString();
                }
            }
            addActionForm.RegisterHotkeys();
        }
    }
}
