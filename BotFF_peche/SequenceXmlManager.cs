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
        public SequenceXmlManager(){
            }

        public String saveSequence(Sequence sequenceToSave)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\Sequences\\";
            saveFileDialog1.Filter = "Xml |*.xml";
            saveFileDialog1.Title = "Sauvegarder une séquence";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                string fileName = saveFileDialog1.FileName;

                //Crée la base du XML
                XDocument doc = new XDocument(new XElement("Sequence"));

                //Ajoute toutes les actions
                foreach(Action action in sequenceToSave.getActions())
                {
                    switch (action.type)
                    {
                        case (int)Action.ActionType.Touche:
                            Action_Touche action_touche = (Action_Touche)action;
                            doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", action_touche.type), action_touche.key));
                            break;

                        case (int)Action.ActionType.Attente:
                            Action_Attente action_attente = (Action_Attente)action;
                            doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", action_attente.type), action_attente.delai));
                            break;

                        case (int)Action.ActionType.Image_Attente:
                            Action_Image action_image = (Action_Image)action;
                            doc.XPathSelectElement("Sequence").Add(new XElement("Action",   new XAttribute("type", action_image.type),
                                                                                            new XAttribute("tolerance", action_image.tolerance),
                                                                                            new XAttribute("x1", action_image.x1),
                                                                                            new XAttribute("y1", action_image.y1),
                                                                                            new XAttribute("x2", action_image.x2),
                                                                                            new XAttribute("y2", action_image.y2),
                                                                                            new XAttribute("sequenceIfExpired", action_image.sequenceIfExpired),
                                                                                            new XAttribute("waitTime", action_image.waitTime),
                                                                                            action_image.chemin));
                            break;

                        case (int)Action.ActionType.Si_Image:
                            Action_Si_Image action_si_image = (Action_Si_Image)action;
                            doc.XPathSelectElement("Sequence").Add(new XElement("Action",   new XAttribute("type", action_si_image.type),
                                                                                            new XAttribute("tolerance", action_si_image.tolerance),
                                                                                            new XAttribute("x1", action_si_image.x1),
                                                                                            new XAttribute("y1", action_si_image.y1),
                                                                                            new XAttribute("x2", action_si_image.x2),
                                                                                            new XAttribute("y2", action_si_image.y2),
                                                                                            new XAttribute("ifTrueSequence", action_si_image.ifTrueSequence),
                                                                                            new XAttribute("ifFalseSequence", action_si_image.ifFalseSequence), 
                                                                                            action_si_image.chemin));
                            break;

                        case (int)Action.ActionType.Sequence:
                            Action_Sequence action_sequence = (Action_Sequence)action;
                            doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", action_sequence.type), action_sequence.chemin));
                            break;

                        case (int)Action.ActionType.Clic:
                            Action_Clic action_clic = (Action_Clic)action;
                            doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", action_clic.type),
                                                                                          new XAttribute("clic", action_clic.clic),
                                                                                          new XAttribute("x", action_clic.x),
                                                                                          new XAttribute("y", action_clic.y)));
                            break;

                        case (int)Action.ActionType.Boucle:
                            Action_Boucle action_boucle = (Action_Boucle)action;
                            doc.XPathSelectElement("Sequence").Add(new XElement("Action", new XAttribute("type", action_boucle.type),
                                                                                          new XAttribute("nbRepetition", action_boucle.nbRepetition), 
                                                                                          action_boucle.chemin));
                            break;

                    }
                }

                //Enregistre le document
                doc.Save(fileName);
                return Path.GetFileName(fileName);
            }
            return "";
        }

        public Sequence loadSequence(String sequenceName)
        {
            Sequence newSequence = new Sequence();

            var doc = XDocument.Load("Sequences\\" + sequenceName);


            foreach (XElement xe in doc.Descendants("Sequence"))
            {               
                foreach (XElement xmlAction in xe.Elements("Action"))
                {

                    int actionType = Int32.Parse(xmlAction.Attribute("type").Value);
                    switch (actionType)
                    {
                        case (int)Action.ActionType.Touche:
                            Action_Touche action_touche = new Action_Touche();
                            action_touche.key = (string)xmlAction;
                            newSequence.addAction(action_touche);
                            break;

                        case (int)Action.ActionType.Attente:
                            Action_Attente action_attente = new Action_Attente();
                            action_attente.delai = (int)xmlAction;
                            newSequence.addAction(action_attente);
                            break;

                        case (int)Action.ActionType.Image_Attente:
                            Action_Image action_image = new Action_Image();
                            action_image.chemin     = (string)xmlAction;
                            action_image.x1         = Int32.Parse(xmlAction.Attribute("x1").Value);
                            action_image.x2         = Int32.Parse(xmlAction.Attribute("x2").Value);
                            action_image.y1         = Int32.Parse(xmlAction.Attribute("y1").Value);
                            action_image.y2         = Int32.Parse(xmlAction.Attribute("y2").Value);
                            action_image.tolerance  = Int32.Parse(xmlAction.Attribute("tolerance").Value);
                            action_image.waitTime   = Int32.Parse(xmlAction.Attribute("waitTime").Value);
                            action_image.sequenceIfExpired = xmlAction.Attribute("sequenceIfExpired").Value;
                            newSequence.addAction(action_image);
                            break;

                        case (int)Action.ActionType.Si_Image:
                            Action_Si_Image action_si_image = new Action_Si_Image();
                            action_si_image.chemin  = (string)xmlAction;
                            action_si_image.x1      = Int32.Parse(xmlAction.Attribute("x1").Value);
                            action_si_image.x2      = Int32.Parse(xmlAction.Attribute("x2").Value);
                            action_si_image.y1      = Int32.Parse(xmlAction.Attribute("y1").Value);
                            action_si_image.y2      = Int32.Parse(xmlAction.Attribute("y2").Value);
                            action_si_image.tolerance       = Int32.Parse(xmlAction.Attribute("tolerance").Value);
                            action_si_image.ifTrueSequence  = xmlAction.Attribute("ifTrueSequence").Value;
                            action_si_image.ifFalseSequence = xmlAction.Attribute("ifFalseSequence").Value;
                            newSequence.addAction(action_si_image);
                            break;

                        case (int)Action.ActionType.Sequence:
                            Action_Sequence action_sequence = new Action_Sequence();
                            action_sequence.chemin = (string)xmlAction;
                            newSequence.addAction(action_sequence);
                            break;

                        case (int)Action.ActionType.Clic:
                            Action_Clic action_clic = new Action_Clic();
                            action_clic.x = Int32.Parse(xmlAction.Attribute("x").Value);
                            action_clic.y = Int32.Parse(xmlAction.Attribute("y").Value);
                            action_clic.clic = xmlAction.Attribute("clic").Value;
                            newSequence.addAction(action_clic);
                            break;

                        case (int)Action.ActionType.Boucle:
                            Action_Boucle action_boucle = new Action_Boucle();
                            action_boucle.chemin = (string)xmlAction;
                            action_boucle.nbRepetition = Int32.Parse(xmlAction.Attribute("nbRepetition").Value);
                            newSequence.addAction(action_boucle);
                            break;
                    }

                }     
            }

            return newSequence;

        }

        public List<String> sequencesList()
        {
            System.IO.Directory.CreateDirectory(@"Sequences");
            DirectoryInfo directory = new DirectoryInfo(@"Sequences");
            FileInfo[] files = directory.GetFiles("*.xml"); //Getting xml files

            List<String> sequencesList = new List<String>();

            foreach (FileInfo file in files)
            {
                sequencesList.Add(file.Name);
            }
            return sequencesList;
        }

    }
}
