using RestaurantPreview.Config;

namespace Kitchen
{
    /// <summary>
    /// 烧焦速度变慢
    /// </summary>
    public class SlowerBurnRate : ABuff
    {
        private NormalCookware Target { get; }
        private BuffProperty Property { get; }
        public SlowerBurnRate(NormalCookware target,BuffProperty property)
        {
            Target = target;
            Property = property;
        }
        
        public override void OnAdd()
        {
            base.OnAdd();
            Target.BurnTime += Property.CWBurnTime;
        }

        public override void OnRemove()
        {
            Target.BurnTime -= Property.CWBurnTime;
        }
    }
}