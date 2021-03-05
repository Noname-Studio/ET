/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_PuTongQiPao : GComponent
    {
        public Controller c1;
        public GImage Bubble;
        public GTextField Name;
        public GImage Line;
        public GRichTextField Desc;
        public GTextField Time;
        public GImage Bubble2;
        public GTextField Name2;
        public GImage Line2;
        public GRichTextField Desc2;
        public GTextField Time2;
        public GButton Head;
        public const string URL = "ui://nvat1mjsrki3dlh";

        public static View_PuTongQiPao CreateInstance()
        {
            return (View_PuTongQiPao)UIPackage.CreateObject("TheGuild", "普通气泡");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Bubble = (GImage)GetChild("Bubble");
            Name = (GTextField)GetChild("Name");
            Line = (GImage)GetChild("Line");
            Desc = (GRichTextField)GetChild("Desc");
            Time = (GTextField)GetChild("Time");
            Bubble2 = (GImage)GetChild("Bubble2");
            Name2 = (GTextField)GetChild("Name2");
            Line2 = (GImage)GetChild("Line2");
            Desc2 = (GRichTextField)GetChild("Desc2");
            Time2 = (GTextField)GetChild("Time2");
            Head = (GButton)GetChild("Head");
        }
    }
}