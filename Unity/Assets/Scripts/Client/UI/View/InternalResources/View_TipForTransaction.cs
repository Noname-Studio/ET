/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_TipForTransaction : GComponent
    {
        public Controller Transaction;
        public GButton bg;
        public GButton ok;
        public GTextField txt;
        public GTextField number;
        public GLoader icon;
        public const string URL = "ui://97pg0d8fgkg62m";

        public static View_TipForTransaction CreateInstance()
        {
            return (View_TipForTransaction)UIPackage.CreateObject("InternalResources", "TipForTransaction");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Transaction = GetController("Transaction");
            bg = (GButton)GetChild("bg");
            ok = (GButton)GetChild("ok");
            txt = (GTextField)GetChild("txt");
            number = (GTextField)GetChild("number");
            icon = (GLoader)GetChild("icon");
        }
    }
}