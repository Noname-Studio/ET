/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_open_anim_front : GComponent
    {
        public GGraph BgHolder;
        public GGraph LeftButtfly;
        public GGraph RightButtfly;
        public GGraph ButtflyParticle;
        public View_LoadingProgress Loading;
        public GTextField Title;
        public Transition t2;
        public Transition t3;
        public Transition t4;
        public const string URL = "ui://97pg0d8fp5kx0";

        public static View_open_anim_front CreateInstance()
        {
            return (View_open_anim_front)UIPackage.CreateObject("InternalResources", "open_anim_front");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            BgHolder = (GGraph)GetChild("BgHolder");
            LeftButtfly = (GGraph)GetChild("LeftButtfly");
            RightButtfly = (GGraph)GetChild("RightButtfly");
            ButtflyParticle = (GGraph)GetChild("ButtflyParticle");
            Loading = (View_LoadingProgress)GetChild("Loading");
            Title = (GTextField)GetChild("Title");
            t2 = GetTransition("t2");
            t3 = GetTransition("t3");
            t4 = GetTransition("t4");
        }
    }
}