/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_Order: GComponent
    {
        public Controller Number;
        public View_FoodDisplay Food1;
        public View_FoodDisplay Food2;
        public const string URL = "ui://dpc3yd4tpgz3tw0i";

        public static View_Order CreateInstance()
        {
            return (View_Order) UIPackage.CreateObject("GamingUI", "Order");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Number = GetController("Number");
            Food1 = (View_FoodDisplay) GetChild("Food1");
            Food2 = (View_FoodDisplay) GetChild("Food2");
        }
    }
}