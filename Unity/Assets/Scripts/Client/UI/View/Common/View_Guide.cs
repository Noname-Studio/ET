/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Guide : GComponent
    {
        public GButton bg;
        public GImage Mask;
        public const string URL = "ui://ucagdrsipjdi1";

        public static View_Guide CreateInstance()
        {
            return (View_Guide)UIPackage.CreateObject("Common", "Guide");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            Mask = (GImage)GetChild("Mask");
        }
    }
}