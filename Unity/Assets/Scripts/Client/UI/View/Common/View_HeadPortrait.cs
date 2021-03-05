/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_HeadPortrait : GButton
    {
        public GLabel Head;
        public const string URL = "ui://ucagdrsiyttvm0";

        public static View_HeadPortrait CreateInstance()
        {
            return (View_HeadPortrait)UIPackage.CreateObject("Common", "HeadPortrait");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Head = (GLabel)GetChild("Head");
        }
    }
}