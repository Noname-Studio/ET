/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_HuiZhangZhiZuo : GComponent
    {
        public Controller c1;
        public GLoader frame;
        public GLoader inside;
        public GButton Confirm;
        public GList List;
        public GList Menu;
        public GButton Close;
        public const string URL = "ui://nvat1mjsbzaljp";

        public static View_HuiZhangZhiZuo CreateInstance()
        {
            return (View_HuiZhangZhiZuo)UIPackage.CreateObject("TheGuild", "徽章制作");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            frame = (GLoader)GetChild("frame");
            inside = (GLoader)GetChild("inside");
            Confirm = (GButton)GetChild("Confirm");
            List = (GList)GetChild("List");
            Menu = (GList)GetChild("Menu");
            Close = (GButton)GetChild("Close");
        }
    }
}