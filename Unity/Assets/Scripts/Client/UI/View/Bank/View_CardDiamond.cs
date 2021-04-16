/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bank
{
    public partial class View_CardDiamond : GButton
    {
        public GRichTextField Num;
        public GRichTextField Additive;
        public GGroup Offer;
        public GTextField InfineTime;
        public GGroup InfineGroup;
        public GTextField Price;
        public GLabel recommend;
        public GButton Buy;
        public Transition ads_effect;
        public const string URL = "ui://yf9s6r30qmjom0";

        public static View_CardDiamond CreateInstance()
        {
            return (View_CardDiamond)UIPackage.CreateObject("Bank", "CardDiamond");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Num = (GRichTextField)GetChild("Num");
            Additive = (GRichTextField)GetChild("Additive");
            Offer = (GGroup)GetChild("Offer");
            InfineTime = (GTextField)GetChild("InfineTime");
            InfineGroup = (GGroup)GetChild("InfineGroup");
            Price = (GTextField)GetChild("Price");
            recommend = (GLabel)GetChild("recommend");
            Buy = (GButton)GetChild("Buy");
            ads_effect = GetTransition("ads_effect");
        }
    }
}