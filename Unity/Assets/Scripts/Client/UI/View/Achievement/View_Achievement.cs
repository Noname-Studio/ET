/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Achievement
{
    public partial class View_Achievement : GLabel
    {
        public GList List;
        public GButton Close;
        public const string URL = "ui://y1hfvz76cnzofh";

        public static View_Achievement CreateInstance()
        {
            return (View_Achievement)UIPackage.CreateObject("Achievement", "Achievement");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList)GetChild("List");
            Close = (GButton)GetChild("Close");
        }
    }
}