/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_DialogCom: GComponent
    {
        public GImage ChatBackground;
        public GTextField Desc;
        public Transition t0;

        public const string URL = "ui://y0mpnw87dnccor";

        public static View_DialogCom CreateInstance()
        {
            return (View_DialogCom) UIPackage.CreateObject("StoryProcess", "DialogCom");
        }

        public View_DialogCom()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ChatBackground = (GImage) GetChildAt(0);
            Desc = (GTextField) GetChildAt(1);
            t0 = GetTransitionAt(0);
        }
    }
}