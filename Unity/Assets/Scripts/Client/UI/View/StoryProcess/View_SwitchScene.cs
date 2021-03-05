/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_SwitchScene : GComponent
	{
		public GGraph Circle;
		public Transition Anim;

		public const string URL = "ui://y0mpnw87gcb9b2";

		public static View_SwitchScene CreateInstance()
		{
			return (View_SwitchScene)UIPackage.CreateObject("StoryProcess","SwitchScene");
		}

		public View_SwitchScene()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Circle = (GGraph)this.GetChildAt(1);
			Anim = this.GetTransitionAt(0);
		}
	}
}