using Cysharp.Threading.Tasks;
using GameBegins;
using Panthea.Asset;

namespace Client.UI.ViewModel
{
    public partial class UI_EnterLevelPanel : UIBase<View_GameBegins>
    {
        private IAssetsLocator AssetsLocator { get; }
        private KRManager KrManager { get; }
        private Data_GameRecord GameRecord { get; set; }
        private LevelProperty LevelProperty { get; set; }

        public UI_EnterLevelPanel()
        {
            AssetsLocator = AssetsKit.Inst;
            KrManager = KRManager.Inst;
        }

        public async override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            InitEditor();
            GameRecord = DBManager.Inst.Query<Data_GameRecord>();
            LevelProperty = await AssetsLocator.Load<LevelProperty>(GameConfig.LevelConfigPath + GameRecord.Level);
            InitPanel(LevelProperty);
            InitUI();
        }

        private void InitUI()
        {
            View.Play.onClick.Add(EnterLevel);
            View.Shop.onClick.Add(EnterShop);
        }

        private void EnterShop()
        {
            Manager.Create<UI_ShopQuick>();
        }

        private void EnterLevel()
        {
            if (LevelProperty != null)
            {
                //注入关卡
                KrManager.SwitchToKitchen<NormalKitchenMode>(LevelProperty).Forget();
            }
            CloseMySelf();
        }

        public void InitPanel(LevelProperty level)
        {
            LevelProperty = level;
            View.Level.text = level.Id.ToString();
        }
    }
}