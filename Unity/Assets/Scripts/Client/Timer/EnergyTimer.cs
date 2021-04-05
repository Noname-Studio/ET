using System;

public class EnergyTimer: TimerAgent
{
    public EnergyTimer(string key, int interval): base(key, interval)
    {
    }

    protected override bool Condition()
    {
        if (EnergyManager.Inst.CurEnergy < EnergyManager.Inst.MaxEnergy)
        {
            return true;
        }
        else
        {
            Reset();
            return false;
        }
    }

    public override void Run()
    {
        if (EnergyManager.Inst.CurEnergy < EnergyManager.Inst.MaxEnergy)
        {
            EnergyManager.Inst.Recover(1, false);
        }
    }
}