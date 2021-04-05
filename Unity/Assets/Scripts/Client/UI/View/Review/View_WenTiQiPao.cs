/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Review
{
    public partial class View_WenTiQiPao: GComponent
    {
        public Controller c1;
        public GTextField Desc;

        public const string URL = "ui://ijwojn7zefhq1f";

        public static View_WenTiQiPao CreateInstance()
        {
            return (View_WenTiQiPao) UIPackage.CreateObject("Review", "问题气泡");
        }

        public View_WenTiQiPao()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Desc = (GTextField) GetChildAt(1);
        }
    }
}