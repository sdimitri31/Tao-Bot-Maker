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
    public partial class ActionPictureWaitPanel : UserControl
    {
        //Store the picture path before moving
        String originalPath;
        String destinationPath;
        ActionView actionView;

        public ActionPictureWaitPanel(ActionView actionView)
        {
            InitializeComponent();
            originalPath = null;
            destinationPath = null;
            this.actionView = actionView;
            comboBoxActionPictureWaitSequenceIfExpired.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
        }
        public ActionPictureWaitPanel(ActionView actionView, Action action)
        {
            InitializeComponent();
            this.actionView = actionView;
            originalPath = null;
            destinationPath = null;
            comboBoxActionPictureWaitSequenceIfExpired.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());

            PictureName = ((ActionPictureWait)action).PictureName;
            Threshold = ((ActionPictureWait)action).Threshold;
            X1 = ((ActionPictureWait)action).X1;
            X2 = ((ActionPictureWait)action).X2;
            Y1 = ((ActionPictureWait)action).Y1;
            Y2 = ((ActionPictureWait)action).Y2;
            WaitTime = ((ActionPictureWait)action).WaitTime;
            SequenceIfExpired = ((ActionPictureWait)action).SequenceIfExpired;
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
            set { buttonActionPictureWaitImagePath.Text = value.ToString(); }
        }
        public int Threshold
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxPanelActionPictureWaitThreshold.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxPanelActionPictureWaitThreshold.Text = value.ToString(); }
        }
        public int X1 
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionPictureWaitX1.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionPictureWaitX1.Text = value.ToString(); }
        }
        public int X2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionPictureWaitX2.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionPictureWaitX2.Text = value.ToString(); }
        }
        public int Y1
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionPictureWaitY1.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionPictureWaitY1.Text = value.ToString(); }
        }
        public int Y2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionPictureWaitY2.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionPictureWaitY2.Text = value.ToString(); }
        }
        public int WaitTime
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(textBoxActionPictureWaitWaitTime.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { textBoxActionPictureWaitWaitTime.Text = value.ToString(); }
        }
        public String SequenceIfExpired
        {
            get
            {
                try
                {
                    if (comboBoxActionPictureWaitSequenceIfExpired.SelectedItem != null)
                    {
                        String sequenceName = comboBoxActionPictureWaitSequenceIfExpired.SelectedItem.ToString();
                        return sequenceName;
                    }
                    return null;
                }
                catch 
                {
                    return null;
                }
            }
            set { comboBoxActionPictureWaitSequenceIfExpired.SelectedItem = value.ToString(); }
        }

        private void buttonActionPictureWaitImagePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + @"\Images\";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    originalPath = openFileDialog.FileName;
                    buttonActionPictureWaitImagePath.Text = openFileDialog.SafeFileName;
                    pictureBoxActionPictureWaitImage.Image = Image.FromFile(originalPath);
                    DestinationPath = Path.Combine(MainApp.PICTURE_FOLDER_NAME, openFileDialog.SafeFileName);
                }
            }
        }

        private void buttonActionPictureWaitFindImage_Click(object sender, EventArgs e)
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
                Log.Write(Log.INFO, "Image trouvée X : " + results_if_image[1] + " Y : " + results_if_image[2]);

            }
            else
            {
                MessageBox.Show("IMG NOT FOUND");
                Log.Write(Log.INFO, "Image introuvable");                
            }
            
        }

        private void buttonActionPictureWaitClearDrawing_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
            actionView.RefreshRectangles();
        }

        private void buttonPanelActionImage_ShowZone_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
            actionView.DrawRectangleAtCoords(X1, Y1, X2, Y2);
            actionView.RefreshRectangles();
        }

    }
}
