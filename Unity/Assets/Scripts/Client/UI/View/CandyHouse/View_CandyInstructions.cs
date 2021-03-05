/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
	public partial class View_CandyInstructions : GComponent
	{
		public Controller c1;
		public Controller c;
		public GButton bg;
		public GList List;
		public GButton Upgrade;
		public GTextField Price;
		public GButton Close;

		public const string URL = "ui://3b4mf257uhxx18";

		public static View_CandyInstructions CreateInstance()
		{
			return (View_CandyInstructions)UIPackage.CreateObject("CandyHouse","CandyInstructions");
		}

		public View_CandyInstructions()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			c = this.GetControllerAt(1);
			bg = (GButton)this.GetChildAt(0);
			List = (GList)this.GetChildAt(5);
			Upgrade = (GButton)this.GetChildAt(7);
			Price = (GTextField)this.GetChildAt(9);
			Close = (GButton)this.GetChildAt(10);
		}
	}
}