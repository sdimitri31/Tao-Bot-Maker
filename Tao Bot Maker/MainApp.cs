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
using LogFramework;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public partial class MainApp : Form
    {
        //DLL Hotkey
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //DLL Drawing
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        //DLL ImageSearch
        [DllImport(@"ImageSearchDLL.dll")]
        private static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)] string imagePath);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public static String PICTURE_FOLDER_NAME = "Pictures";

        DrawingRectangle zoneRecherche;
        Bot bot;

        public List<Action> actionList = new List<Action>();
        public String sequenceName;

        public MainApp()
        {
            SetProcessDPIAware();
            InitializeComponent();

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

            Log.Write(Log.INFO, "Programme initialisé");
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

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            EditAction(listBoxActions.SelectedIndex);
        }

        private void EditAction(int selectedActionIndex)
        {
            if (selectedActionIndex != -1)
            {
                var formPopup = new ActionView(actionList[selectedActionIndex]);
                var result = formPopup.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    MessageBox.Show(formPopup.ReturnValueAction.ToString());

                    actionList.RemoveAt(selectedActionIndex);
                    actionList.Insert(selectedActionIndex, formPopup.ReturnValueAction);
                    log("Action Modifiée : " + actionList[actionList.Count - 1].ToString());
                    afficherActions();

                    Log.Write(Log.INFO, "Action View OK");
                }
                else
                {
                    Log.Write(Log.INFO, "Action View CANCEL");
                }
            }

        }

        //Efface les zones
        private void buttonPanelActionImage_ClearDrawing_Click(object sender, EventArgs e)
        {
            clearZones();
        }


        //Efface les zones
        private void buttonPanelActionIfImage_ClearDrawing_Click(object sender, EventArgs e)
        {
            clearZones();
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
            EditAction(listBoxActions.SelectedIndex);
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
                //switch ((comboBoxActions.SelectedItem as ComboboxItem).Value)
                //{
                //    case (int)Action.ActionType.PictureWait:
                //        textBoxPanelActionImage_x1.Text = Cursor.Position.X.ToString();
                //        textBoxPanelActionImage_y1.Text = Cursor.Position.Y.ToString();
                //        buttonPanelActionImage_ShowZone_Click(null, null);
                //        break;
                //    case (int)Action.ActionType.IfPicture:
                //        textBoxPanelActionIfImage_x1.Text = Cursor.Position.X.ToString();
                //        textBoxPanelActionIfImage_y1.Text = Cursor.Position.Y.ToString();
                //        buttonPanelActionIfImage_ShowZone_Click(null, null);
                //        break;
                //    case (int)Action.ActionType.Click:
                //        textBoxPanelActionMouseClick_X.Text = Cursor.Position.X.ToString();
                //        textBoxPanelActionMouseClick_Y.Text = Cursor.Position.Y.ToString();
                //        buttonPanelActionMouseClick_ShowZone_Click(null, null);
                //        break;
                //}
            }
            else if (keyData == (Keys.F2))
            {
                //switch ((comboBoxActions.SelectedItem as ComboboxItem).Value)
                //{
                //    case (int)Action.ActionType.PictureWait:
                //        textBoxPanelActionImage_x2.Text = Cursor.Position.X.ToString();
                //        textBoxPanelActionImage_y2.Text = Cursor.Position.Y.ToString();
                //        buttonPanelActionImage_ShowZone_Click(null, null);
                //        break;
                //    case (int)Action.ActionType.IfPicture:
                //        textBoxPanelActionIfImage_x2.Text = Cursor.Position.X.ToString();
                //        textBoxPanelActionIfImage_y2.Text = Cursor.Position.Y.ToString();
                //        buttonPanelActionIfImage_ShowZone_Click(null, null);
                //        break;
                //}
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

            comboBoxListSequences.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            try
            {
                comboBoxListSequences.SelectedIndex = -1;
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
            Log.Write(Log.INFO, "Closing App complete");
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

        public void clearZones()
        {
            zoneRecherche.clearRectangles();
            zoneRecherche.Refresh();
        }


        private void buttonClearSequence_Click(object sender, EventArgs e)
        {
            loadSequencesList();
            actionList.Clear();
            afficherActions();
        }

        private void button_Add_Action_Click(object sender, EventArgs e)
        {
            var formPopup = new ActionView();
            var result = formPopup.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                MessageBox.Show(formPopup.ReturnValueAction.ToString());

                actionList.Add(formPopup.ReturnValueAction);
                log("Action Créé : " + actionList[actionList.Count - 1].ToString());
                afficherActions();

                Log.Write(Log.INFO, "Action View OK");
            }
            else
            {
                Log.Write(Log.INFO, "Action View CANCEL");
            }
        }
    }
}
