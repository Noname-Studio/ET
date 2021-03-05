/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_JuGuangDeng_effect : GComponent
    {
        public Controller c1;
        public Transition t0;
        public const string URL = "ui://ytyvezjfgveo8qi";

        public static View_JuGuangDeng_effect CreateInstance()
        {
            return (View_JuGuangDeng_effect)UIPackage.CreateObject("GameBegins", "聚光灯_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            t0 = GetTransition("t0");
        }
    }
}