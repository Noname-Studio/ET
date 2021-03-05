/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_HaoYouBangZhuZuJian : GComponent
    {
        public Controller c1;
        public GTextField Name;
        public GTextField Content;
        public GButton GoHelp;
        public GTextField Time;
        public GTextField helptip;
        public const string URL = "ui://nvat1mjsdtonkw";

        public static View_HaoYouBangZhuZuJian CreateInstance()
        {
            return (View_HaoYouBangZhuZuJian)UIPackage.CreateObject("TheGuild", "好友帮助组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Name = (GTextField)GetChild("Name");
            Content = (GTextField)GetChild("Content");
            GoHelp = (GButton)GetChild("GoHelp");
            Time = (GTextField)GetChild("Time");
            helptip = (GTextField)GetChild("helptip");
        }
    }
}