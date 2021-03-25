using Main;

namespace Client.UI.ViewModel
{
    public class UI_RestaurantMain : UIBase<View_Main>
    {
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            InitUI();
        }

        private void InitUI()
        {
            this.View.Play.onClick.Set(PlayGame_OnClick);
            this.View.Club.onClick.Set(Club_OnClick);
            this.View.Settings.onClick.Set(Settings_OnClick);
        }

        private void Settings_OnClick()
        {
            UIKit.Inst.Create<UI_Settings>();
        }

        private void Club_OnClick()
        {
            if (!GuildManager.Inst.IsJoined())
                UIKit.Inst.Create<UI_NotJoinGuild>();
            else
                UIKit.Inst.Create<UI_JoinedGuild>();
        }

        private void PlayGame_OnClick()
        {
            if (EnterLevelHelper.CheckCondition())
            {
                UIKit.Inst.Create<UI_EnterLevelPanel>();
            }
        }
    }
}