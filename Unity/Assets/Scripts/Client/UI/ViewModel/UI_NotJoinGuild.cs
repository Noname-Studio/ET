using System.Collections.Generic;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_NotJoinGuild: UIBase<View_WeiJiaRuGongHui>
    {
        private Dictionary<string, object> mSubPanel = new Dictionary<string, object>();

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
        }

        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.c1.onChanged.Add(MenuChanged);
            View.c1.onChanged.Call();
        }

        private async void MenuChanged()
        {
            if (View.c1.selectedPage == "加入公会")
            {
                View.GuildList.url = View_GongHuiLieBiao.URL;
                UI_GuildList panel;
                if (!mSubPanel.TryGetValue("join guild", out var obj))
                {
                    obj = new UI_GuildList((View_GongHuiLieBiao) View.GuildList.component, this);
                    await ((UI_GuildList) obj).Init();
                    mSubPanel.Add("join guild", obj);
                }

                panel = (UI_GuildList) obj;
            }
            else if (View.c1.selectedPage == "创建公会")
            {
                View.Creator.url = View_ChuangJianGongHui.URL;
                UI_CreateGuild panel;
                if (!mSubPanel.TryGetValue("create guild", out var obj))
                {
                    obj = new UI_CreateGuild((View_ChuangJianGongHui) View.Creator.component, this);
                    ((UI_CreateGuild) obj).Init();
                    mSubPanel.Add("create guild", obj);
                }

                panel = (UI_CreateGuild) obj;
            }
        }
    }
}