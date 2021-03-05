/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GridDisplay : GComponent
    {
        public GList List;
        public const string URL = "ui://ucagdrsiwybbw3w";

        public static View_GridDisplay CreateInstance()
        {
            return (View_GridDisplay)UIPackage.CreateObject("Common", "GridDisplay");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList)GetChild("List");
        }
    }
}