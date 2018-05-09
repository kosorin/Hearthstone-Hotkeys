namespace HearthstoneHotkeys.Actions
{
    public interface IAction
    {
        string Name { get; }

        void Execute();
    }
}
