/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_MoveBuild : GLabel
    {
        public GList List;
        public const string URL = "ui://97pg0d8fwybbvwl";

        public static View_MoveBuild CreateInstance()
        {
            return (View_MoveBuild)UIPackage.CreateObject("InternalResources", "MoveBuild");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList)GetChild("List");
        }
    }
}