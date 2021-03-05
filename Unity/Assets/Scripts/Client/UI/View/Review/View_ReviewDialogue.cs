/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Review
{
	public partial class View_ReviewDialogue : GComponent
	{
		public GButton bg;
		public GList List;
		public GButton Close;

		public const string URL = "ui://ijwojn7ziccq16";

		public static View_ReviewDialogue CreateInstance()
		{
			return (View_ReviewDialogue)UIPackage.CreateObject("Review","ReviewDialogue");
		}

		public View_ReviewDialogue()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			List = (GList)this.GetChildAt(13);
			Close = (GButton)this.GetChildAt(14);
		}
	}
}