/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_help : GComponent
    {
        public GButton bg;
        public GButton Close;
        public GList List;
        public const string URL = "ui://ucagdrsipzwqvzn";

        public static View_help CreateInstance()
        {
            return (View_help)UIPackage.CreateObject("Common", "help");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            Close = (GButton)GetChild("Close");
            List = (GList)GetChild("List");
        }
    }
}