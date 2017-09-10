using HearthstoneHotkeys.Actions;
using HearthstoneHotkeys.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public class Game
    {
        public List<Hotkey> Hotkeys { get; } = new List<Hotkey>();

        public Game()
        {
            InitializeHotkeys();
            PrintInfo();
        }

        private void InitializeHotkeys()
        {
            Hotkeys.Add(new Hotkey(Keys.None, Keys.F2, new PlayerEmote("Thanks", new GamePosition(-0.12, 0.63))));
            Hotkeys.Add(new Hotkey(Keys.None, Keys.F3, new PlayerEmote("Well Played", new GamePosition(-0.12, 0.71))));
            Hotkeys.Add(new Hotkey(Keys.None, Keys.F4, new PlayerEmote("Greetings", new GamePosition(-0.12, 0.8))));
            Hotkeys.Add(new Hotkey(Keys.None, Keys.F6, new PlayerEmote("Sorry", new GamePosition(0.12, 0.63))));
            Hotkeys.Add(new Hotkey(Keys.None, Keys.F7, new PlayerEmote("Oops", new GamePosition(0.12, 0.71))));
            Hotkeys.Add(new Hotkey(Keys.None, Keys.F8, new PlayerEmote("Threaten", new GamePosition(0.12, 0.8))));

            Hotkeys.Add(new Hotkey(Keys.None, Keys.F12, new EnemyEmote("Squelch", new GamePosition(-0.12, 0.1))));

            Hotkeys.Add(new Hotkey(Keys.ControlKey, Keys.Space, new Click("End Turn", new GamePosition(0.41, 0.45), MouseButton.Left)));
        }

        private void PrintInfo()
        {
            Console.WriteLine();
            Console.WriteLine("  +------------------------------------+");
            Console.WriteLine("  |                                    |");
            Console.WriteLine("  | Hearthstone Hotkeys v1.0 (C) Posix |");
            Console.WriteLine("  |                                    |");
            Console.WriteLine("  +------------------------------------+");
            Console.WriteLine();
            foreach (var hotkey in Hotkeys)
            {
                Console.WriteLine(hotkey);
            }
            Console.WriteLine();
        }

        public void Run()
        {
            while (true)
            {
                if (Window.IsInForeground)
                {
                    foreach (var hotkey in Hotkeys)
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
                    Window.Initialize();
                    Thread.Sleep(500);
                }
            }
        }
    }
}
