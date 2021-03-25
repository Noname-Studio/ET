/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Settings
{
    public partial class View_EditName : GComponent
    {
        public Controller name;
        public GButton bg;
        public GButton Close;
        public GTextInput Input;
        public GButton Confrim;
        public const string URL = "ui://yzgsvb7wm59bm7";

        public static View_EditName CreateInstance()
        {
            return (View_EditName)UIPackage.CreateObject("Settings", "EditName");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            name = GetController("name");
            bg = (GButton)GetChild("bg");
            Close = (GButton)GetChild("Close");
            Input = (GTextInput)GetChild("Input");
            Confrim = (GButton)GetChild("Confrim");
        }
    }
}