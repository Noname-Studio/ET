namespace ET
{
    public class NumericWatcherAttribute: BaseAttribute
    {
        public NumericType NumericType { get; }

        public NumericWatcherAttribute(NumericType type)
        {
            NumericType = type;
        }
    }
}