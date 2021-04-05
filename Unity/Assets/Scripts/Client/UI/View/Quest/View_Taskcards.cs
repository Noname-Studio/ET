/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
    public partial class View_Taskcards: GComponent
    {
        public View_Doit Accept;
        public GTextField Title;
        public GLoader Icon;
        public GComponent Finish;
        public GProgressBar Progress;
        public Transition Enter;
        public Transition Fade;
        public Transition Move;
        public Transition StateChange;
        public Transition ResetState;

        public const string URL = "ui://ytnp4vk8ifeglt";

        public static View_Taskcards CreateInstance()
        {
            return (View_Taskcards) UIPackage.CreateObject("Quest", "Taskcards");
        }

        public View_Taskcards()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Accept = (View_Doit) GetChildAt(4);
            Title = (GTextField) GetChildAt(5);
            Icon = (GLoader) GetChildAt(6);
            Finish = (GComponent) GetChildAt(7);
            Progress = (GProgressBar) GetChildAt(8);
            Enter = GetTransitionAt(0);
            Fade = GetTransitionAt(1);
            Move = GetTransitionAt(2);
            StateChange = GetTransitionAt(3);
            ResetState = GetTransitionAt(4);
        }
    }
}