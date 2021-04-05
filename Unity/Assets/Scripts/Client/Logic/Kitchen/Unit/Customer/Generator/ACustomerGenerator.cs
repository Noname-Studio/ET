namespace Kitchen
{
    public abstract class ACustomerGenerator
    {
        protected LevelProperty LevelProperty { get; }

        /// <summary>
        /// 活跃时间.这个时间只有在有空闲的餐桌的时候才会持续增加
        /// </summary>
        public float ActiveTime { get; set; }

        public ACustomerGenerator(LevelProperty levelProperty)
        {
            LevelProperty = levelProperty;
        }

        /// <summary>
        /// 每当活跃时间发生改变时执行.
        /// 你可以理解为只有有空闲位置出现的时候会被执行
        /// </summary>
        public abstract CustomerOrder Run();
    }
}