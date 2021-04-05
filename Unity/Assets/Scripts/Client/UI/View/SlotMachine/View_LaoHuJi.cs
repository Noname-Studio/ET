/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.SlotMachine
{
    public partial class View_LaoHuJi: GComponent
    {
        public Controller c1;
        public GButton bg;
        public View_Paw Paw;
        public GLoader Close;
        public GComponent Mask;
        public GButton Coin100;
        public GButton Coin1000;

        public const string URL = "ui://yta40mdqini3m0";

        public static View_LaoHuJi CreateInstance()
        {
            return (View_LaoHuJi) UIPackage.CreateObject("SlotMachine", "老虎机");
        }

        public View_LaoHuJi()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            bg = (GButton) GetChildAt(0);
            Paw = (View_Paw) GetChildAt(1);
            Close = (GLoader) GetChildAt(6);
            Mask = (GComponent) GetChildAt(20);
            Coin100 = (GButton) GetChildAt(21);
            Coin1000 = (GButton) GetChildAt(22);
        }
    }
}