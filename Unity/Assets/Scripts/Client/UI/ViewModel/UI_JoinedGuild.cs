using System;
using System.Collections.Generic;
using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_JoinedGuild : UIBase<View_UnionMainPanel>
    {
        public enum MenuType
        {
            Info,//我的公会
            Activity,//公会活动
            Chat,//聊天
            Help,//好友帮助
        }
        private Dictionary<int, object> mSubPanel = new Dictionary<int, object>();

        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            this.View.c2.onChanged.Add(this.Menu_OnChanged);
        }

        private void Menu_OnChanged()
        {
            if (this.View.c2.selectedPage == "我的公会")
                OpenPanel(MenuType.Info);
            else if(this.View.c2.selectedPage == "公会活动")
                OpenPanel(MenuType.Activity);
            else if (this.View.c2.selectedPage == "聊天")
                OpenPanel(MenuType.Chat);
            else if (this.View.c2.selectedPage == "成员互助")
                OpenPanel(MenuType.Help);
        }

        private void OpenPanel(MenuType menuType)
        {
            switch (menuType)
            {
                case MenuType.Info:
                    if (this.View.MyUnion.component == null)
                    {
                        this.View.MyUnion.url = View_WoDeGongHuiZuJian.URL;
                        var component = this.View.MyUnion.component;
                    }
                    break;
                case MenuType.Activity:
                    break;
                case MenuType.Chat:
                    break;
                case MenuType.Help:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof (menuType), menuType, null);
            }
        }
    }
}