using System;
using System.Collections.Generic;
using Client.Manager;
using Cysharp.Threading.Tasks;
using ET;
using InternalResources;
using Panthea.Asset;
using Panthea.NativePlugins;
using RestaurantPreview.Config;
using UnityEngine;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 每次进入游戏的时候进入这个界面.之后游戏过程中不会再弹出这个界面
    /// 这个界面用于判断玩家的一些游戏参数是否正确.文件的完整性.以及文件更新
    /// 同时创建故事场景的所有显示内容
    /// </summary>
    [UIWidget(Depth = UIDeepEnum.GameLoading, IngoreBack = true)]
    public class UI_FirstGameLoading: UIBase<View_open_anim_front>
    {
        private double ProgressValue
        {
            get => View.Loading.value;
            set => View.Loading.TweenValue(value, 0.3f);
        }

        private List<UniTask> LoadQueue { get; } = new List<UniTask>();
        private bool IsFinishAllQueue { get; set; }

        protected override async void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.Loading.value = 0;
            if (Application.internetReachability != NetworkReachability.NotReachable && GameConfig.MobileRuntime)
            {
                LoadQueue.Add(FetchUpdateList());
            }
            else
            {
            }

            LoadQueue.Add(LoadConfig());
            try
            {
                await LoadQueue;
            }
            catch (Exception e)
            {
                Log.Error("GameStart Init:" + e);
            }

            IsFinishAllQueue = true;
        }

        private async UniTask LoadConfig()
        {
            if (GameConfig.MobileRuntime)
            {
                try
                {
                    IAssetsLocator assetsLocator = AssetsKit.Inst;
                    await assetsLocator.LoadAll(GameConfig.FoodConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
                    await assetsLocator.LoadAll(GameConfig.LevelConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
                    await assetsLocator.LoadAll(GameConfig.CookwareConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
                    await assetsLocator.Load<GameObject>("Model/Roles/Lisa/Lisa"); //加载人物
                    await assetsLocator.Load<RuntimeAnimatorController>("Model/Roles/Lisa/Kitchen"); //加载后厨人物动画
                    await assetsLocator.Load<Texture>("Image/Food/plate1_1"); //加载人物托盘
                    //Todo 暂时把加载顾客写在这里
                    foreach (var node in CustomerProperty.ReadDict())
                    {
                        await assetsLocator.Load<GameObject>(node.Value.ModelPath);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return;
                }
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
                    //进入游戏
                    //播放开屏动画
                    View.t2.Play();
                    MessageKit.Inst.Send(new GameStart());
                }
            }
        }
    }
}