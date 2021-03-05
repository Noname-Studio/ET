/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_JiangLiYuLan : GComponent
    {
        public GTextField Desc;
        public GList List;
        public const string URL = "ui://ucagdrsirkx18rc";

        public static View_JiangLiYuLan CreateInstance()
        {
            return (View_JiangLiYuLan)UIPackage.CreateObject("Common", "奖励预览");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Desc = (GTextField)GetChild("Desc");
            List = (GList)GetChild("List");
        }
    }
}