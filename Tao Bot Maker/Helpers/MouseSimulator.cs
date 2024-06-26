using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tao_Bot_Maker.Helpers
{
    public class MouseSimulator
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010,
            Wheel = 0x0800
        }

        private Random random = new Random();

        public async Task LeftClick(int duration = 100)
        {
            await Click(MouseEventFlags.LeftDown, MouseEventFlags.LeftUp, duration);
        }

        public async Task RightClick(int duration = 100)
        {
            await Click(MouseEventFlags.RightDown, MouseEventFlags.RightUp, duration);
        }

        public async Task MiddleClick(int duration = 100)
        {
            await Click(MouseEventFlags.MiddleDown, MouseEventFlags.MiddleUp, duration);
        }

        public async Task DoubleClick(int duration = 100)
        {
            await LeftClick(duration);
            await Task.Delay(GetRandomDelay(duration));
            await LeftClick(duration);
        }

        private async Task Click(MouseEventFlags down, MouseEventFlags up, int duration)
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;

            mouse_event((int)down, X, Y, 0, 0);
            await Task.Delay(GetRandomDelay(duration));
            mouse_event((int)up, X, Y, 0, 0);
        }

        public async Task Move(int x, int y, int speed = 10)
        {
            Point start = Cursor.Position;
            Point end = new Point(x, y);

            int steps = speed;
            for (int i = 0; i <= steps; i++)
            {
                double t = (double)i / steps;
                int currentX = (int)(start.X + t * (end.X - start.X));
                int currentY = (int)(start.Y + t * (end.Y - start.Y));

                Cursor.Position = new Point(currentX, currentY);
                await Task.Delay(GetRandomDelay(10));
            }
        }

        public async Task DragAndDrop(int startX, int startY, int endX, int endY, int speed = 10, int holdDuration = 100)
        {
            Cursor.Position = new Point(startX, startY);
            mouse_event((int)MouseEventFlags.LeftDown, (uint)startX, (uint)startY, 0, 0);

            await Task.Delay(GetRandomDelay(holdDuration));

            await Move(endX, endY, speed);

            mouse_event((int)MouseEventFlags.LeftUp, (uint)endX, (uint)endY, 0, 0);
        }

        public async Task Scroll(int amount, int duration = 100)
        {
            mouse_event((int)MouseEventFlags.Wheel, 0, 0, (uint)amount, 0);
            await Task.Delay(GetRandomDelay(duration));
        }

        public int GetRandomDelay(int baseDelay)
        {
            return baseDelay + random.Next(-baseDelay / 2, baseDelay / 2);
        }
    }
}
