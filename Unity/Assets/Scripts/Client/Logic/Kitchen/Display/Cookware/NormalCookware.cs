using System;
using System.Collections.Generic;
using RestaurantPreview.Config;

namespace Kitchen
{
    /// <summary>
    /// 厨具的公开方法.用于处理状态和获取厨具的相关信息
    /// 你无法操作任何显示层相关的东西.但是你可以通过改变状态去驱动显示层做出变化
    /// </summary>
    public class NormalCookware: ICookware
    {
        public Type Type => GetType();
        public IAnimation Animation { get; }
        public UnityObject Display { get; }
        public CookwareProperty Property { get; }
        public CookwareProperty.CookwareDetailProperty CookwareDetail { get; }

        private List<FoodProperty> mMakeFoodProperty;

        private CookwareState mState = CookwareState.Idle;

        /// <summary>
        /// 厨具当前的状态
        /// </summary>
        public CookwareState State
        {
            get => mState;
            private set
            {
                mState = value;
                mRenderer.ChangeState(mState);
            }
        }

        /// <summary>
        /// 厨具的状态处理器.内部包含一个帧处理器.如果厨具已经完成了工作.且食材会烧焦的情况下的话.帧处理器会处理食物烧焦的情况
        /// </summary>
        private readonly CookwareRenderer mRenderer;

        /// <summary>
        /// 如果这个ID不为0则代表这个厨具上面已经产生了食物.
        /// </summary>
        public string FoodId { get; private set; } = null;

        /// <summary>
        /// 当前FoodId的数量
        /// </summary>
        public int FoodCount { get; private set; }

        /// <summary>
        /// 正在制作中的食物
        /// </summary>
        private string WorkingFoodId { get; set; }

        public PlacedIngredients PlacedIngredients { get; }
        
        /// <summary>
        /// 我们把这个属性从Config中独立出来.这样我们Buff进行修改的时候就改这里就行了.不能修改Config
        /// </summary>
        public float BurnTime { get; set; }
        /// <summary>
        /// 我们把这个属性从Config中独立出来.这样我们Buff进行修改的时候就改这里就行了.不能修改Config
        /// </summary>
        public float WorkTime { get; set; }
        private readonly PlacedRenderer mPlacedRenderer;

        /// <summary>
        /// 避免重复New List 我们这里把GetRequirement的需求条件编程类变量而不是局部变量
        /// </summary>
        private HashSet<string> mRequirement = new HashSet<string>();

        public BuffContainer Buffs = new BuffContainer();
        public NormalCookware(CookwareProperty property, UnityObject display, IAnimation animation)
        {
            Property = property;
            CookwareDetail = property.CurrentLevel;
            BurnTime = CookwareDetail.BurnTime;
            WorkTime = CookwareDetail.WorkTime;
            Display = display;
            Animation = animation;
            mRenderer = new CookwareRenderer(this);
            PlacedIngredients = new PlacedIngredients();
            mPlacedRenderer = new PlacedRenderer(PlacedIngredients, Animation.FoodPos);
            InitMakeFoodProperty();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitMakeFoodProperty()
        {
            mMakeFoodProperty = new List<FoodProperty>(Property.FoodKey);
        }

        public void Dispose()
        {
            mPlacedRenderer.Dispose();
        }

        /// <summary>
        /// 将需要添加到厨具的菜品,如果添加成功了会返回添加成功的菜品
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        public List<string> PutIn(List<string> ingredients)
        {
            if (ingredients == null || ingredients.Count == 0)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(FoodId) && FoodCount > 1)
            {
                return null;
            }

            var list = GetRequirement();
            List<string> put = null;
            foreach (var req in list)
            {
                if (ingredients.Contains(req))
                {
                    if (put == null)
                    {
                        put = new List<string>();
                    }

                    if (PlacedIngredients.List.Contains(req))
                    {
                        //厨具里面已经有这个食材了.我们不需要添加这个食材了
                        continue;
                    }

                    put.Add(req);
                    PlacedIngredients.Add(req);
                }
            }

            return put;
        }

        /// <summary>
        /// 拿走食物
        /// </summary>
        public string TakeFood()
        {
            var food = FoodId;
            FoodCount--;
            mRenderer.RefreshCount();
            if (FoodCount <= 0)
            {
                FoodId = null;
                Animation.Loop = false;
                Animation.AnimationName = "1normal";
                State = CookwareState.Idle;
            }

            return food;
        }

        /// <summary>
        /// 厨具开始工作
        /// </summary>
        public void DoWork()
        {
            string foodKey = null;
            //食材还未集齐.我们无法开始制作
            if (GetRequirement(ref foodKey).Count != 0)
            {
                return;
            }

            //厨具上有食物不能继续工作
            if (!string.IsNullOrEmpty(FoodId))
            {
                return;
            }

            Animation.Loop = true;
            Animation.AnimationName = "3work";
            State = CookwareState.Work;
            PlacedIngredients.Clear();
            WorkingFoodId = foodKey;
        }

        private HashSet<string> GetRequirement()
        {
            string key = null;
            return GetRequirement(ref key);
        }

        /// <summary>
        /// 获取食物制作所需要的食材,该方法返回食材列表
        /// </summary>
        /// <param name="foodKey">返回食物key</param>
        /// <returns></returns>
        private HashSet<string> GetRequirement(ref string foodKey)
        {
            if (mRequirement.Count > 0)
            {
                mRequirement.Clear();
            }

            var placedList = PlacedIngredients.List;

            bool hasPlaced = placedList.Count > 0;
            foreach (var node in mMakeFoodProperty)
            {
                var pass = false;
                if (node.AllIngredients != null && node.AllIngredients.Count != 0)
                {
                    if (hasPlaced)
                    {
                        int overlapCount = Overlap(placedList, node.AllIngredients);
                        if (overlapCount == node.AllIngredients.Count) //发现厨具上的食材完全匹配
                        {
                            pass = true;
                        }
                        else if (overlapCount > 0)
                        {
                            mRequirement.AddRange(node.AllIngredients);
                        }
                    }
                    else
                    {
                        mRequirement.AddRange(node.AllIngredients);
                    }
                }
                else
                {
                    pass = true;
                }

                //我们这里找到了完全匹配的食谱.我们不需要任何食材了.直接清空需求列表并返回
                if (pass)
                {
                    mRequirement.Clear();
                    foodKey = node.Id;
                    return mRequirement;
                }
            }

            return mRequirement;
        }

        /// <summary>
        /// 检查两个List之间存在的交集数量
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private int Overlap(IList<string> from, IList<string> to)
        {
            int count = from.Count;
            int count2 = to.Count;
            int result = 0;
            for (int i = 0; i < count; i++)
            {
                var a = from[i];
                for (int j = 0; j < count2; j++)
                {
                    var b = to[j];
                    if (b != null && a == b)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 完成食物制作
        /// </summary>
        public void FinishWork()
        {
            Animation.Loop = false;
            Animation.AnimationName = "4done";
            FoodId = WorkingFoodId;
            FoodCount = CookwareDetail.MakeCount;
            WorkingFoodId = null;
            State = CookwareState.Done;
            if (BurnTime > 0)
            {
                StartBurn();
            }
        }

        /// <summary>
        /// 开始烧焦
        /// </summary>
        public void StartBurn()
        {
            Animation.Loop = true;
            Animation.AnimationName = "4done";
            State = CookwareState.Burning;
        }

        /// <summary>
        /// 彻底烧焦
        /// </summary>
        public void BurntFood()
        {
            Animation.Loop = true;
            Animation.AnimationName = "5burn";
            FoodId = "F_BurnedFood"; //烧焦食物ID
            State = CookwareState.Burned;
            KitchenRoot.Inst.Record.BurnFoodCount++;
        }

        public void Update()
        {
            mRenderer.Update();
            Buffs.Update();
        }
    }
}