/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_green_button_Icon2 : GButton
    {
        public Controller c1;
        public View_shengjijiantou arrow;
        public GComponent tips;
        public const string URL = "ui://ucagdrsig9fmvzd";

        public static View_green_button_Icon2 CreateInstance()
        {
            return (View_green_button_Icon2)UIPackage.CreateObject("Common", "green_button_Icon2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            arrow = (View_shengjijiantou)GetChild("arrow");
            tips = (GComponent)GetChild("tips");
        }
    }
}