/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_JiaoSeXuanZe: GComponent
    {
        public Controller state;
        public View_JuGuangDeng_effect light;
        public GButton go_guild;
        public View_friendcom friendcom;
        public View_effect_GuangDian point_efffect;
        public GGroup normal;
        public View_ZengYiTiaoJian friendname;
        public GButton rightbtn;
        public GButton leftbtn;
        public GGroup namegroup;
        public const string URL = "ui://ytyvezjf119o8qa";

        public static View_JiaoSeXuanZe CreateInstance()
        {
            return (View_JiaoSeXuanZe) UIPackage.CreateObject("GameBegins", "角色选择");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetController("state");
            light = (View_JuGuangDeng_effect) GetChild("light");
            go_guild = (GButton) GetChild("go_guild");
            friendcom = (View_friendcom) GetChild("friendcom");
            point_efffect = (View_effect_GuangDian) GetChild("point_efffect");
            normal = (GGroup) GetChild("normal");
            friendname = (View_ZengYiTiaoJian) GetChild("friendname");
            rightbtn = (GButton) GetChild("rightbtn");
            leftbtn = (GButton) GetChild("leftbtn");
            namegroup = (GGroup) GetChild("namegroup");
        }
    }
}