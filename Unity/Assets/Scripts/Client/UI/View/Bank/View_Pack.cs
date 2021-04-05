/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
    public partial class View_Pack: GComponent
    {
        public Controller c1;
        public GLoader packIcon;
        public GLoader prop1icon;
        public GTextField prop1text;
        public GGroup prop1;
        public GLoader prop0icon;
        public GTextField prop0text;
        public GGroup prop0;
        public GLoader prop2icon;
        public GTextField prop2text;
        public GGroup prop2;
        public GLoader prop4icon;
        public GTextField prop4text;
        public GGroup prop4;
        public GLoader prop3icon;
        public GTextField prop3text;
        public GGroup prop3;
        public GLoader prop5icon;
        public GTextField prop5text;
        public GGroup prop5;
        public GLoader prop6icon;
        public GTextField prop6text;
        public GGroup prop6;
        public GLoader prop7icon;
        public GTextField prop7text;
        public GGroup prop7;

        public const string URL = "ui://yf9s6r30p9humc";

        public static View_Pack CreateInstance()
        {
            return (View_Pack) UIPackage.CreateObject("Bank", "Pack");
        }

        public View_Pack()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            packIcon = (GLoader) GetChildAt(0);
            prop1icon = (GLoader) GetChildAt(2);
            prop1text = (GTextField) GetChildAt(4);
            prop1 = (GGroup) GetChildAt(5);
            prop0icon = (GLoader) GetChildAt(6);
            prop0text = (GTextField) GetChildAt(8);
            prop0 = (GGroup) GetChildAt(9);
            prop2icon = (GLoader) GetChildAt(10);
            prop2text = (GTextField) GetChildAt(12);
            prop2 = (GGroup) GetChildAt(13);
            prop4icon = (GLoader) GetChildAt(14);
            prop4text = (GTextField) GetChildAt(16);
            prop4 = (GGroup) GetChildAt(17);
            prop3icon = (GLoader) GetChildAt(18);
            prop3text = (GTextField) GetChildAt(20);
            prop3 = (GGroup) GetChildAt(21);
            prop5icon = (GLoader) GetChildAt(22);
            prop5text = (GTextField) GetChildAt(24);
            prop5 = (GGroup) GetChildAt(25);
            prop6icon = (GLoader) GetChildAt(26);
            prop6text = (GTextField) GetChildAt(28);
            prop6 = (GGroup) GetChildAt(29);
            prop7icon = (GLoader) GetChildAt(30);
            prop7text = (GTextField) GetChildAt(32);
            prop7 = (GGroup) GetChildAt(33);
        }
    }
}