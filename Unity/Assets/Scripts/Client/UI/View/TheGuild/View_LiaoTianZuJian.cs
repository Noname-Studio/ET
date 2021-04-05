/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_LiaoTianZuJian : GComponent
    {
        public Controller showstate;
        public GButton Send;
        public GList List;
        public GTextInput Input;
        public GButton Emoji;
        public GButton RequestEnergy;
        public View_BiaoQingBao EmojiImgPanel;
        public const string URL = "ui://nvat1mjsryfbdl6";

        public static View_LiaoTianZuJian CreateInstance()
        {
            return (View_LiaoTianZuJian)UIPackage.CreateObject("TheGuild", "聊天组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            showstate = GetController("showstate");
            Send = (GButton)GetChild("Send");
            List = (GList)GetChild("List");
            Input = (GTextInput)GetChild("Input");
            Emoji = (GButton)GetChild("Emoji");
            RequestEnergy = (GButton)GetChild("RequestEnergy");
            EmojiImgPanel = (View_BiaoQingBao)GetChild("EmojiImgPanel");
        }
    }
}