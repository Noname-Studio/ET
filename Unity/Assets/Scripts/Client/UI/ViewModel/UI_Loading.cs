using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using InternalResources;
using UnityEngine;

namespace Client.UI.ViewModel
{
    [UIWidget(Depth = UIDeepEnum.GameLoading, Pool = true, IngoreBack = true, DontDestroyOnLoad = true)]
    public class UI_Loading: UIBase<View_Loading>
    {
        private double ProgressValue
        {
            get => View.Progress.value;
            set => View.Progress.TweenValue(value, 0.3f);
        }

        /// <summary>
        /// 加载进度条结束后触发回调
        /// </summary>
        private Action mOnCompleteCallback;

        /// <summary>
        /// 帧步数.即经过多少帧进度条更新一次
        /// </summary>
        private const float FrameStep = 10;

        private List<UniTask> LoadQueue { get; } = new List<UniTask>();
        private bool IsFinishAllQueue { get; set; }

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            Visible = true;
            IsFinishAllQueue = false;
            View.Progress.value = 0;
            mOnCompleteCallback = null;
            LoadQueue.Clear();
        }

        public void AddTask(UniTask task)
        {
            LoadQueue.Add(task);
        }

        public async UniTask StartTask()
        {
            try
            {
                await LoadQueue;
            }
            catch (Exception e)
            {
                Log.Error("GameStart Init:" + e);
            }

            IsFinishAllQueue = true;
            while (Visible)
            {
                await UniTask.NextFrame();
            }
        }

        public override async void Update()
        {
            if (ProgressValue >= 100)
            {
                return;
            }

            if (ProgressValue <= 80)
            {
                ProgressValue += IsFinishAllQueue? 3f : 1f;
            }
            else if (IsFinishAllQueue)
            {
                ProgressValue += 3f;
                if (ProgressValue >= 100)
                {
                    ProgressValue = 100;
                    await UniTask.Delay(700);
                    if (mOnCompleteCallback != null)
                    {
                        mOnCompleteCallback();
                    }

                    CloseMySelf();
                    Visible = false;
                }
            }
        }

        public UI_Loading OnComplete(Action action)
        {
            mOnCompleteCallback = action;
            return this;
        }
    }
}