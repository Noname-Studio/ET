/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_ProgressValue : GComponent
    {
        public GImage bar;
        public const string URL = "ui://ucagdrsiu8ei2f";

        public static View_ProgressValue CreateInstance()
        {
            return (View_ProgressValue)UIPackage.CreateObject("Common", "ProgressValue");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GImage)GetChild("bar");
        }
    }
}