namespace Kitchen
{
    /// <summary>
    /// Buff Interface
    /// </summary>
    public interface IBuff
    {
        int ID { get; }
        float Duration { get; } //持续时间
        bool CanStack { get; } //是否可以叠加

        void Trigger(IUnit unit);
    }
}