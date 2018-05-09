using HearthstoneHotkeys.IO;
using System.Threading;
using System.Windows.Forms;

namespace HearthstoneHotkeys.Actions
{
    public abstract class EmoteAction : ActionBase
    {
        protected EmoteAction(string name, GamePoint position) : base("Emote > " + name)
        {
            Position = position;
        }

        public abstract GamePoint HeroPosition { get; }

        public GamePoint Position { get; }

        public override void Execute()
        {
            var oldPosition = Mouse.GetCursorPosition();

            var heroPosition = Window.TransformToScreenPosition(HeroPosition);
            var position = Window.TransformToScreenPosition(Position);

            Mouse.Click(MouseButtons.Right, heroPosition);

            Thread.Sleep(Input.Delay);
            Mouse.Click(MouseButtons.Left, position);

            Thread.Sleep(Input.Delay);
            Mouse.SetCursorPosition(oldPosition);
        }
    }
}
