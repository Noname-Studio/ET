/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_HaoYouNengLiangZhiYuanQiPao : GComponent
    {
        public Controller c1;
        public GTextField Name;
        public GButton Support;
        public GTextField Time;
        public GTextField Name2;
        public GTextField Time2;
        public GButton Head;
        public GProgressBar Progress;
        public GButton Help;
        public GRichTextField title;
        public GButton GoMail;
        public GGroup mail_tips;
        public const string URL = "ui://nvat1mjsrki3dlg";

        public static View_HaoYouNengLiangZhiYuanQiPao CreateInstance()
        {
            return (View_HaoYouNengLiangZhiYuanQiPao)UIPackage.CreateObject("TheGuild", "好友能量支援气泡");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Name = (GTextField)GetChild("Name");
            Support = (GButton)GetChild("Support");
            Time = (GTextField)GetChild("Time");
            Name2 = (GTextField)GetChild("Name2");
            Time2 = (GTextField)GetChild("Time2");
            Head = (GButton)GetChild("Head");
            Progress = (GProgressBar)GetChild("Progress");
            Help = (GButton)GetChild("Help");
            title = (GRichTextField)GetChild("title");
            GoMail = (GButton)GetChild("GoMail");
            mail_tips = (GGroup)GetChild("mail_tips");
        }
    }
}