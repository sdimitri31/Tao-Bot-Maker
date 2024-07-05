using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tao_Bot_Maker.View
{
    public partial class DrawingForm : Form
    {
        //DLL Drawing
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private List<Rectangle> rectangles;
        private List<KnownColor> colors;

        public DrawingForm()
        {
            SetProcessDPIAware();
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.LightGreen;
            TransparencyKey = Color.LightGreen;
            StartPosition = FormStartPosition.Manual;

            var screens = Screen.AllScreens;
            Bounds = screens.Aggregate(Rectangle.Empty, (bounds, screen) => Rectangle.Union(bounds, screen.Bounds));

            rectangles = new List<Rectangle> { };
            colors = new List<KnownColor> { };
            Paint += new PaintEventHandler(PaintRectangles);
        }

        private Point GetWindowOffset()
        {
            return new Point(this.Left, this.Top);
        }

        void PaintRectangles(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2)
            {
                Alignment = PenAlignment.Inset
            };

            for (int i = 0; i < rectangles.Count; i++)
            {
                pen.Color = Color.FromKnownColor(colors[i]);
                e.Graphics.DrawRectangle(pen, rectangles[i].X, rectangles[i].Y, rectangles[i].Width, rectangles[i].Height);
            }
        }

        public void DrawRectangle(int x, int y, int width, int height, KnownColor color = KnownColor.Red)
        {
            if (width == 0 || height == 0)
            {
                //throw new ArgumentException("Width and height must be greater than 0");
            }
            else
            {
                Point offset = GetWindowOffset();
                rectangles.Add(new Rectangle(x - offset.X, y - offset.Y, width, height));
                colors.Add(color);
                Refresh();
            }
        }

        public void DrawRectangleAtCoords(int x1, int y1, int x2, int y2, KnownColor color = KnownColor.Red)
        {
            //Calculate the height and witdh of the bottom right corner
            int width = x2 - x1;
            int height = y2 - y1;
            DrawRectangle(x1, y1, width, height, color);
        }

        public void ClearRectangles()
        {
            rectangles.Clear();
            colors.Clear();
            Refresh();
        }
    }
}
