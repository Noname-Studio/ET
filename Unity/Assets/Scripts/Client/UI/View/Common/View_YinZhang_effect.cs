/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_YinZhang_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsit6f2v";

        public static View_YinZhang_effect CreateInstance()
        {
            return (View_YinZhang_effect)UIPackage.CreateObject("Common", "印章_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}