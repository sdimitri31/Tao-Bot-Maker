using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker
{
    class SequenceXmlManager
    {

        public SequenceXmlManager(){
        }

        public static void SaveSequence(String sequenceName, SequenceController sequenceController)
        {
            System.IO.Directory.CreateDirectory(Constants.SEQUENCES_FOLDER_NAME);
            string fileName = sequenceName + @".xml";

            //Crée la base du XML
            XDocument doc = new XDocument(new XElement("Sequence"));

            //Ajoute toutes les actions
            foreach (Action action in sequenceController.GetActions())
            {
                switch (action.Type)
                {
                    case (int)Action.ActionType.Key:
                        ActionKey actionKey = (ActionKey)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionKey.Type), actionKey.Key));
                        break;

                    case (int)Action.ActionType.Wait:
                        ActionWait actionWait = (ActionWait)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionWait.Type), actionWait.WaitTime));
                        break;

                    case (int)Action.DeprecatedActionType.PictureWait:
                        ActionPictureWait actionPictureWait = (ActionPictureWait)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionPictureWait.Type),
                                                                                        new XAttribute("tolerance", actionPictureWait.Threshold),
                                                                                        new XAttribute("x1", actionPictureWait.X1),
                                                                                        new XAttribute("y1", actionPictureWait.Y1),
                                                                                        new XAttribute("x2", actionPictureWait.X2),
                                                                                        new XAttribute("y2", actionPictureWait.Y2),
                                                                                        new XAttribute("sequenceIfExpired", actionPictureWait.SequenceIfExpired),
                                                                                        new XAttribute("waitTime", actionPictureWait.WaitTime),
                                                                                        actionPictureWait.PictureName));
                        break;

                    case (int)Action.DeprecatedActionType.IfPicture:
                        ActionIfPicture actionIfPicture = (ActionIfPicture)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionIfPicture.Type),
                                                                                        new XAttribute("tolerance", actionIfPicture.Threshold),
                                                                                        new XAttribute("x1", actionIfPicture.X1),
                                                                                        new XAttribute("y1", actionIfPicture.Y1),
                                                                                        new XAttribute("x2", actionIfPicture.X2),
                                                                                        new XAttribute("y2", actionIfPicture.Y2),
                                                                                        new XAttribute("ifFound", actionIfPicture.IfFound),
                                                                                        new XAttribute("ifNotFound", actionIfPicture.IfNotFound),
                                                                                        actionIfPicture.PictureName));
                        break;

                    case (int)Action.ActionType.Sequence:
                        ActionSequence actionSequence = (ActionSequence)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionSequence.Type), actionSequence.SequenceName));
                        break;

                    case (int)Action.ActionType.Click:
                        ActionClick actionClick = (ActionClick)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionClick.Type),
                                                                                      new XAttribute("clic", actionClick.SelectedClick),
                                                                                      new XAttribute("x", actionClick.X1),
                                                                                      new XAttribute("y", actionClick.Y1),
                                                                                      new XAttribute("x2", actionClick.X2),
                                                                                      new XAttribute("y2", actionClick.Y2),
                                                                                      new XAttribute("isDoubleClick", actionClick.IsDoubleClick),
                                                                                      new XAttribute("isDrag", actionClick.IsDrag),
                                                                                      new XAttribute("dragSpeed", actionClick.DragSpeed)));
                        break;

                    case (int)Action.ActionType.Loop:
                        ActionLoop actionLoop = (ActionLoop)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionLoop.Type),
                                                                                      new XAttribute("nbRepetition", actionLoop.RepeatNumber),
                                                                                      actionLoop.SequenceName));
                        break;

                    case (int)Action.ActionType.ImageSearch:
                        ActionImageSearch actionImageSearch = (ActionImageSearch)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionImageSearch.Type),
                                                                                        new XAttribute("tolerance", actionImageSearch.Threshold),
                                                                                        new XAttribute("x1", actionImageSearch.X1),
                                                                                        new XAttribute("y1", actionImageSearch.Y1),
                                                                                        new XAttribute("x2", actionImageSearch.X2),
                                                                                        new XAttribute("y2", actionImageSearch.Y2),
                                                                                        new XAttribute("expiration", actionImageSearch.Expiration),
                                                                                        new XAttribute("ifFound", actionImageSearch.IfFound),
                                                                                        new XAttribute("ifNotFound", actionImageSearch.IfNotFound),
                                                                                        actionImageSearch.PictureName));
                        break;
                }
            }

            //Enregistre le document
            doc.Save(Constants.SEQUENCES_FOLDER_NAME + "\\" + fileName);

        }

        public static Sequence LoadSequence(String sequenceName)
        {
            SequenceController newSequence = new SequenceController
            {
                SequenceName = sequenceName
            };

            try
            {
                string sequencePath = Path.Combine(Constants.SEQUENCES_FOLDER_NAME, sequenceName + ".xml");
                var doc = XDocument.Load(sequencePath);
                
                int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
                foreach (XElement xe in doc.Descendants("Sequence"))
                {
                    foreach (XElement xmlAction in xe.Elements("Action"))
                    {
                        int actionType = -1;

                        //Prevent crash if attribute "type" doesn't exists
                        if (xmlAction.Attribute("type") != null)
                        {
                            //Prevent crash if attribute "type" is not parsable as int
                            try
                            {
                                actionType = Int32.Parse(xmlAction.Attribute("type").Value);
                            }
                            catch(Exception e) 
                            {
                                Log.Write(e.Message, Log.ERROR);
                            }
                        }

                        //Type read successfully, continue loading
                        if(actionType != -1)
                        {
                            bool isTypeSupported = false;

                            //Check if type is supported
                            foreach(int type in Enum.GetValues(typeof(Action.ActionType)))
                            {
                                if(type == actionType)
                                {
                                    isTypeSupported = true;
                                    continue;
                                }
                            }

                            //If supported
                            if(isTypeSupported)
                            {
                                (Action action, string errorMessage) = ActionController.GetActionFromXElement(actionType, xmlAction);
                                newSequence.AddAction(action, errorMessage);
                            }
                            //Else try to load old types
                            else
                            {
                                switch (actionType)
                                {
                                    case (int)Action.DeprecatedActionType.PictureWait:
                                        ActionPictureWait actionPictureWait = new ActionPictureWait();
                                        actionPictureWait.PictureName = (string)xmlAction;
                                        actionPictureWait.X1 = Int32.Parse(xmlAction.Attribute("x1").Value);
                                        actionPictureWait.X2 = Int32.Parse(xmlAction.Attribute("x2").Value);
                                        actionPictureWait.Y1 = Int32.Parse(xmlAction.Attribute("y1").Value);
                                        actionPictureWait.Y2 = Int32.Parse(xmlAction.Attribute("y2").Value);
                                        actionPictureWait.Threshold = Int32.Parse(xmlAction.Attribute("tolerance").Value);
                                        actionPictureWait.WaitTime = Int32.Parse(xmlAction.Attribute("waitTime").Value);
                                        actionPictureWait.SequenceIfExpired = xmlAction.Attribute("sequenceIfExpired").Value;
                                        newSequence.AddAction(actionPictureWait);
                                        break;

                                    case (int)Action.DeprecatedActionType.IfPicture:
                                        //Version ajusting and crash prevention
                                        int threshold = 0;
                                        if (xmlAction.Attribute("x1") != null) x1 = Int32.Parse(xmlAction.Attribute("x1").Value);
                                        if (xmlAction.Attribute("y1") != null) y1 = Int32.Parse(xmlAction.Attribute("y1").Value);
                                        if (xmlAction.Attribute("x2") != null) x2 = Int32.Parse(xmlAction.Attribute("x2").Value);
                                        if (xmlAction.Attribute("y2") != null) y2 = Int32.Parse(xmlAction.Attribute("y2").Value);
                                        if (xmlAction.Attribute("y2") != null) y2 = Int32.Parse(xmlAction.Attribute("y2").Value);


                                        string ifTrueSequence = "EMPTY", ifFalseSequence = "EMPTY";
                                        if (xmlAction.Attribute("ifTrueSequence") != null)
                                            ifTrueSequence = xmlAction.Attribute("ifTrueSequence").Value;
                                        if (xmlAction.Attribute("ifFalseSequence") != null)
                                            ifFalseSequence = xmlAction.Attribute("ifFalseSequence").Value;

                                        ActionIfPicture actionIfPicture = new ActionIfPicture();
                                        actionIfPicture.PictureName = (string)xmlAction;
                                        actionIfPicture.X1 = x1;
                                        actionIfPicture.X2 = x2;
                                        actionIfPicture.Y1 = y1;
                                        actionIfPicture.Y2 = y2;
                                        actionIfPicture.Threshold = threshold;
                                        actionIfPicture.IfFound = ifTrueSequence;
                                        actionIfPicture.IfNotFound = ifFalseSequence;
                                        newSequence.AddAction(actionIfPicture);
                                        break;

                                    default:
                                        newSequence.AddAction(null, "Type unknown");
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                Log.Write(ex.ToString(), Log.ERROR);
                MessageBox.Show(Properties.strings.MessageBox_Error_LoadingSequence);
            }
            return newSequence.Sequence;
        }

        public static List<String> SequencesList()
        {
            System.IO.Directory.CreateDirectory(Constants.SEQUENCES_FOLDER_NAME);
            DirectoryInfo directory = new DirectoryInfo(Constants.SEQUENCES_FOLDER_NAME);
            FileInfo[] files = directory.GetFiles("*.xml"); //Getting xml files

            List<String> sequencesList = new List<String>();

            foreach (FileInfo file in files)
            {
                sequencesList.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }
            return sequencesList;
        }

        public static List<String> SequencesListFiltered(string nameToExclude)
        {
            List<string> sequenceListFiltered = new List<string>();
            foreach (string sequence in SequenceXmlManager.SequencesList())
            {
                //Add sequence to list if it's not the current sequence loaded to prevent Infinite loop
                if (sequence != nameToExclude)
                    sequenceListFiltered.Add(sequence);
            }
            return sequenceListFiltered;
        }

        public static bool IsNameUsed(String name)
        {
            if(File.Exists(Constants.SEQUENCES_FOLDER_NAME + "\\" + name + ".xml")) return true;
            return false;
        }

        public static bool DeleteSequence(String sequenceName)
        {
            string fileName = sequenceName + @".xml";
            try
            {
                File.Delete(Constants.SEQUENCES_FOLDER_NAME + "\\" + fileName);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
