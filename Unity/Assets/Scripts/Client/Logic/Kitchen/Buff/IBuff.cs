using System;

namespace Kitchen
{
    /// <summary>
    /// Buff Interface
    /// </summary>
    public abstract class ABuff
    {
        int ID { get; }
        float Duration { get; } //持续时间
        bool CanStack { get; } //是否可以叠加
        /// <summary>
        /// 当添加到实体时执行逻辑
        /// </summary>
        public virtual void OnAdd()
        {
        }
 
        /// <summary>
        /// 跟随实体每帧更新
        /// </summary>
        public virtual void OnUpdate()
        {
        }
 
        /// <summary>
        /// 当从实体移除时
        /// </summary>
        public virtual void OnRemove()
        {
        }
    }
}