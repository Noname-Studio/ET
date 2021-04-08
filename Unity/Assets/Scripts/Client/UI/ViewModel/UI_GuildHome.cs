using ET;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_GuildHome : InternalComponent
    {
        private UI_JoinedGuild Parent { get; }
        private View_WoDeGongHuiZuJian View { get; }
        private M2C_GuildUpdate GuildData { get; set; }

        public UI_GuildHome(UI_JoinedGuild parent, View_WoDeGongHuiZuJian view)
        {
            Parent = parent;
            View = view;
        }

        public override void OnEnable()
        {
            MessageKit.Inst.Add(EventKey.GuildChanged, Event_GuildChanged);
            GuildData = GuildManager.Inst.Data;
            RefreshUI();
        }

        public override void OnDisable()
        {
            MessageKit.Inst.Remove(EventKey.GuildChanged, Event_GuildChanged);
        }

        private void Event_GuildChanged()
        {
            GuildData = GuildManager.Inst.Data;
            RefreshUI();
        }

        public void RefreshUI()
        {
            View.Name.text = GuildData.Name;
            View.inside.url = GuildIconProperty.Read(GuildData.Inside.GetValueOrDefault(GuildIconProperty.DefaultInside.Id))?.Url;
            View.frame.url = GuildIconProperty.Read(GuildData.Frame.GetValueOrDefault(GuildIconProperty.DefaultFrame.Id))?.Url;
            View.NumOfPeople.text = GuildData.Members.Count + "/" + GuildData.MaxMemberNum;
            View.Edit.onClick.Set(Edit_OnClick);
            View.Menu.onClick.Set(Menu_OnClick);
            View.invite.onClick.Set(Invite_OnClick);
        }

        private void Invite_OnClick()
        {
            UIKit.Inst.Create<UI_GuildApplicationList>();
        }

        private void Menu_OnClick()
        {
            UIKit.Inst.Create<UI_GuildDetail>();
        }

        private void Edit_OnClick()
        {
            UIKit.Inst.Create<UI_EditGuildInfo>();
        }
    }
}