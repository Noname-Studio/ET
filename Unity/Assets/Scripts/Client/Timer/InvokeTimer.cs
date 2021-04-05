using System;

namespace Client.Timer
{
    public class InvokeTimer : TimerAgent
    {
        private Action<InvokeTimer> Action { get; }
        public InvokeTimer(string key, float interval, Action<InvokeTimer> action,bool invokeAtStart): base(key, interval)
        {
            Action = action;
            if (invokeAtStart)
                Action(this);
        }

        public override void Run()
        {
            Action(this);
        }
    }
}