/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GoldExchang1Huang : GLabel
    {
        public Controller c1;
        public GLoader icon0;
        public GLoader icon1;
        public GLoader icon2;
        public const string URL = "ui://ucagdrsis18cvyj";

        public static View_GoldExchang1Huang CreateInstance()
        {
            return (View_GoldExchang1Huang)UIPackage.CreateObject("Common", "GoldExchang1黄");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            icon0 = (GLoader)GetChild("icon0");
            icon1 = (GLoader)GetChild("icon1");
            icon2 = (GLoader)GetChild("icon2");
        }
    }
}