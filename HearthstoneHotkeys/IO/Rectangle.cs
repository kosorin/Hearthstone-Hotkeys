using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.IO
{
    public struct Rectangle
    {
        public int Left;

        public int Top;

        public int Right;

        public int Bottom;

        public int Width => Right - Left;

        public int Height => Bottom - Top;
    }
}
