namespace Client.Event
{
    public class GemChanged : IEventHandle
    {
        public int OldValue { get; }
        public int NewValue { get; }

        public GemChanged(int oldValue, int newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}