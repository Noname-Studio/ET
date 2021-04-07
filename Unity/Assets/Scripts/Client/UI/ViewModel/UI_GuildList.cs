using System;
using System.Collections.Generic;
using Client.Manager;
using Cysharp.Threading.Tasks;
using ET;
using FairyGUI;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 公会列表
    /// </summary>
    public class UI_GuildList
    {
        private List<SearchGuildResult> SearchResults { get; } = new List<SearchGuildResult>();
        private NetworkManager Session;
        private View_GongHuiLieBiao View;
        private UI_NotJoinGuild Parent;
        private int Cursor { get; set; } = 1;

        public UI_GuildList(View_GongHuiLieBiao guildList, UI_NotJoinGuild parent)
        {
            View = guildList;
            Parent = parent;
        }

        public async UniTask Init()
        {
            InitList();
            View.Search.onClick.Add(Search_OnClick);

            await FetchGuildList();

            RefreshList();
        }

        private void Search_OnClick()
        {
            FetchGuildList();
        }

        private async UniTask FetchGuildList(string name = "", int id = 0)
        {
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>().OutOfTime(5);
            try
            {
                Session = NetworkManager.Inst;
                var response = (M2C_SearchGuild) await Session.Call(new C2M_SearchGuild() { Name = name, Id = id, MaxNum = 20, IsNewSearch = true });
                SearchResults.AddRange(response.Results);
            }
            finally
            {
                await UniTask.SwitchToMainThread();
                networkLoad.CloseMySelf();
            }
        }

        private void InitList()
        {
            View.List.SetVirtual();
            View.List.itemRenderer = SearchResultItemRender;
            View.List.scrollPane.onPullUpRelease.Set(OnPullUpToRefresh);
        }

        private async void OnPullUpToRefresh()
        {
            View_PullListToRefresh footer = (View_PullListToRefresh) View.List.scrollPane.footer;
            View.List.scrollPane.LockFooter(footer.sourceHeight);
            footer.Desc.text = "查看更多内容";
            footer.c1.selectedPage = "WaitNet";
            footer.t0.Play();
            var response = (M2C_SearchGuild) await Session.Call(new C2M_SearchGuild() { MaxNum = 20, IsNewSearch = false, Cursor = Cursor });
            SearchResults.AddRange(response.Results);
            await UniTask.SwitchToMainThread();
            if (response.Results.Count == 0)
            {
                footer.Desc.text = "没有更多内容";
                footer.c1.selectedPage = "WithoutAnyData";
                await UniTask.Delay(1500, true);
            }
            else
            {
                Cursor++;
            }

            RefreshList();
            View.List.scrollPane.LockFooter(0);
            footer.t0.Stop();
            footer.Desc.text = "查看更多内容"; //上拉查看更多
            footer.c1.selectedPage = "WaitNet";
        }

        private void SearchResultItemRender(int index, GObject obj)
        {
            var item = (View_JiaRuGongHuiZuJian) obj;
            var data = SearchResults[index];
            item.inside.icon = GuildIconProperty.Read(data.Inside.GetValueOrDefault(GuildIconProperty.DefaultInside.Id))?.Url;
            item.frame.icon = GuildIconProperty.Read(data.Frame.GetValueOrDefault(GuildIconProperty.DefaultFrame.Id))?.Url;
            item.UnionName.text = data.Name;
            item.UnionDesc.text = data.Desc;
            item.Join.data = data;
            item.Join.onClick.Set(Join_OnClick);
        }

        private async void Join_OnClick(EventContext t1)
        {
            var result = (SearchGuildResult) ((GComponent) t1.sender).data;
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>().OutOfTime(5);
            try
            {
                var response = (M2C_JoinGuild) await Session.Call(new C2M_JoinGuild() { Id = result.Id });
                Parent.CloseMySelf();
                if(GuildManager.Inst.IsJoined())//可能只是发送了申请,并没有加入.
                    UIKit.Inst.Create<UI_JoinedGuild>();
            }
            catch (Exception e)
            {
                UIKit.Inst.Create<UI_Tips>().SetContent("加入公会失败").AddButton("确定");
                Log.Error(e.Message);
            }

            networkLoad.CloseMySelf();
        }

        public void RefreshList()
        {
            View.List.numItems = SearchResults.Count;
        }
    }
}