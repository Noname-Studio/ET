namespace Client.Event
{
    public struct CoinChanged : IEventHandle
    {
        public int OldValue { get; }
        public int NewValue { get; }

        public CoinChanged(int oldValue, int newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}