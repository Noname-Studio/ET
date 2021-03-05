/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_ChuangJianGongHui : GComponent
    {
        public Controller c1;
        public GButton bg;
        public GTextInput SearchBar;
        public GList List;
        public GButton SearchParam;
        public GButton Search;
        public GLoader frame;
        public GComboBox UnionRestSelect;
        public GTextInput UnionName;
        public GTextInput UnionDesc;
        public GButton ChangeUnionIcon;
        public GButton CreateUnion;
        public GLoader inside;
        public GButton IsPublic;
        public GComboBox LangSelect;
        public GGroup chuangjian;
        public GList Menu;
        public GButton Close;
        public GGroup BG;
        public const string URL = "ui://nvat1mjsh7udj8";

        public static View_ChuangJianGongHui CreateInstance()
        {
            return (View_ChuangJianGongHui)UIPackage.CreateObject("TheGuild", "创建公会");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton)GetChild("bg");
            SearchBar = (GTextInput)GetChild("SearchBar");
            List = (GList)GetChild("List");
            SearchParam = (GButton)GetChild("SearchParam");
            Search = (GButton)GetChild("Search");
            frame = (GLoader)GetChild("frame");
            UnionRestSelect = (GComboBox)GetChild("UnionRestSelect");
            UnionName = (GTextInput)GetChild("UnionName");
            UnionDesc = (GTextInput)GetChild("UnionDesc");
            ChangeUnionIcon = (GButton)GetChild("ChangeUnionIcon");
            CreateUnion = (GButton)GetChild("CreateUnion");
            inside = (GLoader)GetChild("inside");
            IsPublic = (GButton)GetChild("IsPublic");
            LangSelect = (GComboBox)GetChild("LangSelect");
            chuangjian = (GGroup)GetChild("chuangjian");
            Menu = (GList)GetChild("Menu");
            Close = (GButton)GetChild("Close");
            BG = (GGroup)GetChild("BG");
        }
    }
}