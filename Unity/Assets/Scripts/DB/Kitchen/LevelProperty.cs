using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Sirenix.OdinInspector;
using Spine.Unity;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

[Serializable]
public class RangeFloat
{
    [LabelText("最小值")]public float Min;
    [LabelText("最大值")]public float Max;

    public RangeFloat(float min, float max)
    {
        Min = min;
        Max = max;
    }
}

[Serializable]
public class RangeInt
{
    [LabelText("最小值")]public int Min;
    [LabelText("最大值")]public int Max;

    public RangeInt(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

/// <summary>
/// 订单产生模式
/// </summary>
public enum OrderMode
{
    [LabelText("随机模式")] Random, // 随机模式
    [LabelText("订单池模式")] OrderPool // 订单池模式
}

[Flags]
public enum LevelType
{
    [LabelText("未知")]Unknown = 1 << 0,
    [LabelText("收集金币")]Coin = 1 << 1,
    [LabelText("固定时间")]FixedTime = 1 << 2,
    [LabelText("服务顾客")]NumberOfCustomerService = 1 << 3,
    [LabelText("流失顾客")]LostCustomer = 1 << 4,
    [LabelText("收集点赞")]LikeCount = 1 << 5,
    [LabelText("完成订单")]NumberOfCompletedOrders = 1 << 6,
}

public enum DifficultType
{
    [LabelText("简单关卡")]EasyLevel,
    [LabelText("普通关卡")]MiddleLevel,
    [LabelText("困难关卡")]HardLevel
}

[Serializable]
public class ComboConfig
{
    [LabelText("连击间隔时间(秒)")] public float Interval = 5; // 连击间隔时间（秒）
    [LabelText("连击增益系数")] public float Gain = 0.35f; // 连击增益系数
}

[Serializable]
public class DecayData
{
    [LabelText("衰减间隔")]public float Interval; // 衰减间隔
    [LabelText("每次衰减比例")]public float Rate; // 每次衰减比例
    [LabelText("衰减极限值")]public float Limit; // 衰减极限值

    public DecayData()
    {
    }

    public DecayData(float interval, float rate, float limit = -1)
    {
        Interval = interval;
        Rate = rate;
        Limit = limit;
    }
}

[Serializable]
public class RewardData
{
    [LabelText("ID")]public int ItemID; // 奖励的物品ID
    [LabelText("数量")]public int ItemCount; // 奖励的物品数量
}

[Serializable]
public partial class CustomerOrder
{
    [LabelText("顾客名称"),AssetSelector(Paths = "Assets/Res/DB/Kitchen/Customer",ExcludeExistingValuesInList = true)]
    [HorizontalGroup("xx1"),PropertyOrder(-5),HideLabelAttribute,SerializeField]
    private CustomerProperty mCustomer;
    public CustomerProperty Customer
    {
        get { return mCustomer; }
    }
    
    [LabelText("食物列表"),ListDrawerSettings(ShowIndexLabels = false,NumberOfItemsPerPage = 1,Expanded = true)]
    [HorizontalGroup("xx1"),HideLabelAttribute,SerializeField]
    private List<FoodProperty> mFoods = new List<FoodProperty>();
    public ReadOnlyCollection<FoodProperty> Foods;
    public CustomerOrder()
    {
        Foods = new ReadOnlyCollection<FoodProperty>(mFoods);
    }
}

[Serializable]
public class SecretCustomer
{
    [LabelText("顾客")]public CustomerProperty Customer;
    [LabelText("出现在第几个顾客后")]public int ShowOrder; // 第几次出现之前都会显示订单
}

[Serializable]
public class Requirements
{
    [Serializable]
    public class RequireFood
    {
        [LabelText("食物")]public FoodProperty Data;
        [LabelText("数量")]public int Number;
    }
    [LabelText("是否允许烧焦")]public bool AllowBurn = true; // 是否允许烧焦
    [LabelText("是否允许流失顾客")]public bool AllowLostCustomer = true; // 是否允许流失顾客
    [LabelText("是否允许使用垃圾桶")]public bool AllowUseTrash = true; // 是否允许使用垃圾桶
    [LabelText("收集金币"),ShowIf("@Main.Type.HasFlag(LevelType.Coin)")] public int RequiredCoin;
    [LabelText("收集点赞"),ShowIf("@Main.Type.HasFlag(LevelType.LikeCount)")]public int LikeCount; //
    [LabelText("限定时间"),ShowIf("@Main.Type.HasFlag(LevelType.FixedTime)")]public int FixedTime; //
    [LabelText("流失顾客"),ShowIf("@Main.Type.HasFlag(LevelType.LostCustomer)")]public int LostCustomer; //

    [LabelText("服务顾客个数"), ShowIf("@Main.Type.HasFlag(LevelType.NumberOfCustomerService)")] public int NumberOfCustomerService;
    [LabelText("服务食物个数"),ShowIf("@Main.Type.HasFlag(LevelType.NumberOfCompletedOrders)")] public int NumberOfCompletedOrders;
    //[LabelText("保鲜食物数量")]public int anyFreshFoodCount; // 任意保鲜食物的数量
    //[LabelText("")]public List<NameAndNumber> requiredFreshFoods = new List<NameAndNumber>(); // 需要保鲜的食物个数
    //[LabelText("三连次数")]public int Combo3Count; // 需要收集的三连次数
    //[LabelText("四连次数")]public int Combo4Count; // 需要收集的四连次数
    //[LabelText("需要累计连续服务奖励金币")]public int ComboCoin; //需要连续服务服务奖励金币
#if UNITY_EDITOR
    private LevelProperty Main;
    #endif
}

[Serializable]
public class ChallengeReward
{
    [LabelText("奖励描述")]public int Time;
    [LabelText("奖励金币")]public int Coin;
    [LabelText("奖励钻石")]public int Gem;
    [LabelText("奖励物品")]public string[] Items;
}

[Serializable]
public partial class LevelProperty : SerializedScriptableObject
{
    [BoxGroup("常用")]
    [BoxGroup("常用/Split/基础设定", true, false, 0),HorizontalGroup("常用/Split", 0.0f, 0, 0, 0, LabelWidth = 130)]
    [VerticalGroup("常用/Split/基础设定/Left")]
    [SerializeField,LabelText("真实ID"),Sirenix.OdinInspector.ReadOnly] 
    private int mId;
    [SerializeField,Required, LabelText("关卡ID"),VerticalGroup("常用/Split/基础设定/Left"),OnValueChanged("OnIdChanged")]
    private int mLevel; // 关卡ID
    [Required, ValueDropdown("@RestaurantKey.EDITOR_RESTAURANTSELECT()"),SerializeField,VerticalGroup("常用/Split/基础设定/Left"),LabelText("餐厅ID"),OnValueChanged("OnIdChanged")] 
    private string mRestaurantId = RestaurantKey.Unknown.Key; // 所属餐厅的ID
    [SerializeField, LabelText("订单产生模式"),ValueDropdown("EDITOR_OrderMode"),VerticalGroup("常用/Split/基础设定/Left")] 
    private OrderMode mOrderMode = OrderMode.OrderPool; // 订单产生模式
    [SerializeField, LabelText("关卡类型"),VerticalGroup("常用/Split/基础设定/Left")] 
    private LevelType mType; // 关卡类型
    [SerializeField, LabelText("难度"),ValueDropdown("EDITOR_DifficultType"),VerticalGroup("常用/Split/基础设定/Left")] 
    private DifficultType mDifType = DifficultType.MiddleLevel;
    [SerializeField, LabelText("阶段"), VerticalGroup("常用/Split/基础设定/Left")] private int mSection; //属于本餐厅第几个阶段的关卡 动态计算得出
    [SerializeField, LabelText("刷金币关卡"), VerticalGroup("常用/Split/基础设定/Left")] private bool mCoinLevelEnable = true;
    [SerializeField, LabelText("同时存在的最大订单数"),VerticalGroup("常用/Split/基础设定/Left")] private int mMaxOrder; 

    [SerializeField, FoldoutGroup("过关条件",Expanded = true), HideLabel] private Requirements mRequirements = new Requirements(); // 过关条件
    [LabelText("订单列表"), SerializeField,HideIf("OrderMode",OrderMode.Random),ListDrawerSettings(NumberOfItemsPerPage = 5)] private List<CustomerOrder> mOrders = new List<CustomerOrder>(); // 订单列表
    [SerializeField, LabelText("奖励的物品列表")] private List<RewardData> mRewards = new List<RewardData>(); // 奖励的物品列表
    [SerializeField, LabelText("神秘顾客列表")] private List<SecretCustomer> mSecretCustomers = new List<SecretCustomer>(); // 神秘顾客列表

    //[ShowInInspector, LabelText("顾客光顾最小间隔"),BoxGroup("顾客基础设定")] private float mMinCustomerInterval;
    [SerializeField, HideLabel, BoxGroup("顾客基础设定"), FoldoutGroup("顾客基础设定/订单间隔范围")] private RangeFloat mOrderInterval = new RangeFloat(0, 0); // 订单的间隔范围
    [SerializeField, HideLabel, BoxGroup("顾客基础设定"), FoldoutGroup("顾客基础设定/顾客扔垃圾的间隔")] private RangeInt mLitterInterval = new RangeInt(0, 0); // 顾客扔垃圾的间隔
    [SerializeField, HideLabel, BoxGroup("顾客基础设定"), FoldoutGroup("顾客基础设定/订单出现时间衰减")] private DecayData mOrderDecay = new DecayData(); // 订单出现时间衰减,随时间加速顾客来的频率
    [SerializeField, HideLabel, BoxGroup("顾客基础设定"), FoldoutGroup("顾客基础设定/耐心衰减参数")] private DecayData mWaitingDecay = new DecayData(); // 耐心衰减参数
    [SerializeField, HideLabel, BoxGroup("顾客基础设定"), FoldoutGroup("顾客基础设定/首次出现顾客的时间")] private List<float> mFirstArrivals = new List<float>(); // 首次出现顾客的时间

    [SerializeField, HideLabel, BoxGroup("顾客基础设定/最大顾客数量")] private int mMaxCustomerNumber = 0;
    //[SerializeField, BoxGroup("厨具损坏的间隔"), HideLabel] private RangeInt mBrokenInterval = new RangeInt(0, 0); // 厨具损坏的间隔
    
    [SerializeField, FoldoutGroup("厨具基础设定/制作时间衰减"), BoxGroup("厨具基础设定"), HideLabel] private DecayData mCookingDecay = new DecayData(); // 制作时间衰减
    [SerializeField, FoldoutGroup("厨具基础设定/烧焦时间衰减"), BoxGroup("厨具基础设定"), HideLabel] private DecayData mBurnDecay = new DecayData(); // 烧焦时间衰减

    //[ShowInInspector, LabelText("必须完成任务列表")]
    //private List<string> mRequiredTasks = new List<string>(); // 进入关卡前必须先完成的任务列表

    //[ShowInInspector, LabelText("订单池")] private List<List<string>> mOrderPool = new List<List<string>>(); // 订单池
    //[ShowInInspector, LabelText("顾客池")] private List<string> mCustomerPool = new List<string>(); // 顾客池
    //[ShowInInspector, LabelText("限定订单序列长度")] private int mOrderSequenceLength; // 限定订单序列的长度

    [SerializeField, LabelText("延长关卡顾客列表")] private List<CustomerProperty> mExtendCustomers = new List<CustomerProperty>(); // 延长关卡顾客列表

    [FoldoutGroup("连击设定"), HideLabel, SerializeField] private ComboConfig mComboCfg = new ComboConfig();

    [ShowInInspector, BoxGroup("备注"), TextArea,HideLabel] private string mComments = ""; // 关卡设计备注

    public int Id => mId;
    public int LevelId => mLevel;

    public OrderMode OrderMode => mOrderMode;

    public RestaurantKey RestaurantId => RestaurantKey.Wrap(mRestaurantId);

    public LevelType Type => mType;

    public DifficultType DifType => mDifType;

    public ComboConfig ComboCfg => mComboCfg;

    public int MaxOrder => mMaxOrder;

    public List<float> FirstArrivals => mFirstArrivals;

    public RangeFloat OrderInterval => mOrderInterval;

    public RangeInt LitterInterval => mLitterInterval;

    public DecayData WaitingDecay => mWaitingDecay;

    public DecayData CookingDecay => mCookingDecay;

    public DecayData BurnDecay => mBurnDecay;

    public DecayData OrderDecay => mOrderDecay;

    public List<CustomerOrder> Orders => mOrders;

    public List<SecretCustomer> SecretCustomers => mSecretCustomers;

    public List<CustomerProperty> ExtendCustomers => mExtendCustomers;

    public List<RewardData> Rewards => mRewards;

    public Requirements Requirements => mRequirements;

    public int Section => mSection;

    public bool CoinLevelEnable => mCoinLevelEnable;

    public string Comments => mComments;

    public int MaxCustomerNumber => mMaxCustomerNumber;
}


#if UNITY_EDITOR
public partial class LevelProperty
{
    private bool IdChanged;
    [Button(ButtonSizes.Large,Name = "应用"),VerticalGroup("常用/Split/基础设定/Left"),ShowIf("@IdChanged == true")]
    private void Apply()
    {
        var path = AssetDatabase.GetAssetPath(this);
        var error = AssetDatabase.RenameAsset(path, mId + ".asset");
        if (!string.IsNullOrEmpty(error))
            Log.Error(error);
        else
            IdChanged = false;
    }

    
    private static ValueDropdownList<OrderMode> EDITOR_OrderMode = new ValueDropdownList<OrderMode>
    {
        {"固定模式", OrderMode.OrderPool},
        {"随机订单", OrderMode.Random}
    };
    
    private static ValueDropdownList<DifficultType> EDITOR_DifficultType = new ValueDropdownList<DifficultType>
    {
        {"简单难度", DifficultType.EasyLevel},
        {"普通难度", DifficultType.MiddleLevel},
        {"困难难度", DifficultType.HardLevel}
    };
    
    private static ValueDropdownList<LevelType> EDITOR_LevelType = new ValueDropdownList<LevelType>
    {
        {"收集金币", LevelType.Coin},
        {"固定时间", LevelType.FixedTime},
        {"流失顾客", LevelType.LostCustomer},
        {"服务顾客", LevelType.NumberOfCustomerService},
        {"固定顾客", LevelType.NumberOfCustomerService},
        {"收集点赞", LevelType.LikeCount},
        {"完成订单", LevelType.NumberOfCompletedOrders},
    };
    
    protected override void OnBeforeSerialize()
    {
        base.OnBeforeSerialize();
        Requirements.GetType().GetField("Main",BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Requirements, this);
    }

    private void OnIdChanged()
    {
        var rest = RestaurantId.Index * 1000000;
        mId = rest + mLevel;
        var path = AssetDatabase.GetAssetPath(this);
        var fileName = Path.GetFileNameWithoutExtension(path);
        IdChanged = !mId.ToString().Equals(fileName);
    }
}
#endif