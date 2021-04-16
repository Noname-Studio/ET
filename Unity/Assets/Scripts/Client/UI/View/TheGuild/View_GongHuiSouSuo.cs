/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiSouSuo : GComponent
    {
        public GButton Search;
        public GComboBox UnionLangSelect;
        public GComboBox To;
        public GButton Close;
        public GComboBox From;
        public GComboBox RestaurantProgress;
        public const string URL = "ui://nvat1mjsmwiyki";

        public static View_GongHuiSouSuo CreateInstance()
        {
            return (View_GongHuiSouSuo)UIPackage.CreateObject("TheGuild", "公会搜索");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Search = (GButton)GetChild("Search");
            UnionLangSelect = (GComboBox)GetChild("UnionLangSelect");
            To = (GComboBox)GetChild("To");
            Close = (GButton)GetChild("Close");
            From = (GComboBox)GetChild("From");
            RestaurantProgress = (GComboBox)GetChild("RestaurantProgress");
        }
    }
}