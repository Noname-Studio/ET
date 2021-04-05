using System;
using System.Collections.Generic;

namespace ET
{
    public enum TimerClass
    {
        None,
        OnceWaitTimer,
        OnceTimer,
        RepeatedTimer
    }

    [ObjectSystem]
    public class TimerActionAwakeSystem: AwakeSystem<TimerAction, TimerClass, long, object>
    {
        public override void Awake(TimerAction self, TimerClass timerClass, long time, object callback)
        {
            self.TimerClass = timerClass;
            self.Callback = callback;
            self.Time = time;
        }
    }

    [ObjectSystem]
    public class TimerActionDestroySystem: DestroySystem<TimerAction>
    {
        public override void Destroy(TimerAction self)
        {
            self.Callback = null;
            self.Time = 0;
            self.TimerClass = TimerClass.None;
        }
    }

    public class TimerAction: Entity
    {
        public TimerClass TimerClass;

        public object Callback;

        public long Time;
    }

    [ObjectSystem]
    public class TimerComponentAwakeSystem: AwakeSystem<TimerComponent>
    {
        public override void Awake(TimerComponent self)
        {
            TimerComponent.Instance = self;
        }
    }

    [ObjectSystem]
    public class TimerComponentUpdateSystem: UpdateSystem<TimerComponent>
    {
        public override void Update(TimerComponent self)
        {
            self.Update();
        }
    }

    public class TimerComponent: Entity
    {
        public static TimerComponent Instance { get; set; }

        /// <summary>
        /// key: time, value: timer id
        /// </summary>
        private readonly MultiMap<long, long> TimeId = new MultiMap<long, long>();

        private readonly Queue<long> timeOutTime = new Queue<long>();

        private readonly Queue<long> timeOutTimerIds = new Queue<long>();

        // 记录最小时间，不用每次都去MultiMap取第一个值
        private long minTime;

        public void Update()
        {
            if (TimeId.Count == 0)
            {
                return;
            }

            long timeNow = TimeHelper.ServerNow();

            if (timeNow < minTime)
            {
                return;
            }

            foreach (KeyValuePair<long, List<long>> kv in TimeId)
            {
                long k = kv.Key;
                if (k > timeNow)
                {
                    minTime = k;
                    break;
                }

                timeOutTime.Enqueue(k);
            }

            while (timeOutTime.Count > 0)
            {
                long time = timeOutTime.Dequeue();
                foreach (long timerId in TimeId[time])
                {
                    timeOutTimerIds.Enqueue(timerId);
                }

                TimeId.Remove(time);
            }

            while (timeOutTimerIds.Count > 0)
            {
                long timerId = timeOutTimerIds.Dequeue();

                TimerAction timerAction = GetChild<TimerAction>(timerId);
                if (timerAction == null)
                {
                    continue;
                }

                Run(timerAction);
            }
        }

        private void Run(TimerAction timerAction)
        {
            switch (timerAction.TimerClass)
            {
                case TimerClass.OnceWaitTimer:
                {
                    ETTaskCompletionSource<bool> tcs = timerAction.Callback as ETTaskCompletionSource<bool>;
                    Remove(timerAction.Id);
                    tcs.SetResult(true);
                    break;
                }
                case TimerClass.OnceTimer:
                {
                    Action action = timerAction.Callback as Action;
                    Remove(timerAction.Id);
                    action?.Invoke();
                    break;
                }
                case TimerClass.RepeatedTimer:
                {
                    Action action = timerAction.Callback as Action;
                    long tillTime = TimeHelper.ServerNow() + timerAction.Time;
                    AddTimer(tillTime, timerAction);
                    action?.Invoke();
                    break;
                }
            }
        }

        private void AddTimer(long tillTime, TimerAction timer)
        {
            TimeId.Add(tillTime, timer.Id);
            if (tillTime < minTime)
            {
                minTime = tillTime;
            }
        }

        public async ETTask<bool> WaitTillAsync(long tillTime, ETCancellationToken cancellationToken = null)
        {
            if (TimeHelper.ServerNow() >= tillTime)
            {
                return true;
            }

            ETTaskCompletionSource<bool> tcs = new ETTaskCompletionSource<bool>();
            TimerAction timer = EntityFactory.CreateWithParent<TimerAction, TimerClass, long, object>(this, TimerClass.OnceWaitTimer, 0, tcs, true);
            AddTimer(tillTime, timer);
            long timerId = timer.Id;

            void CancelAction()
            {
                if (Remove(timerId))
                {
                    tcs.SetResult(false);
                }
            }

            bool ret;
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

        public async ETTask<bool> WaitFrameAsync(ETCancellationToken cancellationToken = null)
        {
            return await WaitAsync(1, cancellationToken);
        }

        public async ETTask<bool> WaitAsync(long time, ETCancellationToken cancellationToken = null)
        {
            if (time == 0)
            {
                return true;
            }

            long tillTime = TimeHelper.ServerNow() + time;

            ETTaskCompletionSource<bool> tcs = new ETTaskCompletionSource<bool>();

            TimerAction timer = EntityFactory.CreateWithParent<TimerAction, TimerClass, long, object>(this, TimerClass.OnceWaitTimer, 0, tcs, true);
            AddTimer(tillTime, timer);
            long timerId = timer.Id;

            void CancelAction()
            {
                if (Remove(timerId))
                {
                    tcs.SetResult(false);
                }
            }

            bool ret;
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

        public long NewFrameTimer(Action action)
        {
#if NOT_CLIENT
			return NewRepeatedTimerInner(100, action);
#else
            return NewRepeatedTimerInner(1, action);
#endif
        }

        /// <summary>
        /// 创建一个RepeatedTimer
        /// </summary>
        private long NewRepeatedTimerInner(long time, Action action)
        {
#if NOT_CLIENT
			if (time < 100)
			{
				throw new Exception($"repeated timer < 100, timerType: time: {time}");
			}
#endif
            long tillTime = TimeHelper.ServerNow() + time;
            TimerAction timer =
                    EntityFactory.CreateWithParent<TimerAction, TimerClass, long, object>(this, TimerClass.RepeatedTimer, time, action, true);
            AddTimer(tillTime, timer);
            return timer.Id;
        }

        public long NewRepeatedTimer(long time, Action action)
        {
            return NewRepeatedTimerInner(time, action);
        }

        public void Remove(ref long id)
        {
            Remove(id);
            id = 0;
        }

        public bool Remove(long id)
        {
            if (id == 0)
            {
                return false;
            }

            TimerAction timerAction = GetChild<TimerAction>(id);
            if (timerAction == null)
            {
                return false;
            }

            timerAction.Dispose();
            return true;
        }

        public long NewOnceTimer(long tillTime, Action action)
        {
            if (tillTime < TimeHelper.ServerNow())
            {
                Log.Error($"new once time too small: {tillTime}");
            }

            TimerAction timer = EntityFactory.CreateWithParent<TimerAction, TimerClass, long, object>(this, TimerClass.OnceTimer, 0, action, true);
            AddTimer(tillTime, timer);
            return timer.Id;
        }
    }
}