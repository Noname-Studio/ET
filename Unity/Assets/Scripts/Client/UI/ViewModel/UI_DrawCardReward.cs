using Client.Manager;
using Common;
using ET;
using RestaurantPreview.Config;

namespace Client.UI.ViewModel
{
    public class UI_DrawCardReward : UIBase<View_DrawCardReward>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.play.onClick.Add(Play_OnClick);
        }

        private async void Play_OnClick()
        {
            var response = (G2C_DrawReward)await NetworkManager.Inst.Call(new C2G_DrawReward { Type = 1 });
            View.icon.url = PropProperty.Read(response.Reward).Icon;
        }
    }
}