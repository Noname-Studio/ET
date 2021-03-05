/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_HaoYouXuanZe_Button : GButton
    {
        public Controller c1;
        public GButton Ask;
        public const string URL = "ui://nvat1mjsc7g0dm9";

        public static View_HaoYouXuanZe_Button CreateInstance()
        {
            return (View_HaoYouXuanZe_Button)UIPackage.CreateObject("TheGuild", "好友选择_Button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Ask = (GButton)GetChild("Ask");
        }
    }
}