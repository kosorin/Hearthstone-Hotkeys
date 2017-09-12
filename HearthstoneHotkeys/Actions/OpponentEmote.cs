namespace HearthstoneHotkeys.Actions
{
    public class OpponentEmote : Emote
    {
        public override GamePoint HeroPosition { get; } = new GamePoint(0.5, 0.18);

        public OpponentEmote(string name, GamePoint position) : base(name, position)
        {
        }
    }
}
