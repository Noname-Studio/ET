using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ET;
using FairyGUI;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_GuildList : UIBase<View_ChuangJianGongHui>
    {
        private R2C_SearchGuild SearchResults { get; };
        public override async void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            InitList();
            var networkLoad = Manager.Create<UI_NetworkLoad>().OutOfTime(5);
            var kcp = Game.Scene.Get(1).GetComponent<NetKcpComponent>();
            var response = (R2C_SearchGuild) await ClientHandler.Inst.Call(new SearchGuildRequest {param = new SearchGuildRequest.SearchGuildParams {MaxNum = 20, IsNewSearch = true}});
            SearchResults.AddRange(response.result);
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
            var response = (SearchGuildResponse) await ClientHandler.Inst.Call(new SearchGuildRequest {param = new SearchGuildRequest.SearchGuildParams {MaxNum = 20}});
            SearchResults.AddRange(response.result);
            await UniTask.SwitchToMainThread();
            if (response.result.Count == 0)
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
                var result = (SearchGuildResponse.SearchGuildResult) ((GComponent) t1.sender).data;
                Manager.Create<UI_NetworkLoad>().OutOfTime(5);
                var response = (JoinGuildResponse)await ClientHandler.Inst.Call(new JoinGuildRequest {id = result.Id});
                if (response.result == (ushort) StateCode.Success)
                {
                    CloseMySelf();
                    Manager.Create<UI_GuildHome>();
                }
                else
                {
                    Manager.Create<UI_Tips>().SetContent("加入公会失败").AddButton("确定");
                }
            });
        }

        public void RefreshList()
        {
            View.List.numItems = SearchResults.Count;
        }
    }
}