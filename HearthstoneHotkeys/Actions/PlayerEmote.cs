namespace HearthstoneHotkeys.Actions
{
    public class PlayerEmote : Emote
    {
        public override GamePoint HeroPosition { get; } = new GamePoint(0.5, 0.77);

        public PlayerEmote(string name, GamePoint position) : base(name, position)
        {
        }
    }
}
