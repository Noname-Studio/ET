/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Friend
{
    public partial class View_InviteReward: GComponent
    {
        public GList InviteRewardList;
        public GTextField Description;
        public GTextField Money;
        public GButton Comfrim;

        public const string URL = "ui://y072jhf1cpakdb";

        public static View_InviteReward CreateInstance()
        {
            return (View_InviteReward) UIPackage.CreateObject("Friend", "InviteReward");
        }

        public View_InviteReward()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            InviteRewardList = (GList) GetChildAt(1);
            Description = (GTextField) GetChildAt(6);
            Money = (GTextField) GetChildAt(7);
            Comfrim = (GButton) GetChildAt(8);
        }
    }
}