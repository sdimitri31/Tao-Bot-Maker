using LogFramework;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View;
using static System.Windows.Forms.LinkLabel;
using Log = Tao_Bot_Maker.Controller.Log;

namespace Tao_Bot_Maker
{
    public class ActionImageSearchController
    {
        //Default values
        private static readonly string  _defaultPictureName = "";
        private static readonly int     _defaultThreshold = 100;
        private static readonly int     _defaultX1 = 0;
        private static readonly int     _defaultX2 = 1;
        private static readonly int     _defaultY1 = 0;
        private static readonly int     _defaultY2 = 1;
        private static readonly int     _defaultExpiration = 1;
        private static readonly string  _defaultIfFound = "";
        private static readonly string  _defaultIfNotFound = "";

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
            string errorMessage = string.Empty;

            if (!ValidateImage(pictureName, out string error))
            {
                errorMessage += error + "\r\n";
                pictureName = _defaultPictureName;
            }
            
            if (!ValidateThreshold(threshold, out error))
            {
                errorMessage += error + "\r\n";
                threshold = _defaultThreshold;
            }

            int[] array2 = { x1, x2, y1, y2 };
            if (!ValidateCoord(array2, out error))
            {
                errorMessage += error + "\r\n";
                x1 = _defaultX1;
                x2 = _defaultX2;
                y1 = _defaultY1;
                y2 = _defaultY2;
            }

            if (!ValidateExpiration(expiration, out error))
            {
                errorMessage += error + "\r\n";
                expiration = _defaultExpiration;
            }

            if (!ValidateIfFound(ifFound, out error))
            {
                errorMessage += error + "\r\n";
                ifFound = _defaultIfFound;
            }

            if (!ValidateIfNotFound(ifNotFound, out error))
            {
                errorMessage += error + "\r\n";
                ifNotFound = _defaultIfNotFound;
            }

            ActionImageSearch actionImageSearch = new ActionImageSearch(pictureName, threshold, x1, x2, y1, y2, expiration, ifFound, ifNotFound);

            return (actionImageSearch, errorMessage);
        }

        private static bool ValidateImage(string imageName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(imageName))
            {
                errorMessage = Properties.strings.action_ErrorMessage_Image_NameEmpty;
                Log.Write("ValidateImage(" + imageName + ") Result : false", LogFramework.Log.ERROR);
                return false;

            }
            else if (!File.Exists(Path.Combine(Constants.PICTURE_FOLDER_NAME, imageName)))
            {
                errorMessage = Properties.strings.action_ErrorMessage_Image_NotFound;
                Log.Write("ValidateImage(" + imageName + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
            else
            {
                Log.Write("ValidateImage(" + imageName + ") Result : true", LogFramework.Log.TRACE);
                return true;
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

        public static (ActionImageSearch action, string errorMessage) GetActionFromXElement(XElement xmlAction)
        {
            string pictureName = (string)xmlAction;

            //Version ajusting and crash prevention
            string errors = string.Empty;

            string ifFound = _defaultIfFound;
            if (xmlAction.Attribute("ifFound") != null)
            {
                ifFound = xmlAction.Attribute("ifFound").Value.ToLower();
            }
            else
            {
                errors += Properties.strings.action_Member_IfFound + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            string ifNotFound = _defaultIfNotFound;
            if (xmlAction.Attribute("ifNotFound") != null)
            {
                ifNotFound = xmlAction.Attribute("ifNotFound").Value.ToLower();
            }
            else
            {
                errors += Properties.strings.action_Member_IfNotFound + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int x1 = _defaultX1;
            if (xmlAction.Attribute("x1") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("x1").Value, out x1))
                {
                    errors += Properties.strings.action_Member_X1 + " : " +
                        Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_X1 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int y1 = _defaultY1;
            if (xmlAction.Attribute("y1") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("y1").Value, out y1))
                {
                    errors += Properties.strings.action_Member_Y1 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_Y1 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int x2 = _defaultX2;
            if (xmlAction.Attribute("x2") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("x2").Value, out x2))
                {
                    errors += Properties.strings.action_Member_X2 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_X2 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int y2 = _defaultY2;
            if (xmlAction.Attribute("y2") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("y2").Value, out y2))
                {
                    errors += Properties.strings.action_Member_Y2 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_Y2 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int expiration = _defaultExpiration;
            if (xmlAction.Attribute("expiration") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("expiration").Value, out expiration))
                {
                    errors += Properties.strings.action_Member_Expiration + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_Expiration + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int threshold = _defaultThreshold;
            //Check for all names used for storing "Threshold" value
            if ((xmlAction.Attribute("threshold") != null) || (xmlAction.Attribute("tolerance") != null))
            {
                if (xmlAction.Attribute("threshold") != null)
                    if (!int.TryParse(xmlAction.Attribute("threshold").Value, out threshold))
                    {
                        errors += Properties.strings.action_Member_Threshold + " : " +
                        Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                    }
                else if (xmlAction.Attribute("tolerance") != null)
                    if (!int.TryParse(xmlAction.Attribute("tolerance").Value, out threshold))
                    {
                        errors += Properties.strings.action_Member_Threshold + " : " +
                        Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                    }
            }
            else
            {
                errors += Properties.strings.action_Member_Threshold + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            var (actionSequence, errorMessage) = CreateAction(pictureName, threshold, x1, x2, y1, y2, expiration, ifFound, ifNotFound);

            errors += errorMessage;

            return (actionSequence, errors);
        }


    }
}
