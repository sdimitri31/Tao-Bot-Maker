using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Tao_Bot_Maker
{
    class SequenceXmlManager
    {
        public static String SEQUENCES_FOLDER_NAME = "Sequences";

        public SequenceXmlManager(){
        }

        public static void SaveSequence(String sequenceName, SequenceController sequenceController)
        {
            System.IO.Directory.CreateDirectory(SEQUENCES_FOLDER_NAME);
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

                    case (int)Action.ActionType.PictureWait:
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

                    case (int)Action.ActionType.IfPicture:
                        ActionIfPicture actionIfPicture = (ActionIfPicture)action;
                        doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", actionIfPicture.Type),
                                                                                        new XAttribute("tolerance", actionIfPicture.Threshold),
                                                                                        new XAttribute("x1", actionIfPicture.X1),
                                                                                        new XAttribute("y1", actionIfPicture.Y1),
                                                                                        new XAttribute("x2", actionIfPicture.X2),
                                                                                        new XAttribute("y2", actionIfPicture.Y2),
                                                                                        new XAttribute("ifTrueSequence", actionIfPicture.SequenceIfFound),
                                                                                        new XAttribute("ifFalseSequence", actionIfPicture.SequenceIfNotFound),
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

                }
            }

            //Enregistre le document
            doc.Save(SEQUENCES_FOLDER_NAME + "\\" + fileName);

        }

        public static Sequence LoadSequence(String sequenceName)
        {
            SequenceController newSequence = new SequenceController
            {
                SequenceName = sequenceName
            };

            var doc = XDocument.Load(SEQUENCES_FOLDER_NAME + @"\" + sequenceName + @".xml");


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

                        case (int)Action.ActionType.PictureWait:
                            ActionPictureWait actionPictureWait = new ActionPictureWait();
                            actionPictureWait.PictureName     = (string)xmlAction;
                            actionPictureWait.X1         = Int32.Parse(xmlAction.Attribute("x1").Value);
                            actionPictureWait.X2         = Int32.Parse(xmlAction.Attribute("x2").Value);
                            actionPictureWait.Y1         = Int32.Parse(xmlAction.Attribute("y1").Value);
                            actionPictureWait.Y2         = Int32.Parse(xmlAction.Attribute("y2").Value);
                            actionPictureWait.Threshold  = Int32.Parse(xmlAction.Attribute("tolerance").Value);
                            actionPictureWait.WaitTime   = Int32.Parse(xmlAction.Attribute("waitTime").Value);
                            actionPictureWait.SequenceIfExpired = xmlAction.Attribute("sequenceIfExpired").Value;
                            newSequence.AddAction(actionPictureWait);
                            break;

                        case (int)Action.ActionType.IfPicture:
                            ActionIfPicture actionIfPicture = new ActionIfPicture();
                            actionIfPicture.PictureName  = (string)xmlAction;
                            actionIfPicture.X1      = Int32.Parse(xmlAction.Attribute("x1").Value);
                            actionIfPicture.X2      = Int32.Parse(xmlAction.Attribute("x2").Value);
                            actionIfPicture.Y1      = Int32.Parse(xmlAction.Attribute("y1").Value);
                            actionIfPicture.Y2      = Int32.Parse(xmlAction.Attribute("y2").Value);
                            actionIfPicture.Threshold       = Int32.Parse(xmlAction.Attribute("tolerance").Value);
                            actionIfPicture.SequenceIfFound  = xmlAction.Attribute("ifTrueSequence").Value;
                            actionIfPicture.SequenceIfNotFound = xmlAction.Attribute("ifFalseSequence").Value;
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
                    }

                }     
            }

            return newSequence.Sequence;

        }

        public static List<String> SequencesList()
        {
            System.IO.Directory.CreateDirectory(SEQUENCES_FOLDER_NAME);
            DirectoryInfo directory = new DirectoryInfo(SEQUENCES_FOLDER_NAME);
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
            if(File.Exists(SEQUENCES_FOLDER_NAME + "\\" + name + ".xml")) return true;
            return false;
        }

    }
}
