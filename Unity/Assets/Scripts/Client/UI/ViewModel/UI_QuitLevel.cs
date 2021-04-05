using KitchenUI;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall,Exit = WindowAnimType.Rise)]
    public class UI_QuitLevel : UIBase<View_game_quit>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.Type.selectedPage = "quit";
            View.Yes.onClick.Set(Yes_OnClick);
            View.No.onClick.Set(No_OnClick);
        }

        private void No_OnClick()
        {
            CloseMySelf();
        }

        private void Yes_OnClick()
        {
            KRManager.Inst.BackPrevMode();
        }
        
    }
}