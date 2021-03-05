using FairyGUI;
using KitchenStop;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall,Exit = WindowAnimType.Rise,Pool = true)]
    public class UI_KitchenPause : UIBase<View_stop>
    {
        private LevelProperty LevelProperty { get; }

        public UI_KitchenPause()
        {
            LevelProperty = KitchenRoot.Inst.LevelProperty;
        }
        
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.Back.onClick.Set(BackOnClick);
            View.Restart.onClick.Set(RestartOnClick);
        }

        private void RestartOnClick(EventContext context)
        {
            //TODO 这里应该调用KichenRoot的失败处理..这里先快速实现重启游戏的功能
            
        }
        
        private void BackOnClick(EventContext context)
        {
            CloseMySelf();
        }
    }
}