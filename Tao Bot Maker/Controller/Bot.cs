using LogFramework;
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
using Tao_Bot_Maker.Model;
using Tao_Bot_Maker.View;
using Log = Tao_Bot_Maker.Controller.Log;

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

        public void Start(SequenceController sequenceController)
        {
            if(IsRunning == false)
            {
                IsRunning = true;
                this.sequenceController = sequenceController;
                drawingArea.Show();
                mainApp.UpdateButtonStateBot();
                backgroundThread = new Thread(ts);
                backgroundThread.Start();
            }
        }

        private void StartBotting()
        {
            Log.Write("Début de la séquence de bot", mainApp.GetListBoxLog(), default, true);

            //Execute la séquence chargée
            if (sequenceController != null)
            {
                DoSequence(sequenceController.Sequence, drawingArea);
            }

            Stop();

            Log.Write("Fin de la séquence de bot", mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);
        }

        public void Stop()
        {
            if (IsRunning)
            {
                Log.Write("Arrêt du bot", mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);
                IsRunning = false;
                MethodInvoker mainthread = delegate
                {
                    mainApp.UpdateButtonStateBot();
                };
                mainApp.BeginInvoke(mainthread);
                backgroundThread.Abort();
                ClearRectangles();
            }
        }

        private void DoSequence(Sequence sequence, DrawingRectangle zone)
        {
            ClearRectangles();
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

                    case (int)Action.DeprecatedActionType.PictureWait:
                        DoActionPictureWait(action);
                        break;

                    case (int)Action.DeprecatedActionType.IfPicture:
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

                    case (int)Action.ActionType.ImageSearch:
                        DoActionImageSearch(action);
                        break;
                }
            }
        }

        private void DoActionKey(Action action)
        {
            ActionKey actionKey = (ActionKey)action;
            Log.Write("Action : Touche " + actionKey.Key, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);
            SendKeys.SendWait(PrepareForSendKeys(actionKey.Key));
        }
        private void DoActionWait(Action action)
        {
            ActionWait actionWait = (ActionWait)action;
            Log.Write("Action : Attente " + actionWait.WaitTime, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);
            Thread.Sleep(actionWait.WaitTime);
        }
        
        /// <summary>
        /// Deprecated Type might crash
        /// </summary>
        /// <param name="action"></param>
        private void DoActionPictureWait(Action action)
        {
            ActionPictureWait actionPictureWait = (ActionPictureWait)action;
            Log.Write("Action : Attente d'image " + actionPictureWait.PictureName, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);

            //Get picture size to create borders when found
            String imageFullPath = Constants.PICTURE_FOLDER_NAME + "\\" + actionPictureWait.PictureName;
            System.Drawing.Image imageWait = System.Drawing.Image.FromFile(imageFullPath);

            //Picture searching area
            ClearRectangles();
            int[] coordsHeightWidth = Utils.GetCoordsHeightWidth(actionPictureWait.X1, actionPictureWait.Y1, actionPictureWait.X2, actionPictureWait.Y2);
            DrawRectangle(coordsHeightWidth[0] - 5, coordsHeightWidth[1] - 5, coordsHeightWidth[2] + 5, coordsHeightWidth[3] + 5);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Log.Write("0s ", mainApp.GetListBoxLog(), LogFramework.Log.TRACE, true);

            //Searching picture
            String[] results_wait_image = null;
            int secondsLastLoop = 0;
            while (results_wait_image == null)
            {
                int[] xy = Utils.GetTopLeftCoords(actionPictureWait.X1, actionPictureWait.Y1, actionPictureWait.X2, actionPictureWait.Y2);
                int[] xy2 = Utils.GetBottomRightCoords(actionPictureWait.X1, actionPictureWait.Y1, actionPictureWait.X2, actionPictureWait.Y2);
                
                //Searching picture in the area
                results_wait_image = ImageSearchController.FindImage(
                    imageFullPath, 
                    actionPictureWait.Threshold,
                    xy[0],
                    xy[1],
                    xy2[0],
                    xy2[1]);
                Thread.Sleep(10);

                //Counting elapsed time searching for it
                int seconds = (int)stopwatch.Elapsed.TotalSeconds;

                //Updating log
                if (seconds != secondsLastLoop)
                {
                    Log.Write(seconds + "s", mainApp.GetListBoxLog(), LogFramework.Log.INFO, true, true);
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

            ClearRectangles();
            DrawRectangle(Int32.Parse(results_wait_image[1]) - 15, Int32.Parse(results_wait_image[2]) - 15, imageWait.Width + 30, imageWait.Height + 30);


            Log.Write("Action : Image trouvée X :" + results_wait_image[1] + " Y : " + results_wait_image[2], 
                mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);

        }

        /// <summary>
        /// Deprecated Type might crash
        /// </summary>
        /// <param name="action"></param>
        private void DoActionIfPicture(Action action)
        {
            ActionIfPicture actionIfPicture = (ActionIfPicture)action;
            Log.Write("Action : si image " + actionIfPicture.PictureName, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);

            //Get picture size to create borders when found
            String imageFullPath = Constants.PICTURE_FOLDER_NAME + "\\" + actionIfPicture.PictureName;
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
                Log.Write("Action : Image pas trouvée execution de la séquence : " + actionIfPicture.IfNotFound, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);
                DoSequence(SequenceXmlManager.LoadSequence(actionIfPicture.IfNotFound), drawingArea);
            }
            else
            {
                Log.Write("Action : Image trouvée X :" + results_if_image[1] + " Y : " + results_if_image[2] + " Execution de la séquence : " + actionIfPicture.IfFound, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);

                ClearRectangles();
                DrawRectangle(Int32.Parse(results_if_image[1]) - 15, Int32.Parse(results_if_image[2]) - 15, img.Width + 30, img.Height + 30);

                DoSequence(SequenceXmlManager.LoadSequence(actionIfPicture.IfFound), drawingArea);
            }
        }
        
        private void DoActionSequence(Action action)
        {
            ActionSequence actionSequence = (ActionSequence)action;

            string text = "";
            text += Properties.strings.action + " : " + Properties.strings.ActionName_Sequence;
            text += " | " + Properties.strings.action_Member_Sequence + " : " + actionSequence.SequenceName;
            Log.Write(text, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);

            DoSequence(SequenceXmlManager.LoadSequence(actionSequence.SequenceName), drawingArea);
        }
        
        private void DoActionClick(Action action)
        {
            ActionClick actionMouse = (ActionClick)action;
            Log.Write("Action : click " + actionMouse, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);

            //Get selected click
            int mouseDown, mouseUp;
            switch (actionMouse.SelectedClick)
            {
                case "left":
                    mouseDown = (int)MouseEventFlags.LeftDown;
                    mouseUp = (int)MouseEventFlags.LeftUp;
                    break;

                case "right":
                    mouseDown = (int)MouseEventFlags.RightDown;
                    mouseUp = (int)MouseEventFlags.RightUp;
                    break;

                case "middle":
                    mouseDown = (int)MouseEventFlags.MiddleDown;
                    mouseUp = (int)MouseEventFlags.MiddleUp;
                    break;

                default:
                    mouseDown = (int)MouseEventFlags.LeftDown;
                    mouseUp = (int)MouseEventFlags.LeftUp;
                    break;
            }
                
            //Move cursor to XY
            Cursor.Position = new Point(actionMouse.X1, actionMouse.Y1);
            Log.Write("Cursor.Position " + Cursor.Position.ToString(), LogFramework.Log.TRACE);

            //Click Down on selected click
            uint X = (uint)System.Windows.Forms.Cursor.Position.X;
            uint Y = (uint)System.Windows.Forms.Cursor.Position.Y;
            mouse_event(mouseDown, X, Y, 0, 0);

            //Check if IsDrag
            if (actionMouse.IsDrag)
            {
                //Move cursor to XY2 according to DragSpeed

                int gapX = (actionMouse.X2 - actionMouse.X1);
                int gapY = (actionMouse.Y2 - actionMouse.Y1);
                int smallerGap = Math.Min(Math.Abs(gapX), Math.Abs(gapY));
                int nbStep;

                Log.Write("gapX " + gapX, LogFramework.Log.TRACE);
                Log.Write("gapY " + gapY, LogFramework.Log.TRACE);
                Log.Write("smallerGap " + smallerGap, LogFramework.Log.TRACE);

                if (smallerGap > 50 )
                {
                    decimal calc = (smallerGap / 10);
                    nbStep = (int)Math.Floor(calc);
                }
                else
                {
                    nbStep = smallerGap;
                    if (nbStep == 0)
                        nbStep = 1;
                }

                int stepX = (int)Math.Floor((double)(gapX / nbStep));
                int stepY = (int)Math.Floor((double)(gapY / nbStep));
                int resteX = (int)Math.Floor((double)(gapX % nbStep));
                int resteY = (int)Math.Floor((double)(gapY % nbStep));

                Log.Write("nbStep " + nbStep, LogFramework.Log.TRACE);
                Log.Write("stepX " + stepX, LogFramework.Log.TRACE);
                Log.Write("resteX " + resteX, LogFramework.Log.TRACE); 
                Log.Write("stepY " + stepY, LogFramework.Log.TRACE);
                Log.Write("resteY " + resteY, LogFramework.Log.TRACE);

                int cursorPosX = actionMouse.X1;
                int cursorPosY = actionMouse.Y1;

                for (int i = 0; i < nbStep; i++)
                {
                    cursorPosX += stepX;
                    cursorPosY += stepY;
                    Cursor.Position = new Point(cursorPosX, cursorPosY);
                    mouse_event((int)MouseEventFlags.Move, 1, 0, 0, 0);

                    Log.Write("Cursor.Position " + Cursor.Position.ToString() + " i " + i, LogFramework.Log.TRACE);

                    Thread.Sleep((int)(30 / Math.Abs(actionMouse.DragSpeed)));
                }

                cursorPosX += resteX;
                cursorPosY += resteY;
                Cursor.Position = new Point(cursorPosX, cursorPosY);
                mouse_event((int)MouseEventFlags.Move, 1, 0, 0, 0);

                Log.Write("Cursor.Position " + Cursor.Position.ToString(), LogFramework.Log.TRACE);

            }
            else if (actionMouse.IsDoubleClick)
            {
                Thread.Sleep(20);

                //Release Click
                mouse_event(mouseUp, X, Y, 0, 0);
                Thread.Sleep(20);

                //Double click
                mouse_event(mouseDown, X, Y, 0, 0);
                Thread.Sleep(20);
            }
            else
            {
                Thread.Sleep(10);
            }

            //Release Click
            X = (uint)System.Windows.Forms.Cursor.Position.X;
            Y = (uint)System.Windows.Forms.Cursor.Position.Y;
            mouse_event(mouseUp, X, Y, 0, 0);
        }

        private void DoActionLoop(Action action)
        {
            ActionLoop actionLoop = (ActionLoop)action;
            int i = 1;
            while ((i <= actionLoop.RepeatNumber) || (actionLoop.RepeatNumber == -1))
            {
                string text = "";
                text +=         Properties.strings.action + " : " + Properties.strings.ActionName_Loop;
                text += " | " + Properties.strings.action_Member_Sequence + " : " + actionLoop.SequenceName;
                text += " | " + Properties.strings.action_Member_RepeatNumber + " : " ;
                text += i + " / " + actionLoop.RepeatNumber;
                Log.Write(text, mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);

                DoSequence(SequenceXmlManager.LoadSequence(actionLoop.SequenceName), drawingArea);
                i++;
            }
        }

        private void DoActionImageSearch(Action action)
        {
            ActionImageSearch actionImageSearch = (ActionImageSearch)action;
            Log.Write("Action : Image Search " + actionImageSearch.PictureName, mainApp.GetListBoxLog(), LogFramework.Log.TRACE, true);

            //Get picture size to create borders when found
            String imageFullPath = Constants.PICTURE_FOLDER_NAME + "\\" + actionImageSearch.PictureName;
            System.Drawing.Image imageWait = System.Drawing.Image.FromFile(imageFullPath);

            //Picture searching area with offset to prevent drawing over the target
            ClearRectangles(); 
            int[] coordsHeightWidth = Utils.GetCoordsHeightWidth(actionImageSearch.X1, actionImageSearch.Y1, actionImageSearch.X2, actionImageSearch.Y2);
            DrawRectangle(coordsHeightWidth[0] - 5, coordsHeightWidth[1] - 5, coordsHeightWidth[2] + 5, coordsHeightWidth[3] + 5);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Log.Write("0s ", mainApp.GetListBoxLog(), LogFramework.Log.TRACE, true);

            //Searching picture
            String[] results_wait_image = null;
            int secondsLastLoop = 0;
            while (results_wait_image == null)
            {
                int[] xy = Utils.GetTopLeftCoords(actionImageSearch.X1, actionImageSearch.Y1, actionImageSearch.X2, actionImageSearch.Y2);
                int[] xy2 = Utils.GetBottomRightCoords(actionImageSearch.X1, actionImageSearch.Y1, actionImageSearch.X2, actionImageSearch.Y2);

                //Searching picture in the area
                results_wait_image = ImageSearchController.FindImage(
                    imageFullPath,
                    actionImageSearch.Threshold,
                    xy[0],
                    xy[1],
                    xy2[0],
                    xy2[1]);
                Thread.Sleep(10);

                //Counting elapsed time searching for it
                int seconds = (int)stopwatch.Elapsed.TotalSeconds;

                //Updating log
                if (seconds != secondsLastLoop)
                {
                    Log.Write(seconds + "s", mainApp.GetListBoxLog(), LogFramework.Log.INFO, true, true);
                    secondsLastLoop = seconds;
                }

                //Waits forever
                if(actionImageSearch.Expiration == -1)
                {
                    continue;
                }

                //If Expiration elapsed then do an other sequence
                if ((seconds >= actionImageSearch.Expiration) && (results_wait_image == null))
                {
                    stopwatch.Stop();
                    DoSequence(SequenceXmlManager.LoadSequence(actionImageSearch.IfNotFound), drawingArea);
                    return;
                }
            }
            Log.Write("Action : Image trouvée X :" + results_wait_image[1] + " Y : " + results_wait_image[2], mainApp.GetListBoxLog(), LogFramework.Log.INFO, true);

            stopwatch.Stop();

            ClearRectangles();
            DrawRectangle(Int32.Parse(results_wait_image[1]) - 15, Int32.Parse(results_wait_image[2]) - 15, imageWait.Width + 30, imageWait.Height + 30);

            DoSequence(SequenceXmlManager.LoadSequence(actionImageSearch.IfFound), drawingArea);


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

        private void DrawRectangle(int x1 ,int y1, int width, int height, KnownColor color = Constants.COLOR_LABEL_XY)
        {
            MethodInvoker mainthread = delegate
            {
                drawingArea.DrawRectangle(x1 - 5, y1 - 5, width + 5, height + 5, color);
                drawingArea.Refresh();
            };
            drawingArea.BeginInvoke(mainthread);
        }

        private void ClearRectangles()
        {
            MethodInvoker mainthread = delegate
            {
                drawingArea.ClearRectangles();
            };
            drawingArea.BeginInvoke(mainthread);
        }

    }
}
