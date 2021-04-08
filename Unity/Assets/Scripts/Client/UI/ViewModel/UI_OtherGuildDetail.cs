using System;
using Client.Manager;
using DB;
using ET;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    [UIWindow(Background = true,Enter = WindowAnimType.ScaleToNormal,Exit = WindowAnimType.ScaleToZero)]
    public class UI_OtherGuildDetail : UIBase<View_GongHuiXiangQing>
    {
        public class ParamsData: IUIParams
        {
            public G2C_FetchGuildInfo FetchGuildInfo;

            public ParamsData(G2C_FetchGuildInfo fetchGuildInfo)
            {
                FetchGuildInfo = fetchGuildInfo;
            }
        }

        private ParamsData Args;

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            Args = p as ParamsData;
            if (Args == null)
            {
                Log.Error("参数错误");
                CloseMySelf();
                return;
            }
            MessageKit.Inst.Add(EventKey.GuildChanged, Event_GuildChanged);
            InitUI();
        }

        private void Event_GuildChanged()
        {
            InitMemberList();
        }

        protected override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
            MessageKit.Inst.Remove(EventKey.GuildChanged, Event_GuildChanged);
        }

        public void InitUI()
        {
            View.c1.selectedIndex = 1;
            var guildData = Args.FetchGuildInfo;
            View.frame.icon = (GuildIconProperty.Read(guildData.Frame) ?? GuildIconProperty.DefaultFrame)?.Url;
            View.inside.icon = (GuildIconProperty.Read(guildData.Inside) ?? GuildIconProperty.DefaultInside)?.Url;
            View.Name.text = guildData.Name;
            View.IsPublic.text = guildData.IsPublic ? LocalizationProperty.Read("Public") : LocalizationProperty.Read("NotPublic");
            View.Notice.text = guildData.Desc;
            View.Join.onClick.Set(Join_OnClick);
            if (GuildManager.Inst.IsJoined())
                View.Join.visible = false;
            InitMemberList();
        }

        private void InitMemberList()
        {
            var guildData = Args.FetchGuildInfo;
            View.Member.SetVar("Min", guildData.Members.Count.ToString());
            View.Member.SetVar("Max", "20");
            View.Member.FlushVars();
            View.List.RemoveChildrenToPool();
            guildData.Members.Sort((t1, t2) => (int) (t1.LastLogin - t2.LastLogin));
            foreach (var node in guildData.Members)
            {
                var item = (View_GongHuiChengYuanZuJian)View.List.AddItemFromPool();
                item.Name.text = node.Name;
                item.Head.icon = node.Icon;
                item.Progress.text = LocalizationProperty.Read(RestaurantKey.Map(node.Level / GameConfig.RestaurantOffset)) + " " +
                        string.Format(LocalizationProperty.Read("Level X"), node.Level % GameConfig.RestaurantOffset);
                item.c1.selectedPage = guildData.OwnerId == node.Id? "admin" : "member";
                item.Online.c1 .selectedPage = node.LastLogin == 0 ? "在线" : "离线多久";
                if(node.LastLogin > 0)
                    item.Online.Time.text = LocalizationHelper.GetTimeString(node.LastLogin);
                item.HornorLevel.text = node.Hornor.ToString();
            }
        }

        private async void Join_OnClick()
        {
            var guildData = Args.FetchGuildInfo;
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>();
            try
            {
                var response = (M2C_JoinGuild) await NetworkManager.Inst.Call(new C2M_JoinGuild() { Id = guildData.Id });
                if (GuildManager.Inst.IsJoined()) //可能只是发送了申请,并没有加入.
                {
                    UIKit.Inst.Destroy<UI_NotJoinGuild>();
                    CloseMySelf();
                    UIKit.Inst.Create<UI_JoinedGuild>();
                }
            }
            catch (Exception e)
            {
                UIKit.Inst.Create<UI_Tips>().SetContent("加入公会失败").AddButton("确定");
                Log.Error(e.Message);
            }
            networkLoad.CloseMySelf();
        }
    }
}