/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GoldExchange : GComponent
    {
        public GButton bg;
        public GList List;
        public GButton Close;
        public const string URL = "ui://ucagdrsis18cvyf";

        public static View_GoldExchange CreateInstance()
        {
            return (View_GoldExchange)UIPackage.CreateObject("Common", "GoldExchange");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            List = (GList)GetChild("List");
            Close = (GButton)GetChild("Close");
        }
    }
}