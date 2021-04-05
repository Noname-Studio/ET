using System;
using System.Collections.Generic;

namespace ET
{
    public class ETCancellationToken
    {
        private HashSet<Action> actions = new HashSet<Action>();

        public void Add(Action callback)
        {
            // 如果action是null，绝对不能添加,要抛异常，说明有协程泄漏
            actions.Add(callback);
        }

        public void Remove(Action callback)
        {
            actions?.Remove(callback);
        }

        public void Cancel()
        {
            if (actions == null)
            {
                return;
            }

            if (actions.Count == 0)
            {
                return;
            }

            Invoke();
        }

        private void Invoke()
        {
            HashSet<Action> runActions = actions;
            actions = null;
            try
            {
                foreach (Action action in runActions)
                {
                    action.Invoke();
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public async ETVoid CancelAfter(long afterTimeCancel)
        {
            if (actions == null)
            {
                return;
            }

            if (actions.Count == 0)
            {
                return;
            }

            await TimerComponent.Instance.WaitAsync(afterTimeCancel);

            Invoke();
        }
    }
}