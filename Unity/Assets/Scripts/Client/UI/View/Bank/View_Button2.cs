/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
    public partial class View_Button2: GButton
    {
        public GComponent hit;

        public const string URL = "ui://yf9s6r30qmjolx";

        public static View_Button2 CreateInstance()
        {
            return (View_Button2) UIPackage.CreateObject("Bank", "Button2");
        }

        public View_Button2()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            hit = (GComponent) GetChildAt(4);
        }
    }
}