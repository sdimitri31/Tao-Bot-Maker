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
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View
{
    public partial class ActionPictureWaitPanel : UserControl
    {
        String pictureName;
        //Store the picture path before moving
        String originalPath;
        String destinationPath;
        ActionView actionView;

        //New Action
        public ActionPictureWaitPanel(ActionView actionView)
        {
            InitializeComponent();
            Localization();
            AddHotkeysToLabels();
            originalPath = null;
            destinationPath = null;
            this.actionView = actionView;
            flatComboBoxActionPictureWaitSequenceIfExpired.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
        }

        //Editing Action
        public ActionPictureWaitPanel(ActionView actionView, Action action)
        {
            InitializeComponent();
            Localization();
            AddHotkeysToLabels();
            this.actionView = actionView;
            OriginalPath = null;
            DestinationPath = null;
            flatComboBoxActionPictureWaitSequenceIfExpired.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());

            PictureName = Constants.PICTURE_FOLDER_NAME + "//" + ((ActionPictureWait)action).PictureName;
            pictureBoxActionPictureWaitImage.Image = Image.FromFile(PictureName);
            Threshold = ((ActionPictureWait)action).Threshold;
            X1 = ((ActionPictureWait)action).X1;
            X2 = ((ActionPictureWait)action).X2;
            Y1 = ((ActionPictureWait)action).Y1;
            Y2 = ((ActionPictureWait)action).Y2;
            WaitTime = ((ActionPictureWait)action).WaitTime;
            SequenceIfExpired = ((ActionPictureWait)action).SequenceIfExpired;
        }
        private void Localization()
        {
            label_SequenceIfExpired.Text = Properties.strings.label_SequenceIfExpired;
            label_Threshold.Text = Properties.strings.label_Threshold;
            buttonActionPictureWaitClearDrawing.Text = Properties.strings.button_ClearArea;
            buttonActionPictureWaitFindImage.Text = Properties.strings.button_FindImage;
            buttonActionPictureWaitImagePath.Text = Properties.strings.button_Picture;
            buttonActionPictureWaitShowZone.Text = Properties.strings.button_ShowDrawingArea;
        }
        private void AddHotkeysToLabels()
        {
            int modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY()) << 16;
            Keys hotkeyXY = (Keys)((int)SettingsController.GetHotkeyKeyXY() | modifier);
            label_X1.Text += " (" + hotkeyXY.ToString() + ")";
            label_Y1.Text += " (" + hotkeyXY.ToString() + ")";

            modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY2()) << 16;
            Keys hotkeyXY2 = (Keys)((int)SettingsController.GetHotkeyKeyXY2() | modifier);
            label_X2.Text += " (" + hotkeyXY2.ToString() + ")";
            label_Y2.Text += " (" + hotkeyXY2.ToString() + ")";
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
        public String OriginalPath
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
            set
            {
                originalPath = value;
            }
        }

        public String PictureName
        {
            get
            {
                try
                {
                    if (pictureName != null)
                    {
                        return pictureName;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
            set 
            { 
                buttonActionPictureWaitImagePath.Text = value.ToString();
                pictureName = value;
            }
        }
        public int Threshold
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDownActionPictureWaitThreshold.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { numericUpDownActionPictureWaitThreshold.Text = value.ToString(); }
        }
        public int X1 
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDownActionPictureWaitX1.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { numericUpDownActionPictureWaitX1.Text = value.ToString(); }
        }
        public int X2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDownActionPictureWaitX2.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { numericUpDownActionPictureWaitX2.Text = value.ToString(); }
        }
        public int Y1
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDownActionPictureWaitY1.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { numericUpDownActionPictureWaitY1.Text = value.ToString(); }
        }
        public int Y2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDownActionPictureWaitY2.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { numericUpDownActionPictureWaitY2.Text = value.ToString(); }
        }
        public int WaitTime
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDownActionPictureWaitWaitTime.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set { numericUpDownActionPictureWaitWaitTime.Text = value.ToString(); }
        }
        public String SequenceIfExpired
        {
            get
            {
                try
                {
                    if (flatComboBoxActionPictureWaitSequenceIfExpired.SelectedItem != null)
                    {
                        String sequenceName = flatComboBoxActionPictureWaitSequenceIfExpired.SelectedItem.ToString();
                        return sequenceName;
                    }
                    return null;
                }
                catch 
                {
                    return null;
                }
            }
            set { flatComboBoxActionPictureWaitSequenceIfExpired.SelectedItem = value.ToString(); }
        }

        public void DrawFromTextBoxValues()
        {
            actionView.ClearRectangles();
            actionView.DrawRectangleAtCoords(X1, Y1, X2, Y2);
            actionView.RefreshRectangles();
        }

        private void buttonActionPictureWaitImagePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + @"\Images\";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    OriginalPath = openFileDialog.FileName;
                    buttonActionPictureWaitImagePath.Text = openFileDialog.SafeFileName;
                    pictureBoxActionPictureWaitImage.Image = Image.FromFile(originalPath);
                    DestinationPath = Path.Combine(Constants.PICTURE_FOLDER_NAME, openFileDialog.SafeFileName);
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
                //actionView.Log(Log.INFO, "Image trouvée X : " + results_if_image[1] + " Y : " + results_if_image[2]);

            }
            else
            {
                MessageBox.Show("IMG NOT FOUND");
                //actionView.Log(Log.INFO, "Image introuvable");                
            }
            
        }

        private void buttonActionPictureWaitClearDrawing_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
            actionView.RefreshRectangles();
        }

        private void buttonPanelActionImage_ShowZone_Click(object sender, EventArgs e)
        {
            DrawFromTextBoxValues();
        }

    }
}
