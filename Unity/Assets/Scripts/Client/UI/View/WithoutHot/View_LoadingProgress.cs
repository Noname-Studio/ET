/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_LoadingProgress : GProgressBar
	{
		public GGraph holder;

		public const string URL = "ui://97pg0d8ft3u71";

		public static View_LoadingProgress CreateInstance()
		{
			return (View_LoadingProgress)UIPackage.CreateObject("WithoutHot","LoadingProgress");
		}

		public View_LoadingProgress()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			holder = (GGraph)this.GetChildAt(3);
		}
	}
}