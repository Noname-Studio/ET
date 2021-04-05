/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_HairColorBlock: GButton
    {
        public Controller c1;
        public GImage color;

        public const string URL = "ui://e18f31pov62510";

        public static View_HairColorBlock CreateInstance()
        {
            return (View_HairColorBlock) UIPackage.CreateObject("Fashion", "HairColorBlock");
        }

        public View_HairColorBlock()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(1);
            color = (GImage) GetChildAt(1);
        }
    }
}