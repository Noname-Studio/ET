/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_10ZuanShiLiHe : GComponent
    {
        public GTextField gemnum;
        public Transition t0;
        public const string URL = "ui://ucagdrsigah1vye";

        public static View_10ZuanShiLiHe CreateInstance()
        {
            return (View_10ZuanShiLiHe)UIPackage.CreateObject("Common", "10钻石礼盒");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            gemnum = (GTextField)GetChild("gemnum");
            t0 = GetTransition("t0");
        }
    }
}