/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_CookwareProgress : GProgressBar
    {
        public Controller State;
        public GLoader Fill;
        public GImage Arrow;
        public Transition Warning;
        public const string URL = "ui://dpc3yd4tu9aetw0g";

        public static View_CookwareProgress CreateInstance()
        {
            return (View_CookwareProgress)UIPackage.CreateObject("GamingUI", "CookwareProgress");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            State = GetController("State");
            Fill = (GLoader)GetChild("Fill");
            Arrow = (GImage)GetChild("Arrow");
            Warning = GetTransition("Warning");
        }
    }
}