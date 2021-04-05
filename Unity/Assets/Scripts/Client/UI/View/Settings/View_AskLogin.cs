/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Settings
{
    public partial class View_AskLogin: GComponent
    {
        public Controller c1;
        public GButton bg;
        public GButton login;
        public GButton Close;
        public GRichTextField Relief;
        public const string URL = "ui://yzgsvb7wsqrcns";

        public static View_AskLogin CreateInstance()
        {
            return (View_AskLogin) UIPackage.CreateObject("Settings", "AskLogin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton) GetChild("bg");
            login = (GButton) GetChild("login");
            Close = (GButton) GetChild("Close");
            Relief = (GRichTextField) GetChild("Relief");
        }
    }
}