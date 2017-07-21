using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public class Click : IAction
    {
        public string Description { get; set; }

        public GamePosition Position { get; set; }

        public MouseButton Button { get; set; }

        public bool MoveBackAfterClick { get; set; }

        public Click(string description, GamePosition position, MouseButton button, bool moveBackAfterClick = false)
        {
            Description = description;
            Position = position;
            Button = button;
            MoveBackAfterClick = moveBackAfterClick;
        }

        public void Execute()
        {
            Point oldPosition = Mouse.GetCursorPosition();

            Mouse.SetCursorGamePosition(Position);
            Mouse.Click(Button);

            Thread.Sleep(66);
            if (MoveBackAfterClick)
            {
                Mouse.SetCursorPosition(oldPosition);
            }
        }

        public static void Execute(GamePosition position, MouseButton button, bool moveBackAfterClick = false)
        {
            new Click("", position, button, moveBackAfterClick).Execute();
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}
