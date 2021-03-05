/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_tips : GComponent
    {
        public Transition Enter;
        public Transition Loop;
        public const string URL = "ui://ucagdrsiq1rsms";

        public static View_tips CreateInstance()
        {
            return (View_tips)UIPackage.CreateObject("Common", "tips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Enter = GetTransition("Enter");
            Loop = GetTransition("Loop");
        }
    }
}