/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Achievement
{
    public partial class View_starachievement : GComponent
    {
        public Controller c1;
        public const string URL = "ui://y1hfvz76fzdbg3";

        public static View_starachievement CreateInstance()
        {
            return (View_starachievement)UIPackage.CreateObject("Achievement", "starachievement");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
        }
    }
}