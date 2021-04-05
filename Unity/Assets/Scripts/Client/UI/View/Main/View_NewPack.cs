/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_NewPack: GComponent
    {
        public GButton bg;
        public GTextField titlename;
        public GTextField gemnum;
        public GTextField intimer;
        public GButton buy;
        public GButton Close;
        public GTextField RecommondText;
        public GGroup UI;
        public Transition t0;
        public const string URL = "ui://fmkyh2ywobqw8nb";

        public static View_NewPack CreateInstance()
        {
            return (View_NewPack) UIPackage.CreateObject("Main", "NewPack");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChild("bg");
            titlename = (GTextField) GetChild("titlename");
            gemnum = (GTextField) GetChild("gemnum");
            intimer = (GTextField) GetChild("intimer");
            buy = (GButton) GetChild("buy");
            Close = (GButton) GetChild("Close");
            RecommondText = (GTextField) GetChild("RecommondText");
            UI = (GGroup) GetChild("UI");
            t0 = GetTransition("t0");
        }
    }
}