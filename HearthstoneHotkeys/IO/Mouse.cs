using HearthstoneHotkeys.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.IO
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

        public static void Click(MouseButton button)
        {
            var inputMouseDown = new Input();
            inputMouseDown.Type = 0;
            inputMouseDown.Data.Mouse.Flags = ButtonDownFlag();

            var inputMouseUp = new Input();
            inputMouseUp.Type = 0;
            inputMouseUp.Data.Mouse.Flags = ButtonUpFlag();

            var inputs = new[] { inputMouseDown, inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));

            uint ButtonDownFlag()
            {
                switch (button)
                {
                case MouseButton.Left: return 0x0002;
                case MouseButton.Right: return 0x0008;
                case MouseButton.Middle: return 0x0020;
                default: return 0;
                }
            }

            uint ButtonUpFlag()
            {
                switch (button)
                {
                case MouseButton.Left: return 0x0004;
                case MouseButton.Right: return 0x0010;
                case MouseButton.Middle: return 0x0040;
                default: return 0;
                }
            }
        }

        public static void SetCursorPosition(Point point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static Point GetCursorPosition()
        {
            var point = new Point();
            GetCursorPos(out point);
            return point;
        }
    }
}
