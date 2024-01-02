using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tao_Bot_Maker
{
    class Bot
    {
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
        
        //Mouse Control
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)System.Windows.Forms.Cursor.Position.X;
            uint Y = (uint)System.Windows.Forms.Cursor.Position.Y;
            mouse_event((int)MouseEventFlags.LeftDown, X, Y, 0, 0);
            Thread.Sleep(10);
            mouse_event((int)(int)MouseEventFlags.LeftUp, X, Y, 0, 0);
        }
        
        MainApp mainApp;

        ThreadStart ts;
        Thread backgroundThread;

        bool isRunning = false;

        public List<Action> actionList = new List<Action>();
        public String sequenceName = "";
        public Sequence sequence;

        DrawingRectangle zoneRecherche;

        public Bot(MainApp main, DrawingRectangle zoneRecherche)
        {
            mainApp = main;
            this.zoneRecherche = zoneRecherche;
            //Setup Bot thread
            ts = new ThreadStart(startBot);

        }
        public void log(string logsentence, bool isthread = false, bool isTemporary = false)
        {
            mainApp.log(logsentence, isthread, isTemporary);
        }

        public void setSequence(String sequenceName)
        {
            this.sequenceName = sequenceName;
        }


        public void botStart(Sequence sequence)
        {
            isRunning = true;
            backgroundThread = new Thread(ts);
            backgroundThread.Start();
            this.sequence = sequence;
        }


        private void startBot()
        {
            log("Début de la séquence de bot", true);
            //int i = 0;
            //while (isRunning)
            //{
                //i++;
                //log("Run n°" + i, true);

                //Execute la séquence chargée
                if (sequence != null)
                {
                    doSequence(sequence, zoneRecherche);
                }

                stopBot();

                /*
                if (actionList.Count == 0)
                {
                    isRunning = false;
                }*/
            //}

            log("Fin de la séquence de bot", true);
        }

        public void stopBot()
        {
            if (isRunning)
            {
                log("Arret du bot", true);
                isRunning = false;
                backgroundThread.Abort();
            }
        }

        private void doSequence(Sequence sequence, DrawingRectangle zone)
        {
            zone.clearRectangles();
            refreshRectangles();
            //Charge une séquence 
            SequenceXmlManager sequenceXmlManager = new SequenceXmlManager();
            //Sequence sequence = sequenceXmlManager.loadSequence(sequenceName);

            //Execute la séquence
            foreach (Action action in sequence.getActions())
            {
                switch (action.Type)
                {
                    case (int)Action.ActionType.Key:
                        ActionKey action_touche = (ActionKey)action;
                        log("Action : Touche " + action_touche.Key, true);
                        SendKeys.SendWait(PrepareForSendKeys(action_touche.Key));
                        break;

                    case (int)Action.ActionType.Wait:
                        ActionWait action_attente = (ActionWait)action;
                        log("Action : Attente " + action_attente.WaitTime, true);
                        Thread.Sleep(action_attente.WaitTime);
                        break;

                    case (int)Action.ActionType.PictureWait:

                        ActionPictureWait action_image = (ActionPictureWait)action;
                        log("Action : Attente d'image " + action_image.PictureName, true);

                        //Récupère les dimensions de l'image pour l'encadrement
                        String imageFullPath = MainApp.PICTURE_FOLDER_NAME + "\\" + action_image.PictureName;
                        System.Drawing.Image imageWait = System.Drawing.Image.FromFile(imageFullPath);

                        //Zone de recherche de l'image
                        zone.clearRectangles();
                        zone.DrawRectangle(action_image.X1, action_image.Y1, action_image.X2 - action_image.X1, action_image.Y2 - action_image.Y1);
                        refreshRectangles();

                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        log("0s ", true);
                        //Cherche l'image
                        String[] results_wait_image = null;
                        int secondsLastLoop = 0;
                        while (results_wait_image == null)
                        {
                            //Recherche l'image dans une zone précise
                            results_wait_image = UseImageSearchArea(imageFullPath, action_image.Threshold.ToString(), action_image.X1, action_image.Y1, action_image.X2, action_image.Y2);
                            Thread.Sleep(10);
                            
                            //Compte le temps passé dans la boucle
                            int seconds = (int)stopwatch.Elapsed.TotalSeconds;
                            
                            //Met à jour le log
                            if(seconds != secondsLastLoop)
                            {
                                log(seconds + "s", true, true);
                                secondsLastLoop = seconds;
                            }

                            //Si on passe trop de temps on quitte et lance une autre séquence
                            if (seconds >= action_image.WaitTime)
                            {
                                stopwatch.Stop();
                                doSequence(sequenceXmlManager.loadSequence(action_image.SequenceIfExpired), zone);
                                return;
                            }
                        }
                        stopwatch.Stop();

                        zone.clearRectangles();
                        zone.DrawRectangle(Int32.Parse(results_wait_image[1]) - 15, Int32.Parse(results_wait_image[2]) - 15, imageWait.Width + 30, imageWait.Height + 30);
                        refreshRectangles();

                        log("Action : Image trouvée X :" + results_wait_image[1] + " Y : " + results_wait_image[2], true);


                        break;

                    case (int)Action.ActionType.IfPicture:

                        ActionIfPicture action_si_image = (ActionIfPicture)action;
                        log("Action : si image " + action_si_image.PictureName, true);

                        //Récupère les dimensions de l'image pour l'encadrement
                        String siImageFullPath = Directory.GetCurrentDirectory() + "\\Images\\" + action_si_image.PictureName;
                        System.Drawing.Image img = System.Drawing.Image.FromFile(siImageFullPath);

                        //Recherche de l'image
                        String[] results_if_image = UseImageSearchArea(siImageFullPath, action_si_image.Threshold.ToString(), action_si_image.X1, action_si_image.Y1, action_si_image.X2, action_si_image.Y2);

                        //Si on ne trouve pas l'image
                        if (results_if_image == null)
                        {
                            log("Action : Image pas trouvée execution de la séquence : " + action_si_image.SequenceIfNotFound, true);
                            doSequence(sequenceXmlManager.loadSequence(action_si_image.SequenceIfNotFound), zone);
                        }
                        else
                        {
                            log("Action : Image trouvée X :" + results_if_image[1] + " Y : " + results_if_image[2] + " Execution de la séquence : " + action_si_image.SequenceIfFound, true);

                            zone.clearRectangles();
                            zone.DrawRectangle(Int32.Parse(results_if_image[1]) - 15, Int32.Parse(results_if_image[2]) - 15, img.Width + 30, img.Height + 30);
                            refreshRectangles();
                            doSequence(sequenceXmlManager.loadSequence(action_si_image.SequenceIfFound), zone);
                        }
                        break;

                    case (int)Action.ActionType.Sequence:
                        ActionSequence action_sequence = (ActionSequence)action;
                        log("Action : sequence " + action_sequence.SequencePath, true);
                        doSequence(sequenceXmlManager.loadSequence(action_sequence.SequencePath), zone);
                        break;

                    case (int)Action.ActionType.Click:
                        ActionClick action_clic = (ActionClick)action;
                        Cursor.Position = new Point(action_clic.X, action_clic.Y);
                        DoMouseClick();
                        break;

                    case (int)Action.ActionType.Loop:
                        ActionLoop action_boucle = (ActionLoop)action;
                        int i = 1;
                        while(i <= action_boucle.NumberOfRepetitions)
                        {
                            log("Action : Boucle sequence " + action_boucle.SequencePath + " " + i + "/" + action_boucle.NumberOfRepetitions, true);
                            doSequence(sequenceXmlManager.loadSequence(action_boucle.SequencePath), zone);
                            i++;
                        }
                        break;

                }
            }


        }


        string PrepareForSendKeys(string input)
        {
            var specialChars = "+^%~(){}";
            var c1 = "[BRACEOPEN]";
            var c2 = "[BRACECLOSE]";
            specialChars.ToList().ForEach(x =>
            {
                input = input.Replace(x.ToString(),
                    string.Format("{0}{1}{2}", c1, x.ToString(), c2));
            });
            input = input.Replace(c1, "{");
            input = input.Replace(c2, "}");
            return input;
        }

        private void refreshRectangles()
        {
            MethodInvoker mainthread = delegate
            {
                zoneRecherche.Refresh();
            };
            zoneRecherche.BeginInvoke(mainthread);
        }

        public static string[] UseImageSearch(string imgPath, string tolerance)
        {
            int right = Screen.PrimaryScreen.WorkingArea.Right;
            int bottom = Screen.PrimaryScreen.WorkingArea.Bottom;
            imgPath = "*" + tolerance + " " + imgPath;

            IntPtr result = ImageSearch(0, 0, right, bottom, imgPath);
            string res = Marshal.PtrToStringAnsi(result);

            if (res[0] == '0') return null;

            string[] data = res.Split('|');

            int x; int y;
            int.TryParse(data[1], out x);
            int.TryParse(data[2], out y);


            return data;
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



    }
}
