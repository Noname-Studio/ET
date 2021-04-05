/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_PuTongQiPao_You : GComponent
    {
        public Controller c1;
        public GImage Bubble;
        public GImage Line;
        public GTextField Name;
        public GRichTextField Desc;
        public GButton Head;
        public const string URL = "ui://nvat1mjsivhhw2e";

        public static View_PuTongQiPao_You CreateInstance()
        {
            return (View_PuTongQiPao_You)UIPackage.CreateObject("TheGuild", "普通气泡_右");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Bubble = (GImage)GetChild("Bubble");
            Line = (GImage)GetChild("Line");
            Name = (GTextField)GetChild("Name");
            Desc = (GRichTextField)GetChild("Desc");
            Head = (GButton)GetChild("Head");
        }
    }
}