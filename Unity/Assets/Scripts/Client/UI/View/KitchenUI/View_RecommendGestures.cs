/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_RecommendGestures : GComponent
    {
        public GButton bg;
        public GImage q1;
        public GImage q2;
        public GGroup QQ1;
        public GImage q3;
        public GImage q4;
        public GGroup QQ2;
        public GButton continueBtn;
        public GGroup content;
        public Transition t0;
        public const string URL = "ui://y66af8ydel6zvyb";

        public static View_RecommendGestures CreateInstance()
        {
            return (View_RecommendGestures)UIPackage.CreateObject("KitchenUI", "RecommendGestures");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            q1 = (GImage)GetChild("q1");
            q2 = (GImage)GetChild("q2");
            QQ1 = (GGroup)GetChild("QQ1");
            q3 = (GImage)GetChild("q3");
            q4 = (GImage)GetChild("q4");
            QQ2 = (GGroup)GetChild("QQ2");
            continueBtn = (GButton)GetChild("continueBtn");
            content = (GGroup)GetChild("content");
            t0 = GetTransition("t0");
        }
    }
}