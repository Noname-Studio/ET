using EnergySystem;

namespace Client.UI.ViewModel
{
    public class UI_NoEnergyTips : UIBase<View_NoEnergyTips>
    {
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            this.View.Buy.onClick.Add(Buy_OnClick);
        }

        private void Buy_OnClick()
        {
            
        }
    }
}