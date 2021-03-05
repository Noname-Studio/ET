using System.Collections.Generic;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_NotJoinGuild : UIBase<View_WeiJiaRuGongHui>
    {
        private Dictionary<string, object> mSubPanel = new Dictionary<string, object>();
        public override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
        }

        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            this.View.c1.onChanged.Add(MenuChanged);
        }

        private void MenuChanged()
        {
            if (this.View.c1.selectedPage == "加入公会")
            {
                this.View.GuildList.url = View_GongHuiLieBiao.URL;
                UI_GuildList panel;
                if (!this.mSubPanel.TryGetValue("join guild", out var obj))
                {
                    obj = new UI_GuildList((View_GongHuiLieBiao)this.View.GuildList.component,this);
                    mSubPanel.Add("join guild", obj);
                }
                panel = (UI_GuildList) obj;
                panel.OnEnable();
            }
            else if(this.View.c1.selectedPage == "创建公会")
            {
                this.View.GuildList.url = View_ChuangJianGongHui.URL;
                UI_GuildList panel;
                if (!this.mSubPanel.TryGetValue("join guild", out var obj))
                {
                    obj = new UI_GuildList((View_GongHuiLieBiao)this.View.GuildList.component,this);
                    mSubPanel.Add("join guild", obj);
                }
                panel = (UI_GuildList) obj;
                panel.OnEnable();
            }
        }
    }
}