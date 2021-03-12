using ET;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_GuildHome
    {
        private UI_JoinedGuild Parent { get; }
        private View_WoDeGongHuiZuJian View { get; }
        private M2C_GuildUpdate GuildData { get; set; }
        public UI_GuildHome(UI_JoinedGuild parent, View_WoDeGongHuiZuJian view)
        {
            Parent = parent;
            View = view;
        }

        public void OnEnable()
        {
            MessageKit.Inst.Add(EventKey.GuildChanged, Event_GuildChanged);
            GuildData = GuildManager.Inst.Data;
            this.RefreshUI();
        }

        public void OnDisable()
        {
            MessageKit.Inst.Remove(EventKey.GuildChanged, this.Event_GuildChanged);
        }

        private void Event_GuildChanged()
        {
            GuildData = GuildManager.Inst.Data;
            this.RefreshUI();
        }

        public void RefreshUI()
        {
            this.View.Name.text = this.GuildData.Name;
            this.View.frame.url = GuildIconProperty.Read(this.GuildData.Frame)?.Url ?? GuildIconProperty.DefaultFrame.Url;
            this.View.inside.url = GuildIconProperty.Read(this.GuildData.Inside)?.Url ?? GuildIconProperty.DefaultInside.Url;
            this.View.NumOfPeople.text = this.GuildData.Members.Count + "/" + this.GuildData.MaxMemberNum;
            this.View.Edit.onClick.Set(Edit_OnClick);
            this.View.Menu.onClick.Set(Menu_OnClick);
        }

        private void Menu_OnClick()
        {
            UIKit.Inst.Create<UI_GuildInfoDetail>();
        }

        private void Edit_OnClick()
        {
            UIKit.Inst.Create<UI_EditGuildInfo>();
        }
    }
}