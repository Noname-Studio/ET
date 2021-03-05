/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CollectProduct
{
	public partial class View_packageproduct : GComponent
	{
		public Transition t2;
		public Transition t3;

		public const string URL = "ui://m99fdlgyho1ma";

		public static View_packageproduct CreateInstance()
		{
			return (View_packageproduct)UIPackage.CreateObject("CollectProduct","packageproduct");
		}

		public View_packageproduct()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t2 = this.GetTransitionAt(0);
			t3 = this.GetTransitionAt(1);
		}
	}
}