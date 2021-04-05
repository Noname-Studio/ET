/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_QieHuanTianShu: GComponent
    {
        public GGraph holder;
        public GTextField NextDay;
        public GTextField CurrentDay;
        public Transition t2;
        public Transition Out;
        public Transition In;

        public const string URL = "ui://y0mpnw87rn8bh6";

        public static View_QieHuanTianShu CreateInstance()
        {
            return (View_QieHuanTianShu) UIPackage.CreateObject("StoryProcess", "切换天数");
        }

        public View_QieHuanTianShu()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            holder = (GGraph) GetChildAt(1);
            NextDay = (GTextField) GetChildAt(2);
            CurrentDay = (GTextField) GetChildAt(3);
            t2 = GetTransitionAt(0);
            Out = GetTransitionAt(1);
            In = GetTransitionAt(2);
        }
    }
}