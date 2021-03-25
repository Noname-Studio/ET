using Cysharp.Threading.Tasks;
using Log_in;
using Panthea.NativePlugins.Ads;
using UnityEngine;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 这里检查玩家登录信息.如用手机号码登录.或者用GooglePlayID登录.
    /// 发送登录消息从服务器获得进入的Key后才能正常进入游戏.
    /// </summary>
    public class UI_Login : UIBase<View_Login>
    {
        [RuntimeInitializeOnLoadMethod]
        static void RegistryMessage()
        {
            MessageKit.Inst.Add<GameStart>(GameStartMsgHandler);
        }
        
        static void GameStartMsgHandler(GameStart msg)
        {
            UIKit.Inst.Create<UI_Login>();
        }
        
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            //View.ButtonUp.onClick.Add(EnterGame);
            this.View.FacebookButton.onClick.Add(() =>
            {
                Log.Print("开始登录");
                Social.Active.localUser.Authenticate(b =>
                {
                    Log.Print(b? "登录成功" : "登录失败");
                    Log.Print(Social.localUser.id + "    " + Social.localUser.userName);
                });
            });
            this.View.ButtonUp.onClick.Add(this.EnterGame);
        }

        private async void EnterGame()
        {
            var fadeEffect = EffectFactory.Create<FadeScreen>();
            await fadeEffect.PlayDark();
            this.CloseMySelf();
            //这里我们做一些初始化的工作
            if(UIKit.Inst.Find<UI_FirstGameLoading>() != null)
                UIKit.Inst.Destroy<UI_FirstGameLoading>();
            await KRManager.Inst.SwitchToRestaurant<NormalRestaurantMode>();
            await fadeEffect.PlayWhite();
            //进入实际场景了.
            fadeEffect.Dispose();
            
        }
    }
}