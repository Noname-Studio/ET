/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_KitchenPop : GComponent
    {
        public Controller MaxLevel;
        public Controller Language;
        public GTextField Name;
        public View_kitchenicon iconframe;
        public GImage price_bg;
        public View_green_button UpgradeBtn;
        public GRichTextField price;
        public GGroup upgrade;
        public GLoader max_icon;
        public GList AttributeList;
        public GList Star;
        public View_Sale_effect sale;
        public GTextField tiptxt;
        public GButton resetBtn;
        public GButton Close;
        public GTextField txr;
        public GGroup trying;
        public View_super_kitchen_ware super;
        public const string URL = "ui://ucagdrsirpqto5";

        public static View_KitchenPop CreateInstance()
        {
            return (View_KitchenPop)UIPackage.CreateObject("Common", "KitchenPop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            MaxLevel = GetController("MaxLevel");
            Language = GetController("Language");
            Name = (GTextField)GetChild("Name");
            iconframe = (View_kitchenicon)GetChild("iconframe");
            price_bg = (GImage)GetChild("price_bg");
            UpgradeBtn = (View_green_button)GetChild("UpgradeBtn");
            price = (GRichTextField)GetChild("price");
            upgrade = (GGroup)GetChild("upgrade");
            max_icon = (GLoader)GetChild("max_icon");
            AttributeList = (GList)GetChild("AttributeList");
            Star = (GList)GetChild("Star");
            sale = (View_Sale_effect)GetChild("sale");
            tiptxt = (GTextField)GetChild("tiptxt");
            resetBtn = (GButton)GetChild("resetBtn");
            Close = (GButton)GetChild("Close");
            txr = (GTextField)GetChild("txr");
            trying = (GGroup)GetChild("trying");
            super = (View_super_kitchen_ware)GetChild("super");
        }
    }
}