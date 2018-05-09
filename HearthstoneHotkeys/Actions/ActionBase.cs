namespace HearthstoneHotkeys.Actions
{
    public abstract class ActionBase : IAction
    {
        protected ActionBase(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract void Execute();
    }
}
