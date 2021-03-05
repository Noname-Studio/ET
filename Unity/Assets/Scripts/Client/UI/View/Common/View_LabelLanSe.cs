/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_LabelLanSe : GLabel
    {
        public View_yellow_light_circle icon_light;
        public const string URL = "ui://ucagdrsiq9pooa";

        public static View_LabelLanSe CreateInstance()
        {
            return (View_LabelLanSe)UIPackage.CreateObject("Common", "Label蓝色");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon_light = (View_yellow_light_circle)GetChild("icon_light");
        }
    }
}