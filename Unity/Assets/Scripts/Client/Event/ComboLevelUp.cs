namespace Client.Event
{
    public struct ComboLevelUp : IEventHandle
    {
        public int Level { get; }

        public ComboLevelUp(int level)
        {
            Level = level;
        }
    }
}