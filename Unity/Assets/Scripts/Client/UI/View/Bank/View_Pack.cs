/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bank
{
    public partial class View_Pack : GLabel
    {
        public Controller c1;
        public GLoader packicon;
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
            return (View_Pack)UIPackage.CreateObject("Bank", "Pack");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            packicon = (GLoader)GetChild("packicon");
            prop1icon = (GLoader)GetChild("prop1icon");
            prop1text = (GTextField)GetChild("prop1text");
            prop1 = (GGroup)GetChild("prop1");
            prop0icon = (GLoader)GetChild("prop0icon");
            prop0text = (GTextField)GetChild("prop0text");
            prop0 = (GGroup)GetChild("prop0");
            prop2icon = (GLoader)GetChild("prop2icon");
            prop2text = (GTextField)GetChild("prop2text");
            prop2 = (GGroup)GetChild("prop2");
            prop4icon = (GLoader)GetChild("prop4icon");
            prop4text = (GTextField)GetChild("prop4text");
            prop4 = (GGroup)GetChild("prop4");
            prop3icon = (GLoader)GetChild("prop3icon");
            prop3text = (GTextField)GetChild("prop3text");
            prop3 = (GGroup)GetChild("prop3");
            prop5icon = (GLoader)GetChild("prop5icon");
            prop5text = (GTextField)GetChild("prop5text");
            prop5 = (GGroup)GetChild("prop5");
            prop6icon = (GLoader)GetChild("prop6icon");
            prop6text = (GTextField)GetChild("prop6text");
            prop6 = (GGroup)GetChild("prop6");
            prop7icon = (GLoader)GetChild("prop7icon");
            prop7text = (GTextField)GetChild("prop7text");
            prop7 = (GGroup)GetChild("prop7");
        }
    }
}