/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_VersionDesc : GComponent
	{
		public GTextField Desc;

		public const string URL = "ui://97pg0d8fem56vv6";

		public static View_VersionDesc CreateInstance()
		{
			return (View_VersionDesc)UIPackage.CreateObject("WithoutHot","VersionDesc");
		}

		public View_VersionDesc()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Desc = (GTextField)this.GetChildAt(0);
		}
	}
}