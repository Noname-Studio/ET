/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_Member : GButton
    {
        public GList List;
        public const string URL = "ui://nvat1mjsc6lfdme";

        public static View_Member CreateInstance()
        {
            return (View_Member)UIPackage.CreateObject("TheGuild", "Member");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList)GetChild("List");
        }
    }
}