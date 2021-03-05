/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_Loading : GComponent
	{
		public View_LoadingProgress Progress;
		public GTextField Title;
		public GGraph FoodHolder;
		public GTextField Desc;
		public Transition t0;

		public const string URL = "ui://97pg0d8ft3u70";

		public static View_Loading CreateInstance()
		{
			return (View_Loading)UIPackage.CreateObject("WithoutHot","Loading");
		}

		public View_Loading()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Progress = (View_LoadingProgress)this.GetChildAt(3);
			Title = (GTextField)this.GetChildAt(4);
			FoodHolder = (GGraph)this.GetChildAt(5);
			Desc = (GTextField)this.GetChildAt(6);
			t0 = this.GetTransitionAt(0);
		}
	}
}