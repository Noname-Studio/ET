/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Friend
{
    public partial class View_ChuJuTiao: GLabel
    {
        public GTextField RestaurantName;
        public GButton Comfrim;
        public GTextField Money;

        public const string URL = "ui://y072jhf1m1eebi";

        public static View_ChuJuTiao CreateInstance()
        {
            return (View_ChuJuTiao) UIPackage.CreateObject("Friend", "厨具条");
        }

        public View_ChuJuTiao()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            RestaurantName = (GTextField) GetChildAt(4);
            Comfrim = (GButton) GetChildAt(5);
            Money = (GTextField) GetChildAt(7);
        }
    }
}