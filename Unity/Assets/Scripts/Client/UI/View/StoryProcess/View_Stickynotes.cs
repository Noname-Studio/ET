/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_Stickynotes: GLabel
    {
        public Controller c1;
        public GGraph Bg;
        public GTextField Desc;

        public const string URL = "ui://y0mpnw87qr2jups";

        public static View_Stickynotes CreateInstance()
        {
            return (View_Stickynotes) UIPackage.CreateObject("StoryProcess", "Stickynotes");
        }

        public View_Stickynotes()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Bg = (GGraph) GetChildAt(0);
            Desc = (GTextField) GetChildAt(3);
        }
    }
}