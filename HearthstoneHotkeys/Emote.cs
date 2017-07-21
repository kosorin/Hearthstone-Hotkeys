using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public class Emote : IAction
    {
        public static GamePosition PlayerPosition = new GamePosition(0, 0.77);

        public static GamePosition EnemyPosition = new GamePosition(0, 0.18);

        public string Name { get; set; }

        public GamePosition Position { get; set; }

        public GamePosition HeroPosition { get; set; }

        public Emote(string name, GamePosition position, GamePosition heroPosition)
        {
            Name = name;
            Position = position;
            HeroPosition = heroPosition;
        }

        public void Execute()
        {
            Point oldPosition = Mouse.GetCursorPosition();

            Click.Execute(HeroPosition, MouseButton.Right);
            for (int i = 0; i < 100; ++i)
            {
                Thread.Sleep(4);
                Mouse.SetCursorGamePosition(HeroPosition);
            }
            Click.Execute(Position, MouseButton.Left);

            Mouse.SetCursorPosition(oldPosition);
        }

        public string GetDescription()
        {
            return Name;
        }
    }
}
