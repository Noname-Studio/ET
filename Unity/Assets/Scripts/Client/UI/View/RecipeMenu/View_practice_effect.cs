/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.RecipeMenu
{
	public partial class View_practice_effect : GComponent
	{
		public Transition t1;

		public const string URL = "ui://rrligmrxih8kmy";

		public static View_practice_effect CreateInstance()
		{
			return (View_practice_effect)UIPackage.CreateObject("RecipeMenu","practice_effect");
		}

		public View_practice_effect()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t1 = this.GetTransitionAt(0);
		}
	}
}