using Settings;

namespace Client.UI.ViewModel
{
    public class UI_EditAvatar : UIBase<View_EditAvatar>
    {
        public string Url { get; private set; }
        private Data_GameRecord Record { get; set; }
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            this.View.Confrim.onClick.Add(Confirm_OnClick);
            Record = DBManager.Inst.Query<Data_GameRecord>();
            Url = this.Record.Head;
            var nodes = this.View.AvatarList.GetChildren();
            for (int index = 0; index < nodes.Length; index++)
            {
                var node = nodes[index];
                var button = node.asButton;
                if (button.icon == this.Record.Head)
                {
                    this.View.AvatarList.selectedIndex = index;
                    break;
                }
            }

            if (string.IsNullOrEmpty(Url))
            {
                Url = "ui://Settings/0";
            }
        }

        private void Confirm_OnClick()
        {
            Record.Head = this.View.AvatarList.GetChildAt(this.View.AvatarList.selectedIndex).asButton.icon;
            Url = this.Record.Head;
            DBManager.Inst.Update(Record);
            this.CloseMySelf();
        }
    }
}