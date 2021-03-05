/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiLieBiao : GComponent
    {
        public Controller c1;
        public GTextInput SearchBar;
        public GList List;
        public GButton SearchParam;
        public GButton Search;
        public const string URL = "ui://nvat1mjsvlkhw2c";

        public static View_GongHuiLieBiao CreateInstance()
        {
            return (View_GongHuiLieBiao)UIPackage.CreateObject("TheGuild", "公会列表");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            SearchBar = (GTextInput)GetChild("SearchBar");
            List = (GList)GetChild("List");
            SearchParam = (GButton)GetChild("SearchParam");
            Search = (GButton)GetChild("Search");
        }
    }
}