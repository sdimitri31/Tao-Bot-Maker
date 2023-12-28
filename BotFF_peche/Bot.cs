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
                switch (action.type)
                {
                    case (int)Action.ActionType.Touche:
                        Action_Touche action_touche = (Action_Touche)action;
                        log("Action : Touche " + action_touche.key, true);
                        SendKeys.SendWait(PrepareForSendKeys(action_touche.key));
                        break;

                    case (int)Action.ActionType.Attente:
                        Action_Attente action_attente = (Action_Attente)action;
                        log("Action : Attente " + action_attente.delai, true);
                        Thread.Sleep(action_attente.delai);
                        break;

                    case (int)Action.ActionType.Image_Attente:

                        Action_Image action_image = (Action_Image)action;
                        log("Action : Attente d'image " + action_image.chemin, true);

                        //Récupère les dimensions de l'image pour l'encadrement
                        String imageFullPath = Directory.GetCurrentDirectory() + "\\Images\\" + action_image.chemin;
                        System.Drawing.Image imageWait = System.Drawing.Image.FromFile(imageFullPath);

                        //Zone de recherche de l'image
                        zone.clearRectangles();
                        zone.drawRectangle(action_image.x1, action_image.y1, action_image.x2 - action_image.x1, action_image.y2 - action_image.y1);
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
                            results_wait_image = UseImageSearchArea(imageFullPath, action_image.tolerance.ToString(), action_image.x1, action_image.y1, action_image.x2, action_image.y2);
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
                            if (seconds >= action_image.waitTime)
                            {
                                stopwatch.Stop();
                                doSequence(sequenceXmlManager.loadSequence(action_image.sequenceIfExpired), zone);
                                return;
                            }
                        }
                        stopwatch.Stop();

                        zone.clearRectangles();
                        zone.drawRectangle(Int32.Parse(results_wait_image[1]) - 15, Int32.Parse(results_wait_image[2]) - 15, imageWait.Width + 30, imageWait.Height + 30);
                        refreshRectangles();

                        log("Action : Image trouvée X :" + results_wait_image[1] + " Y : " + results_wait_image[2], true);


                        break;

                    case (int)Action.ActionType.Si_Image:

                        Action_Si_Image action_si_image = (Action_Si_Image)action;
                        log("Action : si image " + action_si_image.chemin, true);

                        //Récupère les dimensions de l'image pour l'encadrement
                        String siImageFullPath = Directory.GetCurrentDirectory() + "\\Images\\" + action_si_image.chemin;
                        System.Drawing.Image img = System.Drawing.Image.FromFile(siImageFullPath);

                        //Recherche de l'image
                        String[] results_if_image = UseImageSearchArea(siImageFullPath, action_si_image.tolerance.ToString(), action_si_image.x1, action_si_image.y1, action_si_image.x2, action_si_image.y2);

                        //Si on ne trouve pas l'image
                        if (results_if_image == null)
                        {
                            log("Action : Image pas trouvée execution de la séquence : " + action_si_image.ifFalseSequence, true);
                            doSequence(sequenceXmlManager.loadSequence(action_si_image.ifFalseSequence), zone);
                        }
                        else
                        {
                            log("Action : Image trouvée X :" + results_if_image[1] + " Y : " + results_if_image[2] + " Execution de la séquence : " + action_si_image.ifTrueSequence, true);

                            zone.clearRectangles();
                            zone.drawRectangle(Int32.Parse(results_if_image[1]) - 15, Int32.Parse(results_if_image[2]) - 15, img.Width + 30, img.Height + 30);
                            refreshRectangles();
                            doSequence(sequenceXmlManager.loadSequence(action_si_image.ifTrueSequence), zone);
                        }
                        break;

                    case (int)Action.ActionType.Sequence:
                        Action_Sequence action_sequence = (Action_Sequence)action;
                        log("Action : sequence " + action_sequence.chemin, true);
                        doSequence(sequenceXmlManager.loadSequence(action_sequence.chemin), zone);
                        break;

                    case (int)Action.ActionType.Clic:
                        Action_Clic action_clic = (Action_Clic)action;
                        Cursor.Position = new Point(action_clic.x, action_clic.y);
                        DoMouseClick();
                        break;

                    case (int)Action.ActionType.Boucle:
                        Action_Boucle action_boucle = (Action_Boucle)action;
                        int i = 1;
                        while(i <= action_boucle.nbRepetition)
                        {
                            log("Action : Boucle sequence " + action_boucle.chemin + " " + i + "/" + action_boucle.nbRepetition, true);
                            doSequence(sequenceXmlManager.loadSequence(action_boucle.chemin), zone);
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
