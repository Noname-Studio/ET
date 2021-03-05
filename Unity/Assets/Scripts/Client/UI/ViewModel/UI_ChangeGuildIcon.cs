using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_ChangeGuildIcon : UIBase<View_HuiZhangZhiZuo>
    {
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            if(PlayerManager.Inst.GuildId == 0)
        }
    }
}