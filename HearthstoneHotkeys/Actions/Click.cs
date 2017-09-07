using HearthstoneHotkeys.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public class Click : IAction
    {
        public string Name { get; }

        public GamePosition Position { get; }

        public MouseButton Button { get; }

        public Click(string name, GamePosition position, MouseButton button)
        {
            Name = name;
            Position = position;
            Button = button;
        }

        public void Execute()
        {
            var oldPosition = Mouse.GetCursorPosition();
            var position = Window.GamePositionToPoint(Position);

            Mouse.SetCursorPosition(position);
            Mouse.Click(Button);

            Thread.Sleep(Input.Delay);
            Mouse.SetCursorPosition(oldPosition);
        }
    }
}
