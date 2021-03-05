/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_LoadingValue : GComponent
	{
		public GImage bar;

		public const string URL = "ui://97pg0d8ft3u73";

		public static View_LoadingValue CreateInstance()
		{
			return (View_LoadingValue)UIPackage.CreateObject("WithoutHot","LoadingValue");
		}

		public View_LoadingValue()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bar = (GImage)this.GetChildAt(0);
		}
	}
}