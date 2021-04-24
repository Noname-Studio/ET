using Panthea.NativePlugins;
using RestaurantPreview.Config;
using Settings;
using UnityEngine;

namespace Client.UI.ViewModel
{
    public class UI_Settings: UIBase<View_setting>
    {
        private Data_GameRecord GameRecord { get; set; }
        private Preference Prefs { get; set; } = Preference.Inst;

        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            GameRecord = DBManager.Inst.Query<Data_GameRecord>();
            View.WebSite.onClick.Set(WebSite_OnClick);
            View.Service.onClick.Set(WebSite_OnClick);
            View.FAQ.onClick.Set(WebSite_OnClick);
            View.Pet.onClick.Set(Pet_OnClick);
            View.Voice.onClick.Set(Voice_OnClick);
            View.Music.onClick.Set(Music_OnClick);
            View.syncBtn.onClick.Set(SyncPlatform_OnClick);
            View.CopyAccount.onClick.Set(CopyAccount_OnClick);

            View.HeadPanel.Name.text = GameRecord.Name;
            View.HeadPanel.EditHead.icon = GameRecord.Head;
            View.Voice.selected = Prefs.SoundEffectVolume == 0;
            View.Music.selected = Prefs.mMusicVolume == 0;
            InitHeadPanel();
        }

        private void InitHeadPanel()
        {
            View.HeadPanel.EditHead.onClick.Add(EditHead_OnClick);
            View.HeadPanel.EditName.onClick.Add(EditName_OnClick);
        }

        private void EditName_OnClick()
        {
            var editName = UIKit.Inst.Create<UI_EditName>();
            editName.OnClose.Set(() => { View.HeadPanel.Name.text = editName.Text; });
        }

        private void EditHead_OnClick()
        {
            var editHead = UIKit.Inst.Create<UI_EditAvatar>();
            editHead.OnClose.Set(() => { View.HeadPanel.EditHead.icon = editHead.Url; });
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
            MediaManager.Inst.MusicVolume = View.Music.selected? 0 : 1;
            Prefs.MusicVolume = MediaManager.Inst.MusicVolume;
        }

        private void Voice_OnClick()
        {
            MediaManager.Inst.SoundEffectVolume = View.Voice.selected? 0 : 1;
            Prefs.SoundEffectVolume = MediaManager.Inst.SoundEffectVolume;
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
            var breakstr = isNeedWeb? "<br/>" : "";
            var account = $"User ID: {userId}" + breakstr + "\n" +
                    $"Platform: {Application.platform}" + breakstr + "\n" +
                    $"Facebook ID: {""}" + breakstr + "\n" +
                    $"Name: {record.Name}" + breakstr + "\n" +
                    $"Guild ID: ##{(GuildManager.Inst.Data != null? GuildManager.Inst.Data.Id.ToString() : "")}" + breakstr + "\n" +
                    $"Version: {Application.version}" + breakstr + "\n" +
                    $"OS version: {SystemInfo.operatingSystem}" + breakstr + "\n";
            return account;
        }

        protected override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
            Prefs.Save();
        }
    }
}