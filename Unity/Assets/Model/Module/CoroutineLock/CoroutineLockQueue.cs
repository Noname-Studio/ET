using System.Collections.Generic;

namespace ET
{
    public class CoroutineLockQueue: Entity
    {
        private readonly Queue<ETTaskCompletionSource<CoroutineLock>> queue = new Queue<ETTaskCompletionSource<CoroutineLock>>();

        public void Enqueue(ETTaskCompletionSource<CoroutineLock> tcs)
        {
            queue.Enqueue(tcs);
        }

        public ETTaskCompletionSource<CoroutineLock> Dequeue()
        {
            return queue.Dequeue();
        }

        public int Count => queue.Count;

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            base.Dispose();

            queue.Clear();
        }
    }
}