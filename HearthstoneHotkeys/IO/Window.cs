using Hearthstone_Deck_Tracker;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace HearthstoneHotkeys.IO
{
    public static class Window
    {
        public static Point TransformToScreenPosition(ITransformable transformable)
        {
            var window = User32.GetHearthstoneWindow();
            var point = new Point();
            var clientRectangle = new ClientRectangle();
            if (ClientToScreen(window, out point) && GetClientRect(window, out clientRectangle))
            {
                var rectangle = new Rectangle(clientRectangle.Left, clientRectangle.Right, clientRectangle.Width, clientRectangle.Height);
                var transformPoint = transformable.Transform(rectangle);
                point.X += transformPoint.X;
                point.Y += transformPoint.Y;
            }
            return point;
        }

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr window, out Point point);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr window, out ClientRectangle rectangle);

        [StructLayout(LayoutKind.Sequential)]
        private struct ClientRectangle
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public int Width => Right - Left;

            public int Height => Bottom - Top;
        }
    }
}
