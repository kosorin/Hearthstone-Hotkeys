using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HearthstoneHotkeys.IO
{
    public static class Mouse
    {
        private static Dictionary<MouseButtons, MouseEvents> MouseEventDownMap = new Dictionary<MouseButtons, MouseEvents>
        {
            [MouseButtons.Left] = MouseEvents.LeftDown,
            [MouseButtons.Right] = MouseEvents.RightDown,
            [MouseButtons.Middle] = MouseEvents.MiddleDown,
        };

        private static Dictionary<MouseButtons, MouseEvents> MouseEventUpMap = new Dictionary<MouseButtons, MouseEvents>
        {
            [MouseButtons.Left] = MouseEvents.LeftUp,
            [MouseButtons.Right] = MouseEvents.RightUp,
            [MouseButtons.Middle] = MouseEvents.MiddleUp,
        };

        public static bool Click(MouseButtons button, Point point)
        {
            if (SetCursorPosition(point))
            {
                return Click(button);
            }
            return false;
        }

        public static bool Click(MouseButtons button)
        {
            if (button != MouseButtons.Left && button != MouseButtons.Right && button != MouseButtons.Middle)
            {
                throw new NotSupportedException();
            }

            var inputMouseDown = new Input();
            inputMouseDown.Type = (uint)InputTypes.Mouse;
            inputMouseDown.Data.Mouse.Flags = (uint)MouseEventDownMap[button];

            var inputMouseUp = new Input();
            inputMouseUp.Type = (uint)InputTypes.Mouse;
            inputMouseUp.Data.Mouse.Flags = (uint)MouseEventUpMap[button];

            var inputs = new[] { inputMouseDown, inputMouseUp };
            return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input))) == inputs.Length;
        }

        public static Point GetCursorPosition()
        {
            return GetCursorPos(out ScreenPoint point)
                ? new Point(point.X, point.Y)
                : Point.Empty;
        }

        public static bool SetCursorPosition(Point point)
        {
            return SetCursorPos(point.X, point.Y);
        }

        [DllImport("User32.dll")]
        private static extern bool GetCursorPos(out ScreenPoint point);

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] Input[] pInputs, int cbSize);

        [Flags]
        private enum MouseEvents : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            VerticalWheel = 0x0800,
            HorizontalWheel = 0x1000,
            VirtualDesk = 0x4000,
            Absolute = 0x8000,
        }

        [Flags]
        private enum InputTypes : uint
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2,
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ScreenPoint
        {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Input
        {
            public uint Type;
            public MouseKeyBDHardwareInput Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct MouseKeyBDHardwareInput
        {
            [FieldOffset(0)]
            public MouseInput Mouse;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MouseInput
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }
    }
}
