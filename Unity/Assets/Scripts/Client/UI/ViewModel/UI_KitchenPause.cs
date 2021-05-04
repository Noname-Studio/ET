using FairyGUI;
using KitchenStop;
using RestaurantPreview.Config;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall, Exit = WindowAnimType.Rise, Pool = true)]
    public class UI_KitchenPause: UIBase<View_stop>
    {
        private LevelProperty LevelProperty { get; }

        public UI_KitchenPause()
        {
            LevelProperty = KitchenRoot.Inst.LevelProperty;
        }

        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.Back.onClick.Set(Back_OnClick);
            View.Restart.onClick.Set(Restart_OnClick);
            View.Rest.text = LocalizationProperty.Read(LevelProperty.Restaurant.Key);
            View.Level.text = LocalizationProperty.Read("Level X");
            View.Exit.onClick.Set(Exit_OnClick);
        }

        private void Exit_OnClick()
        {
            UIKit.Inst.Create<UI_QuitLevel>();
        }

        private void Restart_OnClick(EventContext context)
        {
            if (EnergyManager.Inst.IsInfine)
            {
                //UIKit.Inst.Create<UI_EnterLevelPanel>();
                KitchenRoot.Inst.EndOfKitchenProvider.Restart();
                CloseMySelf();
            }
            else
                UIKit.Inst.Create<UI_RestartLevel>();
        }

        private void Back_OnClick(EventContext context)
        {
            CloseMySelf();
        }

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            TimerKit.Inst.UnityTimer.Pause();
        }

        protected override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
            TimerKit.Inst.UnityTimer.Resume();
        }
    }
}