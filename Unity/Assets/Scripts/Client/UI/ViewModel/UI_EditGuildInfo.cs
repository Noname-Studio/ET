using ET;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_EditGuildInfo : UIBase<View_BianJiGongHuiXinXi>
    {
        private UI_CreateGuild Panel { get; set; }
        private Session Session { get; set; }
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            Session = Game.Scene.Get(1).GetComponent<Session>();
            this.View.Creator.url = View_ChuangJianGongHui.URL;
            Panel = new UI_CreateGuild((View_ChuangJianGongHui)this.View.Creator.component,this);
            Panel.Init();
            Panel.View.CreateUnion.title = LocalizationProperty.Read("Confirm");
            Panel.View.CreateUnion.onClick.Set(Confirm_OnClick);
            RefreshUI();
        }

        private void RefreshUI()
        {
            var guildData = GuildManager.Inst.Data;
            this.Panel.View.frame.url = GuildIconProperty.Read(guildData.Frame).Url ?? GuildIconProperty.DefaultFrame.Url;
            this.Panel.View.inside.url = GuildIconProperty.Read(guildData.Inside).Url ?? GuildIconProperty.DefaultInside.Url;
            this.Panel.View.IsPublic.selected = guildData.IsPublic;
            this.Panel.SelectLanguage.Value = guildData.Language.ToString();
            this.Panel.SelectRestaurant.Value = ((int) 1000000 / guildData.MinLevel).ToString();
            this.Panel.View.UnionDesc.text = guildData.Desc;
            this.Panel.View.UnionName.text = guildData.Name;
        }

        private async void Confirm_OnClick()
        {
            var view = this.Panel.View;
            var guildData = GuildManager.Inst.Data;
            var frame = view.frame.data is int t1? t1 : 0;
            var inside = view.inside.data is int t2? t2 : 0;
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>().OutOfTime(5);
            await this.Session.Call(new C2M_ModifyGuild
            {
                Desc = view.UnionDesc.text == guildData.Desc? null : view.UnionDesc.text,
                Frame = frame,
                Inside = inside,
                IsPublic = view.IsPublic.selected,
                Language = (short) ((Language) this.Panel.SelectLanguage.Value).Id,
                Name = view.UnionName.text == guildData.Name? null : view.UnionName.text,
                MinLevel = RestaurantKey.Map(this.Panel.SelectRestaurant.Value) * 1000000,
            });
            networkLoad.CloseMySelf();
        }
    }
}