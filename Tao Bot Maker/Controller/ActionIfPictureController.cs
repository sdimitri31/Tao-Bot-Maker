using LogFramework;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionIfPictureController
    {
        public ActionIfPictureController() { }
        /// <summary>
        /// Validate and process data from ActionIfPicturePanel and send ActionIfPicture to ActionController
        /// </summary>
        /// <param name="panel">ActionIfPicturePanel</param>
        /// <returns>ActionIfPicture if success or null if error</returns>
        public static Action GetActionFromControl(ActionIfPicturePanel panel)
        {
            int errorCount = 0;
            String errorMessage = "";
            ActionIfPicture actionIfPicture = null;

            //Moving picture into picture folder

            String selectedPictureFullPath = panel.OriginalPath;
            String targetFullPath = null;
            String pictureName = panel.PictureName;

            //Create Pictures folder if not present
            Directory.CreateDirectory(Constants.PICTURE_FOLDER_NAME);

            //Checking if path is correct
            if (File.Exists(selectedPictureFullPath))
            {               
                //Source Folder and Name
                String sourceFolderPath = Path.GetDirectoryName(selectedPictureFullPath);

                //Destination Folder
                String targetFolderPath = Path.Combine(Directory.GetCurrentDirectory().ToString(), Constants.PICTURE_FOLDER_NAME);
                targetFullPath = Path.Combine(targetFolderPath, pictureName);

                //If not in the same directory
                if (targetFolderPath != sourceFolderPath)
                {
                    //Check if file with same name already exists in target folder
                    if (File.Exists(Path.Combine(targetFolderPath, pictureName)))
                    {
                        String message = "File with name : " + pictureName + " already present in Pictures folder.\r\n" +
                            "Choose : \r\n" +
                            "Yes to replace\r\n" +
                            "No to add it with new name\r\n";
                        DialogResult dr = MessageBox.Show(message, "Name used", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            //Replace
                            try
                            {
                                Log.Write(Log.INFO, "Source : " + selectedPictureFullPath);
                                Log.Write(Log.INFO, "Destination : " + targetFullPath);

                                File.Delete(Path.Combine(targetFolderPath, pictureName));
                                File.Copy(selectedPictureFullPath, targetFullPath);
                            }
                            catch (Exception ex)
                            {
                                errorCount++;
                                errorMessage += "Erreur : Unable to replace the file\r\n";
                                Log.Write(Log.ERROR, ex.Message.ToString());
                            }
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            return null;
                        }
                        else if (dr == DialogResult.No)
                        {
                            //Rename before moving
                            try
                            {
                                String ext = Path.GetExtension(selectedPictureFullPath);
                                pictureName = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ext;
                                String dest = Path.Combine(targetFolderPath, pictureName);

                                Log.Write(Log.INFO, "Source : " + selectedPictureFullPath);
                                Log.Write(Log.INFO, "Destination : " + dest);

                                File.Copy(selectedPictureFullPath, dest);
                            }
                            catch (Exception ex)
                            {
                                errorCount++;
                                errorMessage += "Erreur : Unable to rename the file\r\n";
                                Log.Write(Log.ERROR, ex.Message.ToString());
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
                            Log.Write(Log.INFO, "Destination : " + targetFullPath);

                            File.Copy(selectedPictureFullPath, targetFullPath);
                        }
                        catch (Exception ex)
                        {
                            errorCount++;
                            errorMessage += "Erreur : Unable to copy the file\r\n";
                            Log.Write(Log.ERROR, ex.Message.ToString());
                        }
                    }
                }
            }
            else
            {
                errorCount++;
                errorMessage += "Erreur : File not found\r\n";
            }

            if(targetFullPath == null)
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
            if (x1 < -999999 || x1 > 999999)
            {
                errorCount++;
                errorMessage += "Erreur : X1 should be a number between -999999 and 999999\r\n";
            }

            //X2
            int x2 = panel.X2;
            if (x2 < -999999 || x2 > 999999)
            {
                errorCount++;
                errorMessage += "Erreur : X2 should be a number between -999999 and 999999\r\n";
            }

            //Y1
            int y1 = panel.Y1;
            if (y1 < -999999 || y1 > 999999)
            {
                errorCount++;
                errorMessage += "Erreur : Y1 should be a number between -999999 and 999999\r\n";
            }

            //Y2
            int y2 = panel.Y2;
            if (y2 < -999999 || y2 > 999999)
            {
                errorCount++;
                errorMessage += "Erreur : Y2 should be a number between -999999 and 999999\r\n";
            }

            //Expiration
            int expiration = panel.Expiration;
            if (expiration < -1)
            {
                errorCount++;
                errorMessage += "Erreur : Expiration should be a number greater than -2\r\n";
            }

            //SequenceIfFound
            string ifFound = panel.IfFound;

            if (ifFound == null)
            {
                errorCount++;
                errorMessage += "Erreur : A sequence must be selected\r\n";
            }

            //SequenceIfNotFound
            string ifNotFound = panel.IfNotFound;

            if (ifNotFound == null)
            {
                errorCount++;
                errorMessage += "Erreur : A sequence must be selected\r\n";
            }

            if (errorCount == 0)
            {
                actionIfPicture = new ActionIfPicture(pictureName, threshold, x1, x2, y1, y2, expiration, ifFound, ifNotFound);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
           
            return actionIfPicture;
        }

    }
}
