/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Log_in
{
    public partial class View_logo_effect : GComponent
    {
        public Controller c1;
        public GLoader faguang;
        public GLoader cake;
        public GLoader logo;
        public View_logo_liuguang light0;
        public View_logo_liuguangFan light1;
        public View_logo_liuguangJian light2;
        public Transition t0;
        public const string URL = "ui://jevtvvkerir5e";

        public static View_logo_effect CreateInstance()
        {
            return (View_logo_effect)UIPackage.CreateObject("Log_in", "logo_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            faguang = (GLoader)GetChild("faguang");
            cake = (GLoader)GetChild("cake");
            logo = (GLoader)GetChild("logo");
            light0 = (View_logo_liuguang)GetChild("light0");
            light1 = (View_logo_liuguangFan)GetChild("light1");
            light2 = (View_logo_liuguangJian)GetChild("light2");
            t0 = GetTransition("t0");
        }
    }
}