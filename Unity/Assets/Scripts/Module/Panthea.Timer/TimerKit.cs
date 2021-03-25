using System.Collections.Generic;
using UnityEngine;

public class TimerKit
{
    public class TimerData
    {
        public TimerAgent Agent;
        public bool IsPause;
        public string Key;
        public TimerData(TimerAgent agent,int times)
        {
            Agent = agent;
            Agent.Times = times;
        }
    }

    private MessageKit mMessage;
    private UnityBehaviour mUpdateManger;
    
    private static TimerKit _inst;
    public static TimerKit Inst => _inst ?? (_inst = new TimerKit());
    
    public TimerKit()
    {
        mMessage = MessageKit.Inst;
        mUpdateManger = UnityLifeCycleKit.Inst;
        mUpdateManger.AddUpdate(XUpdate);
        //监听事件当游戏退出到后台得时候自动触发
        mMessage.Add(EventKey.OnApplicationPause, Pause);
        mMessage.Add(EventKey.OnApplicationFocus, Focus);
    }
    
    private Dictionary<string,TimerData> Timer = new Dictionary<string,TimerData>();
    private HashSet<string> mDelayRemove = new HashSet<string>();
    //记录上次游戏时间
    private long LastExecuteTime = 0;
    private void Focus()
    {
        var thisTime = TimeUtils.GetUtcTimeStamp();
        var remainTime = thisTime - LastExecuteTime;
        if (LastExecuteTime == 0)
            return;
        Log.Error("切换到后台的时间" + remainTime);
        //强制触发
        foreach(var node in Timer)
        {
            var ct = node.Value.Agent.CountingTime;
            float rt = remainTime;//把countingTime加回去.因为下面Execute得时候会顶掉原始得CountingTime
            float interval = node.Value.Agent.Interval;
            while(true)
            {
                if (rt >= interval)
                {
                    rt -= interval - node.Value.Agent.CountingTime;
                    node.Value.Agent.Execute(interval);
                }
                else
                {
                    //可能会有剩余时间.补上
                    node.Value.Agent.Execute(rt);
                    break;
                }
            }
        }

        LastExecuteTime = 0;
    }

    private void Pause()
    {
        LastExecuteTime = TimeUtils.GetUtcTimeStamp();
    }

    private float XUpdate()
    {
        #if UNITY_EDITOR
        if (!Application.isPlaying)
            return 0 ;
        #endif
        foreach (var node in mDelayRemove)
        {
            Timer.Remove(node);
        }
        mDelayRemove.Clear();
        foreach(var node in Timer)
        {
            node.Value.Agent.Execute(node.Value.Agent.IngoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
        }
        return 0;
    }

    public TimerData Get(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            Log.Error("Key不能为空");
            return null;
        }
        if (!Timer.ContainsKey(key))
        {
            return null;
        }

        return Timer[key];
    }
    
    public void Start(TimerAgent agent,int times)
    {
        string key = agent.Key;
        if (string.IsNullOrEmpty(key))
        {
            Log.Error("Key不能为空");
            return;
        }
        if (Timer.ContainsKey(key))
        {
            Log.Error($"Key:{key}已经存在无法添加");
            return;
        }
        var data = new TimerData(agent, times);
        data.Agent.IsRunning = true;
        data.Agent.IsFinish = false;
        data.Key = key;
        Timer.Add(key,data);
    }
    
    public void Pause(string key)
    {
        var data = Get(key);
        if (data == null)
            return;
        data.Agent.IsPause = true;
    }

    public void Resume(string key)
    {
        var data = Get(key);
        if (data == null)
            return;
        data.Agent.IsPause = false;
    }
    
    public void Stop(string key,bool forceRemove = false)
    {
        var data = Get(key);
        if (data == null)
            return;
        if (forceRemove)
            Timer.Remove(key);
        else
            mDelayRemove.Add(key);
        data.Agent.IsRunning = false;
    }

    public void ImmediatelyFinish(TimerAgent agent)
    {
        agent.CountingTime = agent.Interval;
        agent.IsFinish = true;
    }
}
