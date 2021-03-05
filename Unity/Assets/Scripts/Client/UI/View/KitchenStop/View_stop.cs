/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenStop
{
    public partial class View_stop : GComponent
    {
        public Controller ui_style;
        public GButton bg;
        public GTextField Level;
        public GTextField Rest;
        public GList PropList;
        public GButton Restart;
        public GButton Exit;
        public GButton Back;
        public GButton Close;
        public const string URL = "ui://ydojo8b9o9762t";

        public static View_stop CreateInstance()
        {
            return (View_stop)UIPackage.CreateObject("KitchenStop", "stop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ui_style = GetController("ui_style");
            bg = (GButton)GetChild("bg");
            Level = (GTextField)GetChild("Level");
            Rest = (GTextField)GetChild("Rest");
            PropList = (GList)GetChild("PropList");
            Restart = (GButton)GetChild("Restart");
            Exit = (GButton)GetChild("Exit");
            Back = (GButton)GetChild("Back");
            Close = (GButton)GetChild("Close");
        }
    }
}