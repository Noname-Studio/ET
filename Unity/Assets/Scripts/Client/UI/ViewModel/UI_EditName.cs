using Client.UI.ViewComponent;
using Settings;

namespace Client.UI.ViewModel
{
    public class UI_EditName: UIBase<View_EditName>
    {
        private NameInput mNameInput { get; set; }

        public string Text => mNameInput.Text;

        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            mNameInput = new NameInput(View.Input);
            View.Confrim.onClick.Set(Confirm_OnClick);
        }

        private void Confirm_OnClick()
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            gameRecord.Name = mNameInput.Text;
            DBManager.Inst.Update(gameRecord);
            CloseMySelf();
        }
    }
}