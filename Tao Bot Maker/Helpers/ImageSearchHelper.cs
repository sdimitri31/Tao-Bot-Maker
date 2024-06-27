using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Tao_Bot_Maker.Helpers
{
    internal class ImageSearchHelper
    {
        //DLL ImageSearch
        [DllImport(@"ImageSearchDLL.dll")]
        private static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)] string imagePath);

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

        /// <summary>
        /// Search for a picture on the screen and return coordinates
        /// </summary>
        /// <param name="path">Complete path of picture to look for</param>
        /// <param name="Threshold">Number between 0 and 255. 0 = pixel perfect search. Recommended value 100</param>
        /// <param name="X1">Top left X</param>
        /// <param name="Y1">Top left Y</param>
        /// <param name="X2">Bottom right X</param>
        /// <param name="Y2">Bottom right Y</param>
        /// <returns>String Array with coords</returns>
        public static String[] FindImage(string path, int Threshold, int X1, int Y1, int X2, int Y2)
        {
            String[] results_if_image = null;

            if (File.Exists(path))
            {
                //Determine where are the corners
                int[] xy = CoordinateHelper.GetTopLeftCoords(X1, Y1, X2, Y2);
                int[] xy2 = CoordinateHelper.GetBottomRightCoords(X1, Y1, X2, Y2);

                results_if_image = UseImageSearchArea(path, Threshold.ToString(), xy[0], xy[1], xy2[0], xy2[1]);
            }
            return results_if_image;
        }

        /// <summary>
        /// Search for a picture on the screen and return the coordinates of its center.
        /// </summary>
        /// <param name="path">Complete path of picture to look for</param>
        /// <param name="Threshold">Number between 0 and 255. 0 = pixel perfect search. Recommended value 100</param>
        /// <param name="X1">Top left X</param>
        /// <param name="Y1">Top left Y</param>
        /// <param name="X2">Bottom right X</param>
        /// <param name="Y2">Bottom right Y</param>
        /// <returns>An array containing the x and y coordinates of the center of the image, or null if not found</returns>
        public static int[] FindImageCenter(string path, int Threshold, int X1, int Y1, int X2, int Y2)
        {
            var result = FindImage(path, Threshold, X1, Y1, X2, Y2);

            if (result == null) return null;

            // Assuming the result format is "1|x|y"
            int x = int.Parse(result[1]);
            int y = int.Parse(result[2]);

            // Get the image dimensions
            var image = System.Drawing.Image.FromFile(path);
            int imageWidth = image.Width;
            int imageHeight = image.Height;

            // Calculate the center coordinates
            int centerX = x + (imageWidth / 2);
            int centerY = y + (imageHeight / 2);

            return new int[] { centerX, centerY };
        }

        public static async Task<int[]> FindImageCenter(string path, int threshold, int x1, int y1, int x2, int y2, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = FindImage(path, threshold, x1, y1, x2, y2);

                    if (result != null)
                    {
                        // Assuming the result format is "1|x|y"
                        int x = int.Parse(result[1]);
                        int y = int.Parse(result[2]);

                        // Get the image dimensions
                        var image = Image.FromFile(path);
                        int imageWidth = image.Width;
                        int imageHeight = image.Height;

                        // Calculate the center coordinates
                        int centerX = x + (imageWidth / 2);
                        int centerY = y + (imageHeight / 2);

                        return new int[] { centerX, centerY };
                    }
                }
                return null;
            }, cancellationToken);
        }
    }
}
