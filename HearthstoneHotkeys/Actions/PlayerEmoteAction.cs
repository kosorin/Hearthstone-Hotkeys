namespace HearthstoneHotkeys.Actions
{
    public class PlayerEmoteAction : EmoteAction
    {
        public override GamePoint HeroPosition { get; } = new GamePoint(0.5, 0.77);

        public PlayerEmoteAction(string name, GamePoint position) : base(name, position)
        {
        }
    }
}
