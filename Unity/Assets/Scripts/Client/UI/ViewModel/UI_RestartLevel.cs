using KitchenUI;

namespace Client.UI.ViewModel
{
    public class UI_RestartLevel : UIBase<View_game_quit>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.Type.selectedPage = "again";
            View.Yes.onClick.Set(Yes_OnClick);
            View.No.onClick.Set(No_OnClick);
        }

        private void No_OnClick()
        {
            CloseMySelf();
        }

        private void Yes_OnClick()
        {
            KitchenRoot.Inst.EndOfKitchenProvider.Restart();
            CloseMySelf();
            UIKit.Inst.Destroy<UI_KitchenPause>();
        }
    }
}