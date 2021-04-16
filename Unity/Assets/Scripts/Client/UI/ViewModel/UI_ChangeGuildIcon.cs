using System;
using Cysharp.Threading.Tasks;
using ET;
using FairyGUI;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall, Exit = WindowAnimType.Rise,Background = true)]
    public class UI_ChangeGuildIcon: UIBase<View_HuiZhangZhiZuo>
    {
        private Session mSession { get; set; }

        public delegate UniTask Apply(UI_ChangeGuildIcon panel);

        public event Apply ApplyCallback;

        private string InitFrame { get; set; }
        private string InitInside { get; set; }
        public GuildIconProperty SelectedFrame { get; set; }
        public GuildIconProperty SelectedInside { get; set; }
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            if (GuildManager.Inst.IsJoined())
            {
                var guildData = GuildManager.Inst.Data;
                SelectedInside = GuildIconProperty.Read(guildData.Inside.GetValueOrDefault(GuildIconProperty.DefaultInside.Id));
                InitInside = View.inside.url = SelectedInside.Url;
                SelectedFrame = GuildIconProperty.Read(guildData.Frame.GetValueOrDefault(GuildIconProperty.DefaultFrame.Id));
                InitFrame = View.frame.url = SelectedFrame.Url;
            }
            else
            {
                var data = GuildIconProperty.DefaultFrame;
                SelectedFrame = data;
                InitFrame = View.frame.url = data.Url;
                View.frame.data = data;

                data = GuildIconProperty.DefaultInside;
                SelectedInside = data;
                InitInside = View.inside.url = data.Url;
                View.inside.data = data;
            }

            mSession = Game.Scene.Get(1).GetComponent<SessionComponent>().Session;

            View.List.onClickItem.Add(ClickItem);
            View.c1.onChanged.Add(MenuChanged);
            MenuChanged(null);
            //重设Close点击事件.关闭的时候我们需要弹出弹框告诉玩家是否放弃修改
            View.Close.onClick.Set(Close_OnClick);
            View.Confirm.onClick.Set(Confirm_OnClick);
        }

        private async void Confirm_OnClick()
        {
            if (View.frame.data == null)
            {
                View.frame.data = 10001;
            }
            else if (View.inside.data == null)
            {
                View.inside.data = 20001;
            }

            await ApplyCallback(this);
            InitFrame = View.frame.url;
            InitInside = View.inside.url;
            /*var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>();
            if (this.View.frame != null && this.View.inside != null)
            {
                if ((int)this.View.frame.data == GuildManager.Inst.Data.Frame && (int)this.View.inside.data == GuildManager.Inst.Data.Inside)
                {
                    await UniTask.Delay(200, true);                
                }
                else
                {
                    var update = new C2G_GuildUpdate();
                    update.Frame = (int)this.View.frame.data;
                    update.Inside = (int)this.View.inside.data;
                    await mSession.Call(update);
                }
            }
            else
            {
                await UniTask.Delay(200, true);
            }
            networkLoad.CloseMySelf();*/
        }

        private void Close_OnClick()
        {
            if (InitInside != View.inside.url || InitFrame != View.frame.url)
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.SetContent(LocalizationProperty.Read("ClosePanelDontApply"));
                tips.AddButton(LocalizationProperty.Read("Close"), t1 => CloseMySelf());
                tips.AddButton(LocalizationProperty.Read("Cancel"));
            }
            else
            {
                CloseMySelf();
            }
        }

        private void MenuChanged(EventContext context)
        {
            if (View.c1.selectedIndex == 0)
            {
                InitFrameList();
            }
            else
            {
                InitInsideList();
            }
        }

        private void ClickItem(EventContext context)
        {
            var button = (GButton) context.data;
            var property = button.data as GuildIconProperty;
            if (property.Type == GuildIconProperty.TypeEnum.Frame)
            {
                View.frame.url = property.Url;
                SelectedFrame = property;
            }
            else
            {
                View.inside.url = property.Url;
                SelectedInside = property;
            }
        }

        private void InitFrameList()
        {
            int i = 0;
            View.List.RemoveChildrenToPool();
            foreach (var node in GuildIconProperty.ReadDict())
            {
                var property = node.Value;
                if (property.Type == GuildIconProperty.TypeEnum.Frame)
                {
                    var button = (GButton) View.List.AddItemFromPool();
                    button.icon = property.Url;
                    button.data = property;
                    if (SelectedFrame.Url == property.Url)
                    {
                        View.List.selectedIndex = i;
                    }

                    i++;
                }
            }
        }

        private void InitInsideList()
        {
            int i = 0;
            View.List.RemoveChildrenToPool();
            foreach (var node in GuildIconProperty.ReadDict())
            {
                var property = node.Value;
                if (property.Type == GuildIconProperty.TypeEnum.Inside)
                {
                    var button = (GButton) View.List.AddItemFromPool();
                    button.icon = property.Url;
                    button.data = property;
                    if (SelectedInside.Url == property.Url)
                    {
                        View.List.selectedIndex = i;
                    }

                    i++;
                }
            }
        }
    }
}