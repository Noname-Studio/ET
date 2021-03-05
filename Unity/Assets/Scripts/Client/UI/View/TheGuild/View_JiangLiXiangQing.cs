/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_JiangLiXiangQing : GComponent
    {
        public GTextField title1;
        public GList list1;
        public GTextField title2;
        public GList list2;
        public GTextField title3;
        public GList list3;
        public GTextField title4;
        public GList list4;
        public const string URL = "ui://nvat1mjslbjnl0";

        public static View_JiangLiXiangQing CreateInstance()
        {
            return (View_JiangLiXiangQing)UIPackage.CreateObject("TheGuild", "奖励详情");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title1 = (GTextField)GetChild("title1");
            list1 = (GList)GetChild("list1");
            title2 = (GTextField)GetChild("title2");
            list2 = (GList)GetChild("list2");
            title3 = (GTextField)GetChild("title3");
            list3 = (GList)GetChild("list3");
            title4 = (GTextField)GetChild("title4");
            list4 = (GList)GetChild("list4");
        }
    }
}