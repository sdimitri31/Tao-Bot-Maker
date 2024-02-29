using LogFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
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
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionSequence.Type), actionSequence.SequencePath));
                        break;

                    case (int)Action.ActionType.Click:
                        ActionClick actionClick = (ActionClick)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionClick.Type),
                                                                                      new XAttribute("clic", actionClick.SelectedClick),
                                                                                      new XAttribute("x", actionClick.X),
                                                                                      new XAttribute("y", actionClick.Y)));
                        break;

                    case (int)Action.ActionType.Loop:
                        ActionLoop actionLoop = (ActionLoop)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionLoop.Type),
                                                                                      new XAttribute("nbRepetition", actionLoop.NumberOfRepetitions),
                                                                                      actionLoop.SequencePath));
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

            var doc = XDocument.Load(Constants.SEQUENCES_FOLDER_NAME + @"\" + sequenceName + @".xml");

            try
            {
                foreach (XElement xe in doc.Descendants("Sequence"))
                {
                    foreach (XElement xmlAction in xe.Elements("Action"))
                    {

                        int actionType = Int32.Parse(xmlAction.Attribute("type").Value);
                        switch (actionType)
                        {
                            case (int)Action.ActionType.Key:
                                ActionKey actionKey = new ActionKey();
                                actionKey.Key = (string)xmlAction;
                                newSequence.AddAction(actionKey);
                                break;

                            case (int)Action.ActionType.Wait:
                                ActionWait actionWait = new ActionWait();
                                actionWait.WaitTime = (int)xmlAction;
                                newSequence.AddAction(actionWait);
                                break;

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
                                ActionIfPicture actionIfPicture = new ActionIfPicture();
                                actionIfPicture.PictureName = (string)xmlAction;
                                actionIfPicture.X1 = Int32.Parse(xmlAction.Attribute("x1").Value);
                                actionIfPicture.X2 = Int32.Parse(xmlAction.Attribute("x2").Value);
                                actionIfPicture.Y1 = Int32.Parse(xmlAction.Attribute("y1").Value);
                                actionIfPicture.Y2 = Int32.Parse(xmlAction.Attribute("y2").Value);
                                actionIfPicture.Threshold = Int32.Parse(xmlAction.Attribute("tolerance").Value);
                                actionIfPicture.IfFound = xmlAction.Attribute("ifTrueSequence").Value;
                                actionIfPicture.IfNotFound = xmlAction.Attribute("ifFalseSequence").Value;
                                newSequence.AddAction(actionIfPicture);
                                break;

                            case (int)Action.ActionType.Sequence:
                                ActionSequence actionSequence = new ActionSequence();
                                actionSequence.SequencePath = (string)xmlAction;
                                newSequence.AddAction(actionSequence);
                                break;

                            case (int)Action.ActionType.Click:
                                ActionClick actionClick = new ActionClick();
                                actionClick.X = Int32.Parse(xmlAction.Attribute("x").Value);
                                actionClick.Y = Int32.Parse(xmlAction.Attribute("y").Value);
                                actionClick.SelectedClick = xmlAction.Attribute("clic").Value;
                                newSequence.AddAction(actionClick);
                                break;

                            case (int)Action.ActionType.Loop:
                                ActionLoop actionLoop = new ActionLoop();
                                actionLoop.SequencePath = (string)xmlAction;
                                actionLoop.NumberOfRepetitions = Int32.Parse(xmlAction.Attribute("nbRepetition").Value);
                                newSequence.AddAction(actionLoop);
                                break;

                            case (int)Action.ActionType.ImageSearch:
                                ActionImageSearch actionImageSearch = new ActionImageSearch();
                                actionImageSearch.PictureName = (string)xmlAction;
                                actionImageSearch.X1 = Int32.Parse(xmlAction.Attribute("x1").Value);
                                actionImageSearch.X2 = Int32.Parse(xmlAction.Attribute("x2").Value);
                                actionImageSearch.Y1 = Int32.Parse(xmlAction.Attribute("y1").Value);
                                actionImageSearch.Y2 = Int32.Parse(xmlAction.Attribute("y2").Value);
                                actionImageSearch.Expiration = Int32.Parse(xmlAction.Attribute("expiration").Value);
                                actionImageSearch.Threshold = Int32.Parse(xmlAction.Attribute("tolerance").Value);
                                actionImageSearch.IfFound = xmlAction.Attribute("ifFound").Value;
                                actionImageSearch.IfNotFound = xmlAction.Attribute("ifNotFound").Value;
                                newSequence.AddAction(actionImageSearch);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                Log.Write(Log.ERROR, ex.ToString());
                MessageBox.Show("ERROR Loading sequence");
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
