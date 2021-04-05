/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.BeginCG
{
    public partial class View_BeginCG: GComponent
    {
        public GGroup sence1;
        public GGroup sence2;
        public GGroup sence3;
        public Transition sence1_2;
        public Transition sence2_2;
        public Transition sence3_2;

        public const string URL = "ui://594is3ndwc1k0";

        public static View_BeginCG CreateInstance()
        {
            return (View_BeginCG) UIPackage.CreateObject("BeginCG", "BeginCG");
        }

        public View_BeginCG()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sence1 = (GGroup) GetChildAt(9);
            sence2 = (GGroup) GetChildAt(20);
            sence3 = (GGroup) GetChildAt(28);
            sence1_2 = GetTransitionAt(0);
            sence2_2 = GetTransitionAt(1);
            sence3_2 = GetTransitionAt(2);
        }
    }
}