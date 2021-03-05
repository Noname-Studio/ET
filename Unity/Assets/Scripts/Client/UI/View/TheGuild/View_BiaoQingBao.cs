/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_BiaoQingBao : GComponent
    {
        public GList list;
        public const string URL = "ui://nvat1mjsdys1w24";

        public static View_BiaoQingBao CreateInstance()
        {
            return (View_BiaoQingBao)UIPackage.CreateObject("TheGuild", "表情包");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChild("list");
        }
    }
}