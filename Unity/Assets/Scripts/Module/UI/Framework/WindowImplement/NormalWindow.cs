using System;
using Common;
using DG.Tweening;
using DG.Tweening.Core;
using FairyGUI;
using UnityEngine;

public class NormalWindow: BaseWindow
{
    public WindowAnimType EnterWindowAnim = WindowAnimType.None;
    public WindowAnimType ExitWindowAnim = WindowAnimType.None;

    private bool mInAnimation;

    /// <summary>
    /// 正在播放动画
    /// </summary>
    public bool InAnimation
    {
        get => mInAnimation;
        private set => mInAnimation = value;
    }

    public Tween Tween;

    public Action<NormalWindow> CloseCallback;

    public override void OnClose(bool forceDestory)
    {
        base.OnClose(forceDestory);
        Tween?.Kill(false);
        GRoot.inst.HideWindowImmediately(this, !Base.Widget.Pool || forceDestory);

        //UIManager.Touchable(true);
        InAnimation = false;
        if (CloseCallback != null)
        {
            CloseCallback(this);
        }
    }

    public override void OnCreate()
    {
        base.OnCreate();
        InAnimation = false;
        //UIManager.Touchable(true);
    }

    protected override void DoShowAnimation()
    {
        InAnimation = true;
        //UIManager.Touchable(false);
        if (EnterWindowAnim == WindowAnimType.Custom)
        {
            Base.DoShowAnimation();
        }
        else
        {
            var animation = View_Animation.CreateInstance();
            animation.touchable = false;
            var cacheDisplay = Base.GComponent.displayObject;
            var cacheContainer = cacheDisplay.parent;
            PlayCompleteCallback onFinish = () =>
            {
                cacheContainer.AddChild(cacheDisplay);
                animation.Dispose();
                OnCreate();
            };
            animation.MakeFullScreen();
            var loader = (XUILoader) animation.Container;
            animation.sortingOrder = (int) Base.Widget.Depth;
            GRoot.inst.AddChild(animation);
            loader.WrapComponent(Base.GComponent);
            animation.GetTransition(EnterWindowAnim.ToName()).Play(1, 0, onFinish);
        }
    }

    protected override void DoHideAnimation()
    {
        InAnimation = true;
        //UIManager.Touchable(false);
        if (ExitWindowAnim == WindowAnimType.Custom)
        {
            Base.DoHideAnimation();
        }
        else
        {
            var animation = View_Animation.CreateInstance();
            animation.touchable = false;
            var cacheDisplay = Base.GComponent.displayObject;
            var cacheContainer = cacheDisplay.parent;
            PlayCompleteCallback onFinish = () =>
            {
                cacheContainer.AddChild(cacheDisplay);
                animation.Dispose();
                OnClose(false);
            };
            animation.MakeFullScreen();
            var loader = (XUILoader) animation.Container;
            animation.sortingOrder = (int) Base.Widget.Depth;
            GRoot.inst.AddChild(animation);
            loader.WrapComponent(Base.GComponent);
            animation.GetTransition(ExitWindowAnim.ToName()).Play(1, 0, onFinish);
        }
    }

    public NormalWindow(UIBase @base): base(@base)
    {
    }
}