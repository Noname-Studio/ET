public abstract class TimerAgent
{
    private TimerKit mTimerKit;

    /// <summary>
    /// 不要去修改这个值！！！
    /// </summary>
    public bool IsRunning { get; set; }

    /// <summary>
    /// 不要去修改这个值！！！
    /// </summary>
    public bool IsPause { get; set; }

    /// <summary>
    /// 不要去修改这个值！！！
    /// </summary>
    public bool IsFinish { get; set; }

    public string Key { get; }
    public float Interval { get; set; }

    /// <summary>
    /// 这个只是记录该计时器被创建到现在为止执行的时间
    /// </summary>
    public float TotalTime { get; private set; }

    /// <summary>
    /// 次数
    /// -1为无限次数
    /// 0表示不执行
    /// 1表示只执行1次
    /// </summary>
    public virtual int Times { get; set; } = -1;

    private float mCountingTime;

    public float CountingTime
    {
        get => mCountingTime;
        set
        {
            TotalTime += value;
            mCountingTime = value;
            if (mCountingTime >= Interval)
            {
                Run();
                mCountingTime = 0;
                if (Times > 0)
                {
                    Times--;
                }

                if (Times == 0)
                {
                    Stop();
                    IsFinish = true;
                }
            }
        }
    }

    public float RemainingTime
    {
        get
        {
            if (IsFinish)
            {
                return 0;
            }
            else
            {
                return Interval - mCountingTime;
            }
        }
    }

    public bool IngoreTimeScale = true;

    public TimerAgent(string key, float interval)
    {
        Key = key;
        Interval = interval;
        Reset();
    }

    protected virtual bool Condition()
    {
        return true;
    }

    public void Execute(float time)
    {
        if (Condition())
        {
            CountingTime += time;
        }
    }

    public abstract void Run();

    /// <summary>
    /// 如果为0则使用默认值.如果为-1则无限循环
    /// </summary>
    /// <param name="times"></param>
    public void Start(int times = 0)
    {
        if (times == 0)
        {
            times = Times;
        }

        mTimerKit.Start(this, times);
    }

    public void Stop(bool forceRemove = false)
    {
        Reset();
        mTimerKit.Stop(Key, forceRemove);
    }

    public void Pause()
    {
        mTimerKit.Pause(Key);
    }

    public void Resume()
    {
        mTimerKit.Resume(Key);
    }

    public void Play()
    {
        mTimerKit.Start(this, Times);
    }

    public void Reset()
    {
        TotalTime = 0;
        CountingTime = 0;
    }
}