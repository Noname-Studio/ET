using Client.UI.ViewComponent;
using Settings;

namespace Client.UI.ViewModel
{
    public class UI_EditName : UIBase<View_EditName>
    {
        private NameInput mNameInput { get; set; }

        public string Text
        {
            get
            {
                return this.mNameInput.Text;
            }
        }
        
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            mNameInput = new NameInput(this.View.Input);
            this.View.Confrim.onClick.Set(Confirm_OnClick);
        }

        private void Confirm_OnClick()
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            gameRecord.Name = this.mNameInput.Text;
            DBManager.Inst.Update(gameRecord);
            this.CloseMySelf();
        }
    }
}