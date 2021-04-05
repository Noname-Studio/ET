/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Advertising
{
    public partial class View_Advertising: GComponent
    {
        public Controller c1;
        public Controller Language;
        public GButton bg;
        public GComponent YellowLight;
        public GLabel GiftItem;
        public GButton Get;
        public GComponent Flicker;
        public GGroup after;
        public View_Play_button Play;
        public GLoader Icon;
        public GTextField Number;
        public GGroup before;
        public GComponent Light_1;
        public GComponent Light_2;
        public GComponent Light_3;
        public GComponent Light_4;
        public GComponent Light_5;
        public GButton Close;
        public GButton gotest;
        public GButton next;
        public GButton Close0;
        public GTextField port;

        public const string URL = "ui://lpoqxdrph5c8e";

        public static View_Advertising CreateInstance()
        {
            return (View_Advertising) UIPackage.CreateObject("Advertising", "Advertising");
        }

        public View_Advertising()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Language = GetControllerAt(1);
            bg = (GButton) GetChildAt(0);
            YellowLight = (GComponent) GetChildAt(3);
            GiftItem = (GLabel) GetChildAt(6);
            Get = (GButton) GetChildAt(7);
            Flicker = (GComponent) GetChildAt(8);
            after = (GGroup) GetChildAt(9);
            Play = (View_Play_button) GetChildAt(11);
            Icon = (GLoader) GetChildAt(13);
            Number = (GTextField) GetChildAt(14);
            before = (GGroup) GetChildAt(15);
            Light_1 = (GComponent) GetChildAt(17);
            Light_2 = (GComponent) GetChildAt(18);
            Light_3 = (GComponent) GetChildAt(19);
            Light_4 = (GComponent) GetChildAt(20);
            Light_5 = (GComponent) GetChildAt(21);
            Close = (GButton) GetChildAt(22);
            gotest = (GButton) GetChildAt(24);
            next = (GButton) GetChildAt(25);
            Close0 = (GButton) GetChildAt(28);
            port = (GTextField) GetChildAt(30);
        }
    }
}