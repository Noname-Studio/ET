/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_Main : GComponent
    {
        public Controller State;
        public GList LeftList;
        public View_RenWuAnNiu Menu;
        public View_Button1 More;
        public View_Button_icon Club;
        public GGroup LeftBttom;
        public GList RightList;
        public GButton Settings;
        public GGroup Right;
        public View_RestaurantJump_button Jump;
        public View_KaiShiGuanKa Play;
        public View_Button_icon Shop;
        public View_Button_icon Equipment;
        public GGroup RightBottom;
        public Transition In;
        public Transition Out;
        public const string URL = "ui://fmkyh2ywvqob1";

        public static View_Main CreateInstance()
        {
            return (View_Main)UIPackage.CreateObject("Main", "Main");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            State = GetController("State");
            LeftList = (GList)GetChild("LeftList");
            Menu = (View_RenWuAnNiu)GetChild("Menu");
            More = (View_Button1)GetChild("More");
            Club = (View_Button_icon)GetChild("Club");
            LeftBttom = (GGroup)GetChild("LeftBttom");
            RightList = (GList)GetChild("RightList");
            Settings = (GButton)GetChild("Settings");
            Right = (GGroup)GetChild("Right");
            Jump = (View_RestaurantJump_button)GetChild("Jump");
            Play = (View_KaiShiGuanKa)GetChild("Play");
            Shop = (View_Button_icon)GetChild("Shop");
            Equipment = (View_Button_icon)GetChild("Equipment");
            RightBottom = (GGroup)GetChild("RightBottom");
            In = GetTransition("In");
            Out = GetTransition("Out");
        }
    }
}