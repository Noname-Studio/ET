using Panthea.NativePlugins;
using RestaurantPreview.Config;
using Settings;
using UnityEngine;

namespace Client.UI.ViewModel
{
    public class UI_Settings : UIBase<View_setting>
    {
        private Data_GameRecord GameRecord { get; set; }
        private Preference Prefs { get; set; } = Preference.Inst;
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            this.GameRecord = DBManager.Inst.Query<Data_GameRecord>();
            this.View.WebSite.onClick.Set(this.WebSite_OnClick);
            this.View.Service.onClick.Set(this.WebSite_OnClick);
            this.View.FAQ.onClick.Set(this.WebSite_OnClick);
            this.View.Pet.onClick.Set(this.Pet_OnClick);
            this.View.Voice.onClick.Set(this.Voice_OnClick);
            this.View.Music.onClick.Set(this.Music_OnClick);
            this.View.syncBtn.onClick.Set(this.SyncPlatform_OnClick);
            this.View.CopyAccount.onClick.Set(this.CopyAccount_OnClick);

            this.View.HeadPanel.Name.text = GameRecord.Name;
            this.View.HeadPanel.EditHead.icon = this.GameRecord.Head;
            this.View.Voice.selected = this.Prefs.SoundEffectVolume == 1;
            this.View.Music.selected = this.Prefs.mMusicVolume == 1;
            InitHeadPanel();
        }

        private void InitHeadPanel()
        {
            this.View.HeadPanel.EditHead.onClick.Add(EditHead_OnClick);
            this.View.HeadPanel.EditName.onClick.Add(EditName_OnClick);
        }

        private void EditName_OnClick()
        {
            var editName = UIKit.Inst.Create<UI_EditName>();
            editName.OnClose.Set(() =>
            {
                this.View.HeadPanel.Name.text = editName.Text;
            });
        }

        private void EditHead_OnClick()
        {
            var editHead = UIKit.Inst.Create<UI_EditAvatar>();
            editHead.OnClose.Set(() =>
            {
                this.View.HeadPanel.EditHead.icon = editHead.Url;
            });
        }

        private void CopyAccount_OnClick()
        {
            var record = DBManager.Inst.Query<Data_GameRecord>();
            GUIUtility.systemCopyBuffer = record.id.ToString();
        }

        private async void SyncPlatform_OnClick()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.SetContent(LocalizationProperty.Read("NetworkNotReachable"));
                return;
            }
            var networkLoad = UIKit.Inst.Create<UI_NetworkLoad>();
            await PlatformLogin.Login();
            networkLoad.CloseMySelf();
        }

        private void Music_OnClick()
        {
            MediaManager.Inst.MusicVolume = this.View.Music.selected? 0 : 1;
        }

        private void Voice_OnClick()
        {
            MediaManager.Inst.SoundEffectVolume = this.View.Voice.selected? 0 : 1;
        }

        private void Pet_OnClick()
        {
        }

        private void WebSite_OnClick()
        {
            var tips = UIKit.Inst.Create<UI_Tips>();
            tips.SetContent("暂未实现");
            tips.AddButton(LocalizationProperty.Read("Confirm"));
        }
        
        private string GetAccountInfo(bool isNeedWeb = true)
        {
            var record = DBManager.Inst.Query<Data_GameRecord>();
            var userId = record.id;
            var breakstr = isNeedWeb ? "<br/>" : "";
            var account = $"User ID: {userId}"+ breakstr +"\n" +
                    $"Platform: {Application.platform}"+ breakstr +"\n" +
                    $"Facebook ID: {""}"+ breakstr +"\n" +
                    $"Name: {record.Name}"+ breakstr +"\n" +
                    $"Guild ID: ##{(GuildManager.Inst.Data != null ? GuildManager.Inst.Data.Id.ToString() : "")}"+ breakstr +"\n"+
                    $"Version: {Application.version}"+ breakstr +"\n" +
                    $"OS version: {SystemInfo.operatingSystem}"+ breakstr +"\n";
            return account;
        }

        public override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
            this.Prefs.Save();
        }
    }
}