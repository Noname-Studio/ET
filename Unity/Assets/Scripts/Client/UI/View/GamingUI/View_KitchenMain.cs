/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_KitchenMain: GComponent
    {
        public Controller ui_style;
        public View_coinsBar ScoreBar;
        public View_timerBar TimeBar;
        public View_Condition Condition;
        public View_infiniteBar InfiniteTargetBar;
        public GButton Pause;
        public GButton Exit;
        public GList PropList;
        public View_ContinuousService ComboBar;
        public const string URL = "ui://dpc3yd4ttmfv3";

        public static View_KitchenMain CreateInstance()
        {
            return (View_KitchenMain) UIPackage.CreateObject("GamingUI", "KitchenMain");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ui_style = GetController("ui_style");
            ScoreBar = (View_coinsBar) GetChild("ScoreBar");
            TimeBar = (View_timerBar) GetChild("TimeBar");
            Condition = (View_Condition) GetChild("Condition");
            InfiniteTargetBar = (View_infiniteBar) GetChild("InfiniteTargetBar");
            Pause = (GButton) GetChild("Pause");
            Exit = (GButton) GetChild("Exit");
            PropList = (GList) GetChild("PropList");
            ComboBar = (View_ContinuousService) GetChild("ComboBar");
        }
    }
}