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
    public partial class ActionIfPicturePanel : UserControl
    {
        private String originalPath;    //Full path before moving
        private String pictureName;     //Text to show on the button
        private int threshold;
        private int x1;
        private int y1;
        private int x2;
        private int y2;
        private int expiration;
        private String ifFound;
        private String ifNotFound;

        ActionView actionView;

        public ActionIfPicturePanel(ActionView actionView, Action action = null)
        {
            InitializeComponent();
            Localization();
            AddHotkeysToLabels();

            originalPath = null;
            this.actionView = actionView;

            flatComboBox_ActionPicture_IfFound.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            flatComboBox_ActionPicture_IfNotFound.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());

            //Not null means Editing existing action
            if(action != null)
            {
                ActionIfPicture actionIfPicture = action as ActionIfPicture;

                PictureName = actionIfPicture.PictureName;
                OriginalPath = Path.Combine(Directory.GetCurrentDirectory().ToString(), Constants.PICTURE_FOLDER_NAME, PictureName);
                try
                {
                    using (var img = new Bitmap(Image.FromFile(OriginalPath)))
                    {
                        pictureBox_ActionPicture_Image.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    if(SettingsController.IsSaveLogs()) Log.Write(Log.ERROR, ex.Message.ToString());
                }

                Threshold = actionIfPicture.Threshold;
                X1 = actionIfPicture.X1;
                X2 = actionIfPicture.X2;
                Y1 = actionIfPicture.Y1;
                Y2 = actionIfPicture.Y2;
                IfFound = actionIfPicture.SequenceIfFound;
                IfNotFound = actionIfPicture.SequenceIfNotFound;
            }
        }

        private void Localization()
        {
            label__ActionPicture_IfNotFound.Text = Properties.strings.label_SequenceIfNotFound;
            label_ActionPicture_IfFound.Text = Properties.strings.label_SequenceIfPicture;
            label_ActionPicture_Threshold.Text = Properties.strings.label_Threshold;
            button_ActionPicture_ClearArea.Text = Properties.strings.button_ClearZone;
            button_ActionPicture_FindImage.Text = Properties.strings.button_FindImage;
            button_ActionPicture_PathImage.Text = Properties.strings.button_Picture;
            button_ActionPicture_ShowArea.Text = Properties.strings.button_ShowDrawingArea;
        }

        private void AddHotkeysToLabels()
        {
            int modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY()) << 16;
            Keys hotkeyXY = (Keys)((int)SettingsController.GetHotkeyKeyXY() | modifier);
            label_ActionPicture_X1.Text += " (" + hotkeyXY.ToString() + ")";
            label_ActionPicture_Y1.Text += " (" + hotkeyXY.ToString() + ")";

            modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY2()) << 16;
            Keys hotkeyXY2 = (Keys)((int)SettingsController.GetHotkeyKeyXY2() | modifier);
            label_ActionPicture_X2.Text += " (" + hotkeyXY2.ToString() + ")";
            label_ActionPicture_Y2.Text += " (" + hotkeyXY2.ToString() + ")";
        }

        public String OriginalPath
        {
            get
            {
                try
                {
                    return originalPath;
                }
                catch
                {
                    return null;
                }
            }
            set { originalPath = value.ToString(); }
        }
        public String PictureName
        {
            get
            {
                try
                {
                    return pictureName;
                }
                catch
                {
                    return null;
                }
            }
            set 
            {
                pictureName = value.ToString();
                button_ActionPicture_PathImage.Text = value.ToString(); 
            }
        }
        public int Threshold
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionPicture_Threshold.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -2;
                }
            }
            set 
            {
                threshold = value;
                numericUpDown_ActionPicture_Threshold.Text = value.ToString(); 
            }
        }
        public int X1
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionPicture_X1.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set 
            {
                x1 = value;
                numericUpDown_ActionPicture_X1.Text = value.ToString(); 
            }
        }
        public int X2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionPicture_X2.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set
            {
                x2 = value; 
                numericUpDown_ActionPicture_X2.Text = value.ToString(); 
            }
        }
        public int Y1
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionPicture_Y1.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set
            {
                y1 = value; 
                numericUpDown_ActionPicture_Y1.Text = value.ToString(); 
            }
        }
        public int Y2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionPicture_Y2.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            set
            {
                y2 = value; 
                numericUpDown_ActionPicture_Y2.Text = value.ToString(); 
            }
        }
        public int Expiration
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionPicture_Expiration.Text);
                    return numVal;
                }
                catch (FormatException)
                {
                    return -2;
                }
            }
            set
            {
                expiration = value;
                numericUpDown_ActionPicture_Expiration.Text = value.ToString();
            }
        }
        public String IfFound
        {
            get
            {
                try
                {
                    if (flatComboBox_ActionPicture_IfFound.SelectedItem != null)
                    {
                        String sequenceName = flatComboBox_ActionPicture_IfFound.SelectedItem.ToString();
                        return sequenceName;
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
                ifFound = value;
                flatComboBox_ActionPicture_IfFound.SelectedItem = value.ToString(); 
            }
        }
        public String IfNotFound
        {
            get
            {
                try
                {
                    if (flatComboBox_ActionPicture_IfNotFound.SelectedItem != null)
                    {
                        String sequenceName = flatComboBox_ActionPicture_IfNotFound.SelectedItem.ToString();
                        return sequenceName;
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
                ifNotFound = value;
                flatComboBox_ActionPicture_IfNotFound.SelectedItem = value.ToString(); 
            }
        }

        public void DrawFromTextBoxValues()
        {
            actionView.ClearRectangles();
            actionView.DrawRectangleAtCoords(X1, Y1, X2, Y2);
            actionView.RefreshRectangles();
        }

        private void Button_ActionPicture_PathImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    OriginalPath = openFileDialog.FileName;
                    PictureName = openFileDialog.SafeFileName;

                    //Try to draw in picturebox and release file
                    try
                    {
                        using (var img = new Bitmap(Image.FromFile(OriginalPath)))
                        {
                            pictureBox_ActionPicture_Image.Image = new Bitmap(img);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (SettingsController.IsSaveLogs()) Log.Write(Log.ERROR, ex.Message.ToString());
                    }
                }
            }
        }

        private void Button_ActionPicture_FindImage_Click(object sender, EventArgs e)
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

        private void Button_ActionPicture_ClearArea_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
            actionView.RefreshRectangles();
        }

        private void Button_ActionPicture_ShowArea_Click(object sender, EventArgs e)
        {
            DrawFromTextBoxValues();
        }
    }
}
