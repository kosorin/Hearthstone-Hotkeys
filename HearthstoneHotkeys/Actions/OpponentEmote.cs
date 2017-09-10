using HearthstoneHotkeys.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
