/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_blue_button_Icon2 : GButton
    {
        public View_shengjijiantou arrow;
        public const string URL = "ui://ucagdrsiwlljvz8";

        public static View_blue_button_Icon2 CreateInstance()
        {
            return (View_blue_button_Icon2)UIPackage.CreateObject("Common", "blue_button_Icon2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            arrow = (View_shengjijiantou)GetChild("arrow");
        }
    }
}