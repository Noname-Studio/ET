/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_GameBegins: GComponent
    {
        public Controller board_style;
        public Controller small_board;
        public GButton bg;
        public GGroup board;
        public GButton Close;
        public GButton Shop;
        public GButton Play;
        public View_JiaoSeXuanZe friendPanel;
        public GButton Help;
        public GTextField Restaurant;
        public GImage guidedifficult;
        public GTextField Level;
        public GTextField exname;
        public GList Prop;
        public GImage item0_bg;
        public GList MainTarget;
        public GImage item1_bg;
        public GList SubTarget;
        public View_recipebtn Recipe;
        public View_UpgradeObjectsTips upgradeTip;
        public GList testSelRestList;
        public const string URL = "ui://ytyvezjfo97638";

        public static View_GameBegins CreateInstance()
        {
            return (View_GameBegins) UIPackage.CreateObject("GameBegins", "GameBegins");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            board_style = GetController("board_style");
            small_board = GetController("small_board");
            bg = (GButton) GetChild("bg");
            board = (GGroup) GetChild("board");
            Close = (GButton) GetChild("Close");
            Shop = (GButton) GetChild("Shop");
            Play = (GButton) GetChild("Play");
            friendPanel = (View_JiaoSeXuanZe) GetChild("friendPanel");
            Help = (GButton) GetChild("Help");
            Restaurant = (GTextField) GetChild("Restaurant");
            guidedifficult = (GImage) GetChild("guidedifficult");
            Level = (GTextField) GetChild("Level");
            exname = (GTextField) GetChild("exname");
            Prop = (GList) GetChild("Prop");
            item0_bg = (GImage) GetChild("item0_bg");
            MainTarget = (GList) GetChild("MainTarget");
            item1_bg = (GImage) GetChild("item1_bg");
            SubTarget = (GList) GetChild("SubTarget");
            Recipe = (View_recipebtn) GetChild("Recipe");
            upgradeTip = (View_UpgradeObjectsTips) GetChild("upgradeTip");
            testSelRestList = (GList) GetChild("testSelRestList");
        }
    }
}