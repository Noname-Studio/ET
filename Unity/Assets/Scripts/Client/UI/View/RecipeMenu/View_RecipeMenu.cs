/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.RecipeMenu
{
    public partial class View_RecipeMenu: GComponent
    {
        public GButton bg;
        public GList foodlist;
        public GImage bg3;
        public GImage equal3;
        public GImage arrow3;
        public GLoader food_plate3;
        public GLoader food3;
        public GLoader plate31;
        public GLoader plate33;
        public GLoader plate32;
        public GLoader m31;
        public GLoader m33;
        public GLoader m32;
        public GLoader cw3;
        public GGroup step3;
        public GImage bg1;
        public GImage arrow1;
        public GImage equal1;
        public GLoader food_plate1;
        public GLoader food1;
        public GLoader plate11;
        public GLoader plate13;
        public GLoader plate12;
        public GLoader m11;
        public GLoader m13;
        public GLoader m12;
        public GLoader cw1;
        public GGroup step1;
        public GImage bg2;
        public GImage equal2;
        public GImage arrow2;
        public GLoader food_plate2;
        public GLoader food2;
        public GLoader plate21;
        public GLoader plate23;
        public GLoader plate22;
        public GLoader m21;
        public GLoader m23;
        public GLoader m22;
        public GLoader cw2;
        public GGroup step2;
        public GGroup dishes;
        public GGroup page0;
        public GButton Close;
        public GButton shopbtn;
        public GButton playbtn;
        public GTextField guide;

        public const string URL = "ui://rrligmrx9qkl0";

        public static View_RecipeMenu CreateInstance()
        {
            return (View_RecipeMenu) UIPackage.CreateObject("RecipeMenu", "RecipeMenu");
        }

        public View_RecipeMenu()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChildAt(0);
            foodlist = (GList) GetChildAt(6);
            bg3 = (GImage) GetChildAt(7);
            equal3 = (GImage) GetChildAt(9);
            arrow3 = (GImage) GetChildAt(10);
            food_plate3 = (GLoader) GetChildAt(12);
            food3 = (GLoader) GetChildAt(13);
            plate31 = (GLoader) GetChildAt(14);
            plate33 = (GLoader) GetChildAt(15);
            plate32 = (GLoader) GetChildAt(16);
            m31 = (GLoader) GetChildAt(17);
            m33 = (GLoader) GetChildAt(18);
            m32 = (GLoader) GetChildAt(19);
            cw3 = (GLoader) GetChildAt(20);
            step3 = (GGroup) GetChildAt(21);
            bg1 = (GImage) GetChildAt(22);
            arrow1 = (GImage) GetChildAt(25);
            equal1 = (GImage) GetChildAt(26);
            food_plate1 = (GLoader) GetChildAt(27);
            food1 = (GLoader) GetChildAt(28);
            plate11 = (GLoader) GetChildAt(29);
            plate13 = (GLoader) GetChildAt(30);
            plate12 = (GLoader) GetChildAt(31);
            m11 = (GLoader) GetChildAt(32);
            m13 = (GLoader) GetChildAt(33);
            m12 = (GLoader) GetChildAt(34);
            cw1 = (GLoader) GetChildAt(35);
            step1 = (GGroup) GetChildAt(36);
            bg2 = (GImage) GetChildAt(37);
            equal2 = (GImage) GetChildAt(39);
            arrow2 = (GImage) GetChildAt(40);
            food_plate2 = (GLoader) GetChildAt(42);
            food2 = (GLoader) GetChildAt(43);
            plate21 = (GLoader) GetChildAt(44);
            plate23 = (GLoader) GetChildAt(45);
            plate22 = (GLoader) GetChildAt(46);
            m21 = (GLoader) GetChildAt(47);
            m23 = (GLoader) GetChildAt(48);
            m22 = (GLoader) GetChildAt(49);
            cw2 = (GLoader) GetChildAt(50);
            step2 = (GGroup) GetChildAt(51);
            dishes = (GGroup) GetChildAt(52);
            page0 = (GGroup) GetChildAt(53);
            Close = (GButton) GetChildAt(54);
            shopbtn = (GButton) GetChildAt(55);
            playbtn = (GButton) GetChildAt(56);
            guide = (GTextField) GetChildAt(57);
        }
    }
}