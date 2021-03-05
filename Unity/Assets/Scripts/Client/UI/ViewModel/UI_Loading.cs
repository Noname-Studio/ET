using System;
using Cysharp.Threading.Tasks;
using UI.Story.WithoutHot;
using UnityEngine;

namespace Client.UI.ViewModel
{
    public class UI_Loading : UIBase<View_Loading>
    {
        public class ParamsData : IUIParams
        {
            public SceneKey SceneKey;
            public ISceneLoadData Data;
        }
    
        private RestaurantSceneManager mSceneManager;

        private UI_Loading(RestaurantSceneManager sceneManager)
        {
            mSceneManager = sceneManager;
        }
    
        private ParamsData mArgs;
        private float ActualProgressValue;
        private float FakePrgressValue;
        /// <summary>
        /// 加载进度条结束后触发回调
        /// </summary>
        private Action mOnCompleteCallback;
    
        /// <summary>
        /// 帧步数.即经过多少帧进度条更新一次
        /// </summary>
        private const float FrameStep = 10;
        private float TotalFrame;
        private bool StopUpdate;
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            mArgs = p as ParamsData;
            if (mArgs == null)
            {
                Debug.LogError($"找不到Type为{nameof(ParamsData)}的参数,或者参数为Null");
                CloseMySelf();
                return;
            }

            StartLoad();
        }

        private async void StartLoad()
        {
            var progress = Progress.Create<float>(f => ActualProgressValue = f);
            await mSceneManager.Load(mArgs.SceneKey, mArgs.Data, progress);
            if (mOnCompleteCallback != null) mOnCompleteCallback();
        }
    
        public override void Update()
        {
            if (View.Progress.value >= 1)
            {
                CloseMySelf();
            }
            if (TotalFrame >= FrameStep && !StopUpdate)
            {
                if (FakePrgressValue >= 0.8f)
                {
                    //虚假的进度条已经到了接近尾声了.但是实际进度条还在加载.我们停止进度条更新
                    if (ActualProgressValue < 1)
                    {
                        return;
                    }
                }
                else
                {
                    //实际进度条已经加载完毕.我们加速进度条的更新
                    if (ActualProgressValue >= 1)
                    {
                        FakePrgressValue = 0.95f;
                        return;
                    }
                }
                FakePrgressValue += 0.05f;
                View.Progress.TweenValue(FakePrgressValue, 0.3f);
                if (FakePrgressValue >= 1)
                    StopUpdate = true;
            }
            TotalFrame++;
        }

        public UI_Loading OnComplete(Action action)
        {
            mOnCompleteCallback = action;
            return this;
        }
    }
}
