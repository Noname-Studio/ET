/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Settings
{
	public partial class View_TouXiangZuJian : GComponent
	{
		public Controller c1;
		public GTextField Name;
		public GButton EditName;
		public GButton EditHead;

		public const string URL = "ui://yzgsvb7wujv4mo";

		public static View_TouXiangZuJian CreateInstance()
		{
			return (View_TouXiangZuJian)UIPackage.CreateObject("Settings","头像组件");
		}

		public View_TouXiangZuJian()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			Name = (GTextField)this.GetChildAt(1);
			EditName = (GButton)this.GetChildAt(2);
			EditHead = (GButton)this.GetChildAt(3);
		}
	}
}