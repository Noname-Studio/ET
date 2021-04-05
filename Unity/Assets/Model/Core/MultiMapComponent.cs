/**
 * 封装MultiMap，用于重用
 */

namespace ET
{
    public class MultiMapComponent<T, K>: Entity
    {
        public MultiMap<T, K> MultiMap = new MultiMap<T, K>();

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            base.Dispose();

            MultiMap.Clear();
        }
    }
}