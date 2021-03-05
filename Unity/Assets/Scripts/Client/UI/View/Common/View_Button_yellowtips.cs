/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Button_yellowtips : GButton
    {
        public GComponent tips;
        public const string URL = "ui://ucagdrsif9b9ia";

        public static View_Button_yellowtips CreateInstance()
        {
            return (View_Button_yellowtips)UIPackage.CreateObject("Common", "Button_yellowtips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tips = (GComponent)GetChild("tips");
        }
    }
}