/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_Button_icon: GButton
    {
        public GComponent tips;
        public const string URL = "ui://fmkyh2ywmom6ki";

        public static View_Button_icon CreateInstance()
        {
            return (View_Button_icon) UIPackage.CreateObject("Main", "Button_icon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tips = (GComponent) GetChild("tips");
        }
    }
}