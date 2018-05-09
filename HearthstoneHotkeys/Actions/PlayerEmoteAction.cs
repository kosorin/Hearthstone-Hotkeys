namespace HearthstoneHotkeys.Actions
{
    public class PlayerEmoteAction : EmoteAction
    {
        public PlayerEmoteAction(string name, GamePoint position) : base(name, position)
        {
        }

        public override GamePoint HeroPosition { get; } = new GamePoint(0.5, 0.77);
    }
}
