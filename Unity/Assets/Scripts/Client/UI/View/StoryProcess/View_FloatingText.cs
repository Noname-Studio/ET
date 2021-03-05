/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_FloatingText : GComponent
	{
		public GTextField Dialog;
		public Transition Float;

		public const string URL = "ui://y0mpnw87j73a5m";

		public static View_FloatingText CreateInstance()
		{
			return (View_FloatingText)UIPackage.CreateObject("StoryProcess","FloatingText");
		}

		public View_FloatingText()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Dialog = (GTextField)this.GetChildAt(0);
			Float = this.GetTransitionAt(0);
		}
	}
}