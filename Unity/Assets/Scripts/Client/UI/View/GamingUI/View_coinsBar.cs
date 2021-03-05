/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_coinsBar : GProgressBar
    {
        public Controller c1;
        public GLoader iconLoader;
        public View_Success_effect complete_logo;
        public const string URL = "ui://dpc3yd4ttmfvp";

        public static View_coinsBar CreateInstance()
        {
            return (View_coinsBar)UIPackage.CreateObject("GamingUI", "coinsBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            iconLoader = (GLoader)GetChild("iconLoader");
            complete_logo = (View_Success_effect)GetChild("complete_logo");
        }
    }
}