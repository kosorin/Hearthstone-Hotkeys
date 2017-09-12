using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using System;
using System.Reflection;
using System.Windows.Controls;

namespace HearthstoneHotkeys
{
    public class Plugin : IPlugin
    {
        public string Name => "Hotkeys";

        public string Description => "Hearthstone hotkeys";

        public string ButtonText => "Settings";

        public string Author => "David Kosorin";

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public MenuItem MenuItem => null;


        private Game game;

        private void Start()
        {
            Stop();

            game = new Game();

            GameEvents.OnGameStart.Add(game.Start);
            GameEvents.OnGameEnd.Add(game.Stop);
        }

        private void Stop()
        {
            if (game != null)
            {
                game.Stop();
                game = null;
            }
        }


        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            Start();
        }

        public void OnUnload()
        {
            Stop();
        }

        public void OnUpdate()
        {
        }
    }
}
