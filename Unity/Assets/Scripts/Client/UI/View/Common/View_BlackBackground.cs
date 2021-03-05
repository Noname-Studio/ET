/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_BlackBackground : GButton
    {
        public GButton bg;
        public const string URL = "ui://ucagdrsim7niw33";

        public static View_BlackBackground CreateInstance()
        {
            return (View_BlackBackground)UIPackage.CreateObject("Common", "BlackBackground");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
        }
    }
}