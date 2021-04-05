using System;
using UnityEngine;

public class InfineEnergyTimer: TimerAgent
{
    private long targetTime;

    public InfineEnergyTimer(string key, int interval): base(key, interval)
    {
    }

    public void SetTarget(long timeStamp)
    {
        targetTime = timeStamp;
    }

    public override void Run()
    {
        if (TimeUtils.GetUtcTimeStamp() >= targetTime)
        {
            EnergyManager.Inst.ClearInfine();
        }
    }
}