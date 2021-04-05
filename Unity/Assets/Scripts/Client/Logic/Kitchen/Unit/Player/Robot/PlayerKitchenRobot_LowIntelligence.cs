using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kitchen.Robot
{
    /// <summary>
    /// 控制玩家进行通关得后厨机器人.
    /// 测试级别:新手试玩
    /// 新手试玩,机器人每次仅会思考一个步骤得操作
    /// </summary>
    public class PlayerKitchenRobot_LowIntelligence
    {
        private PlayerController mPlayerController;
        private KitchenRoot mKitchenRoot;
        private RobotInput mRobotInput;
        private QueueEventsKit mQueueEventsKit;
        private int Step = 0;

        public PlayerKitchenRobot_LowIntelligence(PlayerController playerController, QueueEventsKit gam)
        {
            mPlayerController = playerController;
            mKitchenRoot = KitchenRoot.Inst;
            mRobotInput = new RobotInput(mPlayerController, mKitchenRoot.MainCamera);
            mQueueEventsKit = gam;
            UnityLifeCycleKit.Inst.AddUpdate(Update);
        }

        private float Update()
        {
            if (Step > 0)
            {
                // 新手AI每次仅能进行一步判断.当超过一步判断后立即跳出
                return 0;
            }

            List<FoodProperty> orderLists = new List<FoodProperty>();
            List<ACustomer> customers = new List<ACustomer>();
            //先获得所有顾客需要得食物.
            //这样当个别顾客需要2个食材或更多得时候我们可以先推后处理(因为这样得食物往往等待时间较长)
            //同时我们还可以判断如果距离近得食材我们可以一起拿走
            for (int i = 0; i < mKitchenRoot.SpotProvider.TotalCount(); i++)
            {
                //我们先获取到到达目标点得顾客(这是真实得玩家操作.因为顾客在未抵达目标点时,玩家不应该知道目标得食物)
                var spot = mKitchenRoot.SpotProvider.GetSpot(i);
                if (spot.Customer != null)
                {
                    var customer = spot.Customer;
                    if (customer.State != CustomerState.Wait)
                    {
                        continue;
                    }

                    customers.Add(customer);
                    var order = customer.Order;

                    orderLists.AddRange(order);
                }
            }

            //根据顾客耐心排序顾客列表
            customers = customers.OrderBy(t1 =>
            {
                var com = t1.Components.Get<PatienceComponent>();
                if (com == null)
                {
                    return int.MaxValue;
                }

                return com.Value;
            }).ToList();

            foreach (var customer in customers)
            {
                var order = customer.Order;
                //如果我们手中得食物能够直接交给顾客我们这里就直接交给顾客
                foreach (var node in order)
                {
                    if (mPlayerController.HandProvider.HasHold(node.Key))
                    {
                        mRobotInput.DoJob(customer.Spot.Display);
                        Step++;
                        mQueueEventsKit.AddToBottom(new ModifyRobotStep(() => --Step));
                        return 0;
                    }

                    if (mPlayerController.HandProvider.HasFreeSpace())
                    {
                        var cookware = mKitchenRoot.Scene.GetCookware(node.Cookware);
                        if (cookware.FoodId == node.Key)
                        {
                            mRobotInput.DoJob(cookware.Display);
                            Step++;
                            mQueueEventsKit.AddToBottom(new ModifyRobotStep(() => --Step));
                            return 0;
                        }
                    }
                }
            }

            //排序菜谱得难度
            orderLists = orderLists.OrderBy(property => property.AllIngredients.Count).ToList();

            //这里我们把手上拿着的食物放进厨具制作
            foreach (var node in orderLists)
            {
                var ingredients = node.AllIngredients;
                bool pass = true;
                for (int i = 0; i < ingredients.Count; i++)
                {
                    if (!mPlayerController.HandProvider.HasHold(ingredients[i].Key))
                    {
                        pass = false;
                        break;
                    }
                }

                if (!pass)
                {
                    continue;
                }

                var cookware = mKitchenRoot.Scene.GetCookware(node.Cookware);
                if (cookware.State == CookwareState.Idle) //厨具正在等待中
                {
                    mRobotInput.DoJob(cookware.Display);
                    Step++;
                    mQueueEventsKit.AddToBottom(new ModifyRobotStep(() => --Step));
                    return 0;
                }
            }

            //机器人手上有空间得时候可以查找一下有什么食材可以顺手拿一下
            if (mPlayerController.HandProvider.HasFreeSpace() == true)
            {
                for (int i = 0; i < orderLists.Count; i++)
                {
                    var food = orderLists[i];

                    foreach (var node in food.AllIngredients)
                    {
                        //如果手上已经又这个食材了.那么我们就跳过这个拾取操作
                        if (mPlayerController.HandProvider.HasHold(node.Key))
                        {
                            continue;
                        }

                        //如果目标厨具已经在工作了就别拿了.避免卡死关卡(比如说手上拿太多东西在无法丢弃食材得关卡会陷入僵局)
                        var cookware = mKitchenRoot.Scene.GetCookware(food.Cookware);
                        if (cookware.State != CookwareState.Idle)
                        {
                            continue;
                        }

                        IngredientDisplay ingDisplay = mKitchenRoot.Scene.GetIngredient(node);
                        mRobotInput.DoJob(ingDisplay.Display);
                        Step++;
                        mQueueEventsKit.AddToBottom(new ModifyRobotStep(() => --Step));
                        return 0;
                    }
                }
            }

            return 0;
        }
    }
}