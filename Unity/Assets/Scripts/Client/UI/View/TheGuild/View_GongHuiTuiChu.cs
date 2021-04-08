/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiTuiChu : GComponent
    {
        public Controller c1;
        public GButton Confirm;
        public GButton ThinkAgain;
        public GButton Close;
        public GGroup UI;
        public const string URL = "ui://nvat1mjsdy61dm5";

        public static View_GongHuiTuiChu CreateInstance()
        {
            return (View_GongHuiTuiChu)UIPackage.CreateObject("TheGuild", "公会退出");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Confirm = (GButton)GetChild("Confirm");
            ThinkAgain = (GButton)GetChild("ThinkAgain");
            Close = (GButton)GetChild("Close");
            UI = (GGroup)GetChild("UI");
        }
    }
}