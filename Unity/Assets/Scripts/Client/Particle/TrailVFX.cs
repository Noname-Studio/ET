using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 幻影特效
/// 由于Unity原版的拖尾特效无法做的十分平滑.而且在拐弯会扭曲原图形.所以用脚本做一个
/// </summary>
public class TrailVFX : IUnityModule
{
    /// <summary>
    /// 统计时间
    /// </summary>
    private float mCountingTime { get; set; }
    private Vector3 mLastPosition { get; set; }
    public UnityObject BindTarget { get; set; }
    private TrailPool mPool { get; set; }
    private TrailArgs mArgs { get; set; }
    private List<ActiveObject> mActiveObjects { get; set; } = new List<ActiveObject>();
    public TrailVFX(TrailArgs args)
    {
        mPool = new TrailPool(() => BindTarget.Clone());
        mLastPosition = BindTarget.Position;
        mArgs = args;
        UnityLifeCycleKit.Inst.AddUpdate(Update);
    }

    private float Update()
    {
        var curPos = BindTarget.Position;
        if (curPos == mLastPosition)
        {
            return 0;
        }

        var dir = mLastPosition - curPos;
        var time = Time.deltaTime;
        int createTimes = 0;
        mCountingTime += time;
        for (int i = mActiveObjects.Count - 1; i >= 0; i--)
        {
            var obj = mActiveObjects[i];
            obj.LifeTime -= time;
            if (obj.LifeTime <= 0)
            {
                obj.Display.Dispose();
                mActiveObjects.RemoveAt(i);
            }
        }
        if (mCountingTime >= mArgs.Intervals)
        {
            while (true)
            {
                if (mCountingTime - mArgs.Intervals < 0)
                    break;
                mCountingTime -= mArgs.Intervals;
                createTimes++;
            }
        }

        for (int i = 1; i <= createTimes; i++)
        {
            var obj = mPool.Get();
            mActiveObjects.Add(new ActiveObject(mArgs.LifeTime, obj));
            obj.Position -= dir / i;
        }
        return 0;
    }

    private class TrailPool
    {
        private readonly ConcurrentBag<UnityObject> _objects;
        private readonly Func<UnityObject> _objectGenerator;

        public TrailPool(Func<UnityObject> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _objects = new ConcurrentBag<UnityObject>();
        }

        public UnityObject Get() => _objects.TryTake(out UnityObject item) ? item : _objectGenerator();

        public void Return(UnityObject item) => _objects.Add(item);
    }

    private class ActiveObject
    {
        public float LifeTime;
        public UnityObject Display;

        public ActiveObject(float lifeTime, UnityObject display)
        {
            LifeTime = lifeTime;
            Display = display;
        }
    }
    
    public class TrailArgs
    {
        /// <summary>
        /// 生成残影的间隔.间隔的时间越短残影之间的间隙越小
        /// </summary>
        public float Intervals { get; set; }
        /// <summary>
        /// 最大残影数量.超出的残影将会被回收到池中
        /// </summary>
        public int MaxNum { get; set; }
        /// <summary>
        /// 残影生命周期
        /// </summary>
        public float LifeTime { get; set; }
    }
}
