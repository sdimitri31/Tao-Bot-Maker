using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        ActionView actionView;

        public ActionImageSearchPanel(ActionView actionView, Action action = null)
        {
            InitializeComponent();
            this.Visible = false;

            Localization();
            AddHotkeysToLabels();

            originalPath = null;
            this.actionView = actionView;

            //Defaulting XY2 values to max screen size
            X2 = Screen.PrimaryScreen.Bounds.Width;
            Y2 = Screen.PrimaryScreen.Bounds.Height;

            //Loading sequences list without current selected sequence to prevent infinite loops
            List<string> sequenceListFiltered = SequenceXmlManager.SequencesListFiltered(actionView.GetLoadedSequenceName());
            flatComboBox_IfFound.Items.AddRange(sequenceListFiltered.ToArray());
            flatComboBox_IfNotFound.Items.AddRange(sequenceListFiltered.ToArray());

            //Not null = Editing existing action
            if (action != null)
            {
                ActionImageSearch actionImageSearch = action as ActionImageSearch;

                PictureName = actionImageSearch.PictureName;
                OriginalPath = Path.Combine(Directory.GetCurrentDirectory().ToString(), Constants.PICTURE_FOLDER_NAME, PictureName);
                try
                {
                    using (var img = new Bitmap(Image.FromFile(OriginalPath)))
                    {
                        pictureBox_Image.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    if (SettingsController.IsSaveLogs()) Log.Write(ex.Message.ToString(), Log.ERROR);
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
            label_IfNotFound.Text = Properties.strings.label_SequenceIfNotFound;
            label_IfFound.Text = Properties.strings.label_SequenceIfPicture;
            label_Threshold.Text = Properties.strings.label_Threshold;
            label_Expiration.Text = Properties.strings.label_Expiration;
            button_ClearArea.Text = Properties.strings.button_ClearArea;
            button_FindImage.Text = Properties.strings.button_FindImage;
            button_PathImage.Text = Properties.strings.button_Picture;
            button_ShowArea.Text = Properties.strings.button_ShowDrawingArea;
        }

        private void AddHotkeysToLabels()
        {
            string hotkeyXY = Utils.GetFormatedKeysString((Keys)((int)SettingsController.GetHotkeyXY()));
            label_X1.Text += " (" + hotkeyXY + ")";
            label_Y1.Text += " (" + hotkeyXY + ")";

            string hotkeyXY2 = Utils.GetFormatedKeysString((Keys)((int)SettingsController.GetHotkeyXY2()));
            label_X2.Text += " (" + hotkeyXY2 + ")";
            label_Y2.Text += " (" + hotkeyXY2 + ")";
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
                button_PathImage.Text = value.ToString();
            }
        }
        public int Threshold
        {
            get => (int)numericUpDown_Threshold.Value;
            set => numericUpDown_Threshold.Value = value;
        }
        public int X1
        {
            get => (int)numericUpDown_X1.Value;
            set => numericUpDown_X1.Value = value;
        }
        public int X2
        {
            get => (int)numericUpDown_X2.Value;
            set => numericUpDown_X2.Value = value;
        }
        public int Y1
        {
            get => (int)numericUpDown_Y1.Value;
            set => numericUpDown_Y1.Value = value;
        }
        public int Y2
        {
            get => (int)numericUpDown_Y2.Value;
            set => numericUpDown_Y2.Value = value;
        }
        public int Expiration
        {
            get => (int)numericUpDown_Expiration.Value;
            set => numericUpDown_Expiration.Value = value;
        }
        public string IfFound
        {
            get
            {
                try
                {
                    if (flatComboBox_IfFound.SelectedItem != null)
                    {
                        string sequenceName = flatComboBox_IfFound.SelectedItem.ToString();
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
                flatComboBox_IfFound.SelectedItem = value.ToString();
            }
        }
        public string IfNotFound
        {
            get
            {
                try
                {
                    if (flatComboBox_IfNotFound.SelectedItem != null)
                    {
                        string sequenceName = flatComboBox_IfNotFound.SelectedItem.ToString();
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
                flatComboBox_IfNotFound.SelectedItem = value.ToString();
            }
        }

        /// <summary>
        /// Assign values in numboxX1 and numboxY1
        /// </summary>
        /// <param name="x">Value for X1</param>
        /// <param name="y">Value for Y1</param>
        public void HotkeyXY(int x, int y)
        {
            X1 = x;
            Y1 = y;
            DrawArea();
        }

        /// <summary>
        /// Assign values in numboxX2 and numboxY2
        /// </summary>
        /// <param name="x">Value for X2</param>
        /// <param name="y">Value for Y2</param>
        public void HotkeyXY2(int x, int y)
        {
            X2 = x;
            Y2 = y;
            DrawArea();
        }

        /// <summary>
        /// Draw rectangles from coords using values X1, Y1, X2 and Y2
        /// </summary>
        public void DrawArea()
        {
            ClearArea();

            int[] xy = Utils.GetCoordsHeightWidth(X1, Y1, X2, Y2);

            actionView.DrawRectangle(xy[0], xy[1], xy[2], xy[3], Constants.COLOR_LABEL_XY);
        }

        public void ClearArea()
        {
            actionView.ClearRectangles();
        }

        private void Button_PathImage_Click(object sender, EventArgs e)
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
                            pictureBox_Image.Image = new Bitmap(img);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (SettingsController.IsSaveLogs()) Log.Write(ex.Message.ToString(), Log.ERROR);
                    }
                }
            }
        }

        private void Button_FindImage_Click(object sender, EventArgs e)
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
                Log.Write(message, Log.TRACE);

            }
            else
            {
                MessageBox.Show(Properties.strings.MessageBox_ImageNotFound);
                Log.Write(Properties.strings.MessageBox_ImageNotFound, Log.TRACE);
            }

        }

        private void Button_ClearArea_Click(object sender, EventArgs e)
        {
            actionView.ClearRectangles();
        }

        private void Button_ShowArea_Click(object sender, EventArgs e)
        {
            DrawArea();
        }

        private void NumericUpDown_Coords_ValueChanged(object sender, EventArgs e)
        {
            if(this.Visible == true)
                DrawArea();
        }

        private void ActionImageSearchPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                DrawArea();
        }
    }
}
