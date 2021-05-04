using Kitchen.Decay;
using RestaurantPreview.Config;

namespace Kitchen
{
    /// <summary>
    /// 衰减支持
    /// 该组件可以提供
    /// 1.顾客耐心的衰减
    /// 2.订单间隔的衰减
    /// </summary>
    public class DecayProvider
    {
        private PatienceDecayProvider PatienceDecayProvider { get; }
        private OrderDecayProvider OrderDecayProvider { get; }
        public DecayProvider(LevelProperty property)
        {
            if(property.WaitingDecay != null)
                PatienceDecayProvider = new PatienceDecayProvider(property.WaitingDecay);
            if(property.OrderDecay != null)
                OrderDecayProvider = new OrderDecayProvider(property.OrderDecay);
        }

        public void Update()
        {
            PatienceDecayProvider.Update();
            OrderDecayProvider.Update();
        }
    }
}