using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EditorLevelGenerator : ScriptableObject
{
    public class FoodOrder
    {
        public FoodProperty Food;
        public int Weight;

        public FoodOrder(FoodProperty food, int weight)
        {
            Food = food;
            Weight = weight;
        }
    }
    
    [LabelText("从"),Required]
    public int From;
    [LabelText("至"),Required]
    public int To;
    
    [InfoBox("设定关卡成长时自动生成顾客数量的成长曲线")]
    [LabelText("服务食物数量成长曲线")]
    public AnimationCurve OrderGrowthCurve;

    [InfoBox("设定关卡成长时自动生成顾客数量的成长曲线")]
    [LabelText("顾客光顾数量成长曲线")]
    public AnimationCurve CustomerGrowthCurve;
    
    [InfoBox("你可以动态的控制每个关卡的难度条,越接近100则难度越高,反之则越低.AI会不停的检测判断.直到达成条件接近这个数值为止\n" +
             "难度<10 : 允许玩家丢弃垃圾,允许玩家烧焦,允许流失顾客,不会出现要求点赞数量的需求,不会出现时间要求\n" + 
             "难度<30 : 允许玩家丢弃垃圾,允许玩家烧焦,允许流失顾客,顾客开始出现复合订单(随难度增加生成概率)\n" +
             "难度<60 : 缩短玩家的通关时间,减少顾客来的数量,增加需求金币的数量,增加点赞的需求数量等,难度越高对厨具大于等于2级的需求越高,达到60顶峰时,所有食物都按照2级厨具的制作时间参数进行设定\n" +
             "难度<90 : 根据比例随机(1-3)项 ,不允许丢弃垃圾,不允许烧焦,不允许流失顾客,\n" +
             "难度<100 : 极大的增加玩家通关的需求条件,难度越高对厨具大于等于2级的需求越高,所有食物都按照3级厨具的制作时间参数进行设定,没有容错机会" )]
    [InfoBox("设定关卡成长时难度如何上升")]
    [LabelText("难度成长曲线")]
    public AnimationCurve DifficultyGrowthCurve;
    
    //[PropertyRange(0,100)]

    [LabelText("餐厅Key"),ValueDropdown("@RestaurantKey.EDITOR_RESTAURANTSELECT()"),Required]
    public string RestId;

    private const string Path = "Assets/Res/DB/Kitchen/";

    [Button("生成关卡")]
    public void Generator()
    {
        //TODO 写错了.这里是开启一个测试AI.
        {
            //先切换到指定得场景
            //EditorSceneManager.OpenScene("Assets/Scenes/Main.unity");

            //先开始游戏
            //if (!EditorApplication.isPlaying)
            //{
            //    EditorApplication.isPlaying = true;
            //}
            //
            ////然后实例化场景得Entiy
            //UIKit.Inst.Create<UI_Loading>(new UI_Loading.ParamsData
            //    {SceneKey = SceneKey.Kitchen, Data = new KitchenLoadData {Level = KitchenDataHelper.LoadLevel(RestaurantKey.Map(RestId) * 1000000 + From)}}).OnComplete(() =>
            //{
            //    //实例化一个新手AI
            //    Main.container.Instantiate<PlayerKitchenRobot_LowIntelligence>();
            //});
        }

        if (From > To)
        {
            Debug.LogError("开始关卡不能大于结束关卡");
            return;
        }

        List<FoodProperty> AllFoods = new List<FoodProperty>();
        List<CustomerProperty> AllCustomer = new List<CustomerProperty>();

        var dir = new DirectoryInfo(Application.dataPath + "/Res/DB/Kitchen/Foods");
        foreach (var node in dir.GetFiles("*.asset"))
        {
            var path = PathUtils.FullPathToUnityPath(node.FullName);
            var foodProperty = AssetDatabase.LoadAssetAtPath<FoodProperty>(path);
            if (foodProperty.RestId.Key == RestId)
            {
                AllFoods.Add(foodProperty);
            }
        }

        dir = new DirectoryInfo(Application.dataPath + "/Res/DB/Kitchen/Customer");
        foreach (var node in dir.GetFiles("*.asset"))
        {
            var path = PathUtils.FullPathToUnityPath(node.FullName);
            var customerProperty = AssetDatabase.LoadAssetAtPath<CustomerProperty>(path);
            AllCustomer.Add(customerProperty);
        }

        //开始生成关卡
        for (int level = From; level <= To; level++)
        {
            var dif = GetDifficulty(level);

            var leveltmp = level;
            var tmp = AllFoods.Where(t1 => t1.Levels.Count > 0 && leveltmp >= t1.Levels[0].UnlockLv).ToList();
            List<FoodOrder> canOrderFood = new List<FoodOrder>();
            for (int i = 0; i < tmp.Count; i++)
            {
                canOrderFood.Add(new FoodOrder(tmp[i], 100));
            }

            //订单数量
            int orderNumber = Mathf.FloorToInt(OrderGrowthCurve.Evaluate(level));

            //顾客数量
            int customerNumber = Mathf.FloorToInt(CustomerGrowthCurve.Evaluate(level));

            string path = Path + "Levels/" + (RestaurantKey.Map(RestId) * 1000000 + level) + ".asset";
            var reflectionType = typeof(LevelProperty);
            LevelProperty levelData = AssetDatabase.LoadAssetAtPath<LevelProperty>(path);
            if (levelData == null)
            {
                levelData = CreateInstance<LevelProperty>();
                AssetDatabase.CreateAsset(levelData, path);
                AssetDatabase.Refresh();
            }
            else
            {    
                //初始化
                levelData.Orders.Clear();
            }

            reflectionType.GetField("mLevel", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(levelData, level);
            reflectionType.GetField("mId", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(levelData, levelData.name);
            reflectionType.GetField("mRestaurantId", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(levelData, RestaurantKey.Breakfast.Key);
            //开始生成需求内容
            var req = levelData.Requirements;
            //计算通关所需最大金币数量
            float calcCoin = 0;
            //计算通关所需最大时间
            float calcTime = 0;
            //复合菜单出现的概率
            float compositeOrder = 0.1f;
            //生成顾客列表
            for (int i = 0; i < customerNumber; i++)
            {
                List<FoodProperty> foods = new List<FoodProperty>();
                int orderNum = 1;
                //生成复合菜单是有顾客间隔的.我们不能让复合菜单出现的太过频繁
                if (dif > 6)
                {
                    if (compositeOrder > Random.Range(0f, 1f))
                    {
                        compositeOrder = 0;
                        orderNum++;
                    }
                    else
                    {
                        compositeOrder += dif;
                    }
                }

                //生成食物列表,并在此处计算通关所需的最大时间和最大金币数量
                for (int k = 0; k < orderNum; k++)
                {
                    var orderFood = MathUtils.WeightMath(canOrderFood, t1 => t1.Weight);
                    var food = orderFood.Food;
                    //获得食物制作的厨具
                    var cookware = AssetDatabase.LoadAssetAtPath<CookwareProperty>(Path + "Cookwares/" + food.Cookware + ".asset");
                    if (cookware.Levels.Count == 0) //厨具不存在
                        continue;

                    foods.Add(food);

                    if (dif <= 30)
                        calcCoin += food.Levels[0].Tips;
                    else
                        calcCoin += food.Levels[1].Tips;

                    if (dif <= 30 && cookware.Levels.Count > 0)
                        calcTime += cookware.Levels[0].WorkTime - (cookware.Levels[0].WorkTime * (dif / 30)) + Random.Range(2, 7); //基础2秒是移动需要消耗的时间,
                    else if (dif <= 60 && cookware.Levels.Count > 1)
                        calcTime += cookware.Levels[1].WorkTime - (cookware.Levels[1].WorkTime * (dif / 60)) + Random.Range(2, 5); //基础2秒是移动需要消耗的时间,
                    else if (dif <= 90 && cookware.Levels.Count > 2)
                        calcTime += cookware.Levels[2].WorkTime - (cookware.Levels[2].WorkTime * (dif / 60)) + Random.Range(2, 4); //基础2秒是移动需要消耗的时间,
                    else if (dif <= 100 && cookware.Levels.Count > 2)
                        calcTime += cookware.Levels[2].WorkTime - (cookware.Levels[2].WorkTime * (dif / 60));
                    orderFood.Weight -= 33;
                    if (orderFood.Weight < 0)
                        canOrderFood.Remove(orderFood);
                }

                //levelData.Orders.Add(new CustomerOrder(AllCustomer[Random.Range(0, AllCustomer.Count)], foods));
            }

            //初始化额外条件.我们需要先初始化额外条件.去判断降低难度
            int maxExtReq = 3;
            List<int> extReq = new List<int> {0, 1, 2};
            if (dif <= 30)
            {
                req.AllowBurn = true;
                req.AllowUseTrash = true;
                req.AllowLostCustomer = true;
            }
            else if (dif <= 60)
            {
                var t = extReq[Random.Range(0, extReq.Count)];

                if (t == 0)
                    req.AllowBurn = false;
                else if (t == 1)
                    req.AllowLostCustomer = false;
                else if (t == 2)
                    req.AllowUseTrash = false;
            }

            if (dif > 60 && dif <= 100)
            {
                var t = extReq[Random.Range(0, extReq.Count)];
                if (t == 0)
                    req.AllowBurn = false;
                else if (t == 1)
                    req.AllowLostCustomer = false;
                else if (t == 2)
                    req.AllowUseTrash = false;
            }

            //生成关卡类型
            List<LevelType> levelTypes = new List<LevelType>
                {LevelType.FixedTime, LevelType.LikeCount, LevelType.NumberOfCompletedOrders, LevelType.NumberOfCustomerService, LevelType.Coin};
            if (dif <= 10)
            {
                levelTypes.Remove(LevelType.FixedTime);
            }

            if (dif <= 30)
            {
                levelTypes.Remove(LevelType.LikeCount);
            }

            dif.Value = dif - (dif * ((maxExtReq - extReq.Count) * 0.08f));

            int levelTypeNum = 1;
            if (dif >= 30)
            {
                levelTypeNum = 2;
            }

            LevelType levelType = LevelType.Unknown;
            for (int i = 0; i < levelTypeNum; i++)
            {
                LevelType type = levelTypes[Random.Range(0, levelTypes.Count)];
                if(levelType == LevelType.Unknown)
                    levelType = type;
                else
                    levelType |= type;
                if (type == LevelType.Coin)
                {
                    req.RequiredCoin = Mathf.FloorToInt(Random.Range(calcCoin * (dif / dif.Max), calcCoin));
                }
                else if (type == LevelType.NumberOfCompletedOrders)
                {
                    req.NumberOfCompletedOrders = orderNumber;
                }
                else if (type == LevelType.NumberOfCustomerService)
                {
                    req.NumberOfCustomerService = customerNumber;
                }
                else if (type == LevelType.FixedTime)
                {
                    req.FixedTime = Mathf.CeilToInt(calcTime);
                }

                var levelTypeField = levelData.GetType().GetField("mType", BindingFlags.Instance | BindingFlags.NonPublic);
                levelTypeField.SetValue(levelData, levelType);
            }
            
            //生成顾客间隔
            var orderIntervalField = levelData.GetType().GetField("mOrderInterval", BindingFlags.NonPublic | BindingFlags.Instance);
            RangeFloat orderIntervalValue = new RangeFloat(Mathf.Max(1, 2 * (1 - dif / 100)), Mathf.Max(1, 3 * (1 - dif / 100)));
            orderIntervalField.SetValue(levelData, orderIntervalValue);
            
            //生成耐心衰减速度
            var waitingDecayField = levelData.GetType().GetField("mWaitingDecay", BindingFlags.NonPublic | BindingFlags.Instance);
            DecayData waitingDecayValue = new DecayData(1, dif, dif);
            waitingDecayField.SetValue(levelData, waitingDecayValue);

            if (dif <= 5)
            {
                levelData.GetType().GetField("mMaxCustomerNumber", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(levelData,1);
            }
            else if (dif <= 15)
            {
                levelData.GetType().GetField("mMaxCustomerNumber", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(levelData,2);
            }
            else if (dif <= 30)
            {
                levelData.GetType().GetField("mMaxCustomerNumber", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(levelData,3);
            }
            else
            {
                levelData.GetType().GetField("mMaxCustomerNumber", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(levelData, 99);
            }
            EditorUtility.SetDirty(levelData);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public Difficulty GetDifficulty(int level)
    {
        var keys = DifficultyGrowthCurve.keys;
        float min = float.MaxValue;
        float max = float.MinValue;
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i].time < min)
                min = keys[i].time;
            if (keys[i].time > max)
                max = keys[i].time;
        }
        
        if(level < min || level > max)
        {
            Debug.LogError($"关卡成长曲线不够长.编辑器试图生成{level}关,但是关卡曲线并没有这一关的点");
            return null;
        }
        
        var dif = DifficultyGrowthCurve.Evaluate(level);
        if (dif <= 30)
        {
            return new Difficulty(0, dif,30);
        }
        else if (dif <= 60)
        {
            return new Difficulty(30, dif,60);
        }
        else if (dif <= 90)
        {
            return new Difficulty(60, dif,90);
        }
        else if (dif <= 100)
        {
            return new Difficulty(90, dif,100);
        }

        return null;
    }

    public class Difficulty
    {
        public int Min;
        public float Value;
        public int Max;

        public Difficulty(int min, float value, int max)
        {
            Min = min;
            Value = value;
            Max = max;
        }
        
        public static implicit operator float(Difficulty dif)
        {
            return dif.Value;
        }
    }
}
