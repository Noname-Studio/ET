using System.Collections.ObjectModel;
using RestaurantPreview.Config;

namespace Kitchen
{
    public class ACustomer: IUnit
    {
        public AKitchenSpot Spot { get; }
        public UnityObject Display { get; }
        public AnimatorControl Animator { get; }
        protected LevelProperty.CustomerOrder Property { get; }
        public ObservableCollection<string> Order { get; }
        public CustomerState State { get; protected set; } = CustomerState.Enter;
        public ComponentContainer Components { get; } = new ComponentContainer();

        public ACustomer(UnityObject display, AKitchenSpot spot, LevelProperty.CustomerOrder property)
        {
            Spot = spot;
            Display = display;
            Animator = Display.AddComponent<AnimatorControl>();
            Property = property;
            Order = new ObservableCollection<string>(Property.Foods);
        }

        public void RemoveOrder(string key)
        {
            for (var index = 0; index < Order.Count; index++)
            {
                var node = Order[index];
                if (node == key)
                {
                    var property = FoodProperty.Read(node);
                    if (property == null)
                    {
                        Log.Error("找不到食物ID:" + node);
                        continue;
                    }
                    KitchenRoot.Inst.Record.ServicesOrderNumber++;
                    //交一份食物给一分钱
                    KitchenRoot.Inst.Record.CoinNumber += property.CurrentLevel.Tips;
                    Order.Remove(node);
                    break;
                }
            }
        }

        public virtual void Dispose()
        {
            KitchenRoot.Inst.CustomerProvider.Push(this);
            Display.Active = false;
            KitchenRoot.Inst.SpotProvider.ReleaseSpot(Spot);
        }

        public virtual void Update()
        {
        }

        /// <summary>
        /// 顾客离场.
        /// </summary>
        public virtual void OnExit()
        {
            var patience = Components.Get<PatienceComponent>();
            if (patience != null)
            {
                if (patience.Value >= 60)
                {
                    KitchenRoot.Inst.Record.LikeCount++;
                }
                if(patience.Value > 0)
                    KitchenRoot.Inst.Record.ServicesCustomerNumber++;
            }
        }

        /// <summary>
        /// 顾客入场.你可以在这个方法中初始化顾客得一些参数
        /// </summary>
        public virtual void OnEnter()
        {
        }
    }
}