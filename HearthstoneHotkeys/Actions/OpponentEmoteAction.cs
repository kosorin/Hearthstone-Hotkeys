using HearthstoneHotkeys.IO;

namespace HearthstoneHotkeys.Actions
{
    public class OpponentEmoteAction : EmoteAction
    {
        public OpponentEmoteAction(string name, GamePoint position) : base(name, position)
        {
        }

        public override GamePoint HeroPosition { get; } = new GamePoint(0.5, 0.18);
    }
}
