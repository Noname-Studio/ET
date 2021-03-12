using System;
using Cysharp.Threading.Tasks;
using ET;
using FairyGUI;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall,Exit = WindowAnimType.Rise)]
    public class UI_ChangeGuildIcon : UIBase<View_HuiZhangZhiZuo>
    {
        private Session mSession { get; set; }
        public delegate UniTask Apply(UI_ChangeGuildIcon panel);
        public event Apply ApplyCallback;
        
        private string InitFrame { get; set; }
        private string InitInside { get; set; }
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            if (GuildManager.Inst.IsJoined())
            {
                InitFrame = this.View.frame.url = GuildIconProperty.Read(GuildManager.Inst.Data.Frame)?.Url ?? GuildIconProperty.DefaultFrame.Url;
                InitInside = this.View.inside.url = GuildIconProperty.Read(GuildManager.Inst.Data.Inside)?.Url ?? GuildIconProperty.DefaultInside.Url;
            }
            else
            {
                var data = GuildIconProperty.DefaultFrame;
                InitFrame = this.View.frame.url = data.Url;
                this.View.frame.data = data;
                
                data = GuildIconProperty.DefaultInside;
                InitInside = this.View.inside.url = data.Url;
                this.View.inside.data = data;
            }
            mSession = Game.Scene.Get(1).GetComponent<SessionComponent>().Session;
            
            this.View.List.onClickItem.Add(this.ClickItem);
            this.View.c1.onChanged.Add(MenuChanged);
            MenuChanged(null);
            //重设Close点击事件.关闭的时候我们需要弹出弹框告诉玩家是否放弃修改
            this.View.Close.onClick.Set(this.Close_OnClick);
            this.View.Confirm.onClick.Set(this.Confirm_OnClick);
        }

        private async void Confirm_OnClick()
        {
            if (this.View.frame.data == null)
                this.View.frame.data = 10001;
            else if (this.View.inside.data == null)
                this.View.inside.data = 20001;
            await ApplyCallback(this);
            this.InitFrame = this.View.frame.url;
            this.InitInside = this.View.inside.url;
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
            if (this.InitInside != this.View.inside.url || this.InitFrame != this.View.frame.url)
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.SetContent(LocalizationProperty.Read("ClosePanelDontApply"));
                tips.AddButton(LocalizationProperty.Read("Close"), t1 => this.CloseMySelf());
                tips.AddButton(LocalizationProperty.Read("Cancel"));
            }
            else
            {
                this.CloseMySelf();
            }
        }

        private void MenuChanged(EventContext context)
        {
            if (this.View.c1.selectedIndex == 0)
                this.InitFrameList();
            else
                this.InitInsideList();
        }

        private void ClickItem(EventContext context)
        {
            var button = (GButton) context.data;
            var property = button.data as GuildIconProperty;
            if (property.Type == GuildIconProperty.TypeEnum.Frame)
            {
                this.View.frame.url = property.Url;
                this.View.frame.data = property.Id;
            }
            else
            {
                this.View.inside.url = property.Url;
                this.View.inside.data = property.Id;
            }
        }

        private void InitFrameList()
        {
            int i = 0;
            this.View.List.RemoveChildrenToPool();
            foreach (var node in GuildIconProperty.ReadDict())
            {
                var property = node.Value;
                if (property.Type == GuildIconProperty.TypeEnum.Frame)
                {
                    var button = (GButton) this.View.List.AddItemFromPool();
                    button.icon = property.Url;
                    button.data = property;
                    if (this.InitFrame == property.Url)
                        this.View.List.selectedIndex = i;
                    i++;
                }
            }
        }

        private void InitInsideList()
        {
            int i = 0;
            this.View.List.RemoveChildrenToPool();
            foreach (var node in GuildIconProperty.ReadDict())
            {
                var property = node.Value;
                if (property.Type == GuildIconProperty.TypeEnum.Inside)
                {
                    var button = (GButton) this.View.List.AddItemFromPool();
                    button.icon = property.Url;
                    button.data = property;
                    if (this.InitInside == property.Url)
                        this.View.List.selectedIndex = i;
                    i++;
                }
            }
        }
    }
}