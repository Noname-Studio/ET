using System;
using System.Collections.Generic;
using Client.Manager;
using DB;
using ET;
using FairyGUI;
using RestaurantPreview.Config;
using TheGuild;
using UnityEngine;

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
            var guildData = GuildManager.Inst.Data;
            View.frame.icon = GuildIconProperty.Read(guildData.Frame.GetValueOrDefault(GuildIconProperty.DefaultFrame.Id))?.Url;
            View.inside.icon = GuildIconProperty.Read(guildData.Inside.GetValueOrDefault(GuildIconProperty.DefaultInside.Id))?.Url;
            View.Name.text = guildData.Name;
            View.IsPublic.text = guildData.IsPublic.GetValueOrDefault(false)? LocalizationProperty.Read("Public")
                    : LocalizationProperty.Read("NotPublic");
            View.Notice.text = guildData.Desc;
            View.Exit.onClick.Set(Exit_OnClick);
            InitMemberList();
            View.List.onClickItem.Set(List_OnClickItem);
            View.SelectTip.Transfer.onClick.Set(Transfer_OnClick);
            View.SelectTip.KickOut.onClick.Set(KickOut_OnClick);
        }

        private void InitMemberList()
        {
            var guildData = GuildManager.Inst.Data;
            View.Member.SetVar("Min", guildData.Members.Count.ToString());
            View.Member.SetVar("Max", guildData.MaxMemberNum.ToString());
            View.Member.FlushVars();
            View.List.RemoveChildrenToPool();
            guildData.Members.Sort((t1, t2) => (int) (t1.LastLogin - t2.LastLogin));
            foreach (MemberInfo node in guildData.Members)
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
                item.data = node;
            }
        }

        private void List_OnClickItem(EventContext evt)
        {
            if (!GuildManager.Inst.IsOwner())
                return;
            var button = (GButton) evt.data;
            var memberInfo = (MemberInfo) (button).data;
            if (memberInfo.Id == PlayerManager.Inst.Id)
                return;
            View.SelectTip.KickOut.data = memberInfo;
            View.SelectTip.Transfer.data = memberInfo;
            View.SelectTip.visible = true;
            View.SelectTip.position = View.List.TransformPoint(button.position, View);
        }

        private async void Transfer_OnClick(EventContext context)
        {
            var memberInfo = (MemberInfo)((GObject) context.data).data;
            var network = UIKit.Inst.Create<UI_NetworkLoad>();
            try
            {
                await NetworkManager.Inst.Call(new C2G_TransferGuildPresident { PlayerId = memberInfo.Id });
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
            network.CloseMySelf();
        }
        
        private async void KickOut_OnClick(EventContext context)
        {
            var memberInfo = (MemberInfo)((GObject) context.data).data;
            var network = UIKit.Inst.Create<UI_NetworkLoad>();
            try
            {
                await NetworkManager.Inst.Call(new C2G_KickoutFromGuild { PlayerId = memberInfo.Id });
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
            network.CloseMySelf();
        }

        private void Exit_OnClick()
        {
            UIKit.Inst.Create<UI_GuildQuitTips>();
        }

        public override void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                View.SelectTip.visible = false;
            }
        }
    }
}