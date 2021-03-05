/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Achievement
{
    public partial class View_Achievement : GComponent
    {
        public GButton bg;
        public GList AchiList;
        public GButton Close;
        public GTextField title;
        public const string URL = "ui://y1hfvz76cnzofh";

        public static View_Achievement CreateInstance()
        {
            return (View_Achievement)UIPackage.CreateObject("Achievement", "Achievement");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            AchiList = (GList)GetChild("AchiList");
            Close = (GButton)GetChild("Close");
            title = (GTextField)GetChild("title");
        }
    }
}