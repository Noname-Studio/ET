/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
    public partial class View_BankNew: GComponent
    {
        public Controller c1;
        public GGroup BG;
        public GList Menu;
        public GTextField ItemDesc;
        public View_effect Effect;
        public View_Pack Detail;
        public GTextField ItemName2;
        public GLoader ItemIcon;
        public GImage NumShadow;
        public GTextField ItemName;
        public GImage OwnCountFrame;
        public GTextField OwnCount;
        public View_gift DiamondExt;
        public GButton Buy;
        public GButton buy_prop;
        public GTextField InfineTime;
        public GGroup InfineGroup;
        public GList DiamondList;
        public GList GiftList;
        public GList PropList;
        public GButton Close;

        public const string URL = "ui://yf9s6r30qmjolw";

        public static View_BankNew CreateInstance()
        {
            return (View_BankNew) UIPackage.CreateObject("Bank", "BankNew");
        }

        public View_BankNew()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            BG = (GGroup) GetChildAt(9);
            Menu = (GList) GetChildAt(14);
            ItemDesc = (GTextField) GetChildAt(17);
            Effect = (View_effect) GetChildAt(18);
            Detail = (View_Pack) GetChildAt(19);
            ItemName2 = (GTextField) GetChildAt(20);
            ItemIcon = (GLoader) GetChildAt(21);
            NumShadow = (GImage) GetChildAt(22);
            ItemName = (GTextField) GetChildAt(23);
            OwnCountFrame = (GImage) GetChildAt(24);
            OwnCount = (GTextField) GetChildAt(25);
            DiamondExt = (View_gift) GetChildAt(26);
            Buy = (GButton) GetChildAt(27);
            buy_prop = (GButton) GetChildAt(28);
            InfineTime = (GTextField) GetChildAt(30);
            InfineGroup = (GGroup) GetChildAt(32);
            DiamondList = (GList) GetChildAt(34);
            GiftList = (GList) GetChildAt(35);
            PropList = (GList) GetChildAt(36);
            Close = (GButton) GetChildAt(37);
        }
    }
}