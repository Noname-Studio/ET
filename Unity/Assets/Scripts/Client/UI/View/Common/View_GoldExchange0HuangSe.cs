/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GoldExchange0HuangSe : GButton
    {
        public Controller c1;
        public View_GoldExchang1Huang IconLabel;
        public const string URL = "ui://ucagdrsis18cvyl";

        public static View_GoldExchange0HuangSe CreateInstance()
        {
            return (View_GoldExchange0HuangSe)UIPackage.CreateObject("Common", "GoldExchange0黄色");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            IconLabel = (View_GoldExchang1Huang)GetChild("IconLabel");
        }
    }
}