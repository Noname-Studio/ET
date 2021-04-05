using System;
using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public static class WaitTypeError
    {
        public const int Success = 0;
        public const int Destroy = 1;
        public const int Cancel = 2;
        public const int Timeout = 3;
    }

    public interface IWaitType
    {
        int Error { get; set; }
    }

    [ObjectSystem]
    public class ObjectWaitAwakeSystem: AwakeSystem<ObjectWait>
    {
        public override void Awake(ObjectWait self)
        {
            self.tcss.Clear();
        }
    }

    [ObjectSystem]
    public class ObjectWaitDestroySystem: DestroySystem<ObjectWait>
    {
        public override void Destroy(ObjectWait self)
        {
            foreach (object v in self.tcss.Values.ToArray())
            {
                ((ObjectWait.IDestroyRun) v).SetResult();
            }
        }
    }

    public class ObjectWait: Entity
    {
        public interface IDestroyRun
        {
            void SetResult();
        }

        public class ResultCallback<K>: IDestroyRun where K : struct, IWaitType
        {
            private readonly ETTaskCompletionSource<K> tcs;
            private readonly long timer;

            public ResultCallback()
            {
                tcs = new ETTaskCompletionSource<K>();
            }

            public ResultCallback(long timer)
            {
                this.timer = timer;
                tcs = new ETTaskCompletionSource<K>();
            }

            public ETTask<K> Task => tcs.Task;

            public void SetResult(K k)
            {
                TimerComponent.Instance.Remove(timer);
                tcs.SetResult(k);
            }

            public void SetResult()
            {
                TimerComponent.Instance.Remove(timer);
                tcs.SetResult(new K() { Error = WaitTypeError.Destroy });
            }
        }

        public Dictionary<Type, object> tcss = new Dictionary<Type, object>();

        public async ETTask<T> Wait<T>(ETCancellationToken cancellationToken = null) where T : struct, IWaitType
        {
            ResultCallback<T> tcs = new ResultCallback<T>();
            Type type = typeof (T);
            tcss.Add(type, tcs);

            void CancelAction()
            {
                Notify(new T() { Error = WaitTypeError.Cancel });
            }

            T ret;
            try
            {
                cancellationToken?.Add(CancelAction);
                ret = await tcs.Task;
            }
            finally
            {
                cancellationToken?.Remove(CancelAction);
            }

            return ret;
        }

        public async ETTask<T> Wait<T>(int timeout, ETCancellationToken cancellationToken = null) where T : struct, IWaitType
        {
            long timerId = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + timeout,
                () => { Notify(new T() { Error = WaitTypeError.Timeout }); });

            ResultCallback<T> tcs = new ResultCallback<T>(timerId);
            tcss.Add(typeof (T), tcs);

            void CancelAction()
            {
                Notify(new T() { Error = WaitTypeError.Cancel });
            }

            T ret;
            try
            {
                cancellationToken?.Add(CancelAction);
                ret = await tcs.Task;
            }
            finally
            {
                cancellationToken?.Remove(CancelAction);
            }

            return ret;
        }

        public void Notify<T>(T obj) where T : struct, IWaitType
        {
            Type type = typeof (T);
            if (!tcss.TryGetValue(type, out object tcs))
            {
                return;
            }

            tcss.Remove(type);
            ((ResultCallback<T>) tcs).SetResult(obj);
        }
    }
}