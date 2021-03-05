/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_friendcom : GComponent
    {
        public GList mylist;
        public const string URL = "ui://ytyvezjfvnym8rb";

        public static View_friendcom CreateInstance()
        {
            return (View_friendcom)UIPackage.CreateObject("GameBegins", "friendcom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            mylist = (GList)GetChild("mylist");
        }
    }
}