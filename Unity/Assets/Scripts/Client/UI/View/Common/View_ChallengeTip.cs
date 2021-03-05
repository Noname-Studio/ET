/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_ChallengeTip : GComponent
    {
        public Controller state;
        public GButton bg;
        public GButton ok;
        public GButton Close;
        public GTextField timer;
        public View_green_button go;
        public Transition t1;
        public Transition t2;
        public const string URL = "ui://ucagdrsinaf0vze";

        public static View_ChallengeTip CreateInstance()
        {
            return (View_ChallengeTip)UIPackage.CreateObject("Common", "ChallengeTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetController("state");
            bg = (GButton)GetChild("bg");
            ok = (GButton)GetChild("ok");
            Close = (GButton)GetChild("Close");
            timer = (GTextField)GetChild("timer");
            go = (View_green_button)GetChild("go");
            t1 = GetTransition("t1");
            t2 = GetTransition("t2");
        }
    }
}