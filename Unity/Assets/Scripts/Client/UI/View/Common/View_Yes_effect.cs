/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Yes_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsiivbsu2";

        public static View_Yes_effect CreateInstance()
        {
            return (View_Yes_effect)UIPackage.CreateObject("Common", "Yes_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}