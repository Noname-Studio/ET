/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Share
{
    public partial class View_ShareFrame: GComponent
    {
        public GLoader Holder;

        public const string URL = "ui://ypf7zkklom85nj";

        public static View_ShareFrame CreateInstance()
        {
            return (View_ShareFrame) UIPackage.CreateObject("Share", "ShareFrame");
        }

        public View_ShareFrame()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Holder = (GLoader) GetChildAt(1);
        }
    }
}