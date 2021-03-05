/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_giftblue_effect : GButton
    {
        public Controller c1;
        public GLoader open;
        public Transition t0;
        public const string URL = "ui://ucagdrsiukz0lz";

        public static View_giftblue_effect CreateInstance()
        {
            return (View_giftblue_effect)UIPackage.CreateObject("Common", "giftblue_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            open = (GLoader)GetChild("open");
            t0 = GetTransition("t0");
        }
    }
}