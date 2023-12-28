using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tao_Bot_Maker
{
    public partial class MainApp : Form
    {
        //DLL Hotkey
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        //DLL Drawing
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        //DLL ImageSearch
        [DllImport(@"ImageSearchDLL.dll")]
        private static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)]string imagePath);


        DrawingRectangle zoneRecherche;

        Bot bot;

        public List<Action> actionList = new List<Action>();
        public String sequenceName;

        public MainApp()
        {
            SetProcessDPIAware();
            InitializeComponent();

            //Setup "Create action UI"
            setupComboBoxActions();

            loadSequencesList();

            zoneRecherche = new DrawingRectangle();
            zoneRecherche.Show();
            bot = new Bot(this, zoneRecherche);

            RegisterHotKey(this.Handle, 0, (int)KeyModifier.None, Keys.F5.GetHashCode());
            RegisterHotKey(this.Handle, 1, (int)KeyModifier.None, Keys.F6.GetHashCode());

            labelNotice.Text = "F1 : Angle haut gauche ou clic \r\n" +
                           "F2 : Angle bas droite \r\n" +
                           "F6 : Start Bot \r\n" +
                           "F7 : Stop Bot  \r\n" +
                           "Tolérance : 0-255; 0 = pixel perfect; (Recommandé 100-150)";
            movePanels();
            log("Programme initialisé");
        }

        //Initialisation des combobox
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void setupComboBoxActions()
        {
            ComboboxItem action_touche = new ComboboxItem();
            action_touche.Text = "Touche";
            action_touche.Value = (int)Action.ActionType.Touche;

            ComboboxItem action_attente = new ComboboxItem();
            action_attente.Text = "Attente";
            action_attente.Value = (int)Action.ActionType.Attente;

            ComboboxItem action_image = new ComboboxItem();
            action_image.Text = "Attendre Image";
            action_image.Value = (int)Action.ActionType.Image_Attente;

            ComboboxItem action_si_image = new ComboboxItem();
            action_si_image.Text = "Si image";
            action_si_image.Value = (int)Action.ActionType.Si_Image;

            ComboboxItem action_sequence = new ComboboxItem();
            action_sequence.Text = "Sequence";
            action_sequence.Value = (int)Action.ActionType.Sequence;

            ComboboxItem action_clic = new ComboboxItem();
            action_clic.Text = "Clic";
            action_clic.Value = (int)Action.ActionType.Clic;

            ComboboxItem action_boucle = new ComboboxItem();
            action_boucle.Text = "Boucle";
            action_boucle.Value = (int)Action.ActionType.Boucle;


            comboBoxActions.Items.Add(action_touche);
            comboBoxActions.Items.Add(action_attente);
            comboBoxActions.Items.Add(action_image);
            comboBoxActions.Items.Add(action_si_image);
            comboBoxActions.Items.Add(action_sequence);
            comboBoxActions.Items.Add(action_clic);
            comboBoxActions.Items.Add(action_boucle);

            comboBoxActions.SelectedIndex = 0;
        }
        private void comboBoxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelActionDelai.Visible = false;
            panelActionIfImage.Visible = false;
            panelActionImage.Visible = false;
            panelActionSequence.Visible = false;
            panelActionTouche.Visible = false;
            panelActionMouseClick.Visible = false;
            panelActionBoucle.Visible = false;

            switch ((comboBoxActions.SelectedItem as ComboboxItem).Value)
            {
                case (int)Action.ActionType.Touche:
                    panelActionTouche.Visible = true;
                    textBoxPanelActionTouche.Text = "";
                    break;

                case (int)Action.ActionType.Attente:
                    panelActionDelai.Visible = true;
                    textBoxPanelActionAttente.Text = "";
                    break;

                case (int)Action.ActionType.Image_Attente:
                    panelActionImage.Visible = true;
                    buttonPanelActionImage_ImagePath.Text = "Choisir une image";
                    pictureBoxPanelActionImage.Image = null;
                    textBoxPanelActionImage_tolerance.Text = "100";
                    textBoxPanelActionImage_waitTime.Text = "60";
                    textBoxPanelActionImage_x1.Text = "";
                    textBoxPanelActionImage_y1.Text = "";
                    textBoxPanelActionImage_x2.Text = "";
                    textBoxPanelActionImage_y2.Text = "";
                    comboBoxPanelActionImage_sequenceIfExpired.SelectedIndex = -1;
                    break;

                case (int)Action.ActionType.Si_Image:
                    panelActionIfImage.Visible = true;
                    buttonPanelActionIfImage_ImagePath.Text = "Choisir une image";
                    pictureBoxPanelActionIfImage.Image = null;
                    textBoxPanelActionIfImage_x1.Text = "";
                    textBoxPanelActionIfImage_y1.Text = "";
                    textBoxPanelActionIfImage_x2.Text = "";
                    textBoxPanelActionIfImage_y2.Text = "";
                    textBoxPanelActionIfImage_tolerance.Text = "100";
                    comboBoxPanelActionSequenceIfImageFound.SelectedIndex = -1;
                    comboBoxPanelActionSequenceIfImageNotFound.SelectedIndex = -1;
                    break;

                case (int)Action.ActionType.Sequence:
                    panelActionSequence.Visible = true;
                    comboBoxPanelActionSequence.SelectedIndex = -1;
                    break;

                case (int)Action.ActionType.Clic:
                    panelActionMouseClick.Visible = true;
                    textBoxPanelActionMouseClick_X.Text = "";
                    textBoxPanelActionMouseClick_Y.Text = "";
                    break;

                case (int)Action.ActionType.Boucle:
                    panelActionBoucle.Visible = true;
                    textBoxPanelBoucle_NbRepetition.Text = "";
                    comboBoxPanelActionBoucle_Sequence.SelectedIndex = -1;
                    break;
            }
        }

        private void comboBoxListSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListSequences.SelectedIndex != -1)
            {
                SequenceXmlManager sequenceXmlManager = new SequenceXmlManager();
                Sequence sequence = sequenceXmlManager.loadSequence(comboBoxListSequences.SelectedItem.ToString());

                actionList = sequence.getActions();
                sequenceName = comboBoxListSequences.SelectedItem.ToString();
                afficherActions();
            }
        }

        //Retourne une action suivant l'action choisie dans le menu déroulant
        private Action generateAction()
        {
            switch ((comboBoxActions.SelectedItem as ComboboxItem).Value)
            {
                case (int)Action.ActionType.Touche:
                    return (new Action_Touche
                    {
                        key = textBoxPanelActionTouche.Text
                    });

                case (int)Action.ActionType.Attente:
                    try
                    {
                        int x = Int32.Parse(textBoxPanelActionAttente.Text);
                        return(new Action_Attente
                        {
                            delai = x
                        });
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Erreur de saisie : un nombre doit être entré");
                    }
                    break;

                case (int)Action.ActionType.Image_Attente:
                    if (File.Exists("Images\\" + buttonPanelActionImage_ImagePath.Text))
                    {
                        return(new Action_Image
                        {
                            chemin = buttonPanelActionImage_ImagePath.Text,
                            x1 = Int32.Parse(textBoxPanelActionImage_x1.Text),
                            y1 = Int32.Parse(textBoxPanelActionImage_y1.Text),
                            x2 = Int32.Parse(textBoxPanelActionImage_x2.Text),
                            y2 = Int32.Parse(textBoxPanelActionImage_y2.Text),
                            tolerance = Int32.Parse(textBoxPanelActionImage_tolerance.Text),
                            waitTime = Int32.Parse(textBoxPanelActionImage_waitTime.Text),
                            sequenceIfExpired = comboBoxPanelActionImage_sequenceIfExpired.SelectedItem.ToString()
                        });
                    }
                    else
                    {
                        MessageBox.Show("Le chemin de l'image est incorrect");
                    }
                    break;


                case (int)Action.ActionType.Si_Image:
                    String sequencePath1 = "Sequences\\" + comboBoxPanelActionSequenceIfImageFound.SelectedItem.ToString();
                    String sequencePath2 = "Sequences\\" + comboBoxPanelActionSequenceIfImageNotFound.SelectedItem.ToString();

                    if (File.Exists("Images\\" + buttonPanelActionIfImage_ImagePath.Text))
                    {
                        if (File.Exists(sequencePath1))
                        {
                            if (File.Exists(sequencePath2))
                            {
                                return(new Action_Si_Image
                                {
                                    chemin = buttonPanelActionIfImage_ImagePath.Text,
                                    x1 = Int32.Parse(textBoxPanelActionIfImage_x1.Text),
                                    y1 = Int32.Parse(textBoxPanelActionIfImage_y1.Text),
                                    x2 = Int32.Parse(textBoxPanelActionIfImage_x2.Text),
                                    y2 = Int32.Parse(textBoxPanelActionIfImage_y2.Text),
                                    tolerance = Int32.Parse(textBoxPanelActionIfImage_tolerance.Text),
                                    ifTrueSequence = comboBoxPanelActionSequenceIfImageFound.SelectedItem.ToString(),
                                    ifFalseSequence = comboBoxPanelActionSequenceIfImageNotFound.SelectedItem.ToString()
                                });
                            }
                            else
                            {
                                MessageBox.Show("La séquence 2 est introuvable");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La séquence 1 est introuvable");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le chemin de l'image est incorrect");
                    }
                    break;

                case (int)Action.ActionType.Sequence:
                    String sequencePath = "Sequences\\" + comboBoxPanelActionSequence.SelectedItem.ToString();
                    if (File.Exists(sequencePath))
                    {
                        return(new Action_Sequence
                        {
                            chemin = comboBoxPanelActionSequence.SelectedItem.ToString()
                        });
                    }
                    else
                    {
                        MessageBox.Show("La séquence est introuvable");
                    }
                    break;

                case (int)Action.ActionType.Clic:
                    String clicSelected = "Left";
                    if (radioButtonPanelActionMouseClick_right.Checked)
                        clicSelected = "Right";

                        return (new Action_Clic
                        {
                            clic = clicSelected,
                            x = Int32.Parse(textBoxPanelActionMouseClick_X.Text),
                            y = Int32.Parse(textBoxPanelActionMouseClick_Y.Text)
                        });

                case (int)Action.ActionType.Boucle:
                    String sequencePathBoucle = "Sequences\\" + comboBoxPanelActionBoucle_Sequence.SelectedItem.ToString();
                    if (File.Exists(sequencePathBoucle))
                    {
                        return (new Action_Boucle
                        {
                            chemin = comboBoxPanelActionBoucle_Sequence.SelectedItem.ToString(),
                            nbRepetition = Int32.Parse(textBoxPanelBoucle_NbRepetition.Text)
                        }); ;
                    }
                    else
                    {
                        MessageBox.Show("La séquence est introuvable");
                    }
                    break;
            }
            return null;
        }
        private void buttonActionAjout_Click(object sender, EventArgs e)
        {
            actionList.Add(generateAction());
            log("Action Créé : " + actionList[actionList.Count - 1].ToString());
            afficherActions();
        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            int selectedActionIndex = listBoxActions.SelectedIndex;
            if(selectedActionIndex != -1)
            {
                actionList.RemoveAt(selectedActionIndex);
                actionList.Insert(selectedActionIndex, generateAction());
                log("Action Modifiée : " + actionList[selectedActionIndex].ToString());
            }
            afficherActions();
        }

        //IMAGE
        //Choix de l'image
        private void buttonActionImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Images\\";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    String imageToFind = openFileDialog.FileName;
                    buttonPanelActionImage_ImagePath.Text = openFileDialog.SafeFileName;
                    pictureBoxPanelActionImage.Image = Image.FromFile(imageToFind);
                }
            }
        }
        //Affichage de la zone de recherche
        private void buttonPanelActionImage_ShowZone_Click(object sender, EventArgs e)
        {
            zoneRecherche.clearRectangles();
            try
            {
                zoneRecherche.drawRectangle(
                    Int32.Parse(textBoxPanelActionImage_x1.Text),
                    Int32.Parse(textBoxPanelActionImage_y1.Text),
                    Int32.Parse(textBoxPanelActionImage_x2.Text) - Int32.Parse(textBoxPanelActionImage_x1.Text),
                    Int32.Parse(textBoxPanelActionImage_y2.Text) - Int32.Parse(textBoxPanelActionImage_y1.Text));
            }
            catch { }
            zoneRecherche.Refresh();
        }
        //Cherche l'image        
        private void buttonPanelActionImage_FindImage_Click(object sender, EventArgs e)
        {
            String imageFullPath = Directory.GetCurrentDirectory() + "\\Images\\" + buttonPanelActionImage_ImagePath.Text;
            if (File.Exists(imageFullPath))
            {                
                //Recherche de l'image
                System.Drawing.Image img = System.Drawing.Image.FromFile(imageFullPath);
                String[] results_if_image = UseImageSearchArea(imageFullPath, 
                            textBoxPanelActionImage_tolerance.Text,
                            Int32.Parse(textBoxPanelActionImage_x1.Text),
                            Int32.Parse(textBoxPanelActionImage_y1.Text),
                            Int32.Parse(textBoxPanelActionImage_x2.Text),
                            Int32.Parse(textBoxPanelActionImage_y2.Text)
                            );

                //Si on ne trouve pas l'image
                if (results_if_image == null)
                {
                    log("Image introuvable");
                }
                else
                {
                    log("Image trouvée X :" + results_if_image[1] + " Y : " + results_if_image[2]);

                    zoneRecherche.clearRectangles();
                    zoneRecherche.drawRectangle(Int32.Parse(results_if_image[1]) - 15, Int32.Parse(results_if_image[2]) - 15, img.Width + 30, img.Height + 30);
                    zoneRecherche.Refresh();
                }
            }
        }
        //Efface les zones
        private void buttonPanelActionImage_ClearDrawing_Click(object sender, EventArgs e)
        {
            clearZones();
        }


        //IF IMAGE
        //Choix de l'image
        private void buttonPanelActionIfImage_ImagePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Images\\";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    String imageToFind = openFileDialog.FileName;
                    buttonPanelActionIfImage_ImagePath.Text = openFileDialog.SafeFileName;
                    pictureBoxPanelActionImage.Image = Image.FromFile(imageToFind);
                }
            }
        }
        //Affichage de la zone de recherche
        private void buttonPanelActionIfImage_ShowZone_Click(object sender, EventArgs e)
        {
            zoneRecherche.clearRectangles();
            try
            {
                zoneRecherche.drawRectangle(
                Int32.Parse(textBoxPanelActionIfImage_x1.Text),
                Int32.Parse(textBoxPanelActionIfImage_y1.Text),
                Int32.Parse(textBoxPanelActionIfImage_x2.Text) - Int32.Parse(textBoxPanelActionIfImage_x1.Text),
                Int32.Parse(textBoxPanelActionIfImage_y2.Text) - Int32.Parse(textBoxPanelActionIfImage_y1.Text));
            }
            catch { }
            zoneRecherche.Refresh();
        }
        //Cherche l'image  
        private void buttonPanelActionIfImage_FindImage_Click(object sender, EventArgs e)
        {
            String imageFullPath = Directory.GetCurrentDirectory() + "\\Images\\" + buttonPanelActionIfImage_ImagePath.Text;
            if (File.Exists(imageFullPath))
            {
                //Recherche de l'image
                System.Drawing.Image img = System.Drawing.Image.FromFile(imageFullPath);
                String[] results_if_image = UseImageSearchArea(imageFullPath,
                            textBoxPanelActionImage_tolerance.Text,
                            Int32.Parse(textBoxPanelActionIfImage_x1.Text),
                            Int32.Parse(textBoxPanelActionIfImage_y1.Text),
                            Int32.Parse(textBoxPanelActionIfImage_x2.Text),
                            Int32.Parse(textBoxPanelActionIfImage_y2.Text)
                            );

                //Si on ne trouve pas l'image
                if (results_if_image == null)
                {
                    log("Image introuvable");
                }
                else
                {
                    log("Image trouvée X :" + results_if_image[1] + " Y : " + results_if_image[2]);

                    zoneRecherche.clearRectangles();
                    zoneRecherche.drawRectangle(Int32.Parse(results_if_image[1]) - 15, Int32.Parse(results_if_image[2]) - 15, img.Width + 30, img.Height + 30);
                    zoneRecherche.Refresh();
                }
            }

        }
        //Efface les zones
        private void buttonPanelActionIfImage_ClearDrawing_Click(object sender, EventArgs e)
        {
            clearZones();
        }


        //CLIC
        private void buttonPanelActionMouseClick_ShowZone_Click(object sender, EventArgs e)
        {
            zoneRecherche.clearRectangles();
            try
            {
                zoneRecherche.drawRectangle(
                    Int32.Parse(textBoxPanelActionMouseClick_X.Text) - 5,
                    Int32.Parse(textBoxPanelActionMouseClick_Y.Text) - 5,
                    (Int32.Parse(textBoxPanelActionMouseClick_X.Text) + 10) - (Int32.Parse(textBoxPanelActionMouseClick_X.Text)),
                    (Int32.Parse(textBoxPanelActionMouseClick_Y.Text) + 10) - (Int32.Parse(textBoxPanelActionMouseClick_Y.Text)));
            }
            catch { }
            zoneRecherche.Refresh();
        }


        //Traitement de la liste des actions
        private void afficherActions()
        {
            this.listBoxActions.Items.Clear();

            foreach (Action action in actionList)
            {
                String currentItem = action.ToString();
                this.listBoxActions.Items.Add(currentItem);
            }
        }
        private void listBoxActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                try
                {
                    actionList.RemoveAt(listBoxActions.SelectedIndex);
                    afficherActions();
                }
                catch (Exception) { }
            }
        }

        //Double click pour modifier une action
        private void listBoxActions_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxActions.SelectedIndex == -1) return;

            Action action = actionList[listBoxActions.SelectedIndex];
            String currentItem = "Type : " + Enum.GetName(typeof(Action.ActionType), action.type);
            switch (action.type)
            {
                case (int)Action.ActionType.Touche:
                    comboBoxActions.SelectedIndex = 0;
                    textBoxPanelActionTouche.Text = ((Action_Touche)action).key;
                    break;

                case (int)Action.ActionType.Attente:
                    comboBoxActions.SelectedIndex = 1;
                    textBoxPanelActionAttente.Text = ((Action_Attente)action).delai.ToString();
                    break;

                case (int)Action.ActionType.Image_Attente:
                    comboBoxActions.SelectedIndex = 2;
                    Action_Image action_image = (Action_Image)action;
                    textBoxPanelActionImage_tolerance.Text = action_image.tolerance.ToString();
                    textBoxPanelActionImage_waitTime.Text = action_image.waitTime.ToString();
                    textBoxPanelActionImage_x1.Text = action_image.x1.ToString();
                    textBoxPanelActionImage_x2.Text = action_image.x2.ToString();
                    textBoxPanelActionImage_y1.Text = action_image.y1.ToString();
                    textBoxPanelActionImage_y2.Text = action_image.y2.ToString();
                    buttonPanelActionImage_ImagePath.Text = action_image.chemin;
                    pictureBoxPanelActionImage.Image = Image.FromFile("Images\\" + action_image.chemin);
                    comboBoxPanelActionImage_sequenceIfExpired.SelectedItem = action_image.sequenceIfExpired;
                    break;

                case (int)Action.ActionType.Si_Image:
                    comboBoxActions.SelectedIndex = 3;
                    Action_Si_Image action_si_image = (Action_Si_Image)action;
                    textBoxPanelActionIfImage_tolerance.Text = action_si_image.tolerance.ToString();
                    textBoxPanelActionIfImage_x1.Text = action_si_image.x1.ToString();
                    textBoxPanelActionIfImage_x2.Text = action_si_image.x2.ToString();
                    textBoxPanelActionIfImage_y1.Text = action_si_image.y1.ToString();
                    textBoxPanelActionIfImage_y2.Text = action_si_image.y2.ToString();
                    buttonPanelActionIfImage_ImagePath.Text = action_si_image.chemin;
                    pictureBoxPanelActionIfImage.Image = Image.FromFile("Images\\" + action_si_image.chemin);
                    comboBoxPanelActionSequenceIfImageNotFound.SelectedItem = action_si_image.ifFalseSequence;
                    comboBoxPanelActionSequenceIfImageFound.SelectedItem = action_si_image.ifTrueSequence;
                    break;

                case (int)Action.ActionType.Sequence:
                    comboBoxActions.SelectedIndex = 4;
                    Action_Sequence action_sequence = (Action_Sequence)action;
                    comboBoxPanelActionSequence.SelectedItem = action_sequence.chemin;
                    break;

                case (int)Action.ActionType.Clic:
                    comboBoxActions.SelectedIndex = 5;
                    Action_Clic action_clic = (Action_Clic)action;
                    if (action_clic.clic == "Left")
                        radioButtonPanelActionMouseClick_left.Checked = true;
                    else
                        radioButtonPanelActionMouseClick_right.Checked = true;

                    textBoxPanelActionMouseClick_X.Text = action_clic.x.ToString();
                    textBoxPanelActionMouseClick_Y.Text = action_clic.y.ToString();
                    break;

                case (int)Action.ActionType.Boucle:
                    comboBoxActions.SelectedIndex = 6;
                    Action_Boucle action_boucle = (Action_Boucle)action;
                    comboBoxPanelActionBoucle_Sequence.SelectedItem = action_boucle.chemin;
                    textBoxPanelBoucle_NbRepetition.Text = action_boucle.nbRepetition.ToString();
                    break;
            }

        }

        private void listBoxActions_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listBoxActions.SelectedItem == null) return;
            if(e.Clicks == 1)
                this.listBoxActions.DoDragDrop(this.listBoxActions.SelectedItem, DragDropEffects.Move);
        }

        private void listBoxActions_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBoxActions_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBoxActions.PointToClient(new Point(e.X, e.Y));
            //Get release click position
            int index = this.listBoxActions.IndexFromPoint(point); 

            //Backup selected action
            Action actionTPM = this.actionList[this.listBoxActions.SelectedIndex];

            //Delete selected item
            this.actionList.RemoveAt(this.listBoxActions.SelectedIndex);

            //If release mouse where there is no item, move item to last position
            if(index == -1)
                this.actionList.Insert(listBoxActions.Items.Count -1, actionTPM);
            else
                this.actionList.Insert(index, actionTPM);

            afficherActions();
        }

        /*
         * 
            BOT
         *
        */
        private void buttonStartBot_Click(object sender, EventArgs e)
        {
            Sequence sequence = new Sequence();
            sequence.setActions(actionList);
            bot.botStart(sequence);
        }

        private void buttonStopBot_Click(object sender, EventArgs e)
        {
            zoneRecherche.clearRectangles();
            zoneRecherche.Refresh();
            bot.stopBot();
        }

        /*
         * 
            UTILS
         *
        */


        public void log(string logsentence, bool isthread = false, bool isTemporary = false)
        {
            DateTime dateTime = DateTime.Now;
            String log = dateTime.ToString() + " : " + logsentence;
            if (isthread == false)
            {
                listBoxLog.Items.Add(log);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
            else
            {
                if (isTemporary)
                {
                    MethodInvoker mainthread = delegate
                    {
                        listBoxLog.Items.RemoveAt(listBoxLog.Items.Count - 1);
                        listBoxLog.Items.Add(log);
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    };
                    listBoxLog.BeginInvoke(mainthread);
                }
                else
                {
                    MethodInvoker mainthread = delegate
                    {
                        listBoxLog.Items.Add(log);
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    };
                    listBoxLog.BeginInvoke(mainthread);
                }
            }
        }

        //Detects key pressed when focused
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                switch ((comboBoxActions.SelectedItem as ComboboxItem).Value)
                {
                    case (int)Action.ActionType.Image_Attente:
                        textBoxPanelActionImage_x1.Text = Cursor.Position.X.ToString();
                        textBoxPanelActionImage_y1.Text = Cursor.Position.Y.ToString();
                        buttonPanelActionImage_ShowZone_Click(null, null);
                        break;
                    case (int)Action.ActionType.Si_Image:
                        textBoxPanelActionIfImage_x1.Text = Cursor.Position.X.ToString();
                        textBoxPanelActionIfImage_y1.Text = Cursor.Position.Y.ToString();
                        buttonPanelActionIfImage_ShowZone_Click(null, null);
                        break;
                    case (int)Action.ActionType.Clic:
                        textBoxPanelActionMouseClick_X.Text = Cursor.Position.X.ToString();
                        textBoxPanelActionMouseClick_Y.Text = Cursor.Position.Y.ToString();
                        buttonPanelActionMouseClick_ShowZone_Click(null, null);
                        break;
                }
            }
            else if (keyData == (Keys.F2))
            {
                switch ((comboBoxActions.SelectedItem as ComboboxItem).Value)
                {
                    case (int)Action.ActionType.Image_Attente:
                        textBoxPanelActionImage_x2.Text = Cursor.Position.X.ToString();
                        textBoxPanelActionImage_y2.Text = Cursor.Position.Y.ToString();
                        buttonPanelActionImage_ShowZone_Click(null, null);
                        break;
                    case (int)Action.ActionType.Si_Image:
                        textBoxPanelActionIfImage_x2.Text = Cursor.Position.X.ToString();
                        textBoxPanelActionIfImage_y2.Text = Cursor.Position.Y.ToString();
                        buttonPanelActionIfImage_ShowZone_Click(null, null);
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Bitmap takeScreenShot(int x, int y, int width, int height)
        {
            //Create a new bitmap.
            var bmpScreenshot = new Bitmap(width,
                                           height,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(x,
                                        y,
                                        0,
                                        0,
                                        new Size(width, height),
                                        CopyPixelOperation.SourceCopy);

            return bmpScreenshot;
        }


        /*
         * 
            Save/Load Sequence
         *
        */

        private void loadSequencesList()
        {
            SequenceXmlManager sequenceXmlManager = new SequenceXmlManager();
            comboBoxListSequences.Items.Clear();
            comboBoxPanelActionImage_sequenceIfExpired.Items.Clear();
            comboBoxPanelActionSequenceIfImageFound.Items.Clear();
            comboBoxPanelActionSequenceIfImageNotFound.Items.Clear();
            comboBoxPanelActionSequence.Items.Clear();
            comboBoxPanelActionBoucle_Sequence.Items.Clear();

            comboBoxListSequences.Items.AddRange(sequenceXmlManager.sequencesList().ToArray());
            comboBoxPanelActionImage_sequenceIfExpired.Items.AddRange(sequenceXmlManager.sequencesList().ToArray());
            comboBoxPanelActionSequenceIfImageFound.Items.AddRange(sequenceXmlManager.sequencesList().ToArray());
            comboBoxPanelActionSequenceIfImageNotFound.Items.AddRange(sequenceXmlManager.sequencesList().ToArray());
            comboBoxPanelActionSequence.Items.AddRange(sequenceXmlManager.sequencesList().ToArray());
            comboBoxPanelActionBoucle_Sequence.Items.AddRange(sequenceXmlManager.sequencesList().ToArray());
            try
            {
                comboBoxListSequences.SelectedIndex = -1;
                comboBoxPanelActionImage_sequenceIfExpired.SelectedIndex = -1;
                comboBoxPanelActionSequenceIfImageFound.SelectedIndex = -1;
                comboBoxPanelActionSequenceIfImageNotFound.SelectedIndex = -1;
                comboBoxPanelActionSequence.SelectedIndex = -1;
                comboBoxPanelActionBoucle_Sequence.SelectedIndex = -1;
            }
            catch { }
        }

        private void buttonSaveSequence_Click(object sender, EventArgs e)
        {
            Sequence sequence = new Sequence();

            sequence.setActions(actionList);

            SequenceXmlManager sequenceXmlManager = new SequenceXmlManager();
            String sequenceName = sequenceXmlManager.saveSequence(sequence);
            log(sequenceName);
            loadSequencesList();
            comboBoxListSequences.SelectedItem = sequenceName;
        }

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            bot.stopBot();
            UnregisterHotKey(this.Handle, 0); //Start hotkey
            UnregisterHotKey(this.Handle, 1); //Stop hotkey
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if (key.ToString() == "F6")
                    buttonStartBot_Click(null, null);

                if (key.ToString() == "F7")
                    bot.stopBot();
            }
        }

        public static string[] UseImageSearchArea(string imgPath, string tolerance, int x1, int y1, int right, int bottom)
        {
            imgPath = "*" + tolerance + " " + imgPath;

            IntPtr result = ImageSearch(x1, y1, right, bottom, imgPath);
            string res = Marshal.PtrToStringAnsi(result);

            if (res[0] == '0') return null;

            string[] data = res.Split('|');

            int x; int y;
            int.TryParse(data[1], out x);
            int.TryParse(data[2], out y);

            return data;
        }

        public void clearZones()
        {
            zoneRecherche.clearRectangles();
            zoneRecherche.Refresh();
        }



        private void movePanels()
        {
            Point locationPanels = panelActionTouche.Location;
            panelActionDelai.Location = locationPanels;
            panelActionBoucle.Location = locationPanels;
            panelActionIfImage.Location = locationPanels;
            panelActionImage.Location = locationPanels;
            panelActionMouseClick.Location = locationPanels;
            panelActionSequence.Location = locationPanels;
        }

        private void buttonClearSequence_Click(object sender, EventArgs e)
        {
            loadSequencesList();
            actionList.Clear();
            afficherActions();
        }
    }
}
