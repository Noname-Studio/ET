/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_loading_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsi9m1ew1s";

        public static View_loading_effect CreateInstance()
        {
            return (View_loading_effect)UIPackage.CreateObject("Common", "loading_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}