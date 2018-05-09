namespace HearthstoneHotkeys.Actions
{
    public class PlayerEmoteAction : EmoteAction
    {
        public PlayerEmoteAction(string name, GamePoint position) : base("Player > " + name, position)
        {
        }

        public override GamePoint HeroPosition { get; } = new GamePoint(0.5, 0.77);
    }
}
