/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiYaoQing : GComponent
    {
        public GLoader frame;
        public GLoader inside;
        public GTextField Name;
        public GTextField NumberOfPeople;
        public GButton Join;
        public GButton Ignore;
        public GButton Close;
        public const string URL = "ui://nvat1mjsjt3rkm";

        public static View_GongHuiYaoQing CreateInstance()
        {
            return (View_GongHuiYaoQing)UIPackage.CreateObject("TheGuild", "公会邀请");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            frame = (GLoader)GetChild("frame");
            inside = (GLoader)GetChild("inside");
            Name = (GTextField)GetChild("Name");
            NumberOfPeople = (GTextField)GetChild("NumberOfPeople");
            Join = (GButton)GetChild("Join");
            Ignore = (GButton)GetChild("Ignore");
            Close = (GButton)GetChild("Close");
        }
    }
}