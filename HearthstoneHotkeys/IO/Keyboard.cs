using System.Runtime.InteropServices;

namespace HearthstoneHotkeys.IO
{
    public static class Keyboard
    {
        public static bool CheckDown(Keys key)
        {
            return GetAsyncKeyState((int)key) != 0;
        }

        public static bool CheckPressed(Keys key)
        {
            return GetAsyncKeyState((int)key) == -32767;
        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int key);
    }
}
