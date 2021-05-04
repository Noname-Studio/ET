using System.Collections.Generic;
using Kitchen;
using UnityEngine;

namespace Kitchen.Action
{
    public class ClickSpot: IGameAction
    {
        private PlayerController Player { get; }
        private AKitchenSpot Target { get; }
        private List<string> mHoldFood;
        private Vector3 mPosition;
        private bool IsDone { get; set; } = false;

        private QueueEventsKit ActionManager { get; }

        //private UIManager UiManager { get; }
        public ClickSpot(PlayerController player, AKitchenSpot spot)
        {
            Player = player;
            Target = spot;
            mPosition = spot.Position;
            //UiManager = UIKit.Inst;
            ActionManager = QueueEventsKit.Inst;
        }

        public void Execute()
        {
            //如果座位上是空的.我们点击以后不做任何反馈
            if (Target.State == KitchenSpotState.Free)
            {
                IsDone = true;
                return;
            }

            //如果顾客还没坐到座位上.我们不能对座位做任何操作.也不能显示即将到来的订单.
            if (Target.Customer.State != CustomerState.Wait)
            {
                IsDone = true;
                return;
            }
            //显示顾客菜谱
            //var main = UiManager.Find<UI_KitchenMain>();
            //main?.ShowFoodProcess(Target.Customer.Order[0]);

            //我们获取一下玩家手上拿着的食物
            mHoldFood = new List<string>();
            Player.HandProvider.Get(ref mHoldFood);

            //我们这里判断一下手上的食物是否能给顾客.如果不能我们就待命
            if (GetCustomerNeed().Count == 0)
            {
                IsDone = true;
                return;
            }

            //先移动到目标点
            Player.MoveToPoint(ref mPosition);
        }

        public bool Update()
        {
            if (IsDone)
            {
                return true;
            }

            var playerState = Player.IsMoving(mPosition);
            if (playerState == PlayerController.MovingState.Moving)
            {
                return false;
            }

            if (playerState == PlayerController.MovingState.InDestination)
            {
                Player.LookAt(Target.Position);
                //判断一下手上的食物是否有顾客需要的
                var orderList = GetCustomerNeed();
                for (int i = 0; i < orderList.Count; i++)
                {
                    var node = orderList[i];
                    Player.HandProvider.Take(node);
                    Target.Customer.RemoveOrder(node);
                }
            }

            return true;
        }

        private List<string> GetCustomerNeed()
        {
            var order = Target.Customer.Order;
            List<string> orderList = new List<string>();
            for (var index = 0; index < order.Count; index++)
            {
                var node = order[index];
                if (mHoldFood.Contains(node))
                {
                    orderList.Add(node);
                }
            }

            return orderList;
        }
    }
}