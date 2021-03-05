/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_continuebar : GProgressBar
    {
        public View_yellowgiftcom gift;
        public const string URL = "ui://ucagdrsigqtovwt";

        public static View_continuebar CreateInstance()
        {
            return (View_continuebar)UIPackage.CreateObject("Common", "continuebar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            gift = (View_yellowgiftcom)GetChild("gift");
        }
    }
}