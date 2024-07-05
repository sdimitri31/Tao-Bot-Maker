using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Tao_Bot_Maker.Helpers
{
    internal class ImageSearchHelper
    {
        //DLL ImageSearch
        [DllImport(@"ImageSearchDLL.dll")]
        private static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)] string imagePath);

        public static int[] UseImageSearchArea(string imgPath, string tolerance, int x1, int y1, int right, int bottom)
        {
            imgPath = "*" + tolerance + " " + imgPath;

            IntPtr result = ImageSearch(x1, y1, right, bottom, imgPath);
            string res = Marshal.PtrToStringAnsi(result);

            if (res[0] == '0') return null;

            string[] data = res.Split('|');

            int x = int.Parse(data[1]);
            int y = int.Parse(data[2]);

            // Get the image dimensions
            int imageWidth = int.Parse(data[3]);
            int imageHeight = int.Parse(data[4]);

            return new int[] { x, y, imageWidth, imageHeight };
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
        public static int[] FindImage(string path, int Threshold, int X1, int Y1, int X2, int Y2)
        {
            if (!File.Exists(path))
                return null;

            //Determine where are the corners
            int[] xy = CoordinatesHelper.GetTopLeftCoords(X1, Y1, X2, Y2);
            int[] xy2 = CoordinatesHelper.GetBottomRightCoords(X1, Y1, X2, Y2);

            return UseImageSearchArea(path, Threshold.ToString(), xy[0], xy[1], xy2[0], xy2[1]);
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

            if (result == null) 
                return null;

            return CoordinatesHelper.GetCenterCoords(result[0], result[1], result[2], result[3]);
        }

    }
}
