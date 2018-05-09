using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using Hearthstone_Deck_Tracker.Utility.HotKeys;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

namespace HearthstoneHotkeys
{
    public class Plugin : IPlugin
    {
        private Game game;

        public Plugin()
        {
            game = new Game();
        }

        public string Name => "Hotkeys";

        public string Description => GetDescription();

        public string ButtonText => null;

        public string Author => "David Kosorin";

        public MenuItem MenuItem => null;

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            game.OnLoad();

            GameEvents.OnGameStart.Add(game.Start);
            GameEvents.OnGameEnd.Add(game.Stop);
        }

        public void OnUnload()
        {
            game.OnUnload();
        }

        public void OnUpdate()
        {
            game.OnUpdate();
        }

        private string GetDescription()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Hearthstone hotkeys.");
            sb.AppendLine();

            foreach (var item in game.Actions)
            {
                var hotKey = item.Key;
                var action = item.Value;

                if (hotKey.Mod != ModifierKeys.None)
                {
                    sb.AppendFormat("{0} + ", hotKey.Mod.ToString().Replace(", ", " + "));
                }
                sb.AppendLine($"{hotKey.Key} = {action.Name}");
            }

            return sb.ToString();
        }
    }
}
