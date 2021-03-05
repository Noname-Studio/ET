/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_ComboBox1_popup : GComponent
    {
        public GList list;
        public const string URL = "ui://nvat1mjsh7udjb";

        public static View_ComboBox1_popup CreateInstance()
        {
            return (View_ComboBox1_popup)UIPackage.CreateObject("TheGuild", "ComboBox1_popup");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChild("list");
        }
    }
}