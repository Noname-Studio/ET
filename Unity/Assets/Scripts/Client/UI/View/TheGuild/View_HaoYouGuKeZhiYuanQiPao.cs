/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_HaoYouGuKeZhiYuanQiPao : GComponent
    {
        public Controller c1;
        public GButton Support;
        public GTextField Name;
        public GTextField Time;
        public GTextField content;
        public GTextField Desc;
        public GTextField Time2;
        public GTextField Name2;
        public GButton Head;
        public const string URL = "ui://nvat1mjsrki3dli";

        public static View_HaoYouGuKeZhiYuanQiPao CreateInstance()
        {
            return (View_HaoYouGuKeZhiYuanQiPao)UIPackage.CreateObject("TheGuild", "好友顾客支援气泡");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Support = (GButton)GetChild("Support");
            Name = (GTextField)GetChild("Name");
            Time = (GTextField)GetChild("Time");
            content = (GTextField)GetChild("content");
            Desc = (GTextField)GetChild("Desc");
            Time2 = (GTextField)GetChild("Time2");
            Name2 = (GTextField)GetChild("Name2");
            Head = (GButton)GetChild("Head");
        }
    }
}