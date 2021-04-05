/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Signin
{
    public partial class View_SigninComponent: GButton
    {
        public Controller c1;
        public GLoader Icon;
        public View_ShiJianBiaoQian Day;
        public GGroup Tomorrow;
        public Transition t0;
        public Transition t1;

        public const string URL = "ui://9cwletjdfigrc";

        public static View_SigninComponent CreateInstance()
        {
            return (View_SigninComponent) UIPackage.CreateObject("Signin", "SigninComponent");
        }

        public View_SigninComponent()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Icon = (GLoader) GetChildAt(2);
            Day = (View_ShiJianBiaoQian) GetChildAt(4);
            Tomorrow = (GGroup) GetChildAt(7);
            t0 = GetTransitionAt(0);
            t1 = GetTransitionAt(1);
        }
    }
}