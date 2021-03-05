/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_failureprompted : GComponent
    {
        public GButton bg;
        public View_failurePrompted_tip tip;
        public const string URL = "ui://y66af8ydzcxlkj";

        public static View_failureprompted CreateInstance()
        {
            return (View_failureprompted)UIPackage.CreateObject("KitchenUI", "failureprompted");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            tip = (View_failurePrompted_tip)GetChild("tip");
        }
    }
}