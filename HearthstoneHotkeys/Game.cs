using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Utility.HotKeys;
using Hearthstone_Deck_Tracker.Utility.Logging;
using HearthstoneHotkeys.Actions;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace HearthstoneHotkeys
{
    public class Game
    {
        private bool isRunning;
        private bool isExecuting;

        public Dictionary<HotKey, IAction> Actions { get; } = new Dictionary<HotKey, IAction>
        {
            [new HotKey(ModifierKeys.None, Keys.F2)] = new PlayerEmoteAction("Thanks", new GamePoint(0.38, 0.63)),
            [new HotKey(ModifierKeys.None, Keys.F3)] = new PlayerEmoteAction("Well Played", new GamePoint(0.38, 0.71)),
            [new HotKey(ModifierKeys.None, Keys.F4)] = new PlayerEmoteAction("Greetings", new GamePoint(0.38, 0.8)),
            [new HotKey(ModifierKeys.None, Keys.F5)] = new PlayerEmoteAction("Wow", new GamePoint(0.62, 0.63)),
            [new HotKey(ModifierKeys.None, Keys.F6)] = new PlayerEmoteAction("Oops", new GamePoint(0.62, 0.71)),
            [new HotKey(ModifierKeys.None, Keys.F7)] = new PlayerEmoteAction("Threaten", new GamePoint(0.62, 0.8)),
            [new HotKey(ModifierKeys.None, Keys.F9)] = new OpponentEmoteAction("Squelch", new GamePoint(0.38, 0.1)),
            [new HotKey(ModifierKeys.Control, Keys.Space)] = new ClickAction("End Turn", new GamePoint(0.91, 0.45)),
        };

        private static bool IsInForeground => User32.IsHearthstoneInForeground() && Helper.GameWindowState != WindowState.Minimized;

        public void OnLoad()
        {
            foreach (var item in Actions)
            {
                var hotKey = item.Key;
                var action = item.Value;
                HotKeyManager.RegisterHotkey(hotKey, () => ActionHandler(action), action.Name);
            }
        }

        public void OnUnload()
        {
            Stop();
            foreach (var hotKey in Actions.Keys)
            {
                HotKeyManager.RemovePredefinedHotkey(hotKey);
            }
        }

        public void Start()
        {
            isRunning = true;
        }

        public void Stop()
        {
            isRunning = false;
        }

        public void OnUpdate()
        {
            if (!isRunning)
            {
                return;
            }

            isExecuting = false;
        }

        private void ActionHandler(IAction action)
        {
            if (!IsInForeground)
            {
                return;
            }

            if (isRunning && !isExecuting)
            {
                isExecuting = true;

                Log.Info($"Execute hotkey action: {action.Name}");
                action.Execute();
            }
        }
    }
}
