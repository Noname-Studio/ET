/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_item : GComponent
    {
        public Controller lockcontrol;
        public GLoader icon;
        public View_Choice choice;
        public GComponent recommend;
        public const string URL = "ui://ytyvezjfj9sk4n";

        public static View_item CreateInstance()
        {
            return (View_item)UIPackage.CreateObject("GameBegins", "item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            lockcontrol = GetController("lockcontrol");
            icon = (GLoader)GetChild("icon");
            choice = (View_Choice)GetChild("choice");
            recommend = (GComponent)GetChild("recommend");
        }
    }
}