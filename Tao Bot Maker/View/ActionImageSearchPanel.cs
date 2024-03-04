using LogFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using Log = Tao_Bot_Maker.Controller.Log;

namespace Tao_Bot_Maker.View
{
    public partial class ActionImageSearchPanel : UserControl
    {
        private string originalPath;    //Full path before moving
        private string pictureName;     //Text to show on the button
        private int threshold;
        private int x1;
        private int y1;
        private int x2;
        private int y2;
        private int expiration;
        private string ifFound;
        private string ifNotFound;

        ActionView actionView;

        public ActionImageSearchPanel(ActionView actionView, Action action = null)
        {
            InitializeComponent();
            Localization();
            AddHotkeysToLabels();

            originalPath = null;
            this.actionView = actionView;

            List<string> sequenceListFiltered = SequenceXmlManager.SequencesListFiltered(actionView.GetLoadedSequenceName());

            flatComboBox_ActionImageSearch_IfFound.Items.AddRange(sequenceListFiltered.ToArray());
            flatComboBox_ActionImageSearch_IfNotFound.Items.AddRange(sequenceListFiltered.ToArray());

            //Not null = Editing existing action
            if(action != null)
            {
                ActionImageSearch actionImageSearch = action as ActionImageSearch;

                PictureName = actionImageSearch.PictureName;
                OriginalPath = Path.Combine(Directory.GetCurrentDirectory().ToString(), Constants.PICTURE_FOLDER_NAME, PictureName);
                try
                {
                    using (var img = new Bitmap(Image.FromFile(OriginalPath)))
                    {
                        pictureBox_ActionImageSearch_Image.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    if(SettingsController.IsSaveLogs()) Log.Write(ex.Message.ToString(), LogFramework.Log.ERROR);
                }

                Threshold = actionImageSearch.Threshold;
                X1 = actionImageSearch.X1;
                X2 = actionImageSearch.X2;
                Y1 = actionImageSearch.Y1;
                Y2 = actionImageSearch.Y2;
                Expiration = actionImageSearch.Expiration;
                IfFound = actionImageSearch.IfFound;
                IfNotFound = actionImageSearch.IfNotFound;
            }
        }

        private void Localization()
        {
            label_ActionImageSearch_IfNotFound.Text = Properties.strings.label_SequenceIfNotFound;
            label_ActionImageSearch_IfFound.Text = Properties.strings.label_SequenceIfPicture;
            label_ActionImageSearch_Threshold.Text = Properties.strings.label_Threshold;
            label_ActionImageSearch_Expiration.Text = Properties.strings.label_Expiration;
            button_ActionImageSearch_ClearArea.Text = Properties.strings.button_ClearArea;
            button_ActionImageSearch_FindImage.Text = Properties.strings.button_FindImage;
            button_ActionImageSearch_PathImage.Text = Properties.strings.button_Picture;
            button_ActionImageSearch_ShowArea.Text = Properties.strings.button_ShowDrawingArea;
        }

        private void AddHotkeysToLabels()
        {
            int modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY()) << 16;
            Keys hotkeyXY = (Keys)((int)SettingsController.GetHotkeyKeyXY() | modifier);
            label_ActionImageSearch_X1.Text += " (" + hotkeyXY.ToString() + ")";
            label_ActionImageSearch_Y1.Text += " (" + hotkeyXY.ToString() + ")";

            modifier = MainApp.Reverse3Bits((int)SettingsController.GetHotkeyModifierXY2()) << 16;
            Keys hotkeyXY2 = (Keys)((int)SettingsController.GetHotkeyKeyXY2() | modifier);
            label_ActionImageSearch_X2.Text += " (" + hotkeyXY2.ToString() + ")";
            label_ActionImageSearch_Y2.Text += " (" + hotkeyXY2.ToString() + ")";
        }

        public string OriginalPath
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
        public string PictureName
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
                button_ActionImageSearch_PathImage.Text = value.ToString(); 
            }
        }
        public int Threshold
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionImageSearch_Threshold.Text);
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
                numericUpDown_ActionImageSearch_Threshold.Text = value.ToString(); 
            }
        }
        public int X1
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionImageSearch_X1.Text);
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
                numericUpDown_ActionImageSearch_X1.Text = value.ToString(); 
            }
        }
        public int X2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionImageSearch_X2.Text);
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
                numericUpDown_ActionImageSearch_X2.Text = value.ToString(); 
            }
        }
        public int Y1
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionImageSearch_Y1.Text);
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
                numericUpDown_ActionImageSearch_Y1.Text = value.ToString(); 
            }
        }
        public int Y2
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionImageSearch_Y2.Text);
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
                numericUpDown_ActionImageSearch_Y2.Text = value.ToString(); 
            }
        }
        public int Expiration
        {
            get
            {
                try
                {
                    int numVal = Int32.Parse(numericUpDown_ActionImageSearch_Expiration.Text);
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
                numericUpDown_ActionImageSearch_Expiration.Text = value.ToString();
            }
        }
        public string IfFound
        {
            get
            {
                try
                {
                    if (flatComboBox_ActionImageSearch_IfFound.SelectedItem != null)
                    {
                        string sequenceName = flatComboBox_ActionImageSearch_IfFound.SelectedItem.ToString();
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
                flatComboBox_ActionImageSearch_IfFound.SelectedItem = value.ToString(); 
            }
        }
        public string IfNotFound
        {
            get
            {
                try
                {
                    if (flatComboBox_ActionImageSearch_IfNotFound.SelectedItem != null)
                    {
                        string sequenceName = flatComboBox_ActionImageSearch_IfNotFound.SelectedItem.ToString();
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
                flatComboBox_ActionImageSearch_IfNotFound.SelectedItem = value.ToString(); 
            }
        }

        public void DrawFromTextBoxValues()
        {
            actionView.ClearRectangles();
            actionView.DrawRectangleAtCoords(X1, Y1, X2, Y2);
            actionView.RefreshRectangles();
        }

        private void Button_ActionImageSearch_PathImage_Click(object sender, EventArgs e)
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
                            pictureBox_ActionImageSearch_Image.Image = new Bitmap(img);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (SettingsController.IsSaveLogs()) Log.Write(ex.Message.ToString(), LogFramework.Log.ERROR);
                    }
                }
            }
        }

        private void Button_ActionImageSearch_FindImage_Click(object sender, EventArgs e)
        {
            //Looking for image
            string[] results_if_image = ImageSearchController.FindImage(originalPath, Threshold, X1, Y1, X2, Y2);

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

                string message = Properties.strings.MessageBox_ImageFound + "\r\n " +
                    "X : " + results_if_image[1] + " Y : " + results_if_image[2];

                MessageBox.Show(message);
                Log.Write(message, LogFramework.Log.TRACE);

            }
            else
            {
                MessageBox.Show(Properties.strings.MessageBox_ImageNotFound);
                Log.Write(Properties.strings.MessageBox_ImageNotFound, LogFramework.Log.TRACE);
            }

        }

        private void Button_ActionImageSearch_ClearArea_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
        }

        private void Button_ActionImageSearch_ShowArea_Click(object sender, EventArgs e)
        {
            DrawFromTextBoxValues();
        }
    }
}
