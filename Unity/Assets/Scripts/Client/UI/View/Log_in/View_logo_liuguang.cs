/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Log_in
{
    public partial class View_logo_liuguang: GComponent
    {
        public Transition t0;
        public const string URL = "ui://jevtvvketauem";

        public static View_logo_liuguang CreateInstance()
        {
            return (View_logo_liuguang) UIPackage.CreateObject("Log_in", "logo_liuguang");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}