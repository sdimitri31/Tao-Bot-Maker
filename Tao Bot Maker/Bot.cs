using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;

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
        
        ThreadStart ts;
        Thread backgroundThread;
        MainApp mainApp;
        DrawingRectangle drawingArea;

        public SequenceController sequenceController;
        public bool IsRunning { get; set; }

        public List<Action> actionList = new List<Action>();


        public Bot(MainApp main)
        {
            this.mainApp = main;
            this.IsRunning = false;
            this.drawingArea = new DrawingRectangle();
            
            //Setup Bot thread
            ts = new ThreadStart(StartBotting);

        }
        public void Log(string logsentence, bool isthread = false, bool isTemporary = false, int logLevel = LogFramework.Log.INFO)
        {
            mainApp.Log(logsentence, isthread, isTemporary, logLevel);
        }

        public void Start(SequenceController sequenceController)
        {
            IsRunning = true;
            this.sequenceController = sequenceController;
            drawingArea.Show();
            backgroundThread = new Thread(ts);
            backgroundThread.Start();
        }

        private void StartBotting()
        {
            Log("Début de la séquence de bot", true);

            //Execute la séquence chargée
            if (sequenceController != null)
            {
                DoSequence(sequenceController.Sequence, drawingArea);
            }

            Stop();

            Log("Fin de la séquence de bot", true);
        }

        public void Stop()
        {
            if (IsRunning)
            {
                Log("Arret du bot", true);
                IsRunning = false;
                backgroundThread.Abort();
                drawingArea.ClearRectangles();
                drawingArea.Refresh();
            }
        }

        private void DoSequence(Sequence sequence, DrawingRectangle zone)
        {
            zone.ClearRectangles();
            refreshRectangles();
            SequenceController sequenceController = new SequenceController();
            sequenceController.Sequence = sequence;

            //Execute la séquence
            foreach (Action action in sequenceController.GetActions())
            {
                switch (action.Type)
                {
                    case (int)Action.ActionType.Key:
                        DoActionKey(action);
                        break;

                    case (int)Action.ActionType.Wait:
                        DoActionWait(action);
                        break;

                    case (int)Action.ActionType.PictureWait:
                        DoActionPictureWait(action);
                        break;

                    case (int)Action.ActionType.IfPicture:
                        DoActionIfPicture(action);
                        break;

                    case (int)Action.ActionType.Sequence:
                        DoActionSequence(action);
                        break;

                    case (int)Action.ActionType.Click:
                        DoActionClick(action);
                        break;

                    case (int)Action.ActionType.Loop:
                        DoActionLoop(action);
                        break;
                }
            }
        }

        private void DoActionKey(Action action)
        {
            ActionKey actionKey = (ActionKey)action;
            Log("Action : Touche " + actionKey.Key, true, false, LogFramework.Log.TRACE);
            SendKeys.SendWait(PrepareForSendKeys(actionKey.Key));
        }
        private void DoActionWait(Action action)
        {
            ActionWait actionWait = (ActionWait)action;
            Log("Action : Attente " + actionWait.WaitTime, true, false, LogFramework.Log.TRACE);
            Thread.Sleep(actionWait.WaitTime);
        }
        private void DoActionPictureWait(Action action)
        {
            ActionPictureWait actionPictureWait = (ActionPictureWait)action;
            Log("Action : Attente d'image " + actionPictureWait.PictureName, true, false, LogFramework.Log.TRACE);

            //Get picture size to create borders when found
            String imageFullPath = MainApp.PICTURE_FOLDER_NAME + "\\" + actionPictureWait.PictureName;
            System.Drawing.Image imageWait = System.Drawing.Image.FromFile(imageFullPath);

            //Picture searching area
            drawingArea.ClearRectangles();
            drawingArea.DrawRectangle(actionPictureWait.X1, actionPictureWait.Y1, actionPictureWait.X2 - actionPictureWait.X1, actionPictureWait.Y2 - actionPictureWait.Y1);
            refreshRectangles();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Log("0s ", true, false, LogFramework.Log.TRACE);

            //Searching picture
            String[] results_wait_image = null;
            int secondsLastLoop = 0;
            while (results_wait_image == null)
            {
                //Searching picture in the area
                results_wait_image = ImageSearchController.FindImage(
                    imageFullPath, 
                    actionPictureWait.Threshold, 
                    actionPictureWait.X1, 
                    actionPictureWait.Y1, 
                    actionPictureWait.X2, 
                    actionPictureWait.Y2);
                Thread.Sleep(10);

                //Counting elapsed time searching for it
                int seconds = (int)stopwatch.Elapsed.TotalSeconds;

                //Updating log
                if (seconds != secondsLastLoop)
                {
                    Log(seconds + "s", true, true, LogFramework.Log.TRACE);
                    secondsLastLoop = seconds;
                }

                //If WaitTime elapsed then do an other sequence
                if (seconds >= actionPictureWait.WaitTime)
                {
                    stopwatch.Stop();
                    DoSequence(SequenceXmlManager.LoadSequence(actionPictureWait.SequenceIfExpired), drawingArea);
                    return;
                }
            }
            stopwatch.Stop();

            drawingArea.ClearRectangles();
            drawingArea.DrawRectangle(Int32.Parse(results_wait_image[1]) - 15, Int32.Parse(results_wait_image[2]) - 15, imageWait.Width + 30, imageWait.Height + 30);
            refreshRectangles();

            Log("Action : Image trouvée X :" + results_wait_image[1] + " Y : " + results_wait_image[2], true, false, LogFramework.Log.TRACE);

        }
        private void DoActionIfPicture(Action action)
        {
            ActionIfPicture actionIfPicture = (ActionIfPicture)action;
            Log("Action : si image " + actionIfPicture.PictureName, true, false, LogFramework.Log.TRACE);

            //Get picture size to create borders when found
            String imageFullPath = MainApp.PICTURE_FOLDER_NAME + "\\" + actionIfPicture.PictureName;
            System.Drawing.Image img = System.Drawing.Image.FromFile(imageFullPath);

            //Recherche de l'image
            String[] results_if_image = ImageSearchController.FindImage(
                imageFullPath,
                actionIfPicture.Threshold,
                actionIfPicture.X1,
                actionIfPicture.Y1,
                actionIfPicture.X2,
                actionIfPicture.Y2);

            //Si on ne trouve pas l'image
            if (results_if_image == null)
            {
                Log("Action : Image pas trouvée execution de la séquence : " + actionIfPicture.SequenceIfNotFound, true, false, LogFramework.Log.TRACE);
                DoSequence(SequenceXmlManager.LoadSequence(actionIfPicture.SequenceIfNotFound), drawingArea);
            }
            else
            {
                Log("Action : Image trouvée X :" + results_if_image[1] + " Y : " + results_if_image[2] + " Execution de la séquence : " + actionIfPicture.SequenceIfFound, true);

                drawingArea.ClearRectangles();
                drawingArea.DrawRectangle(Int32.Parse(results_if_image[1]) - 15, Int32.Parse(results_if_image[2]) - 15, img.Width + 30, img.Height + 30);
                refreshRectangles();
                DoSequence(SequenceXmlManager.LoadSequence(actionIfPicture.SequenceIfFound), drawingArea);
            }
        }
        private void DoActionSequence(Action action)
        {
            ActionSequence actionSequence = (ActionSequence)action;
            Log("Action : sequence " + actionSequence.SequencePath, true, false, LogFramework.Log.TRACE);
            DoSequence(SequenceXmlManager.LoadSequence(actionSequence.SequencePath), drawingArea);
        }
        private void DoActionClick(Action action)
        {
            ActionClick action_clic = (ActionClick)action;
            Log("Action : click " + action_clic, true, false, LogFramework.Log.TRACE);
            Cursor.Position = new Point(action_clic.X, action_clic.Y);
            DoMouseClick();
        }
        private void DoActionLoop(Action action)
        {
            ActionLoop actionLoop = (ActionLoop)action;
            int i = 1;
            while (i <= actionLoop.NumberOfRepetitions)
            {
                Log("Action : Boucle sequence " + actionLoop.SequencePath + " " + i + "/" + actionLoop.NumberOfRepetitions, true, false, LogFramework.Log.TRACE);
                DoSequence(SequenceXmlManager.LoadSequence(actionLoop.SequencePath), drawingArea);
                i++;
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
                drawingArea.Refresh();
            };
            drawingArea.BeginInvoke(mainthread);
        }
    }
}
