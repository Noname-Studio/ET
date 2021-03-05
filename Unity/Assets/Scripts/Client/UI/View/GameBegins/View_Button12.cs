/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_Button12 : GButton
    {
        public View_item content;
        public const string URL = "ui://ytyvezjfj9sk4o";

        public static View_Button12 CreateInstance()
        {
            return (View_Button12)UIPackage.CreateObject("GameBegins", "Button12");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            content = (View_item)GetChild("content");
        }
    }
}