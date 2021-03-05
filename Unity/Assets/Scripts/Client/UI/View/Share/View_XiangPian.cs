/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Share
{
	public partial class View_XiangPian : GComponent
	{
		public View_ShareFrame Image;

		public const string URL = "ui://ypf7zkklmom6kv";

		public static View_XiangPian CreateInstance()
		{
			return (View_XiangPian)UIPackage.CreateObject("Share","相片");
		}

		public View_XiangPian()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Image = (View_ShareFrame)this.GetChildAt(2);
		}
	}
}