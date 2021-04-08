using System;
using System.Collections.Generic;
using Client.Event;
using Client.Manager;
using ET;
using FairyGUI;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_GuildApplicationList : UIBase<View_GongHuiYaoQingLieBiao>
    {
        private NetworkManager Session { get; }
        private List<RecommendedPlayersInfo> RecommendedPlayersInfos;
        public UI_GuildApplicationList()
        {
            Session = NetworkManager.Inst;
        }
        
        protected override async void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            var network = UIKit.Inst.Create<UI_NetworkLoad>();
            try
            {
                var response = (G2C_GuildGetRecommendedPlayers)await Session.Call(new C2G_GuildGetRecommendedPlayers());
                if (response != null && response.Players != null)
                {
                    RecommendedPlayersInfos = response.Players;
                }
            }
            finally
            {
                network.CloseMySelf();
            }
            MessageKit.Inst.Add<GuildApplicationChanged>(Event_GuildApplicationChanged);
            InitUI();
        }

        protected override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
            MessageKit.Inst.Remove<GuildApplicationChanged>(Event_GuildApplicationChanged);
        }

        private void Event_GuildApplicationChanged(GuildApplicationChanged e)
        {
            foreach (var node in e.ApplicationInfos)
            {
                NewApplication(node);
            }
        }

        private void InitUI()
        {
            View.c1.onChanged.Add(Controller_c1Changed);
            Controller_c1Changed();
        }

        private void Controller_c1Changed()
        {
            if(View.c1.selectedPage == "邀请列表")
                InitInviteList();
            if (View.c1.selectedPage == "申请列表")
                InitApplicationList();
        }

        private void InitInviteList()
        {
            View.FriendList.RemoveChildrenToPool();
            foreach (var node in RecommendedPlayersInfos)
            {
                var item = (View_HaoYouXuanZe_Button)View.FriendList.AddItemFromPool();
                item.icon = node.Head;
                item.text = node.Name;
                item.Ask.data = node;
                item.Ask.onClick.Set(InviteFriend_OnClick);
            }
        }

        private async void InviteFriend_OnClick(EventContext context)
        {
            var button = (GButton) context.sender;
            var info = (RecommendedPlayersInfo) button.data;
            Session.Send(new C2G_InvitePlayerJoinGuild { PlayerId = info.Id });
            button.parent.GetController("c1").selectedPage = "邀请过";
        }

        private void InitApplicationList()
        {
            View.ApplicationList.RemoveChildrenToPool();   
            foreach (ApplicationInfo node in GuildManager.Inst.Data.ApplicationList)
            {
                NewApplication(node);
            }
        }

        private void NewApplication(ApplicationInfo node)
        {
            var item = (View_ShenQingZuJian) View.ApplicationList.AddItemFromPool();
            item.text = node.Name;
            item.icon = node.Head;
            item.Approve.data = node;
            item.Approve.onClick.Set(Approve_OnClick);
            item.Ignore.data = node;
            item.Ignore.onClick.Set(Ignore_OnClick);
        }

        private void Ignore_OnClick(EventContext context)
        {
            var button = (GButton) context.sender;
            var info = (ApplicationInfo) button.data;
            Session.Send(new C2G_HandleApplication { PlayerId = info.Id, Approve = false });
            View.ApplicationList.RemoveChild(button.parent);
        }

        private void Approve_OnClick(EventContext context)
        {
            var button = (GButton) context.sender;
            var info = (ApplicationInfo) button.data;
            Session.Send(new C2G_HandleApplication { PlayerId = info.Id, Approve = true });
            View.ApplicationList.RemoveChild(button.parent);
        }
        
        
    }
}