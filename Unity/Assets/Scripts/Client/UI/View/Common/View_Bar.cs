/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Bar : GComponent
    {
        public GImage bar;
        public const string URL = "ui://ucagdrsiewivjx";

        public static View_Bar CreateInstance()
        {
            return (View_Bar)UIPackage.CreateObject("Common", "Bar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GImage)GetChild("bar");
        }
    }
}