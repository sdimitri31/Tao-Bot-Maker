using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    public class ImageAction : Action
    {
        public const string imagesFolderPath = "Images";
        public override ActionType Type { get; set; }
        public string ImageName { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int Threshold { get; set; }
        public int Expiration { get; set; }
        public Action ActionIfFound { get; set; }
        public Action ActionIfNotFound { get; set; }

        public ImageAction(
            string imageFilePath = "",
            int startX = 0,
            int startY = 0,
            int endX = 0,
            int endY = 0,
            int threshold = 0,
            int expiration = 0,
            Action actionIfFound = null,
            Action actionIfNotFound = null
            )
        {
            Type = ActionType.ImageAction;
            ImageName = imageFilePath;
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
            Threshold = threshold;
            Expiration = expiration;
            ActionIfFound = actionIfFound;
            ActionIfNotFound = actionIfNotFound;
        }

        public override async Task Execute(CancellationToken token)
        {
            string executeAction = string.Format(Resources.Strings.InfoMessageExecuteAction, this.ToString());
            Logger.Log(executeAction);

            // Validate the image path
            string imagePath = Path.Combine(imagesFolderPath, ImageName);
            if (!File.Exists(imagePath))
            {
                string errorMessage = string.Format(Resources.Strings.ErrorMessageFileNotFound, imagePath);
                throw new FileNotFoundException(errorMessage);
            }

            var stopwatch = Stopwatch.StartNew();
            var timer = new System.Timers.Timer(1000); // Timer to update logs every second

            timer.Elapsed += (sender, args) =>
            {
                string message = string.Format(Resources.Strings.InfoMessageSearchingImageFor, stopwatch.ElapsedMilliseconds);

                Logger.Log(message, TraceEventType.Information);
            };
            timer.Start();

            try
            {
                while (!token.IsCancellationRequested)
                {
                    var result = await Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();

                        // Recherche de l'image
                        var imageCoords = ImageSearchHelper.FindImage(imagePath, Threshold, StartX, StartY, EndX, EndY);

                        if (imageCoords != null)
                        {
                            int x = int.Parse(imageCoords[1]);
                            int y = int.Parse(imageCoords[2]);
                            var image = Image.FromFile(imagePath);
                            int centerX = x + (image.Width / 2);
                            int centerY = y + (image.Height / 2);

                            return new int[] { centerX, centerY };
                        }

                        return null;
                    }, token);

                    token.ThrowIfCancellationRequested();

                    if (SequenceController.GetIsPaused())
                    {
                        stopwatch.Stop();
                        timer.Stop();
                        await SequenceController.PauseIfRequested();
                        stopwatch.Start();
                        timer.Start();
                    }

                    if (result != null)
                    {
                        string coords = string.Format(Resources.Strings.CoordinatesFormat, result[0], result[1]);
                        string message = string.Format(Resources.Strings.InfoMessageImageFoundAtCoordsIn, coords, stopwatch.ElapsedMilliseconds);

                        Logger.Log(message, TraceEventType.Information);

                        stopwatch.Stop();
                        timer.Stop();
                        timer.Dispose();
                        if (ActionIfFound != null)
                        {
                            await SequenceController.PauseIfRequested();
                            await SequenceController.ExecuteAction(ActionIfFound, result[0], result[1], token);
                        }
                        break;
                    }

                    if (stopwatch.ElapsedMilliseconds >= Expiration)
                    {
                        string message = string.Format(Resources.Strings.InfoMessageImageSearchTimeOut, stopwatch.ElapsedMilliseconds);

                        Logger.Log(message, TraceEventType.Warning);

                        stopwatch.Stop();
                        timer.Stop();
                        timer.Dispose();
                        if (ActionIfNotFound != null)
                        {
                            await SequenceController.PauseIfRequested();
                            await ActionIfNotFound.Execute(token);
                        }
                        break;
                    }
                }
                token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException e)
            {
                stopwatch.Stop();
                timer.Stop();
                timer.Dispose();
                throw new OperationCanceledException(e.Message, e);
            }

        }

        public override async Task Execute(int x, int y, CancellationToken token)
        {
            await Execute(token);
        }

        public override string ToString()
        {
            string startCoords = string.Format(Resources.Strings.CoordinatesFormat, StartX, StartY);
            string endCoords = string.Format(Resources.Strings.CoordinatesFormat, EndX, EndY);

            return string.Format(Resources.Strings.ImageActionToString, ImageName, startCoords, endCoords, Expiration);
        }

        public override bool Validate(out string errorMessage)
        {
            errorMessage = "";

            // Validate image path
            string imagePath = Path.Combine(imagesFolderPath, ImageName);
            if (!File.Exists(imagePath))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageFileNotFound, imagePath);
                return false;
            }

            // Validate threshold
            if (Threshold < 0 || Threshold > 255)
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidIntervalFor, Resources.Strings.LabelThreshold, 0, 255);
                return false;
            }

            return true;
        }

        public override void Update(Action newAction)
        {
            base.Update(newAction);
            var newImageAction = newAction as ImageAction;
            if (newImageAction != null)
            {
                this.ImageName = newImageAction.ImageName;
                this.StartX = newImageAction.StartX;
                this.StartY = newImageAction.StartY;
                this.EndX = newImageAction.EndX;
                this.EndY = newImageAction.EndY;
                this.Threshold = newImageAction.Threshold;
                this.Expiration = newImageAction.Expiration;
                this.ActionIfFound = newImageAction.ActionIfFound;
                this.ActionIfNotFound = newImageAction.ActionIfNotFound;
            }
        }
    }
}
