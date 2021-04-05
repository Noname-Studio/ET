/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_FoodDisplay: GLabel
    {
        public GLoader Plate1;
        public const string URL = "ui://dpc3yd4tpgz3tw0k";

        public static View_FoodDisplay CreateInstance()
        {
            return (View_FoodDisplay) UIPackage.CreateObject("GamingUI", "FoodDisplay");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Plate1 = (GLoader) GetChild("Plate1");
        }
    }
}