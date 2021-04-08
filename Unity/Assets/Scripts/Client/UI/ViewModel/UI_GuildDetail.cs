using FairyGUI;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_GuildDetail : UIBase<View_GongHuiXiangQing>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
        }

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            InitUI();
        }

        protected override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
        }

        public void InitUI()
        {
            var guildData = GuildManager.Inst.Data;
            View.frame.icon = GuildIconProperty.Read(guildData.Frame.GetValueOrDefault(GuildIconProperty.DefaultFrame.Id))?.Url;
            View.inside.icon = GuildIconProperty.Read(guildData.Inside.GetValueOrDefault(GuildIconProperty.DefaultInside.Id))?.Url;
            View.Name.text = guildData.Name;
            View.IsPublic.text = guildData.IsPublic.GetValueOrDefault(false)? LocalizationProperty.Read("Public")
                    : LocalizationProperty.Read("NotPublic");
            View.Notice.text = guildData.Desc;
            View.Exit.onClick.Set(Exit_OnClick);
            InitMemberList();
        }

        private void InitMemberList()
        {
            var guildData = GuildManager.Inst.Data;
            View.Member.SetVar("Min", guildData.Members.Count.ToString());
            View.Member.SetVar("Max", guildData.MaxMemberNum.ToString());
            View.Member.FlushVars();
            foreach (var node in guildData.Members)
            {
                var item = (View_GongHuiChengYuanZuJian)View.List.AddItemFromPool();
                item.Name.text = node.Name;
                item.Head.icon = node.Icon;
                item.Progress.text = LocalizationProperty.Read(RestaurantKey.Map(node.Level / GameConfig.RestaurantOffset)) + " " +
                        string.Format(LocalizationProperty.Read("Level X"), node.Level % GameConfig.RestaurantOffset);
                item.c1.selectedPage = guildData.OwnerId == node.Id? "admin" : "member";
                item.Online.visible = node.LastLogin == 0;
                item.HornorLevel.text = node.Hornor.ToString();
            }
        }

        private void Exit_OnClick()
        {
            UIKit.Inst.Create<UI_GuildQuitTips>();
        }
    }
}