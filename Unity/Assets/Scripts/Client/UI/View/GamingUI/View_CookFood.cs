/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_CookFood: GComponent
    {
        public GLoader Plate;
        public GLoader Food;
        public GTextField Number;
        public const string URL = "ui://dpc3yd4tazz1tw0h";

        public static View_CookFood CreateInstance()
        {
            return (View_CookFood) UIPackage.CreateObject("GamingUI", "CookFood");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Plate = (GLoader) GetChild("Plate");
            Food = (GLoader) GetChild("Food");
            Number = (GTextField) GetChild("Number");
        }
    }
}