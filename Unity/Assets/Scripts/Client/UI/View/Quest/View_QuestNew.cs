/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
    public partial class View_QuestNew: GComponent
    {
        public GButton bg;
        public GButton Close;
        public GList Menu;
        public View_Taskschedule GiftBar;
        public GLoader Collection;
        public View_PartDate Date;
        public Transition Enter;
        public Transition Exit;

        public const string URL = "ui://ytnp4vk8ifeglr";

        public static View_QuestNew CreateInstance()
        {
            return (View_QuestNew) UIPackage.CreateObject("Quest", "QuestNew");
        }

        public View_QuestNew()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChildAt(0);
            Close = (GButton) GetChildAt(1);
            Menu = (GList) GetChildAt(2);
            GiftBar = (View_Taskschedule) GetChildAt(3);
            Collection = (GLoader) GetChildAt(4);
            Date = (View_PartDate) GetChildAt(5);
            Enter = GetTransitionAt(0);
            Exit = GetTransitionAt(1);
        }
    }
}