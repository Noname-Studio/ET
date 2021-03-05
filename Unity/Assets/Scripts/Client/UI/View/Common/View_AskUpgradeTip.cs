/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_AskUpgradeTip : GComponent
    {
        public Controller c1;
        public GButton bg;
        public GTextField title;
        public GList list;
        public View_green_button go;
        public GButton Close;
        public View_green_button goshop;
        public const string URL = "ui://ucagdrsif7gkpp";

        public static View_AskUpgradeTip CreateInstance()
        {
            return (View_AskUpgradeTip)UIPackage.CreateObject("Common", "AskUpgradeTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton)GetChild("bg");
            title = (GTextField)GetChild("title");
            list = (GList)GetChild("list");
            go = (View_green_button)GetChild("go");
            Close = (GButton)GetChild("Close");
            goshop = (View_green_button)GetChild("goshop");
        }
    }
}