using System.IO;
using System.Threading.Tasks;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    public class ImageAction : Action
    {
        public const string imagesFolderPath = "Images";
        public override string ActionType { get; set; }
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
            ActionType = ActionTypes.ImageAction.ToString();
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
                throw new FileNotFoundException($"Image not found at path: {imagePath}");
            }

            // Search for the image on the screen
            var result = ImageSearchHelper.FindImageCenter(imagePath, Threshold, StartX, StartY, EndX, EndY);

            // If the image is found
            if (result != null)
            {
                if (ActionIfFound != null)
                {
                    await ActionIfFound.Execute();
                }
            }
            else // If the image is not found
            {
                if (ActionIfNotFound != null)
                {
                    await ActionIfNotFound.Execute();
                }
            }
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

            // Validate coordinates
            if (StartX < 0 || StartY < 0 || EndX < 0 || EndY < 0)
            {
                errorMessage = "Coordinates must be non-negative.";
                return false;
            }

            if (StartX > EndX || StartY > EndY)
            {
                errorMessage = "Start coordinates must be less than end coordinates.";
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
    }
}
