/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_green_button_onlyIcon : GButton
    {
        public Controller c1;
        public const string URL = "ui://ucagdrsipdpfw2x";

        public static View_green_button_onlyIcon CreateInstance()
        {
            return (View_green_button_onlyIcon)UIPackage.CreateObject("Common", "green_button_onlyIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
        }
    }
}