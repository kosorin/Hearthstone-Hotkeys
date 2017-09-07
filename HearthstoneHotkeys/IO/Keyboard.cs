using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.IO
{
    public static class Keyboard
    {
        #region WinAPI

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int key);

        #endregion

        public static bool CheckDown(Keys key)
        {
            return GetAsyncKeyState((int)key) != 0;
        }

        public static bool CheckPressed(Keys key)
        {
            return GetAsyncKeyState((int)key) == -32767;
        }
    }
}
