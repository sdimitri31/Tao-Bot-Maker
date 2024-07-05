using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    [JsonConverter(typeof(ActionConverter))]
    public class ImageAction : Action
    {
        public const string imagesFolderPath = "Images";

        [JsonConverter(typeof(StringEnumConverter))]
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

        public override async Task Execute(CancellationToken token, int x, int y)
        {
            string executeAction = string.Format(Resources.Strings.InfoMessageExecuteAction, this.ToString());
            Logger.Log(executeAction);

            if (!Validate(out string errorMessage))
            {
                throw new Exception(errorMessage);
            }

            var stopwatch = Stopwatch.StartNew();
            var timer = new System.Timers.Timer(1000); // Timer to update logs every second

            timer.Elapsed += (sender, args) =>
            {
                if (token.IsCancellationRequested)
                {
                    stopwatch.Stop();
                    timer.Stop();
                    timer.Dispose();
                    return;
                }

                if (!SequenceController.GetIsPaused())
                {
                    string message = string.Format(Resources.Strings.InfoMessageSearchingImageFor, stopwatch.ElapsedMilliseconds);

                    Logger.Log(message, TraceEventType.Information);
                }
            };
            timer.Start();

            try
            {
                string imagePath = Path.Combine(imagesFolderPath, ImageName);
                while (!token.IsCancellationRequested)
                {
                    var result = await Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();

                        // Recherche de l'image
                        var imageCoords = ImageSearchHelper.FindImage(imagePath, Threshold, StartX, StartY, EndX, EndY);

                        if (imageCoords != null)
                        {
                            return CoordinatesHelper.GetCenterCoords(imageCoords[0], imageCoords[1], imageCoords[2], imageCoords[3]);
                        }

                        return null;
                    }, token);

                    token.ThrowIfCancellationRequested();

                    if (result != null)
                    {
                        stopwatch.Stop();
                        timer.Stop();
                        timer.Dispose();

                        await SequenceController.PauseIfRequested();

                        string coords = string.Format(Resources.Strings.CoordinatesFormat, result[0], result[1]);
                        string message = string.Format(Resources.Strings.InfoMessageImageFoundAtCoordsIn, coords, stopwatch.ElapsedMilliseconds);

                        Logger.Log(message, TraceEventType.Information);

                        if (ActionIfFound != null)
                        {
                            await SequenceController.ExecuteAction(ActionIfFound, token, result[0], result[1]);
                        }
                        break;
                    }

                    if (stopwatch.ElapsedMilliseconds >= Expiration)
                    {
                        stopwatch.Stop();
                        timer.Stop();
                        timer.Dispose();

                        await SequenceController.PauseIfRequested();

                        string message = string.Format(Resources.Strings.InfoMessageImageSearchTimeOut, stopwatch.ElapsedMilliseconds);

                        Logger.Log(message, TraceEventType.Warning);

                        if (ActionIfNotFound != null)
                        {
                            await SequenceController.ExecuteAction(ActionIfNotFound, token);
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

        public override string ToString()
        {
            string startCoords = string.Format(Resources.Strings.CoordinatesFormat, StartX, StartY);
            string endCoords = string.Format(Resources.Strings.CoordinatesFormat, EndX, EndY);

            return string.Format(Resources.Strings.ImageActionToString, ImageName, startCoords, endCoords, Expiration);
        }

        public override bool Validate(out string errorMessage)
        {
            if (!ValidateActionType(Type, out errorMessage))
                return false;

            if (!ValidateImageName(ImageName, out errorMessage))
                return false;

            if (!ValidateImageFile(ImageName, out errorMessage))
                return false;

            if (!ValidateCoordinate(StartX, out errorMessage))
                return false;

            if (!ValidateCoordinate(StartY, out errorMessage))
                return false;

            if (!ValidateCoordinate(EndX, out errorMessage))
                return false;

            if (!ValidateCoordinate(EndY, out errorMessage))
                return false;

            if (!ValidateThreshold(Threshold, out errorMessage))
                return false;

            if (!ValidateExpiration(Expiration, out errorMessage))
                return false;

            if (!ValidateAction(ActionIfFound, out errorMessage))
                return false;

            if (!ValidateAction(ActionIfNotFound, out errorMessage))
                return false;

            return true;
        }

        public static bool ValidateActionType(ActionType actionType, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (actionType != ActionType.ImageAction)
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidValueFor, Resources.Strings.ActionType);
                return false;
            }

            return true;
        }

        public static bool ValidateImageName(string imageName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(imageName))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidValueFor, Resources.Strings.ImageActionImageName);
                return false;
            }

            return true;
        }

        public static bool ValidateImageFile(string imageName, out string errorMessage)
        {
            errorMessage = string.Empty;

            string imagePath = Path.Combine(imagesFolderPath, imageName);
            if (!File.Exists(imagePath))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageFileNotFound, imagePath);
                return false;
            }

            return true;
        }

        public static bool ValidateCoordinate(int coordToCheck, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (coordToCheck < -999999 || coordToCheck > 999999)
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidIntervalFor, Resources.Strings.Coordinates, -999999, 999999);
                return false;
            }

            return true;
        }

        public static bool ValidateThreshold(int threshold, out string errorMessage)
        {
            errorMessage = string.Empty;

            if ((threshold < 0) || (threshold > 255))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidIntervalFor, Resources.Strings.ImageActionThreshold, 0, 255);
                return false;
            }

            return true;
        }

        public static bool ValidateExpiration(int expiration, out string errorMessage)
        {
            errorMessage = string.Empty;

            if ((expiration < 0) || (expiration > 999999))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidIntervalFor, Resources.Strings.ImageActionExpiration, 0, 999999);
                return false;
            }

            return true;
        }

        public static bool ValidateAction(Action action, out string errorMessage)
        {
            if (action == null)
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidValueFor, Resources.Strings.Action);
                return false;
            }

            if (!action.Validate(out string errorMsg))
            {
                errorMessage = errorMsg;
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

    }
}
