/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Mail
{
    public partial class View_Mail: GComponent
    {
        public Controller c1;
        public GButton bg;
        public GButton Close;
        public GList List;

        public const string URL = "ui://ypdv1ldxg4h9cj";

        public static View_Mail CreateInstance()
        {
            return (View_Mail) UIPackage.CreateObject("Mail", "Mail");
        }

        public View_Mail()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            bg = (GButton) GetChildAt(0);
            Close = (GButton) GetChildAt(5);
            List = (GList) GetChildAt(6);
        }
    }
}