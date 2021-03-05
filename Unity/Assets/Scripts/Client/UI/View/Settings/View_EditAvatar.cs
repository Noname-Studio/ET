/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Settings
{
	public partial class View_EditAvatar : GComponent
	{
		public GButton bg;
		public GButton Close;
		public GButton Confrim;
		public GList AvatarList;

		public const string URL = "ui://yzgsvb7wm59bm9";

		public static View_EditAvatar CreateInstance()
		{
			return (View_EditAvatar)UIPackage.CreateObject("Settings","EditAvatar");
		}

		public View_EditAvatar()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Close = (GButton)this.GetChildAt(4);
			Confrim = (GButton)this.GetChildAt(5);
			AvatarList = (GList)this.GetChildAt(6);
		}
	}
}