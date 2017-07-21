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
            Console.WriteLine();
            Console.WriteLine("  +------------------------------------+");
            Console.WriteLine("  |                                    |");
            Console.WriteLine("  | Hearthstone Hotkeys v1.0 (C) Posix |");
            Console.WriteLine("  |                                    |");
            Console.WriteLine("  +------------------------------------+");
            Console.WriteLine();

            Emote ThanksEmote = new Emote("Thanks", new GamePosition(-0.12, 0.63), Emote.PlayerPosition);
            Emote WellPlayedEmote = new Emote("Well Played", new GamePosition(-0.12, 0.71), Emote.PlayerPosition);
            Emote GreetingsEmote = new Emote("Greetings", new GamePosition(-0.12, 0.8), Emote.PlayerPosition);
            Emote SorryEmote = new Emote("Sorry", new GamePosition(0.12, 0.63), Emote.PlayerPosition);
            Emote OopsEmote = new Emote("Oops", new GamePosition(0.12, 0.71), Emote.PlayerPosition);
            Emote ThreatenEmote = new Emote("Threaten", new GamePosition(0.12, 0.8), Emote.PlayerPosition);
            Emote SquelchEmote = new Emote("Squelch", new GamePosition(-0.12, 0.1), Emote.EnemyPosition);

            Click EndTurnClick = new Click("End Turn", new GamePosition(0.41, 0.45), MouseButton.Left, true);

            List<Hotkey> hotkeys = new List<Hotkey>();
            hotkeys.Add(new Hotkey(Keys.F2, Keys.None, ThanksEmote));
            hotkeys.Add(new Hotkey(Keys.F3, Keys.None, WellPlayedEmote));
            hotkeys.Add(new Hotkey(Keys.F4, Keys.None, GreetingsEmote));
            hotkeys.Add(new Hotkey(Keys.F6, Keys.None, SorryEmote));
            hotkeys.Add(new Hotkey(Keys.F7, Keys.None, OopsEmote));
            hotkeys.Add(new Hotkey(Keys.F8, Keys.None, ThreatenEmote));
            hotkeys.Add(new Hotkey(Keys.F12, Keys.None, SquelchEmote));
            hotkeys.Add(new Hotkey(Keys.Space, Keys.ControlKey, EndTurnClick));

            bool setWindow = false;
            while (true)
            {
                if (Window.IsInForeground)
                {
                    setWindow = false;

                    foreach (Hotkey hotkey in hotkeys)
                    {
                        if (hotkey.CanExecute())
                        {
                            hotkey.Execute();
                        }
                    }
                    Thread.Sleep(50);
                }
                else
                {
                    if (!Window.SetHearthstoneWindow() && !setWindow)
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
