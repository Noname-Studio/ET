/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_combo : GComponent
    {
        public Controller c1;
        public Controller c0;
        public GLoader title;
        public GRichTextField txt;
        public GLoader title_normal;
        public Transition t0;
        public const string URL = "ui://dpc3yd4tdeodei";

        public static View_effect_combo CreateInstance()
        {
            return (View_effect_combo)UIPackage.CreateObject("GamingUI", "effect_combo");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            c0 = GetController("c0");
            title = (GLoader)GetChild("title");
            txt = (GRichTextField)GetChild("txt");
            title_normal = (GLoader)GetChild("title_normal");
            t0 = GetTransition("t0");
        }
    }
}