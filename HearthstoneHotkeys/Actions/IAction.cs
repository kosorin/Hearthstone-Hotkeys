using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public interface IAction
    {
        string Name { get; }

        void Execute();
    }
}
