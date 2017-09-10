using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Utility.Logging;
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
        private readonly List<Hotkey> hotkeys = new List<Hotkey>
        {
            new Hotkey(Keys.None, Keys.F2, new PlayerEmote("Thanks", new GamePoint(0.38, 0.63))),
            new Hotkey(Keys.None, Keys.F3, new PlayerEmote("Well Played", new GamePoint(0.38, 0.71))),
            new Hotkey(Keys.None, Keys.F4, new PlayerEmote("Greetings", new GamePoint(0.38, 0.8))),
            new Hotkey(Keys.None, Keys.F5, new PlayerEmote("Wow", new GamePoint(0.62, 0.63))),
            new Hotkey(Keys.None, Keys.F6, new PlayerEmote("Oops", new GamePoint(0.62, 0.71))),
            new Hotkey(Keys.None, Keys.F7, new PlayerEmote("Threaten", new GamePoint(0.62, 0.8))),
            new Hotkey(Keys.None, Keys.F9, new OpponentEmote("Squelch", new GamePoint(0.38, 0.1))),
            new Hotkey(Keys.ControlKey, Keys.Space, new Click("End Turn", new GamePoint(0.91, 0.45), MouseButton.Left)),
        };

        private Task task;
        private CancellationTokenSource cancelSource;

        public Game()
        {
            LogInfo();
        }

        private void LogInfo()
        {
            foreach (var hotkey in hotkeys)
            {
                Log.Info($"Hotkey> {hotkey}");
            }
        }

        public void Start()
        {
            Log.Info($"Hotkey> start");

            cancelSource = new CancellationTokenSource();
            var unwrappedTask = Task.Factory.StartNew(RunAsync, cancelSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            task = unwrappedTask.Unwrap();
        }

        public void Stop()
        {
            Log.Info($"Hotkey> stop...");

            cancelSource.Cancel();
            task.Wait();

            Log.Info($"Hotkey> stop ok");
        }

        private async Task RunAsync()
        {
            while (!cancelSource.IsCancellationRequested)
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
