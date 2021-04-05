using System.Collections.Generic;

namespace ET
{
    public class CoroutineLockQueueType: Entity
    {
        private readonly Dictionary<long, CoroutineLockQueue> workQueues = new Dictionary<long, CoroutineLockQueue>();

        public void Add(long key, CoroutineLockQueue coroutineLockQueue)
        {
            workQueues.Add(key, coroutineLockQueue);
            coroutineLockQueue.Parent = this;
        }

        public void Remove(long key)
        {
            if (!workQueues.TryGetValue(key, out CoroutineLockQueue queue))
            {
                return;
            }

            workQueues.Remove(key);
            queue.Dispose();
        }

        public bool ContainsKey(long key)
        {
            return workQueues.ContainsKey(key);
        }

        public bool TryGetValue(long key, out CoroutineLockQueue coroutineLockQueue)
        {
            return workQueues.TryGetValue(key, out coroutineLockQueue);
        }
    }
}