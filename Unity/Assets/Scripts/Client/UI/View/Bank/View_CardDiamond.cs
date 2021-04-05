/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
    public partial class View_CardDiamond: GButton
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
            return (View_CardDiamond) UIPackage.CreateObject("Bank", "CardDiamond");
        }

        public View_CardDiamond()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Num = (GRichTextField) GetChildAt(6);
            Additive = (GRichTextField) GetChildAt(9);
            Offer = (GGroup) GetChildAt(10);
            InfineTime = (GTextField) GetChildAt(12);
            InfineGroup = (GGroup) GetChildAt(14);
            Price = (GTextField) GetChildAt(15);
            recommend = (GLabel) GetChildAt(16);
            Buy = (GButton) GetChildAt(17);
            ads_effect = GetTransitionAt(0);
        }
    }
}