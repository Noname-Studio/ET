using Client.Manager;
using ET;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_GuildQuitTips : UIBase<View_GongHuiTuiChu>
    {
        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            View.ThinkAgain.onClick.Set(ThinkAgain_OnClick);
            View.Confirm.onClick.Set(Confirm_OnClick);
            if (PlayerManager.Id == GuildManager.Inst.Data.OwnerId)
            {
                if (GuildManager.Inst.Data.Members.Count == 0)
                    View.c1.selectedPage = "LastOne";
                else
                    View.c1.selectedPage = "Admin";
            }
            else
            {
                View.c1.selectedPage = "Normal";
            }
        }

        private async void Confirm_OnClick()
        {
            var network = UIKit.Inst.Create<UI_NetworkLoad>();
            await NetworkManager.Inst.Call(new C2G_QuitGuild());
            network.CloseMySelf();
            if (PlayerManager.GuildId == 0)
            {
                UIKit.Inst.Destroy<UI_JoinedGuild>();
                UIKit.Inst.Destroy<UI_GuildDetail>();
            }
            CloseMySelf();
        }

        private void ThinkAgain_OnClick()
        {
            CloseMySelf();
        }
    }
}