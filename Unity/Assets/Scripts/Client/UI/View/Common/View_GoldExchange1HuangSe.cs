/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GoldExchange1HuangSe : GButton
    {
        public GButton MoreGem;
        public View_GoldExchang1Huang2 IconLabel;
        public const string URL = "ui://ucagdrsimfjivz3";

        public static View_GoldExchange1HuangSe CreateInstance()
        {
            return (View_GoldExchange1HuangSe)UIPackage.CreateObject("Common", "GoldExchange1黄色");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            MoreGem = (GButton)GetChild("MoreGem");
            IconLabel = (View_GoldExchang1Huang2)GetChild("IconLabel");
        }
    }
}