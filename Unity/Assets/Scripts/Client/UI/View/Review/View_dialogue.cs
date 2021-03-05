/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Review
{
	public partial class View_dialogue : GLabel
	{
		public GGraph Bg;
		public GTextField Name;

		public const string URL = "ui://ijwojn7ziccq17";

		public static View_dialogue CreateInstance()
		{
			return (View_dialogue)UIPackage.CreateObject("Review","dialogue");
		}

		public View_dialogue()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Bg = (GGraph)this.GetChildAt(0);
			Name = (GTextField)this.GetChildAt(1);
		}
	}
}