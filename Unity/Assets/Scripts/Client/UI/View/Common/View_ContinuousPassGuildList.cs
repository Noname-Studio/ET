/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_ContinuousPassGuildList : GComponent
    {
        public Controller state;
        public GList memberList;
        public GProgressBar bar;
        public View_JiangLiYuLanQiPao rewardBubble;
        public View_loading_effect loading;
        public GTextField tip;
        public const string URL = "ui://ucagdrsimwtuw0u";

        public static View_ContinuousPassGuildList CreateInstance()
        {
            return (View_ContinuousPassGuildList)UIPackage.CreateObject("Common", "ContinuousPassGuildList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetController("state");
            memberList = (GList)GetChild("memberList");
            bar = (GProgressBar)GetChild("bar");
            rewardBubble = (View_JiangLiYuLanQiPao)GetChild("rewardBubble");
            loading = (View_loading_effect)GetChild("loading");
            tip = (GTextField)GetChild("tip");
        }
    }
}