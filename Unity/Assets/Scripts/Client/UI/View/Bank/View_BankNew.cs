/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bank
{
    public partial class View_BankNew : GComponent
    {
        public Controller Page;
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
        public GTextField InfineTime;
        public GGroup InfineGroup;
        public GList List;
        public GButton Close;
        public const string URL = "ui://yf9s6r30qmjolw";

        public static View_BankNew CreateInstance()
        {
            return (View_BankNew)UIPackage.CreateObject("Bank", "BankNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Page = GetController("Page");
            Menu = (GList)GetChild("Menu");
            ItemDesc = (GTextField)GetChild("ItemDesc");
            Effect = (View_effect)GetChild("Effect");
            Detail = (View_Pack)GetChild("Detail");
            ItemName2 = (GTextField)GetChild("ItemName2");
            ItemIcon = (GLoader)GetChild("ItemIcon");
            NumShadow = (GImage)GetChild("NumShadow");
            ItemName = (GTextField)GetChild("ItemName");
            OwnCountFrame = (GImage)GetChild("OwnCountFrame");
            OwnCount = (GTextField)GetChild("OwnCount");
            DiamondExt = (View_gift)GetChild("DiamondExt");
            Buy = (GButton)GetChild("Buy");
            InfineTime = (GTextField)GetChild("InfineTime");
            InfineGroup = (GGroup)GetChild("InfineGroup");
            List = (GList)GetChild("List");
            Close = (GButton)GetChild("Close");
        }
    }
}