/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Share
{
    public partial class View_WenAnKa: GComponent
    {
        public GTextField title;

        public const string URL = "ui://ypf7zkklmom6kw";

        public static View_WenAnKa CreateInstance()
        {
            return (View_WenAnKa) UIPackage.CreateObject("Share", "文案卡");
        }

        public View_WenAnKa()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title = (GTextField) GetChildAt(1);
        }
    }
}