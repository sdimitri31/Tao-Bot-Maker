using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Controller
{
    internal class Utils
    {
        public static int[] GetTopLeftCoords(int x1, int y1, int x2, int y2)
        {
            int x, y;

            if (x1 > x2) 
            { 
                x = x2; 
            }
            else 
            { 
                x = x1; 
            }

            if (y1 > y2) 
            { 
                y = y2; 
            }
            else 
            { 
                y = y1; 
            }

            return new int[] { x, y };
        }
        public static int[] GetBottomRightCoords(int x1, int y1, int x2, int y2)
        {
            int x, y;

            if (x1 < x2)
            {
                x = x2;
            }
            else
            {
                x = x1;
            }

            if (y1 < y2)
            {
                y = y2;
            }
            else
            {
                y = y1;
            }

            return new int[] { x, y };
        }
        
        public static int[] GetCoordsHeightWidth(int x1, int y1, int x2, int y2)
        {
            int height, width;

            int[] xy = Utils.GetTopLeftCoords(x1, y1, x2, y2);
            int[] xy2 = Utils.GetBottomRightCoords(x1, y1, x2, y2);

            width = xy2[0] - xy[0];
            height = xy2[1] - xy[1];

            return new int[] { xy[0], xy[1], width, height };
        }
    }
}
