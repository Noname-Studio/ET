/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_Fashion: GComponent
    {
        public Controller c1;
        public Controller c2;
        public View_Mirror Mirror;
        public GList shose;
        public GList shizhuang;
        public GList heat;
        public GList TypeChoose;
        public View_HuanSeZuJian HairColor;
        public GButton clear;
        public GButton buy;
        public GGroup buy00;
        public GGroup UI;
        public GLoader GemIcon;
        public GTextField Diamond;
        public GButton AddDiamond;
        public GButton Close;
        public GGroup turnoff;
        public GList Menu;

        public const string URL = "ui://e18f31potbryh";

        public static View_Fashion CreateInstance()
        {
            return (View_Fashion) UIPackage.CreateObject("Fashion", "Fashion");
        }

        public View_Fashion()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            c2 = GetControllerAt(1);
            Mirror = (View_Mirror) GetChildAt(17);
            shose = (GList) GetChildAt(28);
            shizhuang = (GList) GetChildAt(29);
            heat = (GList) GetChildAt(30);
            TypeChoose = (GList) GetChildAt(35);
            HairColor = (View_HuanSeZuJian) GetChildAt(36);
            clear = (GButton) GetChildAt(37);
            buy = (GButton) GetChildAt(38);
            buy00 = (GGroup) GetChildAt(39);
            UI = (GGroup) GetChildAt(40);
            GemIcon = (GLoader) GetChildAt(42);
            Diamond = (GTextField) GetChildAt(43);
            AddDiamond = (GButton) GetChildAt(44);
            Close = (GButton) GetChildAt(47);
            turnoff = (GGroup) GetChildAt(48);
            Menu = (GList) GetChildAt(49);
        }
    }
}