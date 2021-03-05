/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_MaskTouchLayer : GComponent
    {
        public GTextField text;
        public const string URL = "ui://ucagdrsij30rts";

        public static View_MaskTouchLayer CreateInstance()
        {
            return (View_MaskTouchLayer)UIPackage.CreateObject("Common", "MaskTouchLayer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            text = (GTextField)GetChild("text");
        }
    }
}