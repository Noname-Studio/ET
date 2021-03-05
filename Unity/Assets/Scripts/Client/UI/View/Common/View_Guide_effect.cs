/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Guide_effect : GComponent
    {
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://ucagdrsif8njvz1";

        public static View_Guide_effect CreateInstance()
        {
            return (View_Guide_effect)UIPackage.CreateObject("Common", "Guide_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}