using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Kitchen;
using Panthea.Asset;
using RestaurantPreview.Config;
using Spine.Unity;
using UnityEngine;
using SpineAnimation = Kitchen.SpineAnimation;

public class KitchenScene
{
    private IAssetsLocator mAssetsLocator { get; }
    private LevelProperty LevelProperty { get; }
    private List<FoodProperty> FoodList { get; } = new List<FoodProperty>();
    private Dictionary<CookwareProperty, List<ICookware>> mCookwareDisplays { get; } = new Dictionary<CookwareProperty, List<ICookware>>();
    private Dictionary<FoodProperty, IngredientDisplay> mIngredientDisplays { get; } = new Dictionary<FoodProperty, IngredientDisplay>();

    private List<UnityObject> Spots { get; } = new List<UnityObject>();
    private UnityObject mBaseScene { get; set; }
    private PlayerController Player { get; set; }
    public KitchenScene(LevelProperty property)
    {
        mAssetsLocator = AssetsKit.Inst;
        LevelProperty = property;
        InitRequireFoods();
    }

    private void InitRequireFoods()
    {
        foreach (var node in LevelProperty.Orders)
        {
            foreach (var property in node.Foods)
            {
                var data = FoodProperty.Read(property);
                if (!FoodList.Contains(data))
                {
                    FoodList.Add(data);
                }
            }
        }

        for (int i = 0; i < FoodList.Count; i++)
        {
            var food = FoodList[i];
            if (food == null)
            {
                throw new Exception("关卡ID:" + LevelProperty.Id + "  出错,存在一个未知的食物配置");
            }
            var ingredients = food.AllIngredients;
            for (int j = 0; j < ingredients.Count; j++)
            {
                FoodProperty node = FoodProperty.Read(ingredients[j]);
                if (node == null)
                {
                    throw new Exception("食物:" + food.Id + "的食材丢失,检查编辑器的食材列表");
                }
                if (!FoodList.Contains(node))
                {
                    FoodList.Add(node);
                }
            }
        }
    }

    public async UniTask Initialize()
    {
        List<UniTask> uniTasks = new List<UniTask>();
        await InitScene(); //BaseScene必须优先创建.因为下面的许多物体需要依赖这个Scene的架构
        uniTasks.Add(InitIngredients());
        uniTasks.Add(InitCookware());
        uniTasks.Add(CreateTrash());
        uniTasks.Add(CreateHoldingPlate());
        uniTasks.Add(InitPlayer());
        await UniTask.WhenAll(uniTasks);
    }

    private async UniTask InitScene()
    {
        mBaseScene = await AssetsKit.Inst.Instantiate("Model/Kitchen/Breakfast/c1");
        InitSpot(mBaseScene);
    }

    /// <summary>
    /// 初始化食材位置
    /// </summary>
    private async UniTask InitIngredients()
    {
        //创建食材
        foreach (var node in FoodList)
        {
            try
            {
                var pos = node.Position;
                if (pos.HasValue)
                {
                    await CreateIngredients(node, pos.Value);
                }
            }
            catch (Exception e)
            {
                Debug.LogError("创建" + node.Id + "发生错误\n" + e);
            }
        }
    }

    private async UniTask CreateIngredients(FoodProperty node, Vector3 pos)
    {
        var obj = new UnityObject(new GameObject(node.Id));
        var parent = mBaseScene.Find("Food");
        if (parent == null)
        {
            throw new Exception("请确认场景Prefab中是否存在名为Food的子物体");
        }

        obj.Parent = parent;
        var tex = await AssetsKit.Inst.Load<Sprite>(node.CurrentLevel.Texture);
        var renderer = obj.AddComponent<SpriteRenderer>();
        renderer.sprite = tex;
        obj.AddComponent<BoxCollider>();
        mIngredientDisplays[node] = new IngredientDisplay(obj, node);
        obj.LocalPosition = pos;
        obj.EulerAngles = new Vector3(30, 135, 0);
        obj.LocalScale = new Vector3(0.4f, 0.4f);
        obj.Layer = LayerHelper.IngoreNav;
        await UniTask.NextFrame();
        /*//方便调试食材的位置
#if UNITY_EDITOR
        UnityLifeCycleKit.Inst.AddUpdate(() =>
        {
            try
            {
                obj.Position = pos.Pos;
            }
            catch
            {
                //发生报错立即中断当前Update
                return -1;
            }

            return 0;
        });
#endif*/
    }

    /// <summary>
    /// 初始化厨具位置
    /// </summary>
    /// <returns></returns>
    private async UniTask InitCookware()
    {
        HashSet<string> alreadyCreate = new HashSet<string>();
        foreach (var foodProperty in FoodList)
        {
            var cookware = foodProperty.Cookware;
            if (cookware != null && !alreadyCreate.Contains(cookware))
            {
                alreadyCreate.Add(cookware);
                var data = CookwareProperty.Read(cookware);
                var detail = data.CurrentLevel;
                foreach (var pos in detail.Position)
                {
                    await CreateCookware(data, pos, detail,
                        (animation, o, property) =>
                        {
                            var cookware = new NormalCookware(property, o, new SpineAnimation(animation));
                            if (KitchenRoot.Inst.UsedProp.TryGetValue("灭火器", out var buff1))
                                cookware.Buffs.Add(new SlowerBurnRate(cookware, BuffProperty.Read("灭火器_" + buff1)));
                            if (KitchenRoot.Inst.UsedProp.TryGetValue("稳定火力", out var buff2))
                                cookware.Buffs.Add(new FasterCook(cookware, BuffProperty.Read("稳定火力_" + buff2)));
                            return cookware;
                        });
                }
            }
        }
    }

    /// <summary>
    /// 创建垃圾桶
    /// </summary>
    private async UniTask CreateTrash()
    {
        try
        {
            var trash = CookwareProperty.Read("K" + LevelProperty.Restaurant.Index + "垃圾桶");
            if (trash == null)
                return;
            var disPosList = trash.CurrentLevel.Position;
            foreach (var pos in disPosList)
            {
                await CreateCookware(trash, pos, trash.CurrentLevel, (animation, o, property) =>
                        new Trash(o, new SpineAnimation(animation)));
                return;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("创建垃圾桶失败\n" + e);
        }
    }

    /// <summary>
    /// 创建置物架
    /// </summary>
    private async UniTask CreateHoldingPlate()
    {
        try
        {
            var holdingPlate = CookwareProperty.Read("K" + LevelProperty.Restaurant.Index + "置物架");
            if (holdingPlate == null)
                return;
            var disPosList = holdingPlate.CurrentLevel.Position;
            foreach (var pos in disPosList)
            {
                await CreateCookware(holdingPlate, pos, holdingPlate.CurrentLevel, (animation, o, property) =>
                        new HoldingPlate(o, new SpineAnimation(animation)));
            }
        }
        catch (Exception e)
        {
            Debug.LogError("创建垃圾桶失败\n" + e);
        }
    }

    private async UniTask CreateCookware(CookwareProperty cookware, Vector3 pos, CookwareProperty.CookwareDetailProperty detail,
    Func<SkeletonAnimation, UnityObject, CookwareProperty, ICookware> registy)
    {
        try
        {
            var spineData = await AssetsKit.Inst.Load<SkeletonDataAsset>(detail.SpineData);
            SkeletonAnimation runtimeSkeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(spineData);
            UnityObject obj = new UnityObject(runtimeSkeletonAnimation.gameObject);
            var parent = mBaseScene.Find("Cookware");
            if (parent == null)
            {
                throw new Exception("请确认场景Prefab中是否存在名为Cookware的子物体");
            }

            obj.Parent = parent;
            obj.LocalPosition = pos;
            obj.EulerAngles = new Vector3(30, 135, 0);
            obj.LocalScale = new Vector3(0.4f, 0.4f, 0.4f);
            obj.Layer = LayerHelper.IngoreNav;
            obj.AddComponent<BoxCollider>();
            runtimeSkeletonAnimation.Initialize(false);
            runtimeSkeletonAnimation.Skeleton.SetSkin("default");
            runtimeSkeletonAnimation.Skeleton.SetSlotsToSetupPose();
            runtimeSkeletonAnimation.AnimationState.SetAnimation(0, "1normal", true);
            if (!mCookwareDisplays.TryGetValue(cookware, out var cookDisplayList))
            {
                mCookwareDisplays.Add(cookware, cookDisplayList = new List<ICookware>());
            }

            cookDisplayList.Add(registy(runtimeSkeletonAnimation, obj, cookware));
            await UniTask.NextFrame();
            //方便调试厨具的位置
/*#if UNITY_EDITOR
            UnityLifeCycleKit.Inst.AddUpdate(() =>
            {
                try
                {
                    obj.Position = pos.Pos;
                }
                catch
                {
                    //发生报错立即中断当前Update
                    return -1;
                }

                return 0;
            });
#endif*/
        }
        catch (Exception e)
        {
            Debug.LogError("创建厨具" + cookware.Id + "失败\n" + e);
        }
    }

    /// <summary>
    /// 初始化游戏角色 
    /// </summary>
    /// <returns></returns>
    private async UniTask InitPlayer()
    {
        var playerObject = await PlayerCreationFactory.CreateKitchenPlayer();
        var display = new PlayerDisplay(playerObject);
        Player = new PlayerController(display);
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        Player.Position = RestaurantProperty.Read(LevelProperty.Restaurant.Key).PlayerInitializePosition;
        Player.HandProvider.Clear();
    }

    /// <summary>
    /// 初始化餐位参数
    /// 必须在餐厅创建之后才能调用
    /// </summary>
    private void InitSpot(UnityObject go)
    {
        foreach (var node in go.GetComponentsInChildren<Transform>(true))
        {
            if (node.name.StartsWith("Spot_"))
            {
                Spots.Add(new UnityObject(node.gameObject));
            }
        }
    }

    #region Public Method

    public ReadOnlyCollection<UnityObject> GetSpots()
    {
        return Spots.AsReadOnly();
    }

    public ICookware GetCookware(Transform transform)
    {
        if (transform == null)
        {
            return null;
        }

        foreach (var node in mCookwareDisplays.Values)
        {
            foreach (var cookware in node)
            {
                if (cookware.Display.Equals(transform))
                {
                    return cookware;
                }
            }
        }

        return null;
    }
    

    public ICookware GetCookware(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return null;
        }

        foreach (var node in mCookwareDisplays)
        {
            foreach (var cookware in node.Value)
            {
                if (node.Key.Id == key)
                {
                    return cookware;
                }
            }
        }

        return null;
    }

    public ICookware GetCookware(CookwareProperty property)
    {
        if (property == null)
        {
            return null;
        }

        foreach (var node in mCookwareDisplays)
        {
            foreach (var cookware in node.Value)
            {
                if (node.Key == property)
                {
                    return cookware;
                }
            }
        }

        return null;
    }

    public IngredientDisplay GetIngredient(Transform transform)
    {
        if (transform == null)
        {
            return null;
        }

        foreach (var node in mIngredientDisplays.Values)
        {
            if (node.Display.Equals(transform))
            {
                return node;
            }
        }

        return null;
    }

    public IngredientDisplay GetIngredient(FoodProperty property)
    {
        if (property == null)
        {
            return null;
        }

        var foodId = property.Id;
        foreach (var node in mIngredientDisplays.Values)
        {
            if (node.FoodId == foodId)
            {
                return node;
            }
        }

        return null;
    }

    public IngredientDisplay GetIngredient(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return null;
        }

        foreach (var node in mIngredientDisplays)
        {
            if (node.Key.Id == key)
            {
                return node.Value;
            }
        }

        return null;
    }

    #endregion

    public void Reset()
    {
        ResetPlayer();
        foreach (var list in mCookwareDisplays.Values)
        {
            foreach (var node in list)
            {
                var count = node.FoodCount;
                for (int i = 0; i < count; i++)
                {
                    node.TakeFood();
                }
            }
        }
    }

    public void Update()
    {
        foreach (List<ICookware> list in mCookwareDisplays.Values)
        {
            foreach (var node in list)
            {
                node.Update();
            }
        }
    }
}