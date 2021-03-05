using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Kitchen;
using Panthea.Asset;
using Spine.Unity;
using UnityEngine;
using SpineAnimation = Kitchen.SpineAnimation;

public class KitchenScene
{
    private IAssetsLocator mAssetsLocator;
    private LevelProperty LevelProperty { get; }
    private List<FoodProperty> FoodList { get; } = new List<FoodProperty>();
    private Dictionary<CookwareProperty, List<ICookware>> mCookwareDisplays = new Dictionary<CookwareProperty, List<ICookware>>();

    private Dictionary<IngredientProperty, IngredientDisplay> mIngredientDisplays =
        new Dictionary<IngredientProperty, IngredientDisplay>();

    private List<UnityObject> Spots = new List<UnityObject>();
    private UnityObject mBaseScene;
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
                if(!FoodList.Contains(property))
                    FoodList.Add(property);
            }
        }

        for (int i = 0; i < FoodList.Count; i++)
        {
            var food = FoodList[i];
            var ingredients = food.AllIngredients;
            for(int j = 0;j<ingredients.Count;j++)
            {
                BaseIngredient node = ingredients[j];
                if (IngredientHelper.IsFood(node))
                {
                    var property = (FoodProperty)node;
                    if(!FoodList.Contains(property))
                        FoodList.Add(property);
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

    async UniTask InitScene()
    {
        mBaseScene = await AssetsKit.Inst.Instantiate("Model/Kitchen/Breakfast/c1");
        InitSpot(mBaseScene);
    }

    /// <summary>
    /// 初始化食材位置
    /// </summary>
    async UniTask InitIngredients()
    {
        HashSet<IngredientProperty> ingredientProperties = new HashSet<IngredientProperty>();
        foreach (var foodProperty in FoodList)
        {
            //没有制作的食材?说明这个食物自身就是食材.
            if (foodProperty.AllIngredients != null)
            {
                foreach (var ingredient in foodProperty.AllIngredients)
                {
                    //食物是另外制作的.不需要创建出来
                    if (IngredientHelper.IsFood(ingredient))
                        continue;
                    var prop = (IngredientProperty)ingredient;
                    if (prop == null)
                    {
                        throw new Exception("找不到对应的食材" + ingredient);
                    }

                    ingredientProperties.Add(prop);
                }
            }
            else
            {
                //await mAssetsLocator.Load<LevelProperty>(GameConfig.IngredientConfigPath + RestaurantKey.Map(property.RestaurantId) + "/" + food.Key);
            }
        }

        //创建食材
        foreach (var node in ingredientProperties)
        {
            try
            {
                var disPosList = node.DisPosList;
                bool hasCreate = false;
                foreach (var pos in disPosList)
                {
                    if (LevelProperty.Id >= pos.Start && LevelProperty.Id <= pos.End)
                    {
                        if (pos.Restaurant == LevelProperty.RestaurantId)
                        {
                            await CreateIngredients(node, pos);
                            hasCreate = true;
                            break;
                        }
                    }
                }

                if (hasCreate == false) //没有找到匹配项.尝试查找默认项
                {
                    foreach (var pos in disPosList)
                    {
                        if (pos.Start == 0 && pos.End == 0)
                        {
                            if (pos.Restaurant == LevelProperty.RestaurantId)
                            {
                                await CreateIngredients(node, pos);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("创建" + node.Key + "发生错误\n" + e);
            }
        }
    }

    private async UniTask CreateIngredients(IngredientProperty node, ReachItemDPosition pos)
    {
        var obj = new UnityObject(new GameObject(node.Key));
        var parent = mBaseScene.Find("Food");
        if(parent == null)
            throw new Exception("请确认场景Prefab中是否存在名为Food的子物体");
        obj.Parent = parent;
        var tex = await AssetsKit.Inst.Load<Sprite>(node.Texture);
        var renderer = obj.AddComponent<SpriteRenderer>();
        renderer.sprite = tex;
        obj.AddComponent<PolygonCollider2D>();
        mIngredientDisplays[node] = new IngredientDisplay(obj, node);
        obj.LocalPosition = pos.Pos;
        obj.LocalScale = new Vector3(0.9f,0.9f);
        //方便调试食材的位置
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
#endif
    }

    /// <summary>
    /// 初始化厨具位置
    /// </summary>
    /// <returns></returns>
    async UniTask InitCookware()
    {
        HashSet<string> alreadyCreate = new HashSet<string>();
        foreach (var foodProperty in FoodList)
        {
            var cookware = foodProperty.Cookware;
            if (cookware != null && !alreadyCreate.Contains(cookware.Key))
            {
                alreadyCreate.Add(cookware.Key);
                var disPosList = cookware.DisPosList;
                var detail = cookware.Current;
                bool hasCreate = false;
                foreach (var pos in disPosList)
                {
                    if (LevelProperty.Id >= pos.Start && LevelProperty.Id <= pos.End)
                    {
                        if (pos.Restaurant == LevelProperty.RestaurantId && detail.Level >= pos.Level)
                        {
                            CreateCookware(cookware, pos, detail, 
                                (animation, o, property) =>
                                    new NormalCookware(property, o, new SpineAnimation(animation)));
                            hasCreate = true;
                        }
                    }
                }

                if (hasCreate == false) //没有找到匹配项.尝试查找默认项
                {
                    foreach (var pos in disPosList)
                    {
                        if (pos.Start == 0 && pos.End == 0)
                        {
                            if (pos.Restaurant == LevelProperty.RestaurantId && detail.Level >= pos.Level)
                            {
                                CreateCookware(cookware, pos, detail, 
                                    (animation, o, property) =>
                                        new NormalCookware(property, o, new SpineAnimation(animation)));
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 创建垃圾桶
    /// </summary>
    async UniTask CreateTrash()
    {
        try
        {
            var trash = KitchenDataHelper.LoadCookware("k" + LevelProperty.RestaurantId.Index + "_trash");
            var disPosList = trash.DisPosList;
            foreach (var pos in disPosList)
            {
                if ((LevelProperty.Id >= pos.Start && LevelProperty.Id <= pos.End) || (pos.Start == 0 && pos.End == 0))
                {
                    if (pos.Restaurant == LevelProperty.RestaurantId)
                    {
                        CreateCookware(trash, pos, trash.Current, (animation, o, property) =>
                            new Trash(o, new SpineAnimation(animation)));
                        return;
                    }
                }
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
    async UniTask CreateHoldingPlate()
    {
        try
        {
            var trash = KitchenDataHelper.LoadCookware("k" + LevelProperty.RestaurantId.Index + "_holding_plate");
            var disPosList = trash.DisPosList;
            foreach (var pos in disPosList)
            {
                if ((LevelProperty.Id >= pos.Start && LevelProperty.Id <= pos.End) || (pos.Start == 0 && pos.End == 0))
                {
                    if (pos.Restaurant == LevelProperty.RestaurantId)
                    {
                        CreateCookware(trash, pos, trash.Current, (animation, o, property) =>
                            new HoldingPlate(o, new SpineAnimation(animation)));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("创建垃圾桶失败\n" + e);
        }
    }
    
    private void CreateCookware(CookwareProperty cookware, ReachItemDPosition pos, CookwareDetailProperty detail,Func<SkeletonAnimation,UnityObject,CookwareProperty,ICookware> registy)
    {
        try
        {
            SkeletonAnimation runtimeSkeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(detail.SpineData);
            UnityObject obj = new UnityObject(runtimeSkeletonAnimation.gameObject);
            var parent = mBaseScene.Find("Cookware");
            if(parent == null)
                throw new Exception("请确认场景Prefab中是否存在名为Cookware的子物体");
            obj.Parent = parent; 
            obj.LocalPosition = pos.Pos;
            obj.LocalScale = new Vector3(0.7f, 0.7f, 0.7f);
            obj.AddComponent<BoxCollider2D>();
            runtimeSkeletonAnimation.Initialize(false);
            runtimeSkeletonAnimation.Skeleton.SetSkin("default");
            runtimeSkeletonAnimation.Skeleton.SetSlotsToSetupPose();
            runtimeSkeletonAnimation.AnimationState.SetAnimation(0, "1normal", true);
            if (!mCookwareDisplays.TryGetValue(cookware, out var cookDisplayList))
                mCookwareDisplays.Add(cookware, cookDisplayList = new List<ICookware>());
            cookDisplayList.Add(registy(runtimeSkeletonAnimation, obj, cookware));
            //方便调试厨具的位置
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
#endif
        }
        catch (Exception e)
        {
            Debug.LogError("创建厨具" + cookware.Key + "失败\n" + e);
        }
    }

    /// <summary>
    /// 初始化游戏角色 
    /// </summary>
    /// <returns></returns>
    async UniTask InitPlayer()
    {
        var player = new PlayerController();
        //TODO 这里应该改成配置表读取的格式而不是硬编码固定数值
        player.Position = new Vector3(-1, -0.76f);
    }

    /// <summary>
    /// 初始化餐位参数
    /// 必须在餐厅创建之后才能调用
    /// </summary>
    void InitSpot(UnityObject go)
    {
        foreach (var node in go.GetComponentsInChildren<Transform>(true))
        {
            if (node.name.StartsWith("Spot_"))
                Spots.Add(new UnityObject(node.gameObject));
        }
    }

    public void Dispose()
    {
    }

    #region Public Method

    public ReadOnlyCollection<UnityObject> GetSpots()
    {
        return Spots.AsReadOnly();
    }

    public ICookware GetCookware(Transform transform)
    {
        if (transform == null)
            return null;
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
            return null;
        foreach (var node in mCookwareDisplays)
        {
            foreach (var cookware in node.Value)
            {
                if (node.Key.Key == key)
                {
                    return cookware;
                }
            }
        }
        return null;
    }

    public ICookware GetCookware(CookwareProperty property)
    {
        if(property == null)
            return null;
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
            return null;
        foreach (var node in mIngredientDisplays.Values)
        {
            if (node.Display.Equals(transform))
            {
                return node;
            }
        }

        return null;
    }
    
    public IngredientDisplay GetIngredient(BaseIngredient property)
    {
        if (property == null)
            return null;
        var foodId = property.Key;
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
            return null;
        foreach (var node in mIngredientDisplays)
        {
            if (node.Key.Key == key)
            {
                return node.Value;
            }
        }

        return null;
    }

    #endregion
}