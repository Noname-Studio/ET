using Cysharp.Threading.Tasks;
using UI.Story.Log_in;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 这里检查玩家登录信息.如用手机号码登录.或者用GooglePlayID登录.
    /// 发送登录消息从服务器获得进入的Key后才能正常进入游戏.
    /// </summary>
    public class UI_Login : UIBase<View_Login>
    {
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.ButtonUp.onClick.Add(EnterGame);
        }

        private async void EnterGame()
        {
            var fadeEffect = EffectFactory.Create<FadeScreen>();
            fadeEffect.PlayDark();
            while (fadeEffect.IsPlaying)
            {
                await UniTask.NextFrame();
            }
            //这里我们做一些初始化的工作
            fadeEffect.PlayWhite();
            //进入实际场景了.
        }
    }
}