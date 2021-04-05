/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Friend
{
    public partial class View_TouXiang: GComponent
    {
        public GButton bg;
        public GButton Close;

        public const string URL = "ui://y072jhf1xinkl8";

        public static View_TouXiang CreateInstance()
        {
            return (View_TouXiang) UIPackage.CreateObject("Friend", "头像");
        }

        public View_TouXiang()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChildAt(0);
            Close = (GButton) GetChildAt(4);
        }
    }
}