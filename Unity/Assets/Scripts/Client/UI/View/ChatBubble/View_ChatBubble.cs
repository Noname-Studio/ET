/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.ChatBubble
{
    public partial class View_ChatBubble: GComponent
    {
        public View_ChatBubbleWrap Core;
        public Transition Anim;

        public const string URL = "ui://ywzdb926j73a5l";

        public static View_ChatBubble CreateInstance()
        {
            return (View_ChatBubble) UIPackage.CreateObject("ChatBubble", "ChatBubble");
        }

        public View_ChatBubble()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Core = (View_ChatBubbleWrap) GetChildAt(0);
            Anim = GetTransitionAt(0);
        }
    }
}