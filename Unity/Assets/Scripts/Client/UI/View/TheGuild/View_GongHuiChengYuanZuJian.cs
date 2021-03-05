/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiChengYuanZuJian : GButton
    {
        public Controller c1;
        public View_TouXiangZuJian Head;
        public GTextField Name;
        public View_online Online;
        public GTextField Progress;
        public GLoader HornorIcon;
        public GTextField HornorLevel;
        public const string URL = "ui://nvat1mjsdy61dm3";

        public static View_GongHuiChengYuanZuJian CreateInstance()
        {
            return (View_GongHuiChengYuanZuJian)UIPackage.CreateObject("TheGuild", "公会成员组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Head = (View_TouXiangZuJian)GetChild("Head");
            Name = (GTextField)GetChild("Name");
            Online = (View_online)GetChild("Online");
            Progress = (GTextField)GetChild("Progress");
            HornorIcon = (GLoader)GetChild("HornorIcon");
            HornorLevel = (GTextField)GetChild("HornorLevel");
        }
    }
}