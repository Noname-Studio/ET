using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ET;
using FairyGUI;
using TheGuild;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 公会列表
    /// </summary>
    public class UI_GuildList
    {
        private List<SearchGuildResult> SearchResults { get; } = new List<SearchGuildResult>();
        private Session Session;
        private View_GongHuiLieBiao View;
        private UI_NotJoinGuild Parent;
        public UI_GuildList(View_GongHuiLieBiao guildList,UI_NotJoinGuild parent)
        {
            View = guildList;
            Parent = parent;
        }
        
        public async void OnEnable()
        {
            InitList();
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>().OutOfTime(5);
            Session = Game.Scene.Get(1).GetComponent<SessionComponent>().Session;
            
            var response = (M2C_SearchGuild) await Session.Call(new C2M_SearchGuild() {MaxNum = 20, IsNewSearch = true});
            SearchResults.AddRange(response.Results);
            await UniTask.SwitchToMainThread();
            networkLoad.CloseMySelf();
            RefreshList();
        }

        private void InitList()
        {
            View.List.SetVirtual();
            View.List.itemRenderer = SearchResultItemRender;
            View.List.scrollPane.onPullUpRelease.Set(OnPullUpToRefresh);
        }
        
        private async void OnPullUpToRefresh()
        {
            View_PullListToRefresh footer = (View_PullListToRefresh)View.List.scrollPane.footer;
            View.List.scrollPane.LockFooter(footer.sourceHeight);
            footer.Desc.text = "查看更多内容";
            footer.c1.selectedPage = "WaitNet";
            footer.t0.Play();
            var response = (M2C_SearchGuild) await Session.Call(new C2M_SearchGuild() {MaxNum = 20, IsNewSearch = true});
            SearchResults.AddRange(response.Results);
            await UniTask.SwitchToMainThread();
            if (response.Results.Count == 0)
            {
                footer.Desc.text = "没有更多内容";
                footer.c1.selectedPage = "WithoutAnyData";
                await UniTask.Delay(1500, true);
            }
            RefreshList();
            View.List.scrollPane.LockFooter(0);
            footer.t0.Stop();
            footer.Desc.text = "查看更多内容";//上拉查看更多
            footer.c1.selectedPage = "WaitNet";
        }

        private void SearchResultItemRender(int index, GObject obj)
        {
            var item = (View_JiaRuGongHuiZuJian) obj;
            var data = SearchResults[index];
            item.frame.icon = "ui://TheGuild/" + data.Outer;
            item.inside.icon = "ui://TheGuild/" + data.Frame;
            item.UnionName.text = data.Name;
            item.UnionDesc.text = data.Desc;
            item.Join.data = data;
            item.Join.onClick.Set(async t1 =>
            {
                var result = (SearchGuildResult) ((GComponent) t1.sender).data;
                UIKit.Inst.Create<UI_NetworkLoad>().OutOfTime(5);
                var response = (M2C_JoinGuild)await Session.Call(new C2M_JoinGuild() {Id = result.Id});
                if (response.Error == 0)
                {
                    this.Parent.CloseMySelf();
                    UIKit.Inst.Create<UI_GuildHome>();
                }
                else
                {
                    UIKit.Inst.Create<UI_Tips>().SetContent("加入公会失败").AddButton("确定");
                }
            });
        }

        public void RefreshList()
        {
            View.List.numItems = SearchResults.Count;
        }
    }
}