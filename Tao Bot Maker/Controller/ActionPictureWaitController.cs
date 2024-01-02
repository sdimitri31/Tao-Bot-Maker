
using LogFramework;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionPictureWaitController
    {
        public ActionPictureWaitController() { }

        public static Action GetActionFromControl(ActionPictureWaitPanel panel)
        {
            int errorCount = 0;
            String errorMessage = "";
            ActionPictureWait actionPictureWait = null;

            //Moving picture into picture folder
            //Get complete path of selected picture
            String selectedPictureFullPath = panel.PictureName;
            String selectedPictureDestinationFullPath = null;
            String selectedPictureName = null;

            //Create Pictures folder if not present
            Directory.CreateDirectory(MainApp.PICTURE_FOLDER_NAME);

            //Checking if path is correct
            if (File.Exists(selectedPictureFullPath))
            {               
                //Source Folder and Name
                String selectedPictureFolderPath = Path.GetDirectoryName(selectedPictureFullPath);
                selectedPictureName = Path.GetFileName(selectedPictureFullPath);

                //Destination Folder
                String picturesFolderPath = Directory.GetCurrentDirectory().ToString() + "\\" + MainApp.PICTURE_FOLDER_NAME;
                selectedPictureDestinationFullPath = picturesFolderPath + "\\" + selectedPictureName;

                //If not in the same directory
                if (picturesFolderPath != selectedPictureFolderPath)
                {
                    //Check if file with same name already exists
                    if (File.Exists(picturesFolderPath + "\\" + selectedPictureName))
                    {
                        String message = "File with name : " + selectedPictureName + " already present in Pictures folder.\r\n" +
                            "Choose : \r\n" +
                            "Yes to replace\r\n" +
                            "No to add it with new name\r\n";
                        DialogResult dr = MessageBox.Show(message, "Name used", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                Log.Write(Log.INFO, "Source : " + selectedPictureFullPath);
                                Log.Write(Log.INFO, "Destination : " + selectedPictureDestinationFullPath);

                                File.Delete(picturesFolderPath + "\\" + selectedPictureName);
                                File.Copy(selectedPictureFullPath, selectedPictureDestinationFullPath);
                            }
                            catch
                            {
                                errorCount++;
                                errorMessage += "Erreur : Unable to replace the file\r\n";
                            }
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            return null;
                        }
                        else if (dr == DialogResult.No)
                        {
                            try
                            {
                                String ext = Path.GetExtension(selectedPictureFullPath);
                                selectedPictureName = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ext;
                                String dest = picturesFolderPath + "\\" + selectedPictureName;

                                Log.Write(Log.INFO, "Source : " + selectedPictureFullPath);
                                Log.Write(Log.INFO, "Destination : " + dest);

                                File.Copy(selectedPictureFullPath, dest);

                            }
                            catch
                            {
                                errorCount++;
                                errorMessage += "Erreur : Unable to rename the file\r\n";
                            }
                        }
                    }
                    //If no file as the same name in Pictures folder
                    else
                    {
                        //Copy the picture in Pictures folder
                        try
                        {
                            Log.Write(Log.INFO, "Source : " + selectedPictureFullPath);
                            Log.Write(Log.INFO, "Destination : " + selectedPictureDestinationFullPath);

                            File.Copy(selectedPictureFullPath, selectedPictureDestinationFullPath);
                        }
                        catch
                        {
                            errorCount++;
                            errorMessage += "Erreur : Unable to copy the file\r\n";
                        }
                    }
                }
            }
            else
            {
                errorCount++;
                errorMessage += "Erreur : File not found\r\n";
            }

            if(selectedPictureDestinationFullPath == null)
            {
                errorCount++;
                errorMessage += "Erreur : Invalid picture destination\r\n";
            }

            //Threshold
            int threshold = panel.Threshold;
            if (threshold < 0 || threshold > 255)
            {
                errorCount++;
                errorMessage += "Erreur : Threshold should be a number between 0 and 255\r\n";
            }

            //X1
            int x1 = panel.X1;
            if (x1 < 0)
            {
                errorCount++;
                errorMessage += "Erreur : X1 should be a number greater or equal to 0\r\n";
            }

            //X2
            int x2 = panel.X2;
            if (x2 < 0)
            {
                errorCount++;
                errorMessage += "Erreur : X2 should be a number greater or equal to 0\r\n";
            }

            //Y1
            int y1 = panel.Y1;
            if (y1 < 0)
            {
                errorCount++;
                errorMessage += "Erreur : Y1 should be a number greater or equal to 0\r\n";
            }

            //Y2
            int y2 = panel.Y2;
            if (y2 < 0)
            {
                errorCount++;
                errorMessage += "Erreur : Y2 should be a number greater or equal to 0\r\n";
            }

            //WaitTime
            int waitTime = panel.WaitTime;
            if (waitTime < 0)
            {
                errorCount++;
                errorMessage += "Erreur : Wait time should be a number greater than 0\r\n";
            }

            //SequenceIfExpired
            string sequenceIfExpired = panel.SequenceIfExpired;

            if (sequenceIfExpired == null)
            {
                errorCount++;
                errorMessage += "Erreur : A sequence must be selected\r\n";
            }

            if(errorCount == 0)
            {
                actionPictureWait = new ActionPictureWait(selectedPictureName, threshold, x1, x2, y1, y2, waitTime, sequenceIfExpired);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
           
            return actionPictureWait;
        }

    }
}
