/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_wutaidengguang_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://dpc3yd4tte9stvz6";

        public static View_wutaidengguang_effect CreateInstance()
        {
            return (View_wutaidengguang_effect)UIPackage.CreateObject("GamingUI", "wutaidengguang_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}