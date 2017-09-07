using HearthstoneHotkeys.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.IO
{
    public static class Window
    {
        #region WinAPI

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string windowName);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr window, out Point point);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr window, out Rectangle rectangle);

        #endregion

        public static IntPtr Current = IntPtr.Zero;

        public static bool IsInForeground => Current == GetForegroundWindow();

        public static bool Initialize()
        {
            Current = FindWindowByCaption(IntPtr.Zero, "Hearthstone");
            return Current != IntPtr.Zero;
        }

        public static Point GamePositionToPoint(GamePosition gamePosition)
        {
            var point = new Point();
            var rectangle = new Rectangle();
            if (ClientToScreen(Window.Current, out point) && GetClientRect(Window.Current, out rectangle))
            {
                var ratio = 1.332792208;
                var width = rectangle.Height * ratio;

                point.X += (int)(rectangle.Width / 2.0) + (int)(width * gamePosition.X);
                point.Y += (int)Math.Round(rectangle.Height * gamePosition.Y);
            }
            return point;
        }
    }
}
