/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_giftfornum : GComponent
    {
        public GTextField content;
        public const string URL = "ui://ytyvezjfq3p3ps";

        public static View_giftfornum CreateInstance()
        {
            return (View_giftfornum)UIPackage.CreateObject("GameBegins", "giftfornum");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            content = (GTextField)GetChild("content");
        }
    }
}