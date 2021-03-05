/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_TouXiangZuJian : GLabel
    {
        public GLabel Mask;
        public const string URL = "ui://nvat1mjsrki3dlf";

        public static View_TouXiangZuJian CreateInstance()
        {
            return (View_TouXiangZuJian)UIPackage.CreateObject("TheGuild", "头像组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Mask = (GLabel)GetChild("Mask");
        }
    }
}