using Client.Manager;
using ET;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_EditGuildInfo: UIBase<View_GongHuiXinXiBianJi>
    {
        private UI_CreateGuild Panel { get; set; }
        private NetworkManager Session { get; set; }

        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            Session = NetworkManager.Inst;
            View.Creator.url = View_ChuangJianGongHui.URL;
            Panel = new UI_CreateGuild((View_ChuangJianGongHui) View.Creator.component, this);
            Panel.Init();
            Panel.View.CreateUnion.title = LocalizationProperty.Read("Confirm");
            Panel.View.CreateUnion.onClick.Set(Confirm_OnClick);
            RefreshUI();
        }

        private void RefreshUI()
        {
            var guildData = GuildManager.Inst.Data;
            Panel.View.inside.url = GuildIconProperty.Read(guildData.Inside.GetValueOrDefault(GuildIconProperty.DefaultInside.Id))?.Url;
            Panel.View.frame.url = GuildIconProperty.Read(guildData.Frame.GetValueOrDefault(GuildIconProperty.DefaultFrame.Id))?.Url;
            Panel.View.IsPublic.selected = guildData.IsPublic ?? true;
            Panel.SelectLanguage.Value = guildData.Language.ToString();
            Panel.SelectRestaurant.Value = ((int) 1000000 / guildData.MinLevel).ToString();
            Panel.View.UnionDesc.text = guildData.Desc;
            Panel.View.UnionName.text = guildData.Name;
        }

        private async void Confirm_OnClick()
        {
            var view = Panel.View;
            var guildData = GuildManager.Inst.Data;
            var frame = view.frame.data is int t1? t1 : 0;
            var inside = view.inside.data is int t2? t2 : 0;
            var level = RestaurantKey.Map(Panel.SelectRestaurant.Value) * GameConfig.RestaurantOffset;
            var language = (short) ((Language) Panel.SelectLanguage.Value).Id;
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>().OutOfTime(5);

            var modify = new C2M_ModifyGuild
            {
                Desc = view.UnionDesc.text == guildData.Desc? null : view.UnionDesc.text,
                Frame = frame == guildData.Frame? (int?) null : frame,
                Inside = inside == guildData.Inside? (int?) null : inside,
                IsPublic = view.IsPublic.selected == guildData.IsPublic? (bool?) null : view.IsPublic.selected,
                Language = language == guildData.Language? (short?) null : language,
                Name = view.UnionName.text == guildData.Name? null : view.UnionName.text,
                MinLevel = level == guildData.MinLevel? (int?) null : level
            };
            //避免发送空消息给服务器.占用线程.
            if (!(modify.Desc == null && modify.Frame == null && modify.Inside == null && modify.IsPublic == null && modify.Language == null &&
                modify.Name == null &&
                modify.MinLevel == null))
            {
                await Session.Call(modify);
            }
            networkLoad.CloseMySelf();
            CloseMySelf();
        }
    }
}