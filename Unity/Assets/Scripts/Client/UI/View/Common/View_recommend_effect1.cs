/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_recommend_effect1 : GComponent
    {
        public Controller c1;
        public GTextField title;
        public const string URL = "ui://ucagdrsiskkajb";

        public static View_recommend_effect1 CreateInstance()
        {
            return (View_recommend_effect1)UIPackage.CreateObject("Common", "recommend_effect1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            title = (GTextField)GetChild("title");
        }
    }
}