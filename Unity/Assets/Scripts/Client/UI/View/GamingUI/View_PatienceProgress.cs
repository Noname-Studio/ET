/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_PatienceProgress: GComponent
    {
        public Controller State;
        public GLoader Bar;
        public const string URL = "ui://dpc3yd4tpgz3tw0l";

        public static View_PatienceProgress CreateInstance()
        {
            return (View_PatienceProgress) UIPackage.CreateObject("GamingUI", "PatienceProgress");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            State = GetController("State");
            Bar = (GLoader) GetChild("Bar");
        }
    }
}