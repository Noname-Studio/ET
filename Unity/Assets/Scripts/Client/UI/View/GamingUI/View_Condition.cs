/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_Condition: GComponent
    {
        public Controller c1;
        public GLoader One;
        public GLoader Two;
        public GLoader Three;
        public const string URL = "ui://dpc3yd4tsglytw0o";

        public static View_Condition CreateInstance()
        {
            return (View_Condition) UIPackage.CreateObject("GamingUI", "Condition");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            One = (GLoader) GetChild("One");
            Two = (GLoader) GetChild("Two");
            Three = (GLoader) GetChild("Three");
        }
    }
}