using RestaurantPreview.Config;

namespace Kitchen
{
    /// <summary>
    /// 厨具工作速度变快
    /// </summary>
    public class FasterCook : ABuff
    {
        private NormalCookware Target { get; }
        private BuffProperty Property { get; }
        public FasterCook(NormalCookware target,BuffProperty property)
        {
            Target = target;
            Property = property;
        }
        
        public override void OnAdd()
        {
            base.OnAdd();
            Target.WorkTime -= Property.CWWorkTime;
        }

        public override void OnRemove()
        {
            Target.BurnTime += Property.CWWorkTime;
        }
    }
}