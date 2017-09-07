using HearthstoneHotkeys.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public class EnemyEmote : Emote
    {
        public override GamePosition HeroPosition { get; } = new GamePosition(0, 0.18);

        public EnemyEmote(string name, GamePosition position) : base(name, position)
        {
        }
    }
}
