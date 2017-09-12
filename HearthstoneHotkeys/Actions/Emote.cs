using HearthstoneHotkeys.IO;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public abstract class Emote : IAction
    {
        public string Name { get; }

        public abstract GamePoint HeroPosition { get; }

        public GamePoint Position { get; }

        public Emote(string name, GamePoint position)
        {
            Name = name;
            Position = position;
        }

        public async Task ExecuteAsync()
        {
            var oldPosition = Mouse.GetCursorPosition();
            var heroPosition = Window.GamePositionToScreenPosition(HeroPosition);
            var position = Window.GamePositionToScreenPosition(Position);

            Mouse.SetCursorPosition(heroPosition);
            Mouse.Click(MouseButton.Right);

            await Task.Delay(Input.Delay);

            Mouse.SetCursorPosition(position);
            Mouse.Click(MouseButton.Left);

            await Task.Delay(Input.Delay);
            Mouse.SetCursorPosition(oldPosition);
        }
    }
}
