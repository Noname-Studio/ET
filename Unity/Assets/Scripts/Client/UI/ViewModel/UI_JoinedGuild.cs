using System;
using System.Collections.Generic;
using TheGuild;

namespace Client.UI.ViewModel
{
    [UIWindow(Background = true,Enter = WindowAnimType.ScaleToNormal,Exit = WindowAnimType.ScaleToZero)]
    public class UI_JoinedGuild: UIBase<View_UnionMainPanel>
    {
        public enum MenuType
        {
            Info, //我的公会
            Activity, //公会活动
            Chat, //聊天
            Help //好友帮助
        }

        private Dictionary<int, InternalComponent> mSubPanel { get; }= new Dictionary<int, InternalComponent>();
        private InternalComponent ActiveUI { get; set; }
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.c2.onChanged.Add(Menu_OnChanged);
            Menu_OnChanged();
        }

        private void Menu_OnChanged()
        {
            if (View.c2.selectedPage == "我的公会")
            {
                OpenPanel(MenuType.Info);
            }
            else if (View.c2.selectedPage == "公会活动")
            {
                OpenPanel(MenuType.Activity);
            }
            else if (View.c2.selectedPage == "聊天")
            {
                OpenPanel(MenuType.Chat);
            }
            else if (View.c2.selectedPage == "成员互助")
            {
                OpenPanel(MenuType.Help);
            }
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            GC.Collect();
        }

        private void OpenPanel(MenuType menuType)
        {
            if (ActiveUI != null)
            {
                ActiveUI.OnDisable();
            }

            InternalComponent ui;
            switch (menuType)
            {
                case MenuType.Info:
                    if (!mSubPanel.TryGetValue((int) MenuType.Info, out ui))
                    {
                        View.MyUnion.url = View_WoDeGongHuiZuJian.URL;
                        ui = new UI_GuildHome(this, (View_WoDeGongHuiZuJian) View.MyUnion.component);
                        mSubPanel.Add((int)MenuType.Info, ui);
                    }
                    ui.OnEnable();
                    ActiveUI = ui;
                    break;
                case MenuType.Activity:
                    break;
                case MenuType.Chat:
                    if (!mSubPanel.TryGetValue((int) MenuType.Chat, out ui))
                    {
                        View.Chat.url = View_LiaoTianZuJian.URL;
                        ui = new UI_GuildChat(this, (View_LiaoTianZuJian) View.Chat.component);
                        mSubPanel.Add((int)MenuType.Chat, ui);
                    }
                    ui.OnEnable();
                    ActiveUI = ui;
                    break;
                case MenuType.Help:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof (menuType), menuType, null);
            }
        }
    }
}