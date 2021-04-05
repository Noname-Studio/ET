/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.RateMe
{
    public partial class View_RateMe: GComponent
    {
        public GButton bg;
        public GButton Close;
        public GButton rate;
        public GButton feedback;

        public const string URL = "ui://p1h6c0ubp2n3on";

        public static View_RateMe CreateInstance()
        {
            return (View_RateMe) UIPackage.CreateObject("RateMe", "RateMe");
        }

        public View_RateMe()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChildAt(0);
            Close = (GButton) GetChildAt(11);
            rate = (GButton) GetChildAt(12);
            feedback = (GButton) GetChildAt(13);
        }
    }
}