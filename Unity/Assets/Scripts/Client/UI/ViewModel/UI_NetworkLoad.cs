using System;
using Common;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UI_NetworkLoad : UIBase<View_NetworkLoad>
{
    private Func<bool> CloseCallback;
    private Action OutOfTimeCallback;
    private float IntevalTime { get; set; }
    private UniTaskCompletionSource Tcs { get; set; }
    private float DestoryTime { get; set; }
    public UI_NetworkLoad OutOfTime(float time,Action callback = null)
    {
        DestoryTime = time;
        OutOfTimeCallback = callback;
        return this;
    }

    public async UniTask Wait(Func<bool> callback)
    {
        if (Tcs != null)
            return;
        CloseCallback = callback;
        Tcs = new UniTaskCompletionSource();
        await Tcs.Task;
    }

    public override void Update()
    {
        base.Update();
        IntevalTime = Time.unscaledDeltaTime;
        if (DestoryTime > 0)
        {
            if (IntevalTime >= DestoryTime)
            {
                Tcs?.TrySetResult();
                if (OutOfTimeCallback != null) 
                    OutOfTimeCallback();
                CloseMySelf();
            }
        }

        if (CloseCallback != null)
        {
            if (CloseCallback())
                Tcs?.TrySetResult();
            CloseMySelf();
        }
    }
}
