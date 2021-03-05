/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Friend
{
	public partial class View_LinkToFacebook : GLabel
	{
		public GButton Comfrim;

		public const string URL = "ui://y072jhf1m1eebf";

		public static View_LinkToFacebook CreateInstance()
		{
			return (View_LinkToFacebook)UIPackage.CreateObject("Friend","LinkToFacebook");
		}

		public View_LinkToFacebook()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Comfrim = (GButton)this.GetChildAt(1);
		}
	}
}