using Client.UI.ViewComponent;
using Cysharp.Threading.Tasks;
using ET;
using FairyGUI;
using RestaurantPreview.Config;
using TheGuild;
using StringHelper = Client.Helper.StringHelper;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 创建公会
    /// </summary>
    public class UI_CreateGuild
    {
        private Session mSession { get; set; }
        public View_ChuangJianGongHui View { get; }
        private NameInput NameInput { get; }
        private Combo_SelectRestaurant SelectRestaurant { get; }
        private Combo_SelectLanguage SelectLanguage { get; }
        private UI_NotJoinGuild mParent { get; }
        private C2M_CreateGuild CreateGuildRequest { get; }
        public UI_CreateGuild(View_ChuangJianGongHui view,UI_NotJoinGuild parent)
        {
            this.View = view;
            this.mParent = parent;
            mSession = Game.Scene.Get(1).GetComponent<SessionComponent>().Session;
            this.CreateGuildRequest = new C2M_CreateGuild();
            this.NameInput = new NameInput(this.View.UnionName);
            this.SelectRestaurant = new Combo_SelectRestaurant(this.View.UnionRestSelect);
            this.SelectLanguage = new Combo_SelectLanguage(this.View.LangSelect);
            this.View.CreateUnion.onClick.Add(CreateUnion_OnClick);
            this.View.frame.url = GuildIconProperty.DefaultFrame.Url;
            this.View.frame.data = GuildIconProperty.DefaultFrame.Id;
            this.View.inside.url = GuildIconProperty.DefaultInside.Url;
            this.View.inside.data = GuildIconProperty.DefaultInside.Id;
        }

        private async void CreateUnion_OnClick(EventContext context)
        {
            string error = StringHelper.CheckNameIsVaild(this.NameInput.Text, 16);
            if (!string.IsNullOrEmpty(error))
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.SetContent(error);
                tips.AddButton(LocalizationProperty.Read("Confirm"));
                return;
            }

            this.CreateGuildRequest.Name = this.NameInput.Text;
            this.CreateGuildRequest.Frame = (int) this.View.frame.data;
            this.CreateGuildRequest.Inside = (int) this.View.inside.data;
            this.CreateGuildRequest.Language = (short)((Language)this.SelectLanguage.Value).Id;
            this.CreateGuildRequest.MinLevel = RestaurantKey.Map(this.SelectRestaurant.Value) * 1000000;
            this.CreateGuildRequest.IsPublic = this.View.IsPublic.selected;
            this.CreateGuildRequest.Desc = this.View.UnionDesc.text;
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>();
            var response = await mSession.Call(this.CreateGuildRequest);
            networkLoad.CloseMySelf();
            if (response.Error >= ErrorCode.ERR_LogicError)
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.SetContent(LocalizationProperty.Read("CreateUnionError"));
                tips.AddButton(LocalizationProperty.Read("Confirm"));
            }
            else
            {
                mParent.CloseMySelf();
            }
        }

        public void Init()
        {
            this.View.ChangeUnionIcon.onClick.Add(this.ChangeUnionIconOnClick);
        }

        private void ChangeUnionIconOnClick()
        {
            var panel = UIKit.Inst.Create<UI_ChangeGuildIcon>();
            panel.ApplyCallback += ChangeGuildIcon_OnApplyCallback;
        }

        private UniTask ChangeGuildIcon_OnApplyCallback(UI_ChangeGuildIcon panel)
        {
            this.View.frame.url = panel.View.frame.url;
            this.View.inside.url = panel.View.inside.url;
            this.CreateGuildRequest.Frame = (int) panel.View.frame.data;
            this.CreateGuildRequest.Inside = (int) panel.View.inside.data;
            return UniTask.CompletedTask;
        }
    }
}