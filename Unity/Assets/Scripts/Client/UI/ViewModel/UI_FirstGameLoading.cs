using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using InternalResources;
using Panthea.Asset;
using Panthea.NativePlugins;
using UnityEngine;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 每次进入游戏的时候进入这个界面.之后游戏过程中不会再弹出这个界面
    /// 这个界面用于判断玩家的一些游戏参数是否正确.文件的完整性.以及文件更新
    /// 同时创建故事场景的所有显示内容
    /// </summary>
    [UIWidget(Depth = UIDeepEnum.GameLoading)]
    public class UI_FirstGameLoading : UIBase<View_open_anim_front>
    {
        private double ProgressValue
        {
            get => View.Loading.value;
            set => View.Loading.TweenValue(value, 0.3f);
        }

        private List<UniTask> LoadQueue { get; } = new List<UniTask>();
        private bool IsFinishAllQueue { get; set; }
        public override async void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.Loading.value = 0;
            if (Application.internetReachability != NetworkReachability.NotReachable && GameConfig.MobileRuntime)
            {
                this.LoadQueue.Add(this.FetchUpdateList());
#if !UNITY_EDITOR
                this.LoadQueue.Add(this.CheckSdkInitialize());
#endif
            }
            else
            {
                
            }
            this.LoadQueue.Add(LoadConfig());
            try
            {
                await this.LoadQueue;
            }
            catch (Exception e)
            {
                Log.Error("GameStart Init:" + e);
            }
            this.IsFinishAllQueue = true;
        }
        
        private async UniTask LoadConfig()
        {
            if (GameConfig.MobileRuntime)
            {
                try
                {
                    IAssetsLocator assetsLocator = AssetsKit.Inst;
                    var customer = await assetsLocator.LoadAll(GameConfig.CustomerConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
                    await assetsLocator.LoadAll(GameConfig.FoodConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
                    await assetsLocator.LoadAll(GameConfig.IngredientConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
                    await assetsLocator.LoadAll(GameConfig.LevelConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
                    await assetsLocator.LoadAll(GameConfig.CookwareConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
                    await assetsLocator.Load<GameObject>("Model/Roles/Lisa/Lisa");//加载人物
                    await assetsLocator.Load<RuntimeAnimatorController>("Model/Roles/Lisa/Kitchen");//加载后厨人物动画
                    await assetsLocator.Load<Texture>("Image/Food/plate1_1");//加载人物托盘
                    //Todo 暂时把加载顾客写在这里
                    foreach (var node in customer)
                    {
                        foreach (var obj in node.Value)
                        {
                            var customerProperty = obj as CustomerProperty;
                            if (customerProperty != null) 
                                await assetsLocator.Load<GameObject>(customerProperty.ModelPath);
                        }
                    }
                }
                catch(Exception e)
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

        /// <summary>
        /// 检查SDK初始化是否正常
        /// </summary>
        /// <returns></returns>
        public async UniTask CheckSdkInitialize()
        {
            await PlatformLogin.Login();//连接GooglePlay & GameCenter
        }

        public override async void Update()
        {
            if (this.ProgressValue >= 100)
            {
                return;
            } 
            if(this.ProgressValue <= 80)
            {
                ProgressValue += IsFinishAllQueue ? 3f : 1f;
            }
            else if(this.IsFinishAllQueue)
            {
                ProgressValue += 3f;
                await UniTask.Delay(700);
                if (this.ProgressValue >= 100)
                {
                    this.ProgressValue = 100;
                    //进入游戏
                    //播放开屏动画
                    this.View.t2.Play();
                    MessageKit.Inst.Send(new GameStart());
                }
            }
        }
    }
}