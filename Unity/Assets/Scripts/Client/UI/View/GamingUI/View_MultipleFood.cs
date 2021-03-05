/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_MultipleFood : GComponent
    {
        public Controller c1;
        public const string URL = "ui://dpc3yd4tsglytw0q";

        public static View_MultipleFood CreateInstance()
        {
            return (View_MultipleFood)UIPackage.CreateObject("GamingUI", "MultipleFood");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
        }
    }
}