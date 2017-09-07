using HearthstoneHotkeys.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public abstract class Emote : IAction
    {
        public string Name { get; }

        public abstract GamePosition HeroPosition { get; }

        public GamePosition Position { get; }

        public Emote(string name, GamePosition position)
        {
            Name = name;
            Position = position;
        }

        public void Execute()
        {
            var oldPosition = Mouse.GetCursorPosition();
            var heroPosition = Window.GamePositionToPoint(HeroPosition);
            var position = Window.GamePositionToPoint(Position);

            Mouse.SetCursorPosition(heroPosition);
            Mouse.Click(MouseButton.Right);

            Thread.Sleep(Input.Delay);

            Mouse.SetCursorPosition(position);
            Mouse.Click(MouseButton.Left);

            Thread.Sleep(Input.Delay);
            Mouse.SetCursorPosition(oldPosition);
        }

        public string GetName()
        {
            return Name;
        }
    }
}
