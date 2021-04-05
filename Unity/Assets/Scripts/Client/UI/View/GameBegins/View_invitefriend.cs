/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_invitefriend: GComponent
    {
        public Controller c1;
        public GButton add;
        public GTextField timer;
        public const string URL = "ui://ytyvezjfsfoz8qf";

        public static View_invitefriend CreateInstance()
        {
            return (View_invitefriend) UIPackage.CreateObject("GameBegins", "invitefriend");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            add = (GButton) GetChild("add");
            timer = (GTextField) GetChild("timer");
        }
    }
}