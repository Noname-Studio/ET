/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_JiaoSeMoXingZu : GComponent
    {
        public Controller c1;
        public GGraph holder;
        public GTextField HornorLevel;
        public GLabel Name;
        public const string URL = "ui://nvat1mjsyajhdlx";

        public static View_JiaoSeMoXingZu CreateInstance()
        {
            return (View_JiaoSeMoXingZu)UIPackage.CreateObject("TheGuild", "角色模型组");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            holder = (GGraph)GetChild("holder");
            HornorLevel = (GTextField)GetChild("HornorLevel");
            Name = (GLabel)GetChild("Name");
        }
    }
}