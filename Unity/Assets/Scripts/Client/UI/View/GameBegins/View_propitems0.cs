/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_propitems0 : GComponent
    {
        public View_Button12 Item1;
        public View_Button12 Item2;
        public View_Button12 Item3;
        public View_Button12 Item4;
        public const string URL = "ui://ytyvezjfgnz6mv";

        public static View_propitems0 CreateInstance()
        {
            return (View_propitems0)UIPackage.CreateObject("GameBegins", "propitems0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Item1 = (View_Button12)GetChild("Item1");
            Item2 = (View_Button12)GetChild("Item2");
            Item3 = (View_Button12)GetChild("Item3");
            Item4 = (View_Button12)GetChild("Item4");
        }
    }
}