using HearthstoneHotkeys.IO;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public class ClickAction : IAction
    {
        public ClickAction(string name, GamePoint position, MouseButton button = MouseButton.Left)
        {
            Name = name;
            Position = position;
            Button = button;
        }

        public string Name { get; }

        public GamePoint Position { get; }

        public MouseButton Button { get; }

        public async Task ExecuteAsync()
        {
            var oldPosition = Mouse.GetCursorPosition();
            var position = Window.GamePositionToScreenPosition(Position);

            Mouse.SetCursorPosition(position);
            Mouse.Click(Button);

            await Task.Delay(Input.Delay);
            Mouse.SetCursorPosition(oldPosition);
        }
    }
}
