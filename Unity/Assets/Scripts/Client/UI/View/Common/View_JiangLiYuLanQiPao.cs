/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_JiangLiYuLanQiPao : GComponent
    {
        public Controller c1;
        public GList TeamReward;
        public GTextField content;
        public const string URL = "ui://ucagdrsicdlovzb";

        public static View_JiangLiYuLanQiPao CreateInstance()
        {
            return (View_JiangLiYuLanQiPao)UIPackage.CreateObject("Common", "奖励预览气泡");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            TeamReward = (GList)GetChild("TeamReward");
            content = (GTextField)GetChild("content");
        }
    }
}