/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace EnergySystem
{
    public partial class View_NoEnergyTips : GComponent
    {
        public Controller IsAdState;
        public GButton bg;
        public GButton Close;
        public GButton Buy;
        public GButton SpGet;
        public GTextField title;
        public GTextField Source;
        public GTextField Target;
        public const string URL = "ui://yvifr4bbb1j2cc7";

        public static View_NoEnergyTips CreateInstance()
        {
            return (View_NoEnergyTips)UIPackage.CreateObject("EnergySystem", "NoEnergyTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            IsAdState = GetController("IsAdState");
            bg = (GButton)GetChild("bg");
            Close = (GButton)GetChild("Close");
            Buy = (GButton)GetChild("Buy");
            SpGet = (GButton)GetChild("SpGet");
            title = (GTextField)GetChild("title");
            Source = (GTextField)GetChild("Source");
            Target = (GTextField)GetChild("Target");
        }
    }
}