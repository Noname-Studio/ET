using TheGuild;

namespace Client.UI.ViewModel
{
    public class UI_CreateGuild
    {
        public View_ChuangJianGongHui View;
        private UI_NotJoinGuild mParent;
        public UI_CreateGuild(View_ChuangJianGongHui view,UI_NotJoinGuild parent)
        {
            this.View = view;
            this.mParent = parent;
        }
        
        public void Init()
        {
            this.View.ChangeUnionIcon.onClick.Add(this.ChangeUnionIconOnClick);
        }

        private void ChangeUnionIconOnClick()
        {
            
        }
    }
}