/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_cupcake_shake : GComponent
    {
        public GTextField num;
        public Transition t0;
        public const string URL = "ui://dpc3yd4tr6xevz1";

        public static View_cupcake_shake CreateInstance()
        {
            return (View_cupcake_shake)UIPackage.CreateObject("GamingUI", "cupcake_shake");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            num = (GTextField)GetChild("num");
            t0 = GetTransition("t0");
        }
    }
}