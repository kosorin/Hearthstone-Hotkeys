using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public interface IAction
    {
        void Execute();

        string GetDescription();
    }
}
