using HearthstoneHotkeys.IO;
using System.Threading;
using System.Windows.Forms;

namespace HearthstoneHotkeys.Actions
{
    public class ClickAction : ActionBase
    {
        public ClickAction(string name, GamePoint position, MouseButtons button = MouseButtons.Left) : base("Click > " + name)
        {
            Position = position;
            Button = button;
        }

        public GamePoint Position { get; }

        public MouseButtons Button { get; }

        public override void Execute()
        {
            var oldPosition = Mouse.GetCursorPosition();

            var position = Window.TransformToScreenPosition(Position);

            Mouse.Click(Button, position);

            Thread.Sleep(Input.Delay);
            Mouse.SetCursorPosition(oldPosition);
        }
    }
}
