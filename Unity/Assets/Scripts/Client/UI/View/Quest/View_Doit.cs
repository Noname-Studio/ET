/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
    public partial class View_Doit: GButton
    {
        public GTextField Consume;
        public GImage Icon;

        public const string URL = "ui://ytnp4vk8ed4g24";

        public static View_Doit CreateInstance()
        {
            return (View_Doit) UIPackage.CreateObject("Quest", "Doit");
        }

        public View_Doit()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Consume = (GTextField) GetChildAt(1);
            Icon = (GImage) GetChildAt(2);
        }
    }
}