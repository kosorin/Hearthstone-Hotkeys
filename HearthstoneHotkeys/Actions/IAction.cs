using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public interface IAction
    {
        string Name { get; }

        Task ExecuteAsync();
    }
}
