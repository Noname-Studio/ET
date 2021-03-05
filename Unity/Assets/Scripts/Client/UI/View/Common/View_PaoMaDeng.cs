/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_PaoMaDeng : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsii6f4mh";

        public static View_PaoMaDeng CreateInstance()
        {
            return (View_PaoMaDeng)UIPackage.CreateObject("Common", "跑马灯");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}