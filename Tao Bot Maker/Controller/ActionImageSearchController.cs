using LogFramework;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View;
using static System.Windows.Forms.LinkLabel;
using Log = Tao_Bot_Maker.Controller.Log;

namespace Tao_Bot_Maker
{
    public class ActionImageSearchController
    {

        /// <summary>
        /// Check if every data needed to create an ActionImageSearch are in specs
        /// </summary>
        /// <param name="pictureName">Expected : not null or empty string</param>
        /// <param name="threshold">Expected : int between 0 and 255</param>
        /// <param name="x1">Expected : int between -999999 and 999999</param>
        /// <param name="y1">Expected : int between -999999 and 999999</param>
        /// <param name="x2">Expected : int between -999999 and 999999</param>
        /// <param name="y2">Expected : int between -999999 and 999999</param>
        /// <param name="expiration">Expected : int between -1 and 999999</param>
        /// <param name="ifFound">Expected : not null or empty string</param>
        /// <param name="ifNotFound">Expected : not null or empty string</param>
        /// <returns>ActionImageSearch if all test passed. string errorMessage if something was wrong</returns>
        public static (ActionImageSearch actionImageSearch, string errorMessage) CreateAction(string pictureName, int threshold, int x1, int x2, int y1, int y2, int expiration, string ifFound, string ifNotFound)
        {
            int errorCount = 0;
            string errorMessage = "";

            if (!ValidateImage(pictureName, out string error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }
            
            if (!ValidateThreshold(threshold, out error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            int[] array2 = { x1, x2, y1, y2 };
            if (!ValidateCoord(array2, out error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            if (!ValidateExpiration(expiration, out error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            if (!ValidateIfFound(ifFound, out error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            if (!ValidateIfNotFound(ifNotFound, out error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            ActionImageSearch actionImageSearch = null;

            if (errorCount == 0)
            {
                actionImageSearch = new ActionImageSearch(pictureName, threshold, x1, x2, y1, y2, expiration, ifFound, ifNotFound);
            }

            //Return Error message if there is an error
            if (actionImageSearch == null)
            {
                Log.Write(errorMessage, LogFramework.Log.ERROR);
                return (null, errorMessage);
            }
            //Or actionImageSearch if no error
            else
                return (actionImageSearch, "");
        }

        private static bool ValidateImage(string imageName, out string errorMessage)
        {
            errorMessage = "";

            if (!string.IsNullOrEmpty(imageName))
            {
                Log.Write("ValidateImage(" + imageName + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_ImageName;
                Log.Write("ValidateImage(" + imageName + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        private static bool ValidateCoord(int[] coords, out string errorMessage)
        {
            errorMessage = "";
            string coordsList = "";

            foreach (int coord in coords)
            {
                if ((coord < -999999) || (coord > 999999))
                {
                    errorMessage = Properties.strings.action_ErrorMessage_InvalidCoords;
                    Log.Write("ValidateCoord(" + coord + ") Result : false", LogFramework.Log.ERROR);
                    return false;
                }
                coordsList += coord + ", ";
            }

            Log.Write("ValidateCoord(" + coordsList + ") Result : true", LogFramework.Log.TRACE);
            return true;
        }

        private static bool ValidateIfFound(string ifFound, out string errorMessage)
        {
            errorMessage = "";

            if (ifFound != null)
            {
                Log.Write("ValidateIf(" + ifFound + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_IfFound;
                Log.Write("ValidateIf(" + ifFound + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        private static bool ValidateIfNotFound(string ifNotFound, out string errorMessage)
        {
            errorMessage = "";

            if (ifNotFound != null)
            {
                Log.Write("ValidateIfNotFound(" + ifNotFound + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_IfNotFound;
                Log.Write("ValidateIfNotFound(" + ifNotFound + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }
        
        private static bool ValidateThreshold(int threshold, out string errorMessage)
        {
            errorMessage = "";

            if ((threshold >= 0) && (threshold <= 255))
            {
                Log.Write("ValidateThreshold(" + threshold + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_ThresholdWrongInterval;
                Log.Write("ValidateThreshold(" + threshold + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        private static bool ValidateExpiration(int expiration, out string errorMessage)
        {
            errorMessage = "";

            if ((expiration >= -1) && (expiration <= 999999))
            {
                Log.Write("ValidateExpiration(" + expiration + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_ExpirationWrongInterval;
                Log.Write("ValidateExpiration(" + expiration + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        private static string ImportPicture(string originalPath, out string errorMessage)
        {
            errorMessage = "";

            string selectedPictureFullPath = originalPath;
            string targetFullPath = null;
            string pictureName = Path.GetFileName(originalPath);

            //Create Pictures folder if not present
            Directory.CreateDirectory(Constants.PICTURE_FOLDER_NAME);

            //Checking if path is correct
            if (File.Exists(selectedPictureFullPath))
            {
                //Source Folder
                string sourceFolderPath = Path.GetDirectoryName(selectedPictureFullPath);

                //Target Folder
                string targetFolderPath = Path.Combine(Directory.GetCurrentDirectory().ToString(), Constants.PICTURE_FOLDER_NAME);

                targetFullPath = Path.Combine(targetFolderPath, pictureName);

                //If not in the same directory
                if (targetFolderPath != sourceFolderPath)
                {
                    //Check if file with same name already exists in target folder
                    if (File.Exists(targetFullPath))
                    {
                        string message = "\"" + pictureName + "\" " + Properties.strings.MessageBox_ImageAlreadyInFolder_Message;

                        DialogResult dr = MessageBox.Show(message, Properties.strings.MessageBox_ImageAlreadyInFolder_Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            //Replace
                            try
                            {
                                Log.Write("Source : " + selectedPictureFullPath, LogFramework.Log.TRACE);
                                Log.Write("Destination : " + targetFullPath, LogFramework.Log.TRACE);

                                //Delete image in target folder
                                File.Delete(Path.Combine(targetFolderPath, pictureName));

                                //Replace it by source image
                                File.Copy(selectedPictureFullPath, targetFullPath);

                                Log.Write("Replacing image success", LogFramework.Log.TRACE);
                            }
                            catch (Exception ex)
                            {
                                errorMessage += "Erreur : Unable to replace the file\r\n";
                                Log.Write(errorMessage, LogFramework.Log.ERROR);
                                Log.Write(ex.Message.ToString(), LogFramework.Log.ERROR);
                                return null;
                            }
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            errorMessage = "MessageBox Canceled";
                            return null;
                        }
                        else if (dr == DialogResult.No)
                        {
                            //Rename before moving
                            try
                            {
                                //Set a new name based on current dateTime
                                String ext = Path.GetExtension(selectedPictureFullPath);
                                pictureName = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ext;
                                String dest = Path.Combine(targetFolderPath, pictureName);

                                Log.Write("Source : " + selectedPictureFullPath);
                                Log.Write("Destination : " + dest);

                                File.Copy(selectedPictureFullPath, dest);

                                Log.Write("Renaming image success", LogFramework.Log.TRACE);
                            }
                            catch (Exception ex)
                            {
                                errorMessage += "Erreur : Unable to rename the file\r\n";
                                Log.Write(errorMessage, LogFramework.Log.ERROR);
                                Log.Write(ex.Message.ToString(), LogFramework.Log.ERROR);
                                return null;
                            }
                        }
                    }
                    //If no file as the same name in Pictures folder
                    else
                    {
                        //Copy the picture in Pictures folder
                        try
                        {
                            Log.Write("Source : " + selectedPictureFullPath);
                            Log.Write("Destination : " + targetFullPath);

                            File.Copy(selectedPictureFullPath, targetFullPath);

                            Log.Write("Copying image success", LogFramework.Log.TRACE);
                        }
                        catch (Exception ex)
                        {
                            errorMessage += "Erreur : Unable to copy the file\r\n";
                            Log.Write(errorMessage, LogFramework.Log.ERROR);
                            Log.Write(ex.Message.ToString(), LogFramework.Log.ERROR);
                            return null;
                        }
                    }
                }
            }
            else
            {
                errorMessage += "Erreur : File not found\r\n";
                Log.Write(errorMessage, LogFramework.Log.ERROR);
                return null;
            }

            if (targetFullPath == null)
            {
                errorMessage += "Erreur : Invalid picture destination\r\n";
                Log.Write(errorMessage, LogFramework.Log.ERROR);
                return null;
            }


            Log.Write("Importing image success. Picture name : " + pictureName, LogFramework.Log.TRACE);
            return pictureName;
        }

        /// <summary>
        /// Validate, import image and process data from ActionImageSearchPanel
        /// </summary>
        /// <param name="panel">ActionImageSearchPanel</param>
        /// <returns>ActionImageSearchPanel : if success or null if error. ErrorMessage empty if success or error details</returns>
        public static (ActionImageSearch action, string errorMessage) GetActionFromControl(ActionImageSearchPanel panel)
        {
            //Moving picture into picture folder
            string pictureName = ImportPicture(panel.OriginalPath, out string error);
            if (pictureName != null)
            {
                var (actionImageSearch, errorMessage) = CreateAction(pictureName, panel.Threshold, panel.X1, panel.X2, panel.Y1, panel.Y2, panel.Expiration, panel.IfFound, panel.IfNotFound);

                return (actionImageSearch, errorMessage);
            }
            else
            {
                return (null, error);
            }
        }

    }
}
