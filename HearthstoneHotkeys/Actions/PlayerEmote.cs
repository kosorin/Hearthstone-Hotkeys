using HearthstoneHotkeys.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public class PlayerEmote : Emote
    {
        public override GamePosition HeroPosition { get; } = new GamePosition(0, 0.77);

        public PlayerEmote(string name, GamePosition position) : base(name, position)
        {
        }
    }
}
