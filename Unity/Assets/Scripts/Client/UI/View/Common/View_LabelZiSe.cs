/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_LabelZiSe : GLabel
    {
        public View_yellow_light_circle icon_light;
        public const string URL = "ui://ucagdrsicabpvw4";

        public static View_LabelZiSe CreateInstance()
        {
            return (View_LabelZiSe)UIPackage.CreateObject("Common", "Label紫色");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon_light = (View_yellow_light_circle)GetChild("icon_light");
        }
    }
}