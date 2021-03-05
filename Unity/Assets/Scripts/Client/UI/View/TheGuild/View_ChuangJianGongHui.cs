/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_ChuangJianGongHui : GComponent
    {
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
        public const string URL = "ui://nvat1mjsvlkhw2d";

        public static View_ChuangJianGongHui CreateInstance()
        {
            return (View_ChuangJianGongHui)UIPackage.CreateObject("TheGuild", "创建公会");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

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
        }
    }
}