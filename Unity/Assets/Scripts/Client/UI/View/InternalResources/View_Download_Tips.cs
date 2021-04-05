/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_Download_Tips: GLabel
    {
        public Controller c1;
        public GButton bg;
        public GGroup BG;
        public GButton Download;
        public GButton WaitMinute;
        public const string URL = "ui://97pg0d8fx3ci35";

        public static View_Download_Tips CreateInstance()
        {
            return (View_Download_Tips) UIPackage.CreateObject("InternalResources", "Download_Tips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton) GetChild("bg");
            BG = (GGroup) GetChild("BG");
            Download = (GButton) GetChild("Download");
            WaitMinute = (GButton) GetChild("WaitMinute");
        }
    }
}