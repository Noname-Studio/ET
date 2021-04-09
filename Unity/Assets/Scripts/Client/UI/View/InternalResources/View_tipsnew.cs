/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_tipsnew : GComponent
    {
        public Controller tips;
        public GButton bg;
        public GGroup BG;
        public GRichTextField Desc;
        public GButton Confirm;
        public GTextField Title;
        public GGroup biaoti;
        public GButton Close;
        public const string URL = "ui://97pg0d8fihve30";

        public static View_tipsnew CreateInstance()
        {
            return (View_tipsnew)UIPackage.CreateObject("InternalResources", "tipsnew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tips = GetController("tips");
            bg = (GButton)GetChild("bg");
            BG = (GGroup)GetChild("BG");
            Desc = (GRichTextField)GetChild("Desc");
            Confirm = (GButton)GetChild("Confirm");
            Title = (GTextField)GetChild("Title");
            biaoti = (GGroup)GetChild("biaoti");
            Close = (GButton)GetChild("Close");
        }
    }
}