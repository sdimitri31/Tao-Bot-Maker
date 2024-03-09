using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;

namespace Tao_Bot_Maker
{
    public class DrawingRectangle : Form
    {
        //DLL Drawing
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);


        public List<Rectangle> rectangles;
        public List<KnownColor> colors;


        public DrawingRectangle()
        {
            SetProcessDPIAware();
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.LightGreen;
            TransparencyKey = Color.LightGreen;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            rectangles = new List<Rectangle> { };
            colors = new List<KnownColor> { };

            /*
            // Use the helper function to get the current dpi.
            SizeF dpi = GetCurrentDpi();

            // Scale the rectangle.
            Width = Width * (int)(dpi.Width / 96f);
            Height = Height * (int)(dpi.Height / 96f);
            */
            Paint += new PaintEventHandler(HalloForm_Paint);
        }

        void HalloForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2)
            {                
                Alignment = PenAlignment.Inset
            };

            for (int i = 0;  i < rectangles.Count; i++)
            {
                pen.Color = Color.FromKnownColor(colors[i]);
                e.Graphics.DrawRectangle(pen, rectangles[i].X, rectangles[i].Y, rectangles[i].Width, rectangles[i].Height);
            }
        }

        public void DrawRectangle(int x, int y, int width, int height, KnownColor color = KnownColor.Red)
        {
            if (width == 0 || height == 0)
            {
                Log.Write("Width and height must be greater than 0", Log.ERROR);
                Log.Write("x = " + x + "; y = " + y + "; width = " + width + "; height = " + height + "; Color = " + color, Log.ERROR);
                throw new ArgumentException("Width and height must be greater than 0");
            }
            else
            {
                Log.Write("Rectangle added : ", Log.TRACE);
                Log.Write("x = " + x + "; y = " + y + "; width = " + width + "; height = " + height + "; Color = " + color, Log.TRACE);
                rectangles.Add(new Rectangle(x, y, width, height));
                colors.Add(color);
                Refresh();
            }
        }

        public void DrawRectangleAtCoords(int x1, int y1, int x2, int y2)
        {
            //Calculate the height and witdh of the bottom right corner
            x2 -= x1; 
            y2 -= y1;
            DrawRectangle(x1, y1, x2, y2);
        }

        public void ClearRectangles()
        {
            rectangles.Clear();
            colors.Clear();
            Refresh();
        }

        public static SizeF GetCurrentDpi()
        {
            using (Form form = new Form())
            using (Graphics g = form.CreateGraphics())
            {
                var result = new SizeF()
                {
                    Width = g.DpiX,
                    Height = g.DpiY
                };
                return result;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingRectangle));
            this.SuspendLayout();
            // 
            // DrawingRectangle
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DrawingRectangle";
            this.ResumeLayout(false);

        }
    }

}
