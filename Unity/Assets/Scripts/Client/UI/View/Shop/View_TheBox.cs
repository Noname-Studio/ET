/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
    public partial class View_TheBox : GComponent
    {
        public Transition t0;
        public const string URL = "ui://y7wvbjtcey9ao4";

        public static View_TheBox CreateInstance()
        {
            return (View_TheBox)UIPackage.CreateObject("Shop", "TheBox");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}