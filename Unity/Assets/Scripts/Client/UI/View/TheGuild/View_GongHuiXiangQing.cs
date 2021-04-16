/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiXiangQing : GComponent
    {
        public Controller c1;
        public GLoader frame;
        public GLoader inside;
        public GTextField Name;
        public GTextField Notice;
        public GTextField IsPublic;
        public GButton Exit;
        public GButton Join;
        public GTextField Title;
        public GList List;
        public GButton Close;
        public GTextField Member;
        public GGroup UI;
        public View_ZhuanYangHuiZhangDanChu SelectTip;
        public const string URL = "ui://nvat1mjsdy61dm0";

        public static View_GongHuiXiangQing CreateInstance()
        {
            return (View_GongHuiXiangQing)UIPackage.CreateObject("TheGuild", "公会详情");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            frame = (GLoader)GetChild("frame");
            inside = (GLoader)GetChild("inside");
            Name = (GTextField)GetChild("Name");
            Notice = (GTextField)GetChild("Notice");
            IsPublic = (GTextField)GetChild("IsPublic");
            Exit = (GButton)GetChild("Exit");
            Join = (GButton)GetChild("Join");
            Title = (GTextField)GetChild("Title");
            List = (GList)GetChild("List");
            Close = (GButton)GetChild("Close");
            Member = (GTextField)GetChild("Member");
            UI = (GGroup)GetChild("UI");
            SelectTip = (View_ZhuanYangHuiZhangDanChu)GetChild("SelectTip");
        }
    }
}