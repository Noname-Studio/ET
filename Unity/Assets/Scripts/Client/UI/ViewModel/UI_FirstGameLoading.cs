using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using InternalResources;
using Panthea.Asset;
using UnityEngine;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 每次进入游戏的时候进入这个界面.之后游戏过程中不会再弹出这个界面
    /// 这个界面用于判断玩家的一些游戏参数是否正确.文件的完整性.以及文件更新
    /// 同时创建故事场景的所有显示内容
    /// </summary>
    public class UI_FirstGameLoading : UIBase<View_open_anim_front>
    {
        private double ProgressValue
        {
            get => View.Loading.value;
            set => View.Loading.TweenValue(value, 0.3f);
        }

        private List<UniTask> mLoadQueue = new List<UniTask>();
        
        public override async void OnInit(IUIParams p)
        {
            base.OnInit(p);
            if (Application.internetReachability == NetworkReachability.NotReachable && GameConfig.MobileRuntime)
            {
                this.mLoadQueue.Add(this.FetchUpdateList());
                this.mLoadQueue.Add(this.FetchUpdateList());
            }
            else
            {
                
            }
        }

        /// <summary>
        /// 下载资源
        /// </summary>
        /// <returns></returns>
        public async UniTask FetchUpdateList()
        {
            var assetMgr = (AssetsManager) AssetsKit.Inst;
            var downloadList = await assetMgr.FetchDownloadList();
            await assetMgr.Download(downloadList);
        }

        /// <summary>
        /// 检查SDK初始化是否正常
        /// </summary>
        /// <returns></returns>
        public async UniTask CheckSdkInitialize()
        {
            Social.localUser.Authenticate(b =>
            {
                Debug.LogError("初始化完成");
            });
        }

        public override void Update()
        {
            base.Update();
            if (Time.frameCount % 5 == 0)
            {
                ProgressValue += 0.01f;
            }
        }
    }
}