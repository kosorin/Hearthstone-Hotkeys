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
            var hotkeys = new List<Hotkey>
            {
                new Hotkey(Keys.None, Keys.F2, new PlayerEmote("Thanks", new GamePosition(-0.12, 0.63))),
                new Hotkey(Keys.None, Keys.F3, new PlayerEmote("Well Played", new GamePosition(-0.12, 0.71))),
                new Hotkey(Keys.None, Keys.F4, new PlayerEmote("Greetings", new GamePosition(-0.12, 0.8))),
                new Hotkey(Keys.None, Keys.F6, new PlayerEmote("Sorry", new GamePosition(0.12, 0.63))),
                new Hotkey(Keys.None, Keys.F7, new PlayerEmote("Oops", new GamePosition(0.12, 0.71))),
                new Hotkey(Keys.None, Keys.F8, new PlayerEmote("Threaten", new GamePosition(0.12, 0.8))),
                new Hotkey(Keys.None, Keys.F12,  new EnemyEmote("Squelch", new GamePosition(-0.12, 0.1))),
                new Hotkey(Keys.ControlKey, Keys.Space, new Click("End Turn", new GamePosition(0.41, 0.45), MouseButton.Left)),
            };


            Console.WriteLine();
            Console.WriteLine("  +------------------------------------+");
            Console.WriteLine("  |                                    |");
            Console.WriteLine("  | Hearthstone Hotkeys v1.0 (C) Posix |");
            Console.WriteLine("  |                                    |");
            Console.WriteLine("  +------------------------------------+");
            Console.WriteLine();
            foreach (var hotkey in hotkeys)
            {
                Console.WriteLine(hotkey);
            }
            Console.WriteLine();


            bool setWindow = false;
            while (true)
            {
                if (Window.IsInForeground)
                {
                    setWindow = false;

                    foreach (var hotkey in hotkeys)
                    {
                        if (hotkey.CanExecute())
                        {
                            hotkey.Execute();
                        }
                    }
                    Thread.Sleep(Input.Delay);
                }
                else
                {
                    if (!Window.Initialize() && !setWindow)
                    {
                        Console.WriteLine("Zapni hru!");
                    }

                    setWindow = true;
                    Thread.Sleep(500);
                }
            }
        }
    }
}
