using Client.Manager;
using Main;
using RestaurantPreview.Config;

namespace Client.UI.ViewModel
{
    public class UI_RestaurantMain: UIBase<View_Main>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            InitUI();
        }

        private void InitUI()
        {
            View.Play.onClick.Set(PlayGame_OnClick);
            View.Club.onClick.Set(Club_OnClick);
            View.Settings.onClick.Set(Settings_OnClick);
            View.Shop.onClick.Set(Shop_OnClick);
        }

        private void Shop_OnClick()
        {
            UIKit.Inst.Create<UI_LegacyShop>(new UI_LegacyShop.ParamsData(PlayerManager.Inst.PlayingRestaurant));
        }

        private void Settings_OnClick()
        {
            UIKit.Inst.Create<UI_Settings>();
        }

        private async void Club_OnClick()
        {
            if (!NetworkManager.Inst.IsConnect)
            {
                await NetworkManager.Inst.Connect();
                if (!NetworkManager.Inst.IsConnect)
                {
                    var tips = UIKit.Inst.Create<UI_Tips>();
                    tips.SetContent(LocalizationProperty.Read("NetworkNotReachable"));
                    tips.AddButton(LocalizationProperty.Read("Confirm"));
                    return;
                }
            }
            if (!GuildManager.Inst.IsJoined())
            {
                UIKit.Inst.Create<UI_NotJoinGuild>();
            }
            else
            {
                UIKit.Inst.Create<UI_JoinedGuild>();
            }
        }

        private void PlayGame_OnClick()
        {
            if (EnterLevelHelper.CheckCondition())
            {
                UIKit.Inst.Create<UI_EnterLevelPanel>();
            }
        }
    }
}