/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Map
{
    public partial class View_Mapgift_effect: GComponent
    {
        public Transition Enter;
        public Transition Loop;

        public const string URL = "ui://z2vd6wpac9wni";

        public static View_Mapgift_effect CreateInstance()
        {
            return (View_Mapgift_effect) UIPackage.CreateObject("Map", "Mapgift_effect");
        }

        public View_Mapgift_effect()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Enter = GetTransitionAt(0);
            Loop = GetTransitionAt(1);
        }
    }
}