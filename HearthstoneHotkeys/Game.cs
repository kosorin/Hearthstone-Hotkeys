﻿using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Utility.Logging;
using HearthstoneHotkeys.Actions;
using HearthstoneHotkeys.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public class Game
    {
        private Task task;

        private CancellationTokenSource cancellationTokenSource;

        private readonly List<Hotkey> hotkeys = new List<Hotkey>
        {
            new Hotkey(Keys.None, Keys.F2, new PlayerEmoteAction("Thanks", new GamePoint(0.38, 0.63))),
            new Hotkey(Keys.None, Keys.F3, new PlayerEmoteAction("Well Played", new GamePoint(0.38, 0.71))),
            new Hotkey(Keys.None, Keys.F4, new PlayerEmoteAction("Greetings", new GamePoint(0.38, 0.8))),
            new Hotkey(Keys.None, Keys.F5, new PlayerEmoteAction("Wow", new GamePoint(0.62, 0.63))),
            new Hotkey(Keys.None, Keys.F6, new PlayerEmoteAction("Oops", new GamePoint(0.62, 0.71))),
            new Hotkey(Keys.None, Keys.F7, new PlayerEmoteAction("Threaten", new GamePoint(0.62, 0.8))),
            new Hotkey(Keys.None, Keys.F9, new OpponentEmoteAction("Squelch", new GamePoint(0.38, 0.1))),
            new Hotkey(Keys.ControlKey, Keys.Space, new ClickAction("End Turn", new GamePoint(0.91, 0.45))),
        };

        public Game()
        {
            foreach (var hotkey in hotkeys)
            {
                Log.Info($"Hotkey> {hotkey}");
            }
        }

        public void Start()
        {
            Log.Info($"Hotkey> start");

            cancellationTokenSource = new CancellationTokenSource();
            var unwrappedTask = Task.Factory.StartNew(RunAsync, cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            task = unwrappedTask.Unwrap();
        }

        public void Stop()
        {
            Log.Info($"Hotkey> stop...");

            cancellationTokenSource.Cancel();
            task.Wait();

            Log.Info($"Hotkey> stop ok");
        }

        private async Task RunAsync()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                if (User32.IsHearthstoneInForeground())
                {
                    await ExecuteHotkeysAsync();
                    await Task.Delay(Input.Delay);
                }
                else
                {
                    await Task.Delay(500);
                }
            }
        }

        private async Task ExecuteHotkeysAsync()
        {
            foreach (var hotkey in hotkeys.Where(x => x.CanExecute()))
            {
                Log.Info($"Hotkey> executing '{hotkey}'");
                await hotkey.ExecuteAsync();
            }
        }
    }
}
