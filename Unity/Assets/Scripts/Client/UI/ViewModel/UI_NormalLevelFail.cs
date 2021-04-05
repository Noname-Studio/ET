using KitchenUI;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall,Exit = WindowAnimType.Rise)]
    public class UI_NormalLevelFail : UIBase<View_failure>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.exit.onClick.Set(Exit_OnClick);
        }

        private void Exit_OnClick()
        {
            KRManager.Inst.BackPrevMode();
            CloseMySelf();
        }
    }
}