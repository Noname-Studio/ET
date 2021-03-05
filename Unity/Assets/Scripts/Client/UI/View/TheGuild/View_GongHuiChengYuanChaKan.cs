/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiChengYuanChaKan : GComponent
    {
        public Controller isAdmin;
        public GButton bg;
        public GButton Head;
        public GTextField Rest;
        public GTextField Level;
        public GLoader HornorIcon;
        public GTextField HornorLevel;
        public GLabel nameframe;
        public View_JiaoSeMoXingZu Model;
        public GButton Close;
        public GGroup BGG;
        public const string URL = "ui://nvat1mjsdy61dm4";

        public static View_GongHuiChengYuanChaKan CreateInstance()
        {
            return (View_GongHuiChengYuanChaKan)UIPackage.CreateObject("TheGuild", "公会成员查看");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            isAdmin = GetController("isAdmin");
            bg = (GButton)GetChild("bg");
            Head = (GButton)GetChild("Head");
            Rest = (GTextField)GetChild("Rest");
            Level = (GTextField)GetChild("Level");
            HornorIcon = (GLoader)GetChild("HornorIcon");
            HornorLevel = (GTextField)GetChild("HornorLevel");
            nameframe = (GLabel)GetChild("nameframe");
            Model = (View_JiaoSeMoXingZu)GetChild("Model");
            Close = (GButton)GetChild("Close");
            BGG = (GGroup)GetChild("BGG");
        }
    }
}