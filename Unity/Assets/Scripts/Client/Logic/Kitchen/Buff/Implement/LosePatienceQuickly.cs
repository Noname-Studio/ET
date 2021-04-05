namespace Kitchen
{
    /// <summary>
    /// TODO
    /// 效果：耐心下降速度增加2倍
    /// 该脚本仅作示例使用.
    /// 你可以使用配置表使这个Buff受到等级或者额外参数的影响.
    /// </summary>
    public class LosePatienceQuickly: IBuff
    {
        public int ID { get; }
        public float Duration { get; }
        public bool CanStack { get; }

        public void Trigger(IUnit unit)
        {
            var customer = unit as ACustomer;
            if (customer != null)
            {
                //BuffManager.Inst.Remove(unit, this);
                return;
            }
        }
    }
}