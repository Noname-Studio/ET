/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GuideBlockLayer : GComponent
    {
        public GTextField txt;
        public const string URL = "ui://ucagdrsihycytt";

        public static View_GuideBlockLayer CreateInstance()
        {
            return (View_GuideBlockLayer)UIPackage.CreateObject("Common", "GuideBlockLayer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            txt = (GTextField)GetChild("txt");
        }
    }
}