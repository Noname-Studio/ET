/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_GridDisplay : GComponent
    {
        public GList List;
        public const string URL = "ui://97pg0d8fwybbw3w";

        public static View_GridDisplay CreateInstance()
        {
            return (View_GridDisplay)UIPackage.CreateObject("InternalResources", "GridDisplay");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList)GetChild("List");
        }
    }
}