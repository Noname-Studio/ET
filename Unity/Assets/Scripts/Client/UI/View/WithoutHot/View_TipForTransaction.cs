/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_TipForTransaction : GComponent
	{
		public Controller Transaction;
		public GButton bg;
		public GButton ok;
		public GTextField txt;
		public GTextField number;
		public GLoader icon;

		public const string URL = "ui://97pg0d8fgkg62m";

		public static View_TipForTransaction CreateInstance()
		{
			return (View_TipForTransaction)UIPackage.CreateObject("WithoutHot","TipForTransaction");
		}

		public View_TipForTransaction()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Transaction = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			ok = (GButton)this.GetChildAt(6);
			txt = (GTextField)this.GetChildAt(8);
			number = (GTextField)this.GetChildAt(10);
			icon = (GLoader)this.GetChildAt(11);
		}
	}
}