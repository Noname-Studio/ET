/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_recommendCom : GComponent
    {
        public View_RecommendTags_effect light;
        public GGroup recommend;
        public const string URL = "ui://ucagdrsimq69pt";

        public static View_recommendCom CreateInstance()
        {
            return (View_recommendCom)UIPackage.CreateObject("Common", "recommendCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light = (View_RecommendTags_effect)GetChild("light");
            recommend = (GGroup)GetChild("recommend");
        }
    }
}