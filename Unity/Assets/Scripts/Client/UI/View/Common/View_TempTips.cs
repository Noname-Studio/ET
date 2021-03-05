/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_TempTips : GComponent
    {
        public GTextField Desc;
        public Transition t0;
        public const string URL = "ui://ucagdrsip69vmk";

        public static View_TempTips CreateInstance()
        {
            return (View_TempTips)UIPackage.CreateObject("Common", "TempTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Desc = (GTextField)GetChild("Desc");
            t0 = GetTransition("t0");
        }
    }
}