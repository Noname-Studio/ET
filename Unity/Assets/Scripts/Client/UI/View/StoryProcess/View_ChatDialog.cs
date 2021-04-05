/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_ChatDialog: GComponent
    {
        public GLabel Comic1;
        public GLabel Comic4;
        public GLoader Head1;
        public GLoader ExtraHead1;
        public GLoader Holder1;
        public GGroup H1;
        public GLoader Head2;
        public GLoader ExtraHead2;
        public GLoader Holder2;
        public GGroup H2;
        public GLoader Head3;
        public GLoader ExtraHead3;
        public GLoader Holder3;
        public GGroup H3;
        public GLoader Head4;
        public GLoader ExtraHead4;
        public GLoader Holder4;
        public GGroup H4;
        public GGraph NextTap;
        public View_DialogCom Dialog;
        public View_NameGroupLeft Name1;
        public View_NameGroupCenter Name2;
        public View_NameGroupCenter Name3;
        public View_NameGroupRight Name4;
        public GButton Skip;
        public Transition DialogFateIn;
        public Transition DX3;
        public Transition DX2;
        public Transition DX4;
        public Transition End;
        public Transition Enter;
        public Transition DX1;

        public const string URL = "ui://y0mpnw87rics4q";

        public static View_ChatDialog CreateInstance()
        {
            return (View_ChatDialog) UIPackage.CreateObject("StoryProcess", "ChatDialog");
        }

        public View_ChatDialog()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Comic1 = (GLabel) GetChildAt(0);
            Comic4 = (GLabel) GetChildAt(1);
            Head1 = (GLoader) GetChildAt(2);
            ExtraHead1 = (GLoader) GetChildAt(3);
            Holder1 = (GLoader) GetChildAt(4);
            H1 = (GGroup) GetChildAt(5);
            Head2 = (GLoader) GetChildAt(6);
            ExtraHead2 = (GLoader) GetChildAt(7);
            Holder2 = (GLoader) GetChildAt(8);
            H2 = (GGroup) GetChildAt(9);
            Head3 = (GLoader) GetChildAt(10);
            ExtraHead3 = (GLoader) GetChildAt(11);
            Holder3 = (GLoader) GetChildAt(12);
            H3 = (GGroup) GetChildAt(13);
            Head4 = (GLoader) GetChildAt(14);
            ExtraHead4 = (GLoader) GetChildAt(15);
            Holder4 = (GLoader) GetChildAt(16);
            H4 = (GGroup) GetChildAt(17);
            NextTap = (GGraph) GetChildAt(18);
            Dialog = (View_DialogCom) GetChildAt(19);
            Name1 = (View_NameGroupLeft) GetChildAt(20);
            Name2 = (View_NameGroupCenter) GetChildAt(21);
            Name3 = (View_NameGroupCenter) GetChildAt(22);
            Name4 = (View_NameGroupRight) GetChildAt(23);
            Skip = (GButton) GetChildAt(24);
            DialogFateIn = GetTransitionAt(0);
            DX3 = GetTransitionAt(1);
            DX2 = GetTransitionAt(2);
            DX4 = GetTransitionAt(3);
            End = GetTransitionAt(4);
            Enter = GetTransitionAt(5);
            DX1 = GetTransitionAt(6);
        }
    }
}