/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Map
{
    public partial class View_coordinates_button: GButton
    {
        public Controller DisplayGift;
        public Controller Lock;
        public View_XuanZhongDeCanTing Select;
        public View_Mapgift_effect GiftButton;
        public Transition tips;
        public Transition yuandian;
        public Transition up;
        public Transition t3;

        public const string URL = "ui://z2vd6wpaookxd";

        public static View_coordinates_button CreateInstance()
        {
            return (View_coordinates_button) UIPackage.CreateObject("Map", "coordinates_button");
        }

        public View_coordinates_button()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            DisplayGift = GetControllerAt(1);
            Lock = GetControllerAt(2);
            Select = (View_XuanZhongDeCanTing) GetChildAt(1);
            GiftButton = (View_Mapgift_effect) GetChildAt(7);
            tips = GetTransitionAt(0);
            yuandian = GetTransitionAt(1);
            up = GetTransitionAt(2);
            t3 = GetTransitionAt(3);
        }
    }
}