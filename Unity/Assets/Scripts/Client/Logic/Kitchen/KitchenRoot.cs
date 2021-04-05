using System;
using Client.UI.ViewModel;
using Cysharp.Threading.Tasks;
using Kitchen;
using Kitchen.Provider;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenRoot: IDisposable
{
    /// <summary>
    /// 寻路组件.你可以传递其他继承该类的寻路支持器.重载寻路算法
    /// </summary>
    private KitchenMoveProvider mMoveProvider { get; set; }

    /// <summary>
    /// 餐厅结束支持器
    /// 重写这个支持器.我们可以在普通
    /// </summary>
    public EndOfKitchenProvider EndOfKitchenProvider { get; private set; }

    /// <summary>
    /// 顾客管理器
    /// </summary>
    public CustomerProvider CustomerProvider { get; private set; }

    /// <summary>
    /// 就餐位访问器,通过该组件可以获得就餐位的状态
    /// </summary>
    public KitchenSpotProvider SpotProvider { get; private set; }

    /// <summary>
    /// 餐厅的所有显示都在这个组件处理
    /// </summary>
    public KitchenScene Scene { get; private set; }

    /// <summary>
    /// 餐厅得所有操作记录
    /// 结束以后可以将这个记录传递至成就当中记录下来.或者在失败后丢弃
    /// </summary>
    public KitchenRecord Record { get; private set; }

    /// <summary>
    /// 给予餐厅可以连击的能力
    /// </summary>
    public ComboProvider ComboProvider { get; private set; }
    public UnitManager Units { get; } = new UnitManager();
    
    public LevelProperty LevelProperty { get; }
    public KitchenConfigProperty KitchenConfig { get; }
    private UIManager UiManager { get; }
    public Camera MainCamera { get; }
    public static KitchenRoot Inst { get; set; }
    public bool IsPause { get; private set; }
    public void Pause()
    {
        IsPause = true;
    }

    public void Resume()
    {
        IsPause = false;
    }
    
    public KitchenRoot(LevelProperty property, KitchenConfigProperty kitchenConfig)
    {
        UiManager = UIKit.Inst;
        KitchenConfig = kitchenConfig;
        Inst = this;
        MainCamera = Camera.main;
        LevelProperty = property;
        Initialize().Forget();
    }

    public async UniTaskVoid Initialize()
    {
        Record = new KitchenRecord();
        //KitchenScene必须要先初始化.后续的寻路和就餐位都是基于场景生成的
        Scene = new KitchenScene(LevelProperty);
        await Scene.Initialize();
        InitKitchenMoveProvider();
        InitSpotsProvider();
        InitCustomerGeneratorProvider();
        InitEndOfKitchenProvider();
        InitOtherProvider();
        //我们UI最后在初始化
        InitUI();
        UnityLifeCycleKit.Inst.AddUpdate(Update);
    }

    /// <summary>
    /// 初始化寻路服务 //0
    /// </summary>
    /// <returns></returns>
    private void InitKitchenMoveProvider()
    {
        mMoveProvider = new KitchenMoveProvider();
    }

    /// <summary>
    /// 初始化所有就餐位 //1
    /// </summary>
    private void InitSpotsProvider()
    {
        SpotProvider = new KitchenSpotProvider();
        //TODO 初始化就餐位不应该在Root中
        foreach (var display in Scene.GetSpots())
        {
            SpotProvider.AddSpot(new KitchenNormalSpot(display));
        }
    }

    /// <summary>
    /// 初始化顾客生成器 //2
    /// </summary>
    /// <returns></returns>
    private void InitCustomerGeneratorProvider()
    {
        CustomerProvider = new CustomerProvider(SpotProvider, LevelProperty);
        var normalCustomerGenerator = new NormalCustomerGenerator(LevelProperty);
        CustomerProvider.AddGenerator(normalCustomerGenerator);
    }

    /// <summary>
    /// 初始化关卡结束(通关,失败,主动退出)触发服务
    /// </summary>
    private void InitEndOfKitchenProvider()
    {
        EndOfKitchenProvider =
                new EndOfKitchenProvider(new EndOfNormalLevel(LevelProperty, Units.GetPlayer()), LevelProperty);
    }
    
    private void InitOtherProvider()
    {
        ComboProvider = new ComboProvider();
    }

    /// <summary>
    /// 初始化UI显示界面
    /// </summary>
    private void InitUI()
    {
        UiManager.Create<UI_KitchenMain>();
    }

    private float Update()
    {
        Units.Update();//这里让单位继续走Update是希望单位在即使暂停的情况下移动组件仍然能够继续Update.
        if (IsPause)
            return 0;
        Scene.Update();
        Record.PlayTime += Time.deltaTime;
        EndOfKitchenProvider.Update();
        CustomerProvider.Update();
        return 0;
    }

    public void Dispose()
    {
        UnityLifeCycleKit.Inst.RemoveUpdate(Update);
        foreach (var node in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            UnityEngine.Object.Destroy(node);
        }
    }

    public void Reset()
    {
        Scene.Reset();
        CustomerProvider.ClearGenerator();
        InitCustomerGeneratorProvider();
    }
}