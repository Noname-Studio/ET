/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_PopAskbuyCw: GComponent
    {
        public GButton bg;
        public GComponent light1;
        public GButton Confrim;
        public GLoader Icon;
        public GComponent light2;
        public GTextField title;
        public GButton Close;
        public const string URL = "ui://ytyvezjfz43qah";

        public static View_PopAskbuyCw CreateInstance()
        {
            return (View_PopAskbuyCw) UIPackage.CreateObject("GameBegins", "PopAskbuyCw");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChild("bg");
            light1 = (GComponent) GetChild("light1");
            Confrim = (GButton) GetChild("Confrim");
            Icon = (GLoader) GetChild("Icon");
            light2 = (GComponent) GetChild("light2");
            title = (GTextField) GetChild("title");
            Close = (GButton) GetChild("Close");
        }
    }
}