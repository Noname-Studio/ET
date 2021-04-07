using System;
using Client.Manager;
using ET;
using RestaurantPreview.Config;
using TheGuild;

namespace Client.UI.ViewModel
{
    [UIWindow(Repeat = true,Enter = WindowAnimType.ScaleToNormal,Exit = WindowAnimType.ScaleToZero )]
    public class UI_GuildInviteTips : UIBase<View_GongHuiYaoQing>
    {
        public class ParamsData: IUIParams
        {
            public GuildInviteInfo Info;

            public ParamsData(GuildInviteInfo info)
            {
                Info = info;
            }
        }
        
        private ParamsData Args { get; set; }
        
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            Args = p as ParamsData;
            if (Args == null)
            {
                Log.Error("参数错误");
                CloseMySelf();
                return;
            }
            InitUI();
        }

        public void InitUI()
        {
            View.Name.text = Args.Info.Name;
            View.frame.icon = GuildIconProperty.Read(Args.Info.Frame)?.Url;
            View.inside.icon = GuildIconProperty.Read(Args.Info.Inside)?.Url;
            View.Ignore.onClick.Set(Ignore_OnClick);
            View.Join.onClick.Set(Join_OnClick);
            View.NumberOfPeople.text = Args.Info.MemberNum.ToString();
        }

        private async void Join_OnClick()
        {
            var network = UIKit.Inst.Create<UI_NetworkLoad>();
            try
            {
                await NetworkManager.Inst.Call(new C2G_HandleGuildInvite { GuildId = Args.Info.GuildId, Approve = true });
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            network.CloseMySelf();
        }

        private void Ignore_OnClick()
        {
            NetworkManager.Inst.Send(new C2G_HandleGuildInvite { GuildId = Args.Info.GuildId, Approve = false });
        }
    }
}