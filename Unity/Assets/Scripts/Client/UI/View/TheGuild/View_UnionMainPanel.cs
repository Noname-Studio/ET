/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_UnionMainPanel : GComponent
    {
        public Controller c2;
        public GList Menu;
        public View_GongHuiHuoDongZuJian Activity;
        public GLoader Chat;
        public GLoader MyUnion;
        public View_GongHuiChengYuanHuZhu MebmerHelp;
        public GButton Close;
        public GGroup UI;
        public const string URL = "ui://nvat1mjs10fii8";

        public static View_UnionMainPanel CreateInstance()
        {
            return (View_UnionMainPanel)UIPackage.CreateObject("TheGuild", "UnionMainPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c2 = GetController("c2");
            Menu = (GList)GetChild("Menu");
            Activity = (View_GongHuiHuoDongZuJian)GetChild("Activity");
            Chat = (GLoader)GetChild("Chat");
            MyUnion = (GLoader)GetChild("MyUnion");
            MebmerHelp = (View_GongHuiChengYuanHuZhu)GetChild("MebmerHelp");
            Close = (GButton)GetChild("Close");
            UI = (GGroup)GetChild("UI");
        }
    }
}