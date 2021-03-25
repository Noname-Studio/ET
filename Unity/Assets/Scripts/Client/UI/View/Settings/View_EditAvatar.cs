/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Settings
{
    public partial class View_EditAvatar : GComponent
    {
        public GButton bg;
        public GButton Close;
        public GButton Confrim;
        public GList AvatarList;
        public const string URL = "ui://yzgsvb7wm59bm9";

        public static View_EditAvatar CreateInstance()
        {
            return (View_EditAvatar)UIPackage.CreateObject("Settings", "EditAvatar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            Close = (GButton)GetChild("Close");
            Confrim = (GButton)GetChild("Confrim");
            AvatarList = (GList)GetChild("AvatarList");
        }
    }
}