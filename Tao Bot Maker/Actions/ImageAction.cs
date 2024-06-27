using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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

        public override async Task Execute()
        {
            // Validate the image path
            string imagePath = Path.Combine(imagesFolderPath, ImageName);
            if (!File.Exists(imagePath))
            {
                Logger.Log($"Error - Image not found at path: {imagePath}.", TraceEventType.Error);
                throw new FileNotFoundException($"Image not found at path: {imagePath}");
            }

            // Create a CancellationTokenSource for the expiration
            using (var cts = new CancellationTokenSource(Expiration))
            {
                var stopwatch = Stopwatch.StartNew();
                var timer = new System.Timers.Timer(1000); // Timer to update logs every second

                timer.Elapsed += (sender, args) =>
                {
                    Logger.Log($"Searching for image... {stopwatch.ElapsedMilliseconds} ms elapsed.", TraceEventType.Information);
                };
                timer.Start();

                try
                {
                    // Search for the image on the screen
                    var result = await Task.Run(() => ImageSearchHelper.FindImageCenter(imagePath, Threshold, StartX, StartY, EndX, EndY, cts.Token), cts.Token);

                    stopwatch.Stop();
                    timer.Stop();
                    timer.Dispose();

                    // If the image is found
                    if (result != null)
                    {
                        Logger.Log($"Image found at coordinates: ({result[0]}, {result[1]}) after {stopwatch.ElapsedMilliseconds} ms.", TraceEventType.Information);
                        if (ActionIfFound != null)
                        {
                            await ActionIfFound.Execute(result[0], result[1]); // Pass the found coordinates
                        }
                    }
                    else // If the image is not found
                    {
                        Logger.Log($"Image not found after {stopwatch.ElapsedMilliseconds} ms.", TraceEventType.Warning);
                        if (ActionIfNotFound != null)
                        {
                            await ActionIfNotFound.Execute();
                        }
                    }
                }
                catch (TaskCanceledException)
                {
                    stopwatch.Stop();
                    timer.Stop();
                    timer.Dispose();
                    Logger.Log($"Image search timed out after {stopwatch.ElapsedMilliseconds} ms.", TraceEventType.Warning);
                    if (ActionIfNotFound != null)
                    {
                        await ActionIfNotFound.Execute();
                    }
                }
            }
        }

        public override async Task Execute(int x, int y)
        {
            await Execute();
        }

        public override string ToString()
        {
            return $"ImageAction: {ImageName}";
        }

        public override bool Validate(out string errorMessage)
        {
            errorMessage = "";

            // Validate image path
            string imagePath = Path.Combine(imagesFolderPath, ImageName);
            if (!File.Exists(imagePath))
            {
                errorMessage = $"Image not found at path: {imagePath}";
                return false;
            }

            // Validate threshold
            if (Threshold < 0 || Threshold > 255)
            {
                errorMessage = "Threshold must be between 0 and 255.";
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
