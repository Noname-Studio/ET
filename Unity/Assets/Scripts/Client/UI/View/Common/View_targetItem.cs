/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_targetItem : GComponent
    {
        public GLoader plate;
        public GLoader food;
        public GLoader fresh;
        public GTextField num;
        public const string URL = "ui://ucagdrsim06imj";

        public static View_targetItem CreateInstance()
        {
            return (View_targetItem)UIPackage.CreateObject("Common", "targetItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            plate = (GLoader)GetChild("plate");
            food = (GLoader)GetChild("food");
            fresh = (GLoader)GetChild("fresh");
            num = (GTextField)GetChild("num");
        }
    }
}