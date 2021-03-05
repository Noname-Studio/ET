/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GoldExchangeZiSe : GLabel
    {
        public Controller c1;
        public GButton Comfirm;
        public GTextField Num;
        public GLoader icon0;
        public GLoader icon1;
        public GLoader icon2;
        public GLoader icon3;
        public GLoader icon4;
        public GLoader icon5;
        public GLoader icon6;
        public View_recommend_effect1 recommand;
        public const string URL = "ui://ucagdrsilsphvz6";

        public static View_GoldExchangeZiSe CreateInstance()
        {
            return (View_GoldExchangeZiSe)UIPackage.CreateObject("Common", "GoldExchange紫色");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Comfirm = (GButton)GetChild("Comfirm");
            Num = (GTextField)GetChild("Num");
            icon0 = (GLoader)GetChild("icon0");
            icon1 = (GLoader)GetChild("icon1");
            icon2 = (GLoader)GetChild("icon2");
            icon3 = (GLoader)GetChild("icon3");
            icon4 = (GLoader)GetChild("icon4");
            icon5 = (GLoader)GetChild("icon5");
            icon6 = (GLoader)GetChild("icon6");
            recommand = (View_recommend_effect1)GetChild("recommand");
        }
    }
}