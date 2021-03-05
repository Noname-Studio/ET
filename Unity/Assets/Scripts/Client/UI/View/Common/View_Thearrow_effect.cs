/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Thearrow_effect : GComponent
    {
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://ucagdrsip056o8";

        public static View_Thearrow_effect CreateInstance()
        {
            return (View_Thearrow_effect)UIPackage.CreateObject("Common", "Thearrow_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}