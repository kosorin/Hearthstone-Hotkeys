using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
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
        static extern bool GetClientRect(IntPtr window, out Rect rect);

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr window, out Point point);
        #endregion

        public static IntPtr Current = IntPtr.Zero;

        public static bool IsInForeground
        {
            get
            {
                return Current == GetForegroundWindow();
            }
        }

        public static bool SetHearthstoneWindow()
        {
            Current = FindWindowByCaption(IntPtr.Zero, "Hearthstone");
            return Current != IntPtr.Zero;
        }
    }
}
