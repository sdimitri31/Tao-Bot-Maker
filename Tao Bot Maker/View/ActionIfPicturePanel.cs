using LogFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;

namespace Tao_Bot_Maker.View
{
    public partial class ActionIfPicturePanel : UserControl
    {
        //Store the picture path before moving
        String originalPath;
        String destinationPath;
        ActionView actionView;
        public ActionIfPicturePanel(ActionView actionView)
        {
            InitializeComponent();
            Localization();
            originalPath = null;
            destinationPath = null;
            this.actionView = actionView;
            comboBoxActionIfPictureImageFound.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            comboBoxActionIfPictureImageNotFound.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
        }
        public ActionIfPicturePanel(ActionView actionView, Action action)
        {
            InitializeComponent();
            Localization();
            originalPath = null;
            destinationPath = null;
            this.actionView = actionView;
            comboBoxActionIfPictureImageFound.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            comboBoxActionIfPictureImageNotFound.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());

            PictureName = ((ActionIfPicture)action).PictureName;
            Threshold = ((ActionIfPicture)action).Threshold;
            X1 = ((ActionIfPicture)action).X1;
            X2 = ((ActionIfPicture)action).X2;
            Y1 = ((ActionIfPicture)action).Y1;
            Y2 = ((ActionIfPicture)action).Y2;
            SequenceIfFound = ((ActionIfPicture)action).SequenceIfFound;
            SequenceIfNotFound = ((ActionIfPicture)action).SequenceIfNotFound;
        }
        private void Localization()
        {
            label_SequenceIfNoPicture.Text = Properties.strings.label_SequenceIfNotFound;
            label_SequenceIfPicture.Text = Properties.strings.label_SequenceIfPicture;
            label_Threshold.Text = Properties.strings.label_Threshold;
            buttonActionIfPictureClearDrawing.Text = Properties.strings.button_ClearZone;
            buttonActionIfPictureFindImage.Text = Properties.strings.button_FindImage;
            buttonActionIfPictureImagePath.Text = Properties.strings.button_Picture;
            buttonActionIfPictureShowZone.Text = Properties.strings.button_ShowDrawingArea;
        }

        public String DestinationPath
        {
            get
            {
                try
                {
                    if (destinationPath != null)
                    {
                        return destinationPath;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
            set { destinationPath = value.ToString(); }
        }
        public String PictureName
        {
            get
            {
                try
                {
                    if (originalPath != null)
                    {
                        return originalPath;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
            set { buttonActionIfPictureImagePath.Text = value.ToString(); }
        }
        public int Threshold
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionIfPictureThreshold.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionIfPictureThreshold.Text = value.ToString(); }
        }
        public int X1
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionIfPicture_x1.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionIfPicture_x1.Text = value.ToString(); }
        }
        public int X2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionIfPicture_x2.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionIfPicture_x2.Text = value.ToString(); }
        }
        public int Y1
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionIfPicture_y1.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionIfPicture_y1.Text = value.ToString(); }
        }
        public int Y2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionIfPicture_y2.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionIfPicture_y2.Text = value.ToString(); }
        }
        public String SequenceIfFound
        {
            get
            {
                try
                {
                    if (comboBoxActionIfPictureImageFound.SelectedItem != null)
                    {
                        String sequenceName = comboBoxActionIfPictureImageFound.SelectedItem.ToString();
                        return sequenceName;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
            set { comboBoxActionIfPictureImageFound.SelectedItem = value.ToString(); }
        }
        public String SequenceIfNotFound
        {
            get
            {
                try
                {
                    if (comboBoxActionIfPictureImageNotFound.SelectedItem != null)
                    {
                        String sequenceName = comboBoxActionIfPictureImageNotFound.SelectedItem.ToString();
                        return sequenceName;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
            set { comboBoxActionIfPictureImageNotFound.SelectedItem = value.ToString(); }
        }

        public void DrawFromTextBoxValues()
        {
            actionView.ClearRectangles();
            actionView.DrawRectangleAtCoords(X1, Y1, X2, Y2);
            actionView.RefreshRectangles();
        }

        private void buttonActionIfPictureImagePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + @"\Images\";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    originalPath = openFileDialog.FileName;
                    buttonActionIfPictureImagePath.Text = openFileDialog.SafeFileName;
                    pictureBoxPanelActionIfImage.Image = Image.FromFile(originalPath);
                    DestinationPath = Path.Combine(MainApp.PICTURE_FOLDER_NAME, openFileDialog.SafeFileName);
                }
            }
        }

        private void buttonActionIfPictureFindImage_Click(object sender, EventArgs e)
        {
            //Looking for image
            String[] results_if_image = ImageSearchController.FindImage(originalPath, Threshold, X1, Y1, X2, Y2);

            //If something is found
            if (results_if_image != null)
            {
                //Read image to get size properties
                System.Drawing.Image img = System.Drawing.Image.FromFile(originalPath);

                //Draw a rectangle at result coordinates
                actionView.ClearRectangles();
                actionView.DrawRectangle(
                    Int32.Parse(results_if_image[1]) - 15,
                    Int32.Parse(results_if_image[2]) - 15,
                    img.Width + 30,
                    img.Height + 30);
                actionView.RefreshRectangles();

                MessageBox.Show("IMG FOUND\r\n " +
                    "Coords X :" + results_if_image[1] + " Y : " + results_if_image[2]);
                actionView.Log(Log.INFO, "Image trouvée X : " + results_if_image[1] + " Y : " + results_if_image[2]);

            }
            else
            {
                MessageBox.Show("IMG NOT FOUND");
                actionView.Log(Log.INFO, "Image introuvable");
            }

        }

        private void buttonActionIfPictureClearDrawing_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
            actionView.RefreshRectangles();
        }

        private void buttonActionIfPictureShowZone_Click(object sender, EventArgs e)
        {
            DrawFromTextBoxValues();
        }
    }
}
