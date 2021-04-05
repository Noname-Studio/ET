/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Map
{
    public partial class View_Map: GComponent
    {
        public Controller c1;
        public GButton bg;
        public GButton Close;
        public View_coordinates_button rest1;
        public View_coordinates_button rest2;
        public View_coordinates_button rest3;

        public const string URL = "ui://z2vd6wpaookxa";

        public static View_Map CreateInstance()
        {
            return (View_Map) UIPackage.CreateObject("Map", "Map");
        }

        public View_Map()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            bg = (GButton) GetChildAt(0);
            Close = (GButton) GetChildAt(2);
            rest1 = (View_coordinates_button) GetChildAt(5);
            rest2 = (View_coordinates_button) GetChildAt(6);
            rest3 = (View_coordinates_button) GetChildAt(7);
        }
    }
}