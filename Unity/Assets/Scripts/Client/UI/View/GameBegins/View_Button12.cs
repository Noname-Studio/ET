/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_Button12: GButton
    {
        public Controller IsLock;
        public View_Choice choice;
        public GComponent recommend;
        public const string URL = "ui://ytyvezjfj9sk4o";

        public static View_Button12 CreateInstance()
        {
            return (View_Button12) UIPackage.CreateObject("GameBegins", "Button12");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            IsLock = GetController("IsLock");
            choice = (View_Choice) GetChild("choice");
            recommend = (GComponent) GetChild("recommend");
        }
    }
}