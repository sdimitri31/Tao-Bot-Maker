﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
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
            Log.Write("Début de la séquence de bot", mainApp.GetListBoxLog(), Log.INFO, true);

            //Execute la séquence chargée
            if (sequenceController != null)
            {
                DoSequence(sequenceController.Sequence, drawingArea);
            }

            Stop();

            Log.Write("Fin de la séquence de bot", mainApp.GetListBoxLog(), Log.INFO, true);
        }

        public void Stop()
        {
            if (IsRunning)
            {
                Log.Write("Arrêt du bot", mainApp.GetListBoxLog(), Log.INFO, true);
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
                    case (int)Action.ActionType.Text:
                        DoActionText(action);
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

                    case (int)Action.DeprecatedActionType.Sequence:
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

                    case (int)Action.ActionType.Key:
                        DoActionKey(action);
                        break;
                }
            }
        }

        private void DoActionText(Action action)
        {
            ActionText actionText = (ActionText)action;
            Log.Write(actionText.ToString(), mainApp.GetListBoxLog(), Log.INFO, true);
            SendKeys.SendWait(PrepareForSendKeys(actionText.Text));
        }

        private void DoActionWait(Action action)
        {
            ActionWait actionWait = (ActionWait)action;

            Log.Write(actionWait.ToString(), mainApp.GetListBoxLog(), Log.INFO, true);

            int waitTime = actionWait.WaitTime;

            if (actionWait.IsRandomInterval)
            {
                var random = new Random();
                waitTime = random.Next(actionWait.WaitTime, actionWait.WaitTimeMax);
                string message = Properties.strings.label_WaitTime + " : " + waitTime + "ms";
                Log.Write(message, mainApp.GetListBoxLog(), Log.INFO, true);
            }

            Thread.Sleep(waitTime);
        }
        
        /// <summary>
        /// Deprecated Type might crash
        /// </summary>
        /// <param name="action"></param>
        private void DoActionPictureWait(Action action)
        {
            ActionPictureWait actionPictureWait = (ActionPictureWait)action;
            Log.Write("Action : Attente d'image " + actionPictureWait.PictureName, mainApp.GetListBoxLog(), Log.INFO, true);

            //Get picture size to create borders when found
            string imageFullPath = Constants.PICTURE_FOLDER_NAME + "\\" + actionPictureWait.PictureName;
            System.Drawing.Image imageWait = System.Drawing.Image.FromFile(imageFullPath);

            //Picture searching area
            ClearRectangles();
            int[] coordsHeightWidth = Utils.GetCoordsHeightWidth(actionPictureWait.X1, actionPictureWait.Y1, actionPictureWait.X2, actionPictureWait.Y2);
            DrawRectangle(coordsHeightWidth[0] - 5, coordsHeightWidth[1] - 5, coordsHeightWidth[2] + 5, coordsHeightWidth[3] + 5);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Log.Write("0s ", mainApp.GetListBoxLog(), Log.TRACE, true);

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
                    Log.Write(seconds + "s", mainApp.GetListBoxLog(), Log.INFO, true, true);
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
                mainApp.GetListBoxLog(), Log.INFO, true);

        }

        /// <summary>
        /// Deprecated Type might crash
        /// </summary>
        /// <param name="action"></param>
        private void DoActionIfPicture(Action action)
        {
            ActionIfPicture actionIfPicture = (ActionIfPicture)action;
            Log.Write("Action : si image " + actionIfPicture.PictureName, mainApp.GetListBoxLog(), Log.INFO, true);

            //Get picture size to create borders when found
            string imageFullPath = Constants.PICTURE_FOLDER_NAME + "\\" + actionIfPicture.PictureName;
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
                Log.Write("Action : Image pas trouvée execution de la séquence : " + actionIfPicture.IfNotFound, mainApp.GetListBoxLog(), Log.INFO, true);
                DoSequence(SequenceXmlManager.LoadSequence(actionIfPicture.IfNotFound), drawingArea);
            }
            else
            {
                Log.Write("Action : Image trouvée X :" + results_if_image[1] + " Y : " + results_if_image[2] + " Execution de la séquence : " + actionIfPicture.IfFound, mainApp.GetListBoxLog(), Log.INFO, true);

                ClearRectangles();
                DrawRectangle(Int32.Parse(results_if_image[1]) - 15, Int32.Parse(results_if_image[2]) - 15, img.Width + 30, img.Height + 30);

                DoSequence(SequenceXmlManager.LoadSequence(actionIfPicture.IfFound), drawingArea);
            }
        }

        /// <summary>
        /// Deprecated Type might crash
        /// </summary>
        /// <param name="action"></param>
        private void DoActionSequence(Action action)
        {
            ActionSequence actionSequence = (ActionSequence)action;

            string text = "";
            text += Properties.strings.action + " : " + Properties.strings.ActionName_Sequence;
            text += " | " + Properties.strings.action_Member_Sequence + " : " + actionSequence.SequenceName;
            Log.Write(text, mainApp.GetListBoxLog(), Log.INFO, true);

            DoSequence(SequenceXmlManager.LoadSequence(actionSequence.SequenceName), drawingArea);
        }
        
        private void DoActionClick(Action action)
        {
            ActionClick actionMouse = (ActionClick)action;
            Log.Write(actionMouse.ToString(), mainApp.GetListBoxLog(), Log.INFO, true);

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

                case "move":
                    mouseDown = (int)MouseEventFlags.Move;
                    mouseUp = (int)MouseEventFlags.Move;
                    break;

                default:
                    mouseDown = (int)MouseEventFlags.LeftDown;
                    mouseUp = (int)MouseEventFlags.LeftUp;
                    break;
            }
                
            //Move cursor to XY if "IsCurrentPosClick == false"
            if(!actionMouse.IsCurrentPosClick)
                Cursor.Position = new Point(actionMouse.X1, actionMouse.Y1);
            else
            {
                actionMouse.X1 = Cursor.Position.X;
                actionMouse.Y1 = Cursor.Position.Y;
            }
            Log.Write("Start Cursor.Position : " + Cursor.Position.ToString(), Log.TRACE);

            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;

            //Click down if selectectedClick is not "move"
            if (!(actionMouse.SelectedClick == "move"))
            {
                //Click Down on selected click
                mouse_event(mouseDown, X, Y, 0, 0);
            }

            //Check if IsDrag
            if (actionMouse.IsDrag)
            {
                double deltaX = (actionMouse.X2 - actionMouse.X1);
                double deltaY = (actionMouse.Y2 - actionMouse.Y1);

                //avoid dividing by 0
                if (deltaX != 0)
                {
                    //Calculate function y = ax + b
                    //Step 1 : determine "a"
                    double a = (deltaY / deltaX);

                    //Step 2 : determine "b"
                    // b = y - (a * x)
                    double b = actionMouse.Y1 - (a * actionMouse.X1);

                    Log.Write("y = " + a + " * x + " + b, Log.TRACE);

                    //Loop through delta X
                    for (int i = 1; i < 11; i++)
                    {
                        //Calculate y 
                        double x = (actionMouse.X1 + (i * (deltaX /10)));
                        double y = a * x + b;
                        x = Math.Round(x);
                        y = Math.Round(y);

                        Log.Write("x : " + x + " y : " + y , Log.TRACE);

                        //Move mouse to coords (x - 1, y)
                        // - 1 to compensate + 1 in move event 
                        Cursor.Position = new Point(Convert.ToInt32(x) - 1, Convert.ToInt32(y));
                        mouse_event((int)MouseEventFlags.Move, 1, 0, 0, 0);

                        //Wait depending on dragspeed
                        Thread.Sleep((int)(50 / Math.Abs(actionMouse.DragSpeed)));
                    }
                }
                //Moving on Y axis
                else
                {
                    //Loop through delta Y
                    for (int i = 1; i < 11; i++)
                    {
                        //Calculate y 
                        double x = actionMouse.X1;
                        double y = actionMouse.Y1 + (i * (deltaY / 10));
                        x = Math.Round(x);
                        y = Math.Round(y);

                        //Move mouse to coords (x - 1, y)
                        // - 1 to compensate + 1 in move event 
                        Cursor.Position = new Point(Convert.ToInt32(x) - 1, Convert.ToInt32(y));
                        mouse_event((int)MouseEventFlags.Move, 1, 0, 0, 0);

                        //Wait depending on dragspeed
                        Thread.Sleep((int)(50 / Math.Abs(actionMouse.DragSpeed)));
                    }
                }
                Log.Write("End Cursor.Position " + Cursor.Position.ToString(), Log.TRACE);

            }
            //Double click if "IsDoubleClick == true" and "IsDrag == false"
            else if ((actionMouse.IsDoubleClick) && (!actionMouse.IsDrag))
            {
                Thread.Sleep(20);

                //Release Click
                X = (uint)Cursor.Position.X;
                Y = (uint)Cursor.Position.Y;
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

            //Click up if selectectedClick is not "move"
            if (!(actionMouse.SelectedClick == "move"))
            {
                //Release Click
                X = (uint)Cursor.Position.X;
                Y = (uint)Cursor.Position.Y;
                mouse_event(mouseUp, X, Y, 0, 0);
            }
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
                Log.Write(text, mainApp.GetListBoxLog(), Log.INFO, true);

                DoSequence(SequenceXmlManager.LoadSequence(actionLoop.SequenceName), drawingArea);
                i++;
            }
        }

        private void DoActionImageSearch(Action action)
        {
            ActionImageSearch actionImageSearch = (ActionImageSearch)action;
            Log.Write("Action : Image Search " + actionImageSearch.PictureName, mainApp.GetListBoxLog(), Log.TRACE, true);

            //Get picture size to create borders when found
            string imageFullPath = Constants.PICTURE_FOLDER_NAME + "\\" + actionImageSearch.PictureName;
            System.Drawing.Image imageWait = System.Drawing.Image.FromFile(imageFullPath);

            //Picture searching area with offset to prevent drawing over the target
            ClearRectangles(); 
            int[] coordsHeightWidth = Utils.GetCoordsHeightWidth(actionImageSearch.X1, actionImageSearch.Y1, actionImageSearch.X2, actionImageSearch.Y2);
            DrawRectangle(coordsHeightWidth[0] - 5, coordsHeightWidth[1] - 5, coordsHeightWidth[2] + 5, coordsHeightWidth[3] + 5);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Log.Write("0s ", mainApp.GetListBoxLog(), Log.TRACE, true);

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
                    Log.Write(seconds + "s", mainApp.GetListBoxLog(), Log.INFO, true, true);
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
            Log.Write("Action : Image trouvée X :" + results_wait_image[1] + " Y : " + results_wait_image[2], mainApp.GetListBoxLog(), Log.INFO, true);

            stopwatch.Stop();

            ClearRectangles();
            DrawRectangle(Int32.Parse(results_wait_image[1]) - 15, Int32.Parse(results_wait_image[2]) - 15, imageWait.Width + 30, imageWait.Height + 30);

            DoSequence(SequenceXmlManager.LoadSequence(actionImageSearch.IfFound), drawingArea);


        }

        private void DoActionKey(Action action)
        {
            ActionKey actionKey = (ActionKey)action;
            Log.Write(actionKey.ToString(), mainApp.GetListBoxLog(), Log.INFO, true);

            string prepare = PrepareForSendKeys(actionKey.Key);

            SendKeys.SendWait(prepare);
        }

        string PrepareForSendKeys(Keys input)
        {
            //Delete spaces
            string preparedString = input.ToString().Replace(" ", "");

            //Split key from modifiers
            string[] keysSplited = preparedString.Split(',');

            //Prepare modifiers
            string preparedModifiers = string.Empty;

            for (int i = 1; i < keysSplited.Length; i++)
            {
                keysSplited[i] = keysSplited[i].Replace("Control", "^");
                keysSplited[i] = keysSplited[i].Replace("Alt", "%");
                keysSplited[i] = keysSplited[i].Replace("Shift", "+");
                preparedModifiers += keysSplited[i];
            }

            //If no modifiers
            if (preparedModifiers == string.Empty)
            {
                preparedString = Utils.KeysToString(input);
            }
            else
            {
                Enum.TryParse(keysSplited[0], out Keys key);
                preparedString = Utils.KeysToString(key);

                preparedString = preparedModifiers + "(" + preparedString + ")";
            }

            Log.Write("Prepared String : " + preparedString, Log.TRACE);

            return preparedString;
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
            input = input.Replace("\r\n", "\r");
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
