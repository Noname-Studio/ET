using System;
using FairyGUI;
using View_Tips = InternalResources.View_Tips;

namespace Client.UI.ViewModel
{
    public class UI_Tips : UIBase<View_Tips>
    {
        public UI_Tips SetContent(string content)
        {
            View.Content.text = content;
            return this;
        }

        public UI_Tips AddButton(string title, Action<UI_Tips> callback = null)
        {
            var button = (GButton)View.ButtonList.AddItemFromPool();
            button.title = title;
            if(callback != null)
                button.onClick.Set(()=>callback(this));
            button.onClick.Add(CloseMySelf);
            return this;
        }
    }
}