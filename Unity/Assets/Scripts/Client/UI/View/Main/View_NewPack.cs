/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_NewPack : GLabel
    {
        public GTextField Gem;
        public GTextField InfineTime;
        public GButton buy;
        public GButton Close;
        public GTextField RecommondText;
        public GGroup UI;
        public Transition t0;
        public const string URL = "ui://fmkyh2ywobqw8nb";

        public static View_NewPack CreateInstance()
        {
            return (View_NewPack)UIPackage.CreateObject("Main", "NewPack");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Gem = (GTextField)GetChild("Gem");
            InfineTime = (GTextField)GetChild("InfineTime");
            buy = (GButton)GetChild("buy");
            Close = (GButton)GetChild("Close");
            RecommondText = (GTextField)GetChild("RecommondText");
            UI = (GGroup)GetChild("UI");
            t0 = GetTransition("t0");
        }
    }
}