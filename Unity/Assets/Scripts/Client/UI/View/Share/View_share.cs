/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Share
{
	public partial class View_share : GComponent
	{
		public View_WenAnKa Card;
		public GButton Confrim;
		public GButton Cancel;
		public View_XiangPian Picture;
		public Transition appear;
		public Transition share;
		public Transition share_later;

		public const string URL = "ui://ypf7zkklmom6ks";

		public static View_share CreateInstance()
		{
			return (View_share)UIPackage.CreateObject("Share","share");
		}

		public View_share()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Card = (View_WenAnKa)this.GetChildAt(4);
			Confrim = (GButton)this.GetChildAt(5);
			Cancel = (GButton)this.GetChildAt(6);
			Picture = (View_XiangPian)this.GetChildAt(7);
			appear = this.GetTransitionAt(0);
			share = this.GetTransitionAt(1);
			share_later = this.GetTransitionAt(2);
		}
	}
}