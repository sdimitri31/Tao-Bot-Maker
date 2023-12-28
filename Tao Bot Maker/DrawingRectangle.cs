﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        public DrawingRectangle()
        {
            rectangles = new List<Rectangle> { };
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
            Pen pen = new Pen(Color.Red, 2);
            pen.Alignment = PenAlignment.Inset;
            foreach (Rectangle rect in rectangles)
                e.Graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void drawRectangle(int x, int y, int width, int height)
        {
            rectangles.Add(new Rectangle(x, y, width, height));
        }

        public void clearRectangles()
        {
            rectangles.Clear();
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


    }

}