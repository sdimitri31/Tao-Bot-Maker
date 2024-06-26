using System;

namespace Tao_Bot_Maker.Helpers
{
    public static class CoordinateHelper
    {
        /// <summary>
        /// Gets the top-left coordinates between two points.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>An array containing the x and y coordinates of the top-left point.</returns>
        public static int[] GetTopLeftCoords(int x1, int y1, int x2, int y2)
        {
            return new int[] { Math.Min(x1, x2), Math.Min(y1, y2) };
        }

        /// <summary>
        /// Gets the bottom-right coordinates between two points.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>An array containing the x and y coordinates of the bottom-right point.</returns>
        public static int[] GetBottomRightCoords(int x1, int y1, int x2, int y2)
        {
            return new int[] { Math.Max(x1, x2), Math.Max(y1, y2) };
        }
    }
}
