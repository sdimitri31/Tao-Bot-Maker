using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Controller
{
    internal class ImageSearchController
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
        public static String[] FindImage(String path, int Threshold, int X1, int Y1, int X2, int Y2)
        {
            String[] results_if_image = null;

            if (File.Exists(path))
            {
                //Determine where are the corners
                int[] xy = Utils.GetTopLeftCoords(X1, Y1, X2, Y2);
                int[] xy2 = Utils.GetBottomRightCoords(X1, Y1, X2, Y2);

                results_if_image = ImageSearchController.UseImageSearchArea(path, Threshold.ToString(), xy[0], xy[1], xy2[0], xy2[1]);
            }
            return results_if_image;
        }
    }
}
