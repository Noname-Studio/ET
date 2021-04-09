/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_Tips : GComponent
    {
        public Controller ButtonState;
        public GButton bg;
        public GRichTextField Content;
        public GList ButtonList;
        public Transition t0;
        public const string URL = "ui://97pg0d8ft3u7j";

        public static View_Tips CreateInstance()
        {
            return (View_Tips)UIPackage.CreateObject("InternalResources", "Tips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ButtonState = GetController("ButtonState");
            bg = (GButton)GetChild("bg");
            Content = (GRichTextField)GetChild("Content");
            ButtonList = (GList)GetChild("ButtonList");
            t0 = GetTransition("t0");
        }
    }
}