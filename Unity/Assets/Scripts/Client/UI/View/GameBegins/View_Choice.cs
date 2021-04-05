/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_Choice: GButton
    {
        public GImage Plus;
        public const string URL = "ui://ytyvezjfo97642";

        public static View_Choice CreateInstance()
        {
            return (View_Choice) UIPackage.CreateObject("GameBegins", "Choice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Plus = (GImage) GetChild("Plus");
        }
    }
}