/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_littletips : GLabel
    {
        public GRichTextField Desc;
        public GButton bg;
        public const string URL = "ui://ucagdrsimvhjvuq";

        public static View_littletips CreateInstance()
        {
            return (View_littletips)UIPackage.CreateObject("Common", "littletips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Desc = (GRichTextField)GetChild("Desc");
            bg = (GButton)GetChild("bg");
        }
    }
}