using System.Collections.Generic;

namespace Client.Event
{
    public struct MaxCombo : IEventHandle
    {
        public int Level { get; }

        public MaxCombo(int level)
        {
            Level = level;
        }
    }
}