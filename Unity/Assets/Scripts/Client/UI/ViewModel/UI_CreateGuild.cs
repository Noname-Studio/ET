using System;
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
        public Combo_SelectRestaurant SelectRestaurant { get; }
        public Combo_SelectLanguage SelectLanguage { get; }
        private UIBase mParent { get; }
        private C2M_CreateGuild CreateGuildRequest { get; }

        public UI_CreateGuild(View_ChuangJianGongHui view, UIBase parent)
        {
            View = view;
            mParent = parent;
            mSession = Game.Scene.Get(1).GetComponent<SessionComponent>().Session;
            CreateGuildRequest = new C2M_CreateGuild();
            NameInput = new NameInput(View.UnionName);
            SelectRestaurant = new Combo_SelectRestaurant(View.UnionRestSelect);
            SelectLanguage = new Combo_SelectLanguage(View.LangSelect);
            View.CreateUnion.onClick.Add(CreateUnion_OnClick);
            View.frame.url = GuildIconProperty.DefaultFrame.Url;
            View.frame.data = GuildIconProperty.DefaultFrame.Id;
            View.inside.url = GuildIconProperty.DefaultInside.Url;
            View.inside.data = GuildIconProperty.DefaultInside.Id;
            SelectLanguage.Component.dropdown.sortingOrder = mParent.GComponent.sortingOrder;
            SelectRestaurant.Component.dropdown.sortingOrder = mParent.GComponent.sortingOrder;
        }

        private async void CreateUnion_OnClick(EventContext context)
        {
            string error = StringHelper.CheckNameIsVaild(NameInput.Text, 16);
            if (!string.IsNullOrEmpty(error))
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.SetContent(error);
                tips.AddButton(LocalizationProperty.Read("Confirm"));
                return;
            }

            CreateGuildRequest.Name = NameInput.Text;
            CreateGuildRequest.Frame = (int) View.frame.data;
            CreateGuildRequest.Inside = (int) View.inside.data;
            CreateGuildRequest.Language = (short) ((Language) SelectLanguage.Value).Id;
            CreateGuildRequest.MinLevel = RestaurantKey.Map(SelectRestaurant.Value) * GameConfig.RestaurantOffset;
            CreateGuildRequest.IsPublic = View.IsPublic.selected;
            CreateGuildRequest.Desc = View.UnionDesc.text;
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>();
            try
            {
                var response = await mSession.Call(CreateGuildRequest);
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
            catch (Exception e)
            {
                Log.Error(e);
            }
            finally
            {
                networkLoad.CloseMySelf();
            }
        }

        public void Init()
        {
            View.ChangeUnionIcon.onClick.Add(ChangeUnionIconOnClick);
        }

        private void ChangeUnionIconOnClick()
        {
            var panel = UIKit.Inst.Create<UI_ChangeGuildIcon>();
            panel.ApplyCallback += ChangeGuildIcon_OnApplyCallback;
        }

        private UniTask ChangeGuildIcon_OnApplyCallback(UI_ChangeGuildIcon panel)
        {
            View.frame.url = panel.View.frame.url;
            View.inside.url = panel.View.inside.url;
            CreateGuildRequest.Frame = (int) panel.View.frame.data;
            CreateGuildRequest.Inside = (int) panel.View.inside.data;
            return UniTask.CompletedTask;
        }
    }
}