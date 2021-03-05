using System;
using Cysharp.Threading.Tasks;
using FairyGUI;
using Panthea.Asset;
using UnityEngine;
using Object = UnityEngine.Object;

public class StartGame
{
    public StartGame()
    {
        Initialize().Forget();
    }

    private async UniTaskVoid Initialize()
    {
        GlobalSetting();
        await LoadConfig();
        Start();
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
                /*foreach (var node in customer)
                {
                    foreach (var obj in node.Value)
                    {
                        var customerProperty = obj as CustomerProperty;
                        if (customerProperty != null) 
                            await assetsLocator.Load<GameObject>(customerProperty.ModelPath);
                    }
                }*/
            }
            catch(Exception e)
            {
                Debug.LogError(e);
                return;
            }
        }
    }
    
    private void GlobalSetting()
    {
        GRoot.inst.SetContentScaleFactor(UIGlobalConfig.UIDesignX,UIGlobalConfig.UIDesignY,UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
        //Application.targetFrameRate = 30;
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // 常亮
        Object.DontDestroyOnLoad(StageCamera.main.gameObject);
    }
    
    private void Start()
    {
        //mManager.Create<UI_FirstGameLoading>();
        UIKit.Inst.Create<Client.UI.ViewModel.UI_GuildList>();
    }
}
