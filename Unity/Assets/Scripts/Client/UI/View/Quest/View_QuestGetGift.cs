/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_QuestGetGift : GComponent
	{
		public GButton bg;
		public GGraph ParticleHolder;
		public GButton GetGift;
		public GGraph GiftObj;

		public const string URL = "ui://ytnp4vk8x2zukb";

		public static View_QuestGetGift CreateInstance()
		{
			return (View_QuestGetGift)UIPackage.CreateObject("Quest","QuestGetGift");
		}

		public View_QuestGetGift()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			ParticleHolder = (GGraph)this.GetChildAt(1);
			GetGift = (GButton)this.GetChildAt(2);
			GiftObj = (GGraph)this.GetChildAt(3);
		}
	}
}