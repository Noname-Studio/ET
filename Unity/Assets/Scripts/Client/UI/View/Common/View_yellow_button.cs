/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_yellow_button : GButton
    {
        public GComponent Hit;
        public const string URL = "ui://ucagdrsiiy0811";

        public static View_yellow_button CreateInstance()
        {
            return (View_yellow_button)UIPackage.CreateObject("Common", "yellow_button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Hit = (GComponent)GetChild("Hit");
        }
    }
}