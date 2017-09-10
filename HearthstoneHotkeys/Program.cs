using HearthstoneHotkeys.Actions;
using HearthstoneHotkeys.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Run();
        }
    }
}
