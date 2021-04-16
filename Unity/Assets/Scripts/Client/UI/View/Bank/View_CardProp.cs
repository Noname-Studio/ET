/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bank
{
    public partial class View_CardProp : GButton
    {
        public GButton Buy;
        public GRichTextField Desc;
        public GTextField Num;
        public const string URL = "ui://yf9s6r30qmjom5";

        public static View_CardProp CreateInstance()
        {
            return (View_CardProp)UIPackage.CreateObject("Bank", "CardProp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Buy = (GButton)GetChild("Buy");
            Desc = (GRichTextField)GetChild("Desc");
            Num = (GTextField)GetChild("Num");
        }
    }
}