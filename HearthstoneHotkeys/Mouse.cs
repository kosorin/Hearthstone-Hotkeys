using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public static class Mouse
    {
        #region WinAPI
        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] Input[] pInputs, int cbSize);

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("User32.dll")]
        private static extern bool GetCursorPos(out Point point);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr window, out Rect rect);

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr window, out Point point);

#pragma warning disable 649
        private struct Input
        {
            public UInt32 Type;
            public MouseKeyBDHardwareInput Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct MouseKeyBDHardwareInput
        {
            [FieldOffset(0)]
            public MouseInput Mouse;
        }

        private struct MouseInput
        {
            public Int32 X;
            public Int32 Y;
            public UInt32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public IntPtr ExtraInfo;
        }
#pragma warning restore 649
        #endregion

        private static uint ButtonDownFlag(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left: return 0x0002;
                case MouseButton.Right: return 0x0008;
                case MouseButton.Middle: return 0x0020;
                default: return 0;
            }
        }

        private static uint ButtonUpFlag(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left: return 0x0004;
                case MouseButton.Right: return 0x0010;
                case MouseButton.Middle: return 0x0040;
                default: return 0;
            }
        }

        public static void Click(MouseButton button)
        {
            Input inputMouseDown = new Input();
            inputMouseDown.Type = 0;
            inputMouseDown.Data.Mouse.Flags = ButtonDownFlag(button);

            Input inputMouseUp = new Input();
            inputMouseUp.Type = 0;
            inputMouseUp.Data.Mouse.Flags = ButtonUpFlag(button);

            Input[] inputs = new Input[] { inputMouseDown, inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }

        public static void ClickAt(MouseButton button, Point position, bool moveBackAfterClick = true)
        {
            Point oldPosition = GetCursorPosition();

            SetCursorPosition(position);
            Click(button);

            if (moveBackAfterClick)
            {
                Thread.Sleep(50);
                SetCursorPosition(oldPosition);
            }
        }

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SetCursorPosition(Point point)
        {
            SetCursorPosition(point.X, point.Y);
        }

        public static Point GetCursorPosition()
        {
            Point point = new Point();
            GetCursorPos(out point);
            return point;
        }

        public static void SetCursorGamePosition(GamePosition gamePosition)
        {
            Point point = new Point(0, 0);
            Rect rect = new Rect();
            if (ClientToScreen(Window.Current, out point) && GetClientRect(Window.Current, out rect))
            {
                double ratio = 1.332792208;
                double width = rect.Height * ratio;

                point.X += (int)(rect.Width / 2.0) + (int)(width * gamePosition.X);
                point.Y += (int)Math.Round(rect.Height * gamePosition.Y);

                SetCursorPosition(point);
            }
        }
    }
}
